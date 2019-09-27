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


        void SaveChanges();
        Task SaveChangesAsync();
    }
}