using BankingSystem.Api.Filter;
using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;
using BankingSystem.Core.Extensions;
using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	[PermissionChecker(1)]
	public class BranchController : ControllerBase
	{
		private readonly IBranchService _branchService;

		#region ctor
		public BranchController(IBranchService branchService)
		{
			_branchService = branchService;
		}
		#endregion
		[HttpGet("GetBranch")]
		public async Task<IActionResult> GetBranch()
		{
			if (ModelState.IsValid)
			{
				var branch = await _branchService.GetBranch();
				if (branch != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<BranchDto>.CreateSuccess(branch));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpGet("GetBranchById")]
		public async Task<IActionResult> GetBranchById(int branchId)
		{
			if (ModelState.IsValid)
			{
				var branch = await _branchService.GetBranchById(branchId);
				if(branch != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<BranchDto>.CreateSuccess(branch));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}


		[HttpPost("AddBranch")]
		[Authorize]

		public async Task<IActionResult> AddBranch(AddBranchDto branchDto)
		{
			if (ModelState.IsValid)
			{
				if( await _branchService.AddBranch(branchDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}

		[HttpPut("UpdateBranch")]
		public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
		{
			if (ModelState.IsValid)
			{
				if (await _branchService.UpdateBranch(updateBranchDto))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}


		[HttpDelete("DeleteBranch")]
		public async Task<IActionResult> DeleteBranch(int branchId)
		{
			if (ModelState.IsValid)
			{
				if (await _branchService.DeleteBranch(branchId))
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(ApiResultDto<bool>.CreateSuccess(true));
				}
			}
			throw new Exception(StatusCodes.Status404NotFound.ToString());
		}
	}
}
