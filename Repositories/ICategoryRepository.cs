using Internet1_RentACar.Models;

namespace Internet1_RentACar.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
