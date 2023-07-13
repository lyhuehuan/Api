using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;
using WebApi.Services.IServices;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        [HttpGet("{id:int}")]
        public Category GetById(int id) 
        {
            return _categoryService.GetById(id);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);
            if (!result)
            {
                return NotFound();
            }
           
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryCreateDto categoryDto)
        {
            var category = new Category()
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
            _categoryService.Create(category);
            return StatusCode(201);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute] int id, [FromBody] Category category)
        {
            _categoryService.Update(id, category);
            return StatusCode(201);
        }
    }


}
