using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Save()
        {
            _appDbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            _appDbContext.Update(category);
        }
    }
}
