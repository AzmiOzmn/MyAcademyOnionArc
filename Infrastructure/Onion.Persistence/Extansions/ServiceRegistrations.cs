using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Interfaces;
using Onion.Persistence.Context;
using Onion.Persistence.Repositories;

namespace Onion.Persistence.Extansions
{
    public static class ServiceRegistrations
    {
       public static void AddPersistanceExt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
