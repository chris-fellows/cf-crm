using Azure;
using CFCRMCommon.Constants;
using CFCRMCommon.EntityReader;
using CFCRMCommon.Interfaces;
using CFCRMCommon.Models;

namespace CFCRM.Data
{
    /// <summary>
    /// Loads seed data
    /// </summary>
    public class SeedLoader
    {   
        /// <summary>
        /// Deletes all data
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public async Task DeleteAsync(IServiceScope scope)
        {
            // Get services
            var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
            var auditEventService = scope.ServiceProvider.GetRequiredService<IAuditEventService>();
            var auditEventTypeService = scope.ServiceProvider.GetRequiredService<IAuditEventTypeService>();
            var contactService = scope.ServiceProvider.GetRequiredService<IContactService>();
            //var jobTypeService = scope.ServiceProvider.GetRequiredService<IJobT>
            var systemValueTypeService = scope.ServiceProvider.GetRequiredService<ISystemValueTypeService>();            
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            // Delete transaction data
            var auditEvents = await auditEventService.GetAllAsync();
            foreach (var auditEvent in auditEvents)
            {
                await auditEventService.DeleteByIdAsync(auditEvent.Id);
            }            

            var users = await userService.GetAllAsync();
            foreach (var user in users)
            {
                await userService.DeleteByIdAsync(user.Id);
            }

            var auditEventTypes = await auditEventTypeService.GetAllAsync();
            foreach (var auditEventType in auditEventTypes)
            {
                await auditEventTypeService.DeleteByIdAsync(auditEventType.Id);
            }

            var systemValueTypes = await systemValueTypeService.GetAllAsync();
            foreach (var systemValueType in systemValueTypes)
            {
                await systemValueTypeService.DeleteByIdAsync(systemValueType.Id);
            }            
        }

        /// <summary>
        /// Loads seed data. Throws exception if any data exists.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="randomIssuesToCreate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task LoadAsync(IServiceScope scope)
        {
            // Get services
            var accountService = scope.ServiceProvider.GetRequiredService<IAccountService>();
            var auditEventService = scope.ServiceProvider.GetRequiredService<IAuditEventService>();
            var auditEventTypeService = scope.ServiceProvider.GetRequiredService<IAuditEventTypeService>();
            var contactService = scope.ServiceProvider.GetRequiredService<IContactService>();
            var countryService = scope.ServiceProvider.GetRequiredService<ICountryService>();
            var jobTypeService = scope.ServiceProvider.GetRequiredService<IJobTypeService>();
            var leadService = scope.ServiceProvider.GetRequiredService<ILeadService>();
            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();
            var systemValueTypeService = scope.ServiceProvider.GetRequiredService<ISystemValueTypeService>();            
            var userService = scope.ServiceProvider.GetRequiredService<IUserService>();

            // Get seed data services
            var accountSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<Account>>("AccountSeed");
            var auditEventTypeSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<AuditEventType>>("AuditEventTypeSeed");
            var contactSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<Contact>>("ContactSeed");
            var countrySeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<Country>>("CountrySeed");
            var jobTypeSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<JobType>>("JobTypeSeed");
            var leadSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<Lead>>("LeadSeed");
            var productSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<Product>>("ProductSeed");
            var systemValueTypeSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<SystemValueType>>("SystemValueTypeSeed");            
            var userSeed = scope.ServiceProvider.GetRequiredKeyedService<IEntityReader<User>>("UserSeed");

            // Check that no data exists
            var auditEventTypesOld = await auditEventTypeService.GetAllAsync();
            if (auditEventTypesOld.Any())
            {
                throw new ArgumentException("Cannot load seed data because data already exists");
            }

            // Add system value types
            var systemValueTypesNew = systemValueTypeSeed.Read();
            foreach (var systemValueType in systemValueTypesNew)
            {
                await systemValueTypeService.AddAsync(systemValueType);
            }

            // Add audit event types
            var auditEventTypesNew = auditEventTypeSeed.Read();
            foreach (var auditEventType in auditEventTypesNew)
            {
                await auditEventTypeService.AddAsync(auditEventType);
            }

            // Get audit event types & system value types
            var auditEventTypes = await auditEventTypeService.GetAllAsync();
            var systemValueTypes = await systemValueTypeService.GetAllAsync();

            // Add countries
            var countriesNew = countrySeed.Read();
            foreach (var country in countriesNew)
            {
                await countryService.AddAsync(country);
            }

            // Add job types
            var jobTypesNew = jobTypeSeed.Read();
            foreach (var jobType in jobTypesNew)
            {
                await jobTypeService.AddAsync(jobType);
            }

            // Add products
            var productsNew = productSeed.Read();
            foreach (var product in productsNew)
            {
                await productService.AddAsync(product);
            }

            // Add users
            var usersNew = userSeed.Read();
            foreach (var user in usersNew)
            {
                var userResult = await userService.AddAsync(user);

                var auditEvent = new AuditEvent()
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedDateTime = DateTimeOffset.UtcNow,
                    TypeId = auditEventTypes.First(i => i.Name == AuditEventTypeNames.UserCreated).Id,
                    Parameters = new List<AuditEventParameter>()
                    {
                        new AuditEventParameter()
                        {
                            Id = Guid.NewGuid().ToString(),
                            SystemValueTypeId = systemValueTypes.First(i => i.Name == SystemValueTypeNames.UserId).Id,
                            Value = userResult.Id
                        }
                    }
                };
                await auditEventService.AddAsync(auditEvent);
            }

            // Add accounts
            var accountsNew = accountSeed.Read();
            foreach (var account in accountsNew)
            {
                await accountService.AddAsync(account);
            }

            // Add contacts
            var contactsNew = contactSeed.Read();
            foreach (var contact in contactsNew)
            {
                await contactService.AddAsync(contact);
            }

            // Add leads
            var leadsNew = leadSeed.Read();
            foreach (var lead in leadsNew)
            {
                await leadService.AddAsync(lead);
            }
        }        
    }
}
