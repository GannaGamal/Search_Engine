using Microsoft.EntityFrameworkCore;
using Search_Engine.Models;

namespace Search_Engine.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        

        public DbSet<UrlInfo> Urls { get; set; }
       
        public DbSet<InvertedIndex> InvertedIndexes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvertedIndex>().HasNoKey();
            modelBuilder.Entity<InvertedIndex>()
                .HasOne(ii => ii.UrlInfo)
                .WithMany()
                .HasForeignKey(ii => ii.UrlId);
            modelBuilder.Entity<UrlInfo>()
            .Property(u => u.UrlId)
            .ValueGeneratedNever();


        }
    }
}