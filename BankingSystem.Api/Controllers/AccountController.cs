using BankingSystem.Core.DTOs.Account.User;
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
			if(ModelState.IsValid)
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
					return Ok();
				}
			}
			return BadRequest();
		}

		[HttpPut("UpdatePermission")]
		public async Task<IActionResult> UpdatePermission(UpdatePermissionDto updatePermissionDto)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.UpdatePermission(updatePermissionDto))
				{
					return Ok();
				}
			}
			return BadRequest();
		}


		[HttpDelete("DeletePermission")]
		public async Task<IActionResult> DeletePermission(int permissionId)
		{
			if (ModelState.IsValid)
			{
				if (await _userService.DeletePermission(permissionId))
				{
					return Ok();
				}
			}
			return BadRequest();
		}
		#endregion
	}
}
