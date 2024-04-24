using DataAcessLayer.Configuration;
using DataAcessLayer.Models;
using LinqToDB.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace DataAcessLayer
{
    public class ChatServerEntities : DbContext, IChatServerEntities
    {
       
        public DbSet<User> Users {  get; set; }

        public DbSet<Message> Messages {  get; set; }

        
        public ChatServerEntities(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                AddConfiguration(modelBuilder);
                base.OnModelCreating(modelBuilder);
        }
        private void AddConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
        }

    }
}
