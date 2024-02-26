using Microsoft.EntityFrameworkCore;
using TaskManager.Logic.Entities;

namespace TaskManager.Logic.Repository
{
    public class TaskManagerContext : DbContext
    {
        public DbSet<WorkingTask> WorkingTasks { get; set; }

        public static string ConnectionString { get; set; }

        public TaskManagerContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}
