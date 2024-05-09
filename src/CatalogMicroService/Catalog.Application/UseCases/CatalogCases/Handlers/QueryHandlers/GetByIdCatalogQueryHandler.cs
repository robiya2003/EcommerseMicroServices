
using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain;
using Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.QueryHandlers
{
    public class GetByIdCatalogQueryHandler : IRequestHandler<GetByIdCatalogQuery, CatalogModel>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;
        public GetByIdCatalogQueryHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<CatalogModel> Handle(GetByIdCatalogQuery request, CancellationToken cancellationToken)
        {
            var catalog = await _context.catalogModels.FirstOrDefaultAsync(x => x.Id == request.Id);

            return catalog;
        }
    }
}
