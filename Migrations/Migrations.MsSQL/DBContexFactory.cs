using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using DataAcessLayer;

namespace Migrations.MsSQL
{
    public class DbContextFactory : IDesignTimeDbContextFactory<ChatServerEntities>
    {
        public ChatServerEntities CreateDbContext(string[] args)
        {
            var contextBuilder = new DbContextOptionsBuilder<ChatServerEntities>();
            contextBuilder.UseSqlServer("Server=fake;Database=db;User=root;Password=root;", config =>
            {
                config.MigrationsAssembly("Migrations.MsSQL");
            });
            return new ChatServerEntities(contextBuilder.Options);
        }
    }
}
