using System;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PeopleSearch.Models;
using PeopleSearch.Controllers;
using System.Data.Entity;
using System.Linq;


namespace PeopleSearch.Tests.Controllers
{
	/// <summary>
	/// Unit tests for PersonController
	/// </summary>
	[TestFixture]
	public class PersonControllerTest
	{
		ICollection<IPerson> data;
		ICollection<IPerson> filteredData;
		const string NAME = "an";

		[OneTimeSetUp]
		public void GlobalSetUp()
		{
			data = new List<IPerson>();
			data.Add(new Person
			{
				Id = 1,
				FirstName = "Alan",
				LastName = "Tong",
				Address = "21 Jump St.",
				City = "Metropolis",
				State = "WA",
				Zip = "11111",
				Birthday = new DateTime(2001, 1, 1),
				Picture = "atong.jpg",
				Interests = new List<Interest>() { new Interest { Id = 1, Name = "School" }, new Interest { Id = 2, Name = "Policing" } }
			});
			data.Add(new Person
			{
				Id = 2,
				FirstName = "Bertha",
				LastName = "Channing",
				Address = "2 34th St.",
				City = "Emeryville",
				State = "CA",
				Zip = "94000",
				Birthday = new DateTime(2002, 2, 2),
				Picture = "bchanning.jpg",
				Interests = new List<Interest>() { new Interest { Id = 3, Name = "Scuba" }, new Interest { Id = 2, Name = "Policing" } }
			});
			data.Add(new Person
			{
				Id = 3,
				FirstName = "Joe",
				LastName = "Hill",
				Address = "33b Baker St.",
				City = "San Jose",
				State = "CA",
				Zip = "94999",
				Birthday = new DateTime(1983, 3, 3),
				Picture = "jhill.jpg",
				Interests = new List<Interest>() { new Interest { Id = 3, Name = "Scuba" }, new Interest { Id = 4, Name = "Turtles" }, new Interest { Id = 5, Name = "Guitars" } }
			});
			data.Add(new Person
			{
				Id = 4,
				FirstName = "Janice",
				LastName = "Jellyfish",
				Address = "444 Market St.",
				City = "San Francisco",
				State = "CA",
				Zip = "94444",
				Birthday = new DateTime(1964, 4, 4),
				Picture = "jjellyfish.jpg",
				Interests = new List<Interest>() { new Interest { Id = 3, Name = "Scuba" }, new Interest { Id = 4, Name = "Turtles" }, new Interest { Id = 6, Name = "Fish" }, new Interest { Id = 7, Name = "Cruises" } }
			});

			filteredData = new List<IPerson>();
			filteredData = (from p in data
						   where ((Person)p).FirstName.Contains(NAME) || ((Person)p).LastName.Contains(NAME)
						   select p).ToList<IPerson>();
		}

		[Test]
		public void GetPersonByIdReturnsPersonWithSameIdAndName()
		{
			var mockRep = new Mock<PeopleSearch.Models.IPersonBuilder>();
			mockRep.Setup(x => x.GetPerson(1)).Returns(new Person { Id = 1, FirstName = "Alan", LastName = "Tong"});
			var controller = new PersonController(mockRep.Object);

			IHttpActionResult actionResult = controller.GetPerson(1);
			var contentResult = actionResult as OkNegotiatedContentResult<IPerson>;
			var person = (Person)contentResult.Content;

			Assert.IsNotNull(actionResult);
			Assert.IsNotNull(contentResult.Content);
			Assert.AreEqual(1, person.Id);
			Assert.AreEqual("Alan", person.FirstName);
			Assert.AreEqual("Tong", person.LastName);
		}

		[Test]
		public void GetPersonsReturnsAllPersons()
		{
			var mockRep = new Mock<PeopleSearch.Models.IPersonBuilder>();
			mockRep.Setup(x => x.GetPersons()).Returns(data);
			var controller = new PersonController(mockRep.Object);

			IHttpActionResult actionResult = controller.GetPersons();
			var contentResult = actionResult as OkNegotiatedContentResult<ICollection<IPerson>>;
			var persons = contentResult.Content;

			Assert.IsNotNull(actionResult);
			Assert.IsNotNull(contentResult.Content);
			Assert.AreEqual(4, persons.Count);

		}

		[Test]
		public void GetPersonsByNameReturnsCorrectPersons()
		{
			var mockRep = new Mock<PeopleSearch.Models.IPersonBuilder>();
			mockRep.Setup(x => x.GetPersons(NAME)).Returns(filteredData);
			var controller = new PersonController(mockRep.Object);

			IHttpActionResult actionResult = controller.Get(NAME);
			var contentResult = actionResult as OkNegotiatedContentResult<ICollection<IPerson>>;
			var persons = contentResult.Content;

			Assert.IsNotNull(actionResult);
			Assert.IsNotNull(contentResult.Content);
			Assert.AreEqual(3, persons.Count); // Alan, Channing and Janice
		}
	}
}
