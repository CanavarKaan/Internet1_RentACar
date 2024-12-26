using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }


        public void Update(ApplicationUser applicationUser)
        {
            _appDbContext.Update(applicationUser);
        }
    }
}
