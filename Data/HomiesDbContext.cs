using Data.Common;
using Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class HomiesDbContext : IdentityDbContext<ApplicationUser>
    {
        public HomiesDbContext()
            : base("DefaultConnection", false)
        {
        }


        //TO-DO 
        //all the Tables for this App
        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Food> Foods { get; set; }
        public virtual IDbSet<FoodPicture> FoodPictures { get; set; }


        public static HomiesDbContext Create()
        {
            return new HomiesDbContext();
        }

        public override int SaveChanges()
        {
            ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync()
        {
            ApplyAuditInfoRules();
            return await base.SaveChangesAsync();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && (e.State == EntityState.Added || e.State == EntityState.Modified))
                )
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

    }
}
