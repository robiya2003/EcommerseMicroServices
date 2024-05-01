using Catalog.Application.Abstractions;
using Catalog.Application.UseCases.CatalogCases.Commands;
using Catalog.Application.UseCases.CatalogCases.Queries;
using Catalog.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers.CatalogControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogDbContext _context;
        private readonly IMediator _mediator;

        public CatalogsController(ICatalogDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CatalogModel>>> GetAllCatalogs()
        {
            var result = await _mediator.Send(new GetAllCatalogsQuery());

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CatalogModel>> GetByIdCatalog(GetByIdCatalogQuery command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog(CreateCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<CatalogModel>> UpdateCatalog(UpdateCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCatalog(DeleteCatalogCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
