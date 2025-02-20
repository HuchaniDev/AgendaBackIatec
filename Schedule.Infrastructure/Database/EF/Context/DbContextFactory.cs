using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Schedule.Infrastructure.Database.EF.Context;

namespace Academic.Infrastructure.Database.EntityFramework.Context;

public class DbContextFactory : IDesignTimeDbContextFactory<ScheduleBdContext>
{
    public ScheduleBdContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddUserSecrets<DbContextFactory>()  
            .Build();
        
        string connectionString = configuration["ConnectionStrings:localConnection"];

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentNullException(nameof(connectionString), "La cadena de conexión no puede ser nula ni estar vacía.");
        }
        
        var optionsBuilder = new DbContextOptionsBuilder<ScheduleBdContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new ScheduleBdContext(optionsBuilder.Options);
    }
}