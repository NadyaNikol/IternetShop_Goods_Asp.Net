using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class SampleData
    {
        public static async Task Initialize(GoodContext context)
        {
            if (!context.Goods.Any())
            {
                context.Goods.AddRange(
              new Good
              {
                  Name = "good1",
                  Price = 600.2,
                  FileName = "1.jpg",
                  Path = "/Files/1.jpg"
              },
              new Good
              {
                  Name = "good2",
                  Price = 550.3,
                  FileName = "2.jpg",
                  Path = "/Files/2.jpg"
              },
              new Good
              {
                  Name = "good3",
                  Price = 500.5,
                  FileName = "3.jpg",
                  Path = "/Files/3.jpg"
              });

                await context.SaveChangesAsync();
            }

        }
    }

}