using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JAPChallenge.Models
{
    public class JapChallengeDbContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<VehicleModel> Vehicle { get; set; }
        public DbSet<ClientModel> Client { get; set; }
        public DbSet<RentingModel> Renting { get; set; }
        public JapChallengeDbContext(DbContextOptions<JapChallengeDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!_configuration.GetValue<bool>("IsDbConfigured"))
            {
                // Get the connection string from IConfiguration
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        
    }
}
