using Catalog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Abstractions
{
    public interface ICatalogDbContext
    {
        public DbSet<CatalogModel> catalogModels { get; set; }
        

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
