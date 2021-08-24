using Microsoft.EntityFrameworkCore;

namespace ACNHApi.Models
{
    public class ACNHContext : DbContext
    {
        public ACNHContext(DbContextOptions<ACNHContext> options)
            : base(options)
        {
        }

        public DbSet<VillagerResponse> VillagerItems { get; set; }
        public DbSet<FishResponse> FishItems { get; set; }
    }
}
