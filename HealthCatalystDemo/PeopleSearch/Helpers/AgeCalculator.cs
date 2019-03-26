using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Helpers
{
	public static class AgeCalculator
	{
		public static int GetAgeFromBirthday(DateTime birthday)
		{
			return GetAgeFromBirthday(birthday, DateTime.Now);
		}

		public static int GetAgeFromBirthday(DateTime birthday, DateTime currentDate)
		{
			int year = currentDate.Year - birthday.Year;
			int month = currentDate.Month - birthday.Month;
			if (month < 0)
			{
				year--;
			}
			return year;
		}
	}
}