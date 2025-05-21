using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Pubg",
                    Platform = "Desktop",
                    Developer = "Tencent",
                    Publisher = "Tencent"
                }, new VideoGame
                {
                    Id = 2,
                    Title = "Pubg Mobile",
                    Platform = "Mobile",
                    Developer = "Tencent",
                    Publisher = "Tencent"
                }, new VideoGame
                {
                    Id = 3,
                    Title = "COC",
                    Platform = "Mobile",
                    Developer = "Supercell",
                    Publisher = "Supercell"
                }
                );
        }
    }
}