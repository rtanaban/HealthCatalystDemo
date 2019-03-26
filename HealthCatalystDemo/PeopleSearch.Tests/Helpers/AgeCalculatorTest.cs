using System;
using PeopleSearch.Helpers;
using NUnit.Framework;

namespace PeopleSearch.Tests.Helpers
{
	[TestFixture]
	public class AgeCalculatorTest
	{
		[TestCase("1/1/2000", "3/1/2019", 19)]
		[TestCase("12/30/1990", "3/1/2019", 28)]
		[TestCase("4/1/1970", "3/1/2019", 48)]
		[TestCase("2/29/2004", "3/1/2019", 15)]
		public void Age_IsCorrect(string birthDateString, string currentDateString, int expectedAge)
		{
			DateTime birthDate = DateTime.Parse(birthDateString);
			DateTime currentDate = DateTime.Parse(currentDateString);
			int age = AgeCalculator.GetAgeFromBirthday(birthDate, currentDate);

			Assert.AreEqual(age, expectedAge);
		}
		
	}
}
