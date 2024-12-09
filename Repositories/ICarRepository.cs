using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        void Update(Car car);
        void Save();
    }
}
