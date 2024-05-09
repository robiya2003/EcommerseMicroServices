
using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Domain;
using Catalog.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogCases.Handlers.CommandHandlers
{
    public class UpdateCatalogCommandHandler : IRequestHandler<UpdateCatalogCommand, CatalogModel>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public UpdateCatalogCommandHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<CatalogModel> Handle(UpdateCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _context.catalogModels.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (catalog is not null)
            {
                catalog.Name = request.Name;
                catalog.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return catalog;
            }

            return null;
        }
    }
}
