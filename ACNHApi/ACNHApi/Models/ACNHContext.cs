using Microsoft.EntityFrameworkCore;

namespace ACNHApi.Models
{
    public class ACNHContext : DbContext
    {
        public ACNHContext(DbContextOptions<ACNHContext> options)
            : base(options)
        {
        }

        public DbSet<VillagerResponse> ACNHVillagerItems { get; set; }
        public DbSet<FishResponse> ACNHFishItems { get; set; }

    }
}