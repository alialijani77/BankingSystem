using BankingSystem.Core.DTOs.ApiResult;
using BankingSystem.Core.DTOs.Branch;
using BankingSystem.CoreBusiness.Services.Interfaces;
using BankingSystem.Domain.Entities.Branch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BranchController : ControllerBase
	{
		private readonly IBranchService _branchService;

		#region ctor
		public BranchController(IBranchService branchService)
		{
			_branchService = branchService;
		}
		#endregion
		[HttpGet("GetBranchById")]
		public async Task<IActionResult> GetBranchById(int branchId)
		{
			var apiResult = new ApiResultDto<BranchDto>();

			if (ModelState.IsValid)
			{
				var branch = await _branchService.GetBranchById(branchId);
				if(branch != null)
				{
					Response.StatusCode = StatusCodes.Status200OK;
					return new JsonResult(apiResult.CreateSuccess(branch));
				}
			}
			Response.StatusCode = StatusCodes.Status404NotFound;
			return new JsonResult(apiResult.NotFound(false));
		}


		[HttpPost("AddBranch")]

		public async Task<IActionResult> AddBranch(BranchDto branchDto)
		{
			var apiResult = new ApiResultDto<BranchDto>();
			if (ModelState.IsValid)
			{
				var result = await _branchService.AddBranch(branchDto);
				Response.StatusCode = StatusCodes.Status404NotFound;

				//var res2 = apiResult.CreateSuccess(result);
				return new JsonResult("ok");
			}
			Response.StatusCode = StatusCodes.Status400BadRequest;
			//var res3 = apiResult.CreateSuccess(true);

			return new JsonResult("notok");
		}

		[HttpPut("UpdateBranch")]
		public async Task<IActionResult> UpdateBranch(UpdateBranchDto updateBranchDto)
		{
			if (ModelState.IsValid)
			{
				if (await _branchService.UpdateBranch(updateBranchDto))
				{
					return Ok();
				}
			}
			return BadRequest();
		}


		[HttpDelete("DeleteBranch")]
		public async Task<IActionResult> DeleteBranch(int branchId)
		{
			if (ModelState.IsValid)
			{
				if (await _branchService.DeleteBranch(branchId))
				{
					return Ok();
				}
			}
			return BadRequest();
		}
	}
}
