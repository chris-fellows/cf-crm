using CFCRMCommon.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFCRMCommon.EntityReader
{
    public class CountrySeed1 : IEntityReader<Country>
    {
        public IEnumerable<Country> Read()
        {
            var list = new List<Country>()
            {
                new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Belgium",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                },
                new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "France",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                },
                new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Germany",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                },
                new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Italy",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                },
                 new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Netherlands",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                },
                new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Spain",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                },
                new Country()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "UK",
                    Color = Color.Blue.ToArgb().ToString(),
                    ImageSource = "country.png"
                }                 
            };

            return list;
        }
    }
}
