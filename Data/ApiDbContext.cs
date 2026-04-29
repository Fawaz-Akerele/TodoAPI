using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
