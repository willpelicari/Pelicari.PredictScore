using Microsoft.EntityFrameworkCore;

namespace Pelicari.PredictScore.Data.Models.Context
{
    public class PredictScoreContext : DbContext
    {
        private string _connString;

        public PredictScoreContext(string connString)
        {
            _connString = connString;
        }

        public PredictScoreContext(DbContextOptions<PredictScoreContext> options) : base(options)
        {

        }

        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Prediction> Prediction { get; set; }
        public virtual DbSet<Round> Round { get; set; }
        public virtual DbSet<Sport> Sport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasOne(e => e.HomeTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(e => e.GuestTeam)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prediction>()
                .HasOne(e => e.Schedule)
                .WithMany()
                .HasForeignKey(e => e.ScheduleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Score>()
                .HasOne(e => e.Prediction)
                .WithMany()
                .HasForeignKey(e => e.PredictionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
