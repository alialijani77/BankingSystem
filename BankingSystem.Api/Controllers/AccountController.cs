using BankingSystem.Core.DTOs.Account.User;
using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		public readonly IUserService _userService;

		#region ctor
		public AccountController(IUserService userService)
		{
			_userService = userService;
		}
		#endregion
		#region User

		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginDto login)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.CheckForLogin(login))
				{
					var user = await _userService.GetUserByNationalCode(login.NationalCode);
					#region Login User

					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.NameIdentifier, user.NationalCode.ToString()),
					};

					var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);
					var properties = new AuthenticationProperties { IsPersistent = login.RememberMe };

					await HttpContext.SignInAsync(principal, properties);

					#endregion
					return Ok(login);
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpPost]
		public async Task<IActionResult> AddUser(UserDto user)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.AddUser(user))
				{
					return Ok();
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		#endregion
		#region Permission
		[HttpPost("AddPermission")]

		public async Task<IActionResult> AddPermission(PermissionDto permissionDto)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.AddPermission(permissionDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpPut("UpdatePermission")]
		public async Task<IActionResult> UpdatePermission(UpdatePermissionDto updatePermissionDto)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.UpdatePermission(updatePermissionDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}


		[HttpDelete("DeletePermission")]
		public async Task<IActionResult> DeletePermission(int permissionId)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.DeletePermission(permissionId))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
		#endregion
	}
}
