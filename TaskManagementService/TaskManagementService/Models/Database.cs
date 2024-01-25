using Microsoft.EntityFrameworkCore;

namespace TaskManagementService.Models
{
    public partial class Database : DbContext, IDatabase
    {
        public Database(DbContextOptions<Database> options)
            : base(options)
        { }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskHistory> TaskHistory { get; set; }
        public DbSet<UserTaskHistory> UserTaskHistory { get; set; }
        public DbSet<UserTaskStatusType> UserTaskStatusType { get; set; }
        public DbSet<TaskType> TaskType { get; set; }

    }
}