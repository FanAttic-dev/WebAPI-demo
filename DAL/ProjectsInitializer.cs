using DAL.Models;

namespace DAL
{
    public static class ProjectsInitializer
    {
        public static void Seed(ProjectsDbContext context)
        {
            var students = new List<Student>
            {
                new Student { Uco = 940861486, Name = "Lindsay Parker", ProjectId = 1 },
                new Student { Uco = 199333303, Name = "David Rios", ProjectId = 2 },
                new Student { Uco = 320824289, Name = "Christine Dalton", ProjectId = 3 },
                new Student { Uco = 1706124396, Name = "Corey Smith", ProjectId = 4 },
                new Student { Uco = 1176155603, Name = "Joshua Walker", ProjectId = 5 },
                new Student { Uco = 1441050855, Name = "Jordan Wilson", ProjectId = 6 },
                new Student { Uco = 174922999, Name = "Gary Frank", ProjectId = 7 },
                new Student { Uco = 922098890, Name = "Rebecca Arias", ProjectId = 8 },
                new Student { Uco = 714125625, Name = "Carol Salas", ProjectId = 9 },
                new Student { Uco = 953933849, Name = "Daniel Mack", ProjectId = 10 },
                new Student { Uco = 292179603, Name = "Corey Murphy", ProjectId = 11 },
                new Student { Uco = 1711741498, Name = "Crystal Campbell", ProjectId = 12 },
                new Student { Uco = 1558880486, Name = "Matthew Randall", ProjectId = 13 },
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var projects = new List<Project>
            {
                new Project { Name = "Tournament Manager", StudentId = 1 },
                new Project { Name = "Google Analytics", StudentId = 2 },
                new Project { Name = "Pixel art", StudentId = 3 },
                new Project { Name = "Motion Capture", StudentId = 4 },
                new Project { Name = "E-shop API", StudentId = 5 },
                new Project { Name = "Sport Tournament Manager", StudentId = 6 },
                new Project { Name = "Tournament Manager + export to MS Word", StudentId = 7 },
                new Project { Name = "Image Augmentor", StudentId = 8 },
                new Project { Name = "Tournament Manager (WinForms)", StudentId = 9 },
                new Project { Name = "Expense Manager", StudentId = 10 },
                new Project { Name = "Daily Journal", StudentId = 11 },
                new Project { Name = "Expense Manager", StudentId = 12 },
                new Project { Name = "Expense Manager (WinForms)", StudentId = 13 },
            };

            context.Projects.AddRange(projects);
            context.SaveChanges();
        }
    }
}
