namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public void Save();

        public bool IsDisposed();
    }
}
