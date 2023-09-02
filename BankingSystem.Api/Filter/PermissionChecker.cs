using BankingSystem.CoreBusiness.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using BankingSystem.Core.Extensions;

namespace BankingSystem.Api.Filter
{
	public class PermissionChecker : Attribute, IAsyncAuthorizationFilter
	{
		private readonly long _permissionId;

		public PermissionChecker(long permissionId)
		{
			_permissionId = permissionId;
		}
		public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
		{
			var userService = (IUserService)context.HttpContext.RequestServices.GetService(typeof(IUserService))!;

			if (!await userService.CheckUserPermission(_permissionId, context.HttpContext.User.GetUserId()))
			{
				throw new Exception(StatusCodes.Status403Forbidden.ToString());
			}

		}
	}
}
