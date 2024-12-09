using Internet1_RentACar.Migrations;
using Internet1_RentACar.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Internet1_RentACar.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _AppDbContext;
        internal DbSet<T> dbSet;
        public GenericRepository(AppDbContext appDbContext) 
        { 
            _AppDbContext = appDbContext;
            this.dbSet = _AppDbContext.Set<T>();
            _AppDbContext.Cars.Include(k => k.Category).Include(k => k.CategoryId);
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProps = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(string? includeProps = null)
        {
            IQueryable<T> query = dbSet;

            if (!string.IsNullOrEmpty(includeProps))
            {
                foreach (var includeProp in includeProps.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }

        public void MultipleDelete(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
