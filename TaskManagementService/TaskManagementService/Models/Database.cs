using Microsoft.EntityFrameworkCore;
using TaskManagementService.Models;

namespace TaskManagementService.Models
{
    public partial class Database : DbContext
    {
        public Database(DbContextOptions<Database> options)
            : base(options)
        { }
        public virtual DbSet<Task> Tasks { get; set; }
    }
}