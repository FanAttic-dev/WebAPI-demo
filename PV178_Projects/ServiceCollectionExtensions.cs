using DAL;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace PV178_Projects
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUnitOfWorkFactory(this IServiceCollection services, WebApplicationBuilder builder)
        {
            string config = builder.Configuration.GetConnectionString("ProjectContext") ?? throw new InvalidOperationException("Connection string 'ProjectContext' not found.");
            var contextOptions = new DbContextOptionsBuilder<ProjectsDbContext>()
                .UseSqlServer(config)
                .Options;

            builder.Services.AddScoped(o => new UnitOfWorkFactory(contextOptions));
            builder.Services.AddScoped<IUnitOfWorkFactory>(o => o.GetRequiredService<UnitOfWorkFactory>());
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
