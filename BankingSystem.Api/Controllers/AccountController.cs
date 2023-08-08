using BankingSystem.Core.DTOs.Account.User;
using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
			return BadRequest();
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
