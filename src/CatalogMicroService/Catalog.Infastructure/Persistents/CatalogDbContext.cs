using Catalog.Application.Abstractions;
using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infastructure.Persistents
{
    public class CatalogDbContext : DbContext, ICatalogDbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            :base(options) 
        {
            
        }
        public DbSet<CatalogModel> catalogModels { get ; set; }
    }
}
