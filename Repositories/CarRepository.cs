using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private AppDbContext _appDbContext;
        public CarRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            _appDbContext.Update(car);
        }
    }
}
