using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Database.Context
{
    /// <summary>
    /// DB context
    /// </summary>
    public class TaskTrackerContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public TaskTrackerContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
