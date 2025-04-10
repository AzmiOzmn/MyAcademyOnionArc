using Microsoft.Extensions.DependencyInjection;
using Onion.Application.Features.CQRS.Commends;
using Onion.Application.Features.CQRS.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Extansions
{
   public static class ServiceRegistrations
    {
        public static void AddAplicationExt(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistrations).Assembly);

            services.AddScoped<GetCategoryQueryHandler>();

            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();
        }
    }
}
