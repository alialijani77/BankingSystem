using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.Core.Generator
{
	public static class DateTimeGenerator
	{
		public static string GetPersianYear(this DateTime dateTime)
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			var getYear = persianCalendar.GetYear(dateTime).ToString().Substring(2);
			return getYear;
		}

		public static string GetPersianMonth(this DateTime dateTime)
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			var getMonth = persianCalendar.GetMonth(dateTime).ToString("00");
			return getMonth;
		}
	}
}
