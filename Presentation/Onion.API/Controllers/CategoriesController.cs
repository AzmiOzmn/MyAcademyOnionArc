using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.Application.Features.CQRS.Commends;
using Onion.Application.Features.CQRS.Handlers;
using Onion.Application.Features.CQRS.Queries;

namespace Onion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler removeCategoryCommandHandler;

        public CategoriesController(
            GetCategoryQueryHandler getCategoryQueryHandler,
            CreateCategoryCommandHandler createCategoryCommandHandler,
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
            UpdateCategoryCommandHandler updateCategoryCommandHandler,
            RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.createCategoryCommandHandler = createCategoryCommandHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
            this.removeCategoryCommandHandler = removeCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var values = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));

            if (values == null)
            {
                return NotFound("Kategori bulunmadı");
            }

            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand cmd)
        {
            var result = await createCategoryCommandHandler.Handle(cmd);

            if (!result)
            {
                return BadRequest("Kategori eklenemedi");
            }

            return Created("", "Kategori oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            var result = await updateCategoryCommandHandler.Handle(command);
            if (!result)
            {
                return BadRequest("Kategori güncellenemedi");
            }
            return Ok("Kategori güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            if (!result)
            {
                return BadRequest("Kategori silinemedi");
            }
            return Ok("Kategori silindi");
        }
    }
}
