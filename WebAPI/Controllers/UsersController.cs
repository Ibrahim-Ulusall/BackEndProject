using Business.Abstract;
using Core.Entities.Concrete.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{

		private readonly IUserService _userService;

        public UsersController(IUserService userSerivce)
        {
			_userService = userSerivce;
        }

		[HttpGet("get-all")]
		public IActionResult GetAll()
		{
			var result = _userService.GetAll();
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpGet("getby-id")]
		public IActionResult Get(int id)
		{
			var result = _userService.Get(id);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpPost("add")]
		public IActionResult Add(User user)
		{
			var result = _userService.Add(user);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpPost("delete")]
		public IActionResult Delete(User user)
		{
			var result = _userService.Delete(user);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpPost("update")]
		public IActionResult Update(User user)
		{
			var result = _userService.Update(user);
			if (result.Success)
				return Ok(result);
			return BadRequest(result.Message);
		}

		[HttpPost("claims")]
		public IActionResult GetClaims(User user)
		{
			var result = _userService.GetClaims(user);
			if (result.Count > 0)
				return Ok(result);
			return BadRequest($" {user.FirstName} kullanıcısının herhangi bir yetkisi yok");
		}
    }
}
