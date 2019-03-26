using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Runtime.CompilerServices;
[assembly:InternalsVisibleTo("PeopleSearch.Tests")]

namespace PeopleSearch.Models
{
	public class PersonBuilder : IPersonBuilder
	{
		private Entity.HealthCatalystDemoEntities db;

		public PersonBuilder(Entity.HealthCatalystDemoEntities dbContext)
		{
			db = dbContext;
		}

		public ICollection<IPerson> GetPersons()
		{
			ICollection<IPerson> persons = new List<IPerson>();
			var dbPersons = db.Persons;
			persons = BuildPersons(dbPersons);
			return persons;
		}

		public IPerson GetPerson(int id)
		{
			Person person = BuildPerson(db.Persons.Find(id));
			return person;
		}

		public ICollection<IPerson> GetPersons(string name)
		{
			ICollection<IPerson> persons = new List<IPerson>();
			var dbPersons = from p in db.Persons
						 where p.FirstName.Contains(name) || p.LastName.Contains(name)
						 select p;
			persons = BuildPersons(dbPersons);
			return persons;
		}

		private ICollection<IPerson> BuildPersons(IQueryable dbPersons)
		{
			ICollection<IPerson> persons = new List<IPerson>();
			foreach (var p in dbPersons)
			{
				persons.Add(BuildPerson((Entity.Person)p));
			}
			return persons;
		}

		internal static Person BuildPerson(Entity.Person ep)
		{
			if (ep == null)
			{
				return null;
			}

			Person person = new Person();
			person.Id = ep.Id;
			person.FirstName = ep.FirstName;
			person.LastName = ep.LastName;
			person.Address = ep.Address;
			person.City = ep.City;
			person.State = ep.State;
			person.Zip = ep.Zip;
			person.Birthday = ep.Birthday;
			person.Picture = ep.PictureUrl;

			foreach (var i in ep.Interests)
			{
				Interest interest = new Interest();
				interest.Id = i.Id;
				interest.Name = i.Interest1;
				person.Interests.Add(interest);
			}

			return person;
		}
	}
}