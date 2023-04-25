namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ProjectsDbContext DbContext { get; }

        private bool _disposed;

        public UnitOfWork(ProjectsDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Save()
        {
            DbContext?.SaveChanges();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
            _disposed = true;
        }

        public bool IsDisposed()
        {
            return _disposed;
        }
    }
}
