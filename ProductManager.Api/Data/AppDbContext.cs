using Microsoft.EntityFrameworkCore;
using ProductManger.Api.Models;

namespace ProductManger.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeatureModel> Features { get; set; }
    }
}