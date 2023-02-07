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
            modelBuilder.Entity<Match>().Property(x => x.WinnerFirstName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.WinnerLastName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.LoserFirstName).IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.LoserLastName).IsRequired();

            //modelBuilder.Entity<Match>().HasData(MatchInitialData.DataSeed);
        }
    }
}
