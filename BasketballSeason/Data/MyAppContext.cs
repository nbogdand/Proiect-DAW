using System;
using BasketballSeason.Models;
using BasketballSeason.Models.OnetoOne;
using Microsoft.EntityFrameworkCore;

namespace BasketballSeason.Data
{
    public class MyAppContext : DbContext
    {
        // One to Many
        public DbSet<Team> Team { get; set; }

        public DbSet<Player> Player { get; set; }

        // One to One

        public DbSet<Coach> Coach { get; set; }

        // Many to Many

        public DbSet<User> User { get; set; }

        public DbSet<Tournament> Tournament { get; set; }
        public DbSet<TeamInTournament> TeamInTournament { get; set; }

        public MyAppContext(DbContextOptions<MyAppContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // One to Many
            // Team to Players

            builder.Entity<Team>()
                .HasMany(x => x.Players)
                .WithOne(y => y.Team);

            // One to One
            // Coach to Team

            builder.Entity<Coach>()
                .HasOne(x => x.Team)
                .WithOne(y => y.Coach)
                .HasForeignKey<Team>
                (z => z.CoachId);

            // Many to Many
            // Team to Tournament

            builder.Entity<TeamInTournament>()
                .HasKey(mr => new { mr.TeamId, mr.TournamentId });

            builder.Entity<TeamInTournament>()
                .HasOne<Team>(x => x.Team)
                .WithMany(y => y.TeamInTournament)
                .HasForeignKey(z => z.TeamId);

            builder.Entity<TeamInTournament>()
                .HasOne<Tournament>(x => x.Tournament)
                .WithMany(y => y.TeamInTournament)
                .HasForeignKey(z => z.TournamentId);

            base.OnModelCreating(builder);
        }

    }
}
