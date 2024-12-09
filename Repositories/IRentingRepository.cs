using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public interface IRentingRepository : IGenericRepository<Renting>
    {
        void Update(Renting renting);
        void Save();
    }
}
