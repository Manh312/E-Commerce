using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Data
{
    public class AuthContext:DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options): base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> users { get; set; }
    }
}
