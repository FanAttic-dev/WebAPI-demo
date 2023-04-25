using DAL;
using DAL.Models;
using DAL.Repository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

var contextOptions = new DbContextOptionsBuilder<ProjectsDbContext>()
    .UseSqlServer(config.GetConnectionString("ProjectContext"))
    .Options;

var dbContextFactory = new UnitOfWorkFactory(contextOptions);

ResetDb(contextOptions);

using (var db = dbContextFactory.CreateUnitOfWork())
{
    var studentRepo = new Repository<Student>(dbContextFactory);
    var projectRepo = new Repository<Project>(dbContextFactory);
    Console.WriteLine($"Number of registered students: {studentRepo.Get().Count()}");
    Console.WriteLine($"Number of registered projects: {projectRepo.Get().Count()}");
}

static void ResetDb(DbContextOptions<ProjectsDbContext> contextOptions)
{
    using (var db = new ProjectsDbContext(contextOptions))
    {
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        ProjectsInitializer.Seed(db);
    }
}