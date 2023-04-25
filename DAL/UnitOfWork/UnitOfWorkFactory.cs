using Microsoft.EntityFrameworkCore;

namespace DAL.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly DbContextOptions<ProjectsDbContext> _dbContextOptions;

        private UnitOfWork _unitOfWork;

        public UnitOfWorkFactory(DbContextOptions<ProjectsDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            if (_unitOfWork != null)
            {
                throw new InvalidOperationException("Unit of Work already exists");
            }

            _unitOfWork = new UnitOfWork(new ProjectsDbContext(_dbContextOptions));
            
            return _unitOfWork;
        }

        public UnitOfWork GetUnitOfWork()
        {
            if (_unitOfWork == null || _unitOfWork.IsDisposed())
            {
                throw new InvalidOperationException("Invalid Unit of Work");
            }

            return _unitOfWork;
        }
    }
}
