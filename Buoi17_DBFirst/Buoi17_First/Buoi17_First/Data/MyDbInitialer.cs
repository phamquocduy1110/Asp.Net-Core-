using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Buoi17_First.Data
{
    public class MyDbInitialer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ShopDbContext>();

                if (!context.Sizes.Any())
                {
                    context.AddRange(new Size
                    {
                        Name = "M"
                    },
                    new Size
                    {
                        Name = "L"
                    }, new Size
                    {
                        Name = "XL"
                    },
                    new Size
                    {
                        Name = "M"
                    });
                }

                if (!context.Colors.Any())
                {
                    context.AddRange(new BrandColor
                    {
                        Name = "Red",
                        ColorName = "#FF0000"
                    },
                    new BrandColor
                    {
                        Name = "Green",
                        ColorName = "#00FF00"
                    },
                    new BrandColor
                    {
                        Name = "Blue",
                        ColorName = "#0000FF"
                    });
                }

                context.SaveChanges();
            }

        }
    }
}