using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core.DTOs.ApiResult
{
	public class ApiResultDto<T>
	{
		public bool IsSuccess { get; set; }

		public string Message { get; set; }

		public T Data { get; set; }

        public int RsCode { get; set; }


		public ApiResultDto<T> CreateSuccess<T>(T data, bool IsSuccess = true, string Message = "عملیات با موفقیت انجام شد.")
		{
			return new ApiResultDto<T>() { Data = data, IsSuccess = IsSuccess, Message = Message,RsCode = (int)ResultRsCode.Success};
		}

		public ApiResultDto<T> NotFound<T>(T data, bool IsSuccess = false, string Message = "مورد درخواستی یافت نشد")
		{
			return new ApiResultDto<T>() { Data = data, IsSuccess = IsSuccess, Message = Message, RsCode = (int)ResultRsCode.NotFound};
		}

		public enum ResultRsCode
		{
			Success = 00,
			NotFound = 404,
			BadRequest = 401
		}
	}
}
