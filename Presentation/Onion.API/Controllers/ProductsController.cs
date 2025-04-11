using MediatR;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.Mediator.Commands;
using Onion.Application.Features.Mediator.Queries;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _mediator.Send(new GetProductQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result)
            {
                return BadRequest("Ürün eklerken bir hata oluştu.");
            }


            return CreatedAtAction(nameof(GetAll), null);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }
            return Ok(product);
        }

        [HttpPut]

        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result == false)
            {
                return BadRequest("Ürün güncellenirken bir hata oluştu.");
            }
            return Ok("Ürün başarı ile güncellendi");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            if (product == null)
            {
                return NotFound("Ürün bulunamadı.");
            }

            var result = await _mediator.Send(new RemoveProductCommand(id));
            if (!result)
            {
                return BadRequest("Ürün silinirken bir hata oluştu.");
            }
            return Ok("Ürün başarı ile silindi");
        }
    }
}
