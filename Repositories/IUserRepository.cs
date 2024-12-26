using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        void Update(ApplicationUser applicationUser);
        void Save();
    }
}
