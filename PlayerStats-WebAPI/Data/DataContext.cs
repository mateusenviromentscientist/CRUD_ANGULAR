

using Microsoft.EntityFrameworkCore;

namespace PlayerStats_WebAPI {
    public class DataContext : DbContext {
        
        public DataContext(DbContextOptions<DataContext> options) 
        :base(options)
        {

        }

        public DbSet<Player> Players {get; set;}

        public DbSet<Stat> Stats {get; set;}

        public DbSet<User> Users {get; set;}

    }

}