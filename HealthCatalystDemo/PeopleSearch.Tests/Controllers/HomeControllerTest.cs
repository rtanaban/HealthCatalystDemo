using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PeopleSearch;
using PeopleSearch.Controllers;

namespace PeopleSearch.Tests.Controllers
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("Home Page", result.ViewBag.Title);
		}
	}
}
