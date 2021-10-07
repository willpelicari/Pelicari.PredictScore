using Microsoft.EntityFrameworkCore;

namespace Pelicari.PredictScore.Data.Models.Context
{
    public class PredictScoreContext : DbContext
    {
        public virtual DbSet<Season> Seasons { get; internal set; }
        public virtual DbSet<Group> Groups { get; internal set; }

        public virtual DbSet<User> Users { get; internal set; }

        public PredictScoreContext(string connString)
        {
        }

        public PredictScoreContext(DbContextOptions<PredictScoreContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Admin)
                .WithMany()
                .HasForeignKey(g => g.AdminId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(u => u.Groups);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.HomeTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.GuestTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Score)
                .WithOne(s => s.Match)
                .HasForeignKey<Score>(s => s.MatchId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Round)
                .WithMany(r => r.Matches)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prediction>()
                .HasOne(p => p.User)
                .WithMany(u => u.Predictions)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prediction>()
                .HasOne(m => m.Match)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Prediction>()
                .HasOne(m => m.Score)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Season>()
                .HasMany(s => s.Groups)
                .WithMany(g => g.Seasons);

            modelBuilder.Entity<Sport>()
                .HasMany(s => s.Seasons)
                .WithOne(s => s.Sport)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Sport)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
