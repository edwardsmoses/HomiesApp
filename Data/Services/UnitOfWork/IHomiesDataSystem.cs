using Data.Common;
using Data.Models;
using System.Threading.Tasks;

namespace Data.Services.UnitOfWork
{
    public interface IHomiesDataSystem
    {
        IDeletableEntityRepository<ApplicationUser> Users { get; }

        //TO-Do
        //create the other tables properties here
        IDeletableEntityRepository<Food> Foods { get; }
        IDeletableEntityRepository<FoodPicture> FoodPictures { get; }
        IDeletableEntityRepository<Category> Categories { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}