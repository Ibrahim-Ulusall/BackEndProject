using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
			_categoryService = categoryService;
        }

        [HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _categoryService.GetAll();
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _categoryService.GetById(id);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}
	}
}
