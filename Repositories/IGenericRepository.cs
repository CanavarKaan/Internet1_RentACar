using System.Linq.Expressions;

namespace Internet1_RentACar.Repositories
{
   public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProps = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProps = null);

        void Add(T entity);
        void Delete(T entity);
        void MultipleDelete(IEnumerable<T> entities);

    }
}
