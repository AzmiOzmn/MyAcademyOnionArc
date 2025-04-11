using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Features.CQRS.Handlers;

namespace Onion.Application.Extansions
{
   public static class ServiceRegistrations
    {
        public static void AddAplicationExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistrations).Assembly);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistrations).Assembly); 
                   
            });

            services.AddScoped<GetCategoryQueryHandler>();


            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
        }
    }
}
