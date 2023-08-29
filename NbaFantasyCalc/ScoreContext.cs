using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NbaFantasyCalc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NbaFantasyCalc
{
    public class ScoreContext : DbContext
    {
        //entities
        public DbSet<Score> Scores { get; set; }
        public DbSet<Player> Players { get; set; }

        public ScoreContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configFile = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configFile.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Player>(eb =>
            //{
            //    eb.HasMany(w => w.Scores)
            //    .WithOne(c => c.BasketballPlayer)
            //    .HasForeignKey(c => c.BasketballPlayerId);


            //});
        }
    }
}
