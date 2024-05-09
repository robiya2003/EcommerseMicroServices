
using Catalog.Application.Abstractions;
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
    public class GetAllCatalogsQueryHandler : IRequestHandler<GetAllCatalogsQuery, List<CatalogModel>>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;
        public GetAllCatalogsQueryHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<List<CatalogModel>> Handle(GetAllCatalogsQuery request, CancellationToken cancellationToken)
        {
            var catalogs = await _context.catalogModels.ToListAsync();

            return catalogs;
        }
    }
}
