using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EfCore;
using Services;
using Services.Contracts;

namespace WebApi.Extension
{
    //uzantı 
    //yapılandırma işlemleri çok uzayacak her biri için ilgili tanımları yaparsak program.cs cok şişer
    //servicelere ait tanımları burada tanımlayacağız
    public  static class ServicesExtension
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)=>
            services.AddDbContext<RepositoryContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

         public static void ConfigureRepositoryManager(this IServiceCollection services)=>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        //AddScoped:kullanıcı bazlı
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();
    }
}
