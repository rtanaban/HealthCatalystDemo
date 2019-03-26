using System;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PeopleSearch.Models;
using System.Data.Entity;
using System.Linq;

namespace PeopleSearch.Tests.Models
{
	[TestFixture]
	public class PersonBuilderTest
	{
		[Test]
		public void BuildPersonBuildsSuccessfully()
		{
			PeopleSearch.Models.Entity.Person ep = new PeopleSearch.Models.Entity.Person();
			ep.Id = 1;
			ep.FirstName = "First";
			ep.LastName = "Last";
			ep.Address = "Address";
			ep.City = "City";
			ep.State = "State";
			ep.Zip = "Zip";
			ep.Birthday = new DateTime(1980, 8, 8);
			ep.PictureUrl = "some url";

			var person = PersonBuilder.BuildPerson(ep);

			Assert.AreEqual(person.Id, ep.Id);
			Assert.AreEqual(person.FirstName, ep.FirstName);
			Assert.AreEqual(person.LastName, ep.LastName);
			Assert.AreEqual(person.Address, ep.Address);
			Assert.AreEqual(person.City, ep.City);
			Assert.AreEqual(person.State, ep.State);
			Assert.AreEqual(person.Zip, ep.Zip);
			Assert.AreEqual(person.Birthday, ep.Birthday);
			Assert.AreEqual(person.Picture, ep.PictureUrl);
		}
	}
}
