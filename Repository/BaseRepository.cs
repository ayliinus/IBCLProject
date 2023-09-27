using Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            entity.CreatedAt = DateTime.Now.ToLocalTime();
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.SaveChanges();
            return entity;
        }

        public T Delete(T entity)
        {
            entity.DeletedAt = DateTime.Now.ToLocalTime();
            Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T Find(int id)
        {
            return Set().Find(id);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> whereCondition)
        {
            return Set().Where(whereCondition);
        }

        public T GetFirst(Expression<Func<T, bool>> whereCondition)
        {
            return Set().FirstOrDefault(whereCondition);
        }

        public List<T> List()
        {
            return Set().ToList();
        }

        public DbSet<T> Set()
        {
            return _dbContext.Set<T>();
        }

        public T Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now.ToLocalTime();
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return entity;
        }
    }
}
