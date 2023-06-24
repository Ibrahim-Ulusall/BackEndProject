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
        [HttpGet]
		public List<Product> GetProducts()
		{
			var result = _productService.GetAll();
			return result.Data;
		}
	}
}
