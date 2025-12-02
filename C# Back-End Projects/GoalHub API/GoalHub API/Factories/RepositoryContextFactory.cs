using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository.Context;

namespace GoalHub_API.Factories
{
    public class GoalHubSQLContextFactory : IDesignTimeDbContextFactory<GoalHubSQLContext>
    {
        public GoalHubSQLContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            DbContextOptionsBuilder<GoalHubSQLContext> builder = new DbContextOptionsBuilder<GoalHubSQLContext>()
                                        .UseSqlServer(configuration.GetConnectionString("SQLDBConnection"),
                                                b => b.MigrationsAssembly("GoalHub API"));

            return new GoalHubSQLContext(builder.Options);

        }

    }

    public class GoalHubSQLiteContextFactory : IDesignTimeDbContextFactory<GoalHubSQLiteContext>
    {
        public GoalHubSQLiteContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

            DbContextOptionsBuilder<GoalHubSQLiteContext> builder = new DbContextOptionsBuilder<GoalHubSQLiteContext>()
                                        .UseSqlite(configuration.GetConnectionString("SQLiteDBConnection"),
                                                b => b.MigrationsAssembly("GoalHub API"));

            return new GoalHubSQLiteContext(builder.Options);

        }

    }
}
