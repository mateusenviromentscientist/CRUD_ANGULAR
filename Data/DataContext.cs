using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;



namespace PlayerStats_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Player_Stats> Player_Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Player_Stats>()
                .HasKey(AD => new { AD.PlayerId, AD.StatsId });

            builder.Entity<Player>()
                .HasData(new List<Player>(){
                    new Player(1, "Messi"),
                    new Player(2, "CR7"),
                    new Player(3, "Modric"),
                    new Player(4, "Zidane"),
                    new Player(5, "Ronaldo"),
                });

            builder.Entity<Stat>()
                .HasData(new List<Stat>(){
                    new Stat(1, "70 gols e 30 assistencias", 1),
                    new Stat (2, "57 gols e 20 assistencias", 2),
                    new Stat (3, "10 gols e 2 assistencias", 3),
                    new Stat (4, "20 gols e 20 assistencias", 4),
                    new Stat (5, "30 gols e 20 assistencias", 5)
                });

            builder.Entity<Player_Stats>()
                .HasData(new List<Player_Stats>() {
                    new Player_Stats() {PlayerId = 1, StatsId = 1 },
                    new Player_Stats() {PlayerId = 2, StatsId = 2 },
                    new Player_Stats() {PlayerId = 3, StatsId = 3 },
                    new Player_Stats() {PlayerId = 4, StatsId = 4 },
                    new Player_Stats() {PlayerId = 5, StatsId = 5 },
               });
        }
    }
}