using Business.Abstract;
using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		IProductService _productService;
        public ProductsController(IProductService productService)
        {
			_productService = productService;
        }
        [HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _productService.GetAll();
			if (result.Success)
				return Ok(result.Data);
			return BadRequest(result.Message);
		}

		[HttpGet("getbyid")]
	
		public IActionResult GetByCategoryId(int id)
		{
			var result = _productService.GetAllByCategory(id);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpPost("add")]
		public IActionResult Post(Product product)
		{
			var result = _productService.Add(product);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}
	}
}
