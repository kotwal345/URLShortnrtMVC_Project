using Microsoft.EntityFrameworkCore;
using URLShortnerMVC_Project.Models;

namespace URLShortnerMVC_Project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ShortUrl> ShortUrls { get; set; }
    }
}
