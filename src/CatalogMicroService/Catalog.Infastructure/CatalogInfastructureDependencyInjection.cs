
using Catalog.Application.Abstractions;
using Catalog.Infastructure.Persistents;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infastructure
{
    public static class CatalogInfastructureDependencyInjection
    {
        public static  IServiceCollection AddCatalogInfastructureDependencyInjection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ICatalogDbContext, CatalogDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("CatalogConnectionString")));
            return services;
        }
    }
}
