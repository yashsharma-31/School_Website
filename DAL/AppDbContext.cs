using Microsoft.EntityFrameworkCore;
using School.Api.DMOs;

namespace School.Api.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
