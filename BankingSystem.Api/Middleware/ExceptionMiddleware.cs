using BankingSystem.Core.DTOs.ApiResult;
using Newtonsoft.Json;
using static BankingSystem.Core.DTOs.ApiResult.ApiResultDto<bool>;

namespace BankingSystem.Api.Middleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				var statusCodeResult = (ex.InnerException.Message.Length > 3 ? 500 : Convert.ToInt16(ex.InnerException.Message));
				var result = ApiResultDto<bool>.CreateSuccess(false);
				switch (statusCodeResult)
				{
					case 400:
						result.Data = false;
						result.IsSuccess = false;
						result.Message = "BadRequest";
						result.RsCode = (int)ResultRsCode.BadRequest;
						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						
						break;
					case 404:
						result.Data = false;
						result.IsSuccess = false;
						result.Message = "NotFound";
						result.RsCode = (int)ResultRsCode.NotFound;
						context.Response.StatusCode = StatusCodes.Status404NotFound;
						break;
					case 403:
						result.Data = false;
						result.IsSuccess = false;
						result.Message = "ForBidden";
						result.RsCode = (int)ResultRsCode.NotFound;
						context.Response.StatusCode = StatusCodes.Status403Forbidden;
						break;
					default:
						result.Data = false;
						result.IsSuccess = false;
						result.Message = "ServerError";
						result.RsCode = (int)ResultRsCode.ServerError;
						context.Response.StatusCode = StatusCodes.Status500InternalServerError;
						break;
				}
				string json = JsonConvert.SerializeObject(result);
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsJsonAsync(result);
			}
		}
	}
}
