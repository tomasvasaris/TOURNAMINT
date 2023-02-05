using Microsoft.EntityFrameworkCore;
using Tournamint_BackEnd.Models;
using Tournamint_BackEnd.Database.InitialData;

namespace Tournamint_BackEnd.Database
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options) : base(options) {}

        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasKey(x => x.Id);
            modelBuilder.Entity<Match>().Property(x => x.TournamentId).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerOneFirstName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerOneLastName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerTwoFirstName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerTwoLastName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerOneResult).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerTwoResult).IsRequired();

            modelBuilder.Entity<Match>().HasData(MatchInitialData.DataSeed);
        }
    }
}
