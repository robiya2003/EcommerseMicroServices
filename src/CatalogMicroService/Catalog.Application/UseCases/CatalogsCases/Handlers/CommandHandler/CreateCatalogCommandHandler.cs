using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogsCases.Commands;
using Catalog.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.UseCases.CatalogsCases.Handlers.CommandHandler
{
    public class CreateCatalogCommandHandler : IRequestHandler<CreateCatalogCommand, ResponseModel>
    {
        private readonly ICatalogDbContext _catalogDbContext;
        public CreateCatalogCommandHandler(ICatalogDbContext catalogDbContext)
        {
            _catalogDbContext = catalogDbContext;
        }
        public async Task<ResponseModel> Handle(CreateCatalogCommand request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                CatalogModel catalogModel = new CatalogModel
                {
                    Name = request.Name,
                    Description = request.Description,
                };
                await _catalogDbContext.catalogModels.AddAsync(catalogModel,cancellationToken);
                await _catalogDbContext.SaveChangesAsync(cancellationToken);
                return new ResponseModel
                {
                    StatusCode = 201,
                    Message="Catalog Create bo'ldi",
                    IsSuccess=true
                };
            }

            return new ResponseModel
            {
                StatusCode = 400,
                Message = "Catalog is null",
                IsSuccess = false
            };
        }
    }
}
