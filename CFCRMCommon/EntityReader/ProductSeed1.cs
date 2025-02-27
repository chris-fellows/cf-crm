using CFCRMCommon.Constants;
using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    public class ProductSeed1 : IEntityReader<Product>
    {
        public IEnumerable<Product> Read()
        {
            var list = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 1",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 2",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 3",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 4",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 5",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 6",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 7",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 8",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 9",
                    Notes = "Notes for product"
                },
                new Product()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Product 10",
                    Notes = "Notes for product"
                }
            };

            return list;
        }
    }
}
