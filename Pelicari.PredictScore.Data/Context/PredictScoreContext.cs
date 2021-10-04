using Microsoft.EntityFrameworkCore;

namespace Pelicari.PredictScore.Data.Models.Context
{
    public class PredictScoreContext : DbContext
    {
        public virtual DbSet<Schedule> Schedules { get; internal set; }
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
                .WithMany();

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(u => u.Groups);

            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Groups)
                .WithMany(g => g.Schedules);

            modelBuilder.Entity<Game>()
                .HasIndex(g => new { g.HomeTeamId, g.GuestTeamId });
        }
    }
}
