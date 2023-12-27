using Microsoft.EntityFrameworkCore;

namespace Pechi.Data
{
    public class DatabaseContext:DbContext
    {
        public DbSet<DataRow> DataRows { get; set; }
        public DbSet<User> Users { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
    }
}
