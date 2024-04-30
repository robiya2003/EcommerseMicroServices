using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models
{
    public class CatalogModel
    {
        public Guid Id { get; set; }= Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
