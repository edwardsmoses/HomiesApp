using Data.Common;
using Data.Models;
using Data.Services.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Data.Services.UnitOfWork
{
    public class HomiesDataSystem : IHomiesDataSystem
    {
        private readonly DbContext dbContext;

        private readonly IDictionary<Type, object> repositories;

        private IUserStore<ApplicationUser> userStore;


        public HomiesDataSystem(DbContext context)
        {
            dbContext = context;
            repositories = new Dictionary<Type, object>();
        }


        public IUserStore<ApplicationUser> UserStore
            => userStore ?? (userStore = new UserStore<ApplicationUser>(dbContext));
        public IDeletableEntityRepository<ApplicationUser> Users => GetRepository<ApplicationUser>();


        //To-do
        //implement the unit-of-works properties for the Application right here

        public IDeletableEntityRepository<Food> Foods => GetRepository<Food>();
        public IDeletableEntityRepository<FoodPicture> FoodPictures => GetRepository<FoodPicture>();
        public IDeletableEntityRepository<Category> Categories => GetRepository<Category>();


        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            if (!repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                repositories.Add(typeof(T), Activator.CreateInstance(type, dbContext));
            }

            return (IDeletableEntityRepository<T>)repositories[typeof(T)];
        }
    }
}