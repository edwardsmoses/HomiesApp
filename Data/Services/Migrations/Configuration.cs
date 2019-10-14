using Common;
using Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Data.Services.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<HomiesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(HomiesDbContext context)
        {
            SeedRoles(context);
            SeedUsers(context);

            SeedCategoryAndFood(context);
        }

        private void SeedRoles(HomiesDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var roleNames = new[] { RoleConstants.Admin, RoleConstants.Staff, RoleConstants.Foodie };

                foreach (var roleName in roleNames)
                {
                    var role = new IdentityRole { Name = roleName };
                    roleManager.Create(role);
                }

                context.SaveChanges();
            }
        }

        private void SeedUsers(HomiesDbContext context)
        {
            if (!context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var admin = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@Homies.com",
                    CreatedOn = DateTime.Now,
                    EmailConfirmed = true
                };

                var userCreateResult = userManager.Create(admin, "Password@123$");
                if (userCreateResult.Succeeded)
                {
                    context.Users.AddOrUpdate(admin);
                }

                context.SaveChanges();

                userManager.AddToRole(admin.Id, RoleConstants.Admin);

                context.SaveChanges();
            }
        }


        private void SeedCategoryAndFood(HomiesDbContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddOrUpdate(x => x.Name,
                    new Category()
                    {
                        
                        CreatedOn = DateTime.Now,
                        Name = "Rice",
                        Foods = new List<Food>()
                        {
                            new Food()
                            {
                                
                                CreatedOn = DateTime.Now,
                                Name = "Fried Rice",
                                IsMealOfTheDay = true,
                                Currency = Currency.Naira,
                                Price = 600,
                            },
                            new Food()
                            {
                                
                                CreatedOn = DateTime.Now,
                                Name = "Jollof Rice",
                                IsMealOfTheDay = false,
                                Currency = Currency.Naira,
                                Price = 500,
                            }
                        }
                    },
                     new Category()
                     {
                         Id = Guid.NewGuid(),
                         CreatedOn = DateTime.Now,
                         Name = "Beans",
                         Foods = new List<Food>()
                         {
                             new Food()
                             {
                                 
                                 CreatedOn = DateTime.Now,
                                 Name = "Beans",
                                 IsMealOfTheDay = false,
                                 Currency = Currency.Naira,
                                 Price = 400,
                             },
                             new Food()
                             {
                                 
                                 CreatedOn = DateTime.Now,
                                 Name = "Beans & Plantain",
                                 IsMealOfTheDay = true,
                                 Currency = Currency.Naira,
                                 Price = 900,
                             }
                         }
                     }
                    );
            }
        }
    }
}