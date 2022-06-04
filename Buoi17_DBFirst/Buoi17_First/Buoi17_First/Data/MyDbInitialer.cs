using Buoi17_First.Models;
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

#pragma warning disable CS8602 // Dereference of a possibly null reference.
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

#pragma warning restore CS8602 // Dereference of a possibly null reference.
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

                if (!context.Roles.Any())
                {
                    context.AddRange(
                        new Role
                        {
                            RoleName = "Administrator",
                            Description = "Quản trị hệ thống",

                        },
                        new Role
                        {
                            RoleName = "Sales",
                            Description = "Nhân viên kinh doanh",
                        },
                        new Role
                        {
                            RoleName = "Customer",
                            Description = "Khách hàng",
                        },
                        new Role
                        {
                            RoleName = "Accountant",
                            Description = "Kế toán",
                        }
                    );
                }

                context.SaveChanges();
            }

        }
    }
}