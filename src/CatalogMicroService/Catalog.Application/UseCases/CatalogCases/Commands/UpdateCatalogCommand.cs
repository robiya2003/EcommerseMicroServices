using Catalog.Domain;
using Catalog.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Commands
{
    public class UpdateCatalogCommand : ProductCatalogDTO, IRequest<CatalogModel>
    {
        public Guid Id { get; set; }
    }
}
