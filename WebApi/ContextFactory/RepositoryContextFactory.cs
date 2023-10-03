using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EfCore;

namespace WebApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //ConfigurationBuilder 
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //DbContextOptionBuilder
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                   .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                   prj=>prj.MigrationsAssembly("WebApi"));


            return new RepositoryContext(builder.Options);

               
        }
    }
}
