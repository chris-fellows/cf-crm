using CFCRM.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CFCRM.Data;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using CFCRM.Services;
using Azure;
using CFCRMCommon.EntityReader;
using CFCRMCommon.Models;

const bool registerSeedDataLoad = true;
const bool registerRequestInfoService = true;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<CFCRMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CFCRMContext") ?? throw new InvalidOperationException("Connection string 'CFCRMContext' not found.")));

// Set authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "auth_cookie";
            options.LoginPath = "/login";
            options.Cookie.MaxAge = TimeSpan.FromMinutes(120);
            options.AccessDeniedPath = "/access-denied";
        });

builder.Services.AddAuthorization();            // CMF Added
builder.Services.AddCascadingAuthenticationState(); // CMF Added

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

if (registerRequestInfoService) builder.Services.AddHttpContextAccessor();  // Added for IRequestContextService

// Add data services
builder.Services.AddScoped<IActivityService, EFActivityService>();
builder.Services.AddScoped<IAccountService, EFAccountService>();
builder.Services.AddScoped<IAuditEventService, EFAuditEventService>();
builder.Services.AddScoped<IAuditEventTypeService, EFAuditEventTypeService>();
//builder.Services.AddScoped<ICaseService, EFCaseService>();
builder.Services.AddScoped<ICaseTypeService, EFCaseTypeService>();
builder.Services.AddScoped<ICommunicationService, EFCommunicationService>();
builder.Services.AddScoped<ICommunicationTypeService, EFCommunicationTypeService>();
builder.Services.AddScoped<ICountryService, EFCountryService>();
builder.Services.AddScoped<IContactService, EFContactService>();
builder.Services.AddScoped<IJobTypeService, EFJobTypeService>();
builder.Services.AddScoped<ILeadService, EFLeadService>();
builder.Services.AddScoped<IOpportunityService, EFOpportunityService>();
builder.Services.AddScoped<IPasswordResetService, EFPasswordResetService>();
builder.Services.AddScoped<IProductService, EFProductService>();
builder.Services.AddScoped<ISystemValueTypeService, EFSystemValueTypeService>();
builder.Services.AddScoped<IUserService, EFUserService>();

// Add seed data services
if (registerSeedDataLoad)
{
    builder.Services.AddKeyedScoped<IEntityReader<Account>, AccountSeed1>("AccountSeed");
    builder.Services.AddKeyedScoped<IEntityReader<AuditEventType>, AuditEventTypeSeed1>("AuditEventTypeSeed");
    builder.Services.AddKeyedScoped<IEntityReader<Contact>, ContactSeed1>("ContactSeed");
    builder.Services.AddKeyedScoped<IEntityReader<Country>, CountrySeed1>("CountrySeed");
    builder.Services.AddKeyedScoped<IEntityReader<JobType>, JobTypeSeed1>("JobTypeSeed");
    builder.Services.AddKeyedScoped<IEntityReader<Lead>, LeadSeed1>("LeadSeed");
    builder.Services.AddKeyedScoped<IEntityReader<Product>, ProductSeed1>("ProductSeed");
    builder.Services.AddKeyedScoped<IEntityReader<SystemValueType>, SystemValueTypeSeed1>("SystemValueTypeSeed");    
    builder.Services.AddKeyedScoped<IEntityReader<User>, UserSeed1>("UserSeed");
}

// Add password service
builder.Services.AddScoped<IPasswordService, PBKDF2PasswordService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
//app.UseAntiforgery();
app.UseAuthentication();    // CMF Added
app.UseAuthorization();     // CMF Added

app.UseAntiforgery();   // CF Moved from above

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

/*
// Populate seed data
using (var scope = app.Services.CreateScope())
{
    //new SeedLoader().DeleteAsync(scope).Wait();
    new SeedLoader().LoadAsync(scope).Wait();
}
*/

app.Run();
