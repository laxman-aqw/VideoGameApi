using Microsoft.EntityFrameworkCore;
using VideoGameApi.Models;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGameDetails => Set<VideoGameDetails>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Pubg",
                    Platform = "Desktop",
                  
                }, new VideoGame
                {
                    Id = 2,
                    Title = "Pubg Mobile",
                    Platform = "Mobile",
                  
                }, new VideoGame
                {
                    Id = 3,
                    Title = "COC",
                    Platform = "Mobile",

                }
                );
        }
    }
}