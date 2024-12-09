using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public class RentingRepository : GenericRepository<Renting>, IRentingRepository
    {
        private AppDbContext _appDbContext;
        public RentingRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Renting renting)
        {
            _appDbContext.Update(renting);
        }
    }
}
