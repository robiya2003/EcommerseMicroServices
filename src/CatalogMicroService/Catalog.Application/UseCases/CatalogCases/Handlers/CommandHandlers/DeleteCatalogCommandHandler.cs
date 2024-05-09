
using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;

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
    public class DeleteCatalogCommandHandler : IRequestHandler<DeleteCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public DeleteCatalogCommandHandler(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(DeleteCatalogCommand request, CancellationToken cancellationToken)
        {
            var catalog = await _context.catalogModels.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (catalog != null)
            {
                _context.catalogModels.Remove(catalog);
                await _context.SaveChangesAsync(cancellationToken);

                return new ResponseModel
                {
                    StatusCode = 201,
                    Message = $"{request.Id} => Catalog Deleted",
                    IsSuccess = true
                };
            }

            return new ResponseModel
            {
                Message = "Catalog is maybe null",
                StatusCode = 400
            };
        }
    }
}
