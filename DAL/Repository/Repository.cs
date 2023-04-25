using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private UnitOfWorkFactory _unitOfWorkFactory;

        private DbSet<TEntity> DbSet => _unitOfWorkFactory.GetUnitOfWork().DbContext.Set<TEntity>();

        public Repository(UnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public void Create(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public TEntity Get(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public void Delete(int id)
        {
            var entity = DbSet.Find(id);

            if (entity == null)
            {
                return;
            }

            DbSet.Remove(entity);
        }
    }
}
