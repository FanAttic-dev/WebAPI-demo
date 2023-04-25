using System.Linq.Expressions;

namespace DAL.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity entity);

        TEntity Get(int id);

        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        void Delete(int id);
    }
}
