using Microsoft.EntityFrameworkCore;
using Tournamint_BackEnd.Database.InitialData;
using Tournamint_BackEnd.Models;

namespace Tournamint_BackEnd.Database
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options) : base(options)
        {
        }

        public DbSet<Match> matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>().HasKey(x => x.MatchId);
            modelBuilder.Entity<Match>().Property(x => x.TournamentId);//.IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerOne);//.IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerTwo);//.IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerOneScore);//.IsRequired();
            modelBuilder.Entity<Match>().Property(x => x.PlayerTwoScore);//.IsRequired();

            modelBuilder.Entity<Match>().HasData(MatchInitialData.DataSeed);
        }
    }
}
