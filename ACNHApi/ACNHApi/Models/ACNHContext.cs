using Microsoft.EntityFrameworkCore;

namespace ACNHApi.Models
{
    public class ACNHContext : DbContext
    {
        public ACNHContext(DbContextOptions<ACNHContext> options)
            : base(options)
        {
        }

        public DbSet<ACNHItem> ACNHItems { get; set; }
    }
}