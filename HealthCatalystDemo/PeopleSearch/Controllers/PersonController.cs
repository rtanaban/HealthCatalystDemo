using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PeopleSearch.Models;

namespace PeopleSearch.Controllers
{
    public class PersonController : ApiController
    {
		private IPersonBuilder personBuilder;

		public PersonController(IPersonBuilder p) : base()
		{
			this.personBuilder = p;
		}

		// GET: api/Person
		/// <summary>
		/// Returns all persons stored in the DB
		/// </summary>
		/// <returns>Collection of Person objects</returns>
		[ResponseType(typeof(List<Person>))]
		[Route("api/person")]
		public IHttpActionResult GetPersons()
        {
			ICollection<IPerson> persons = personBuilder.GetPersons();
			if (persons == null)
			{
				return NotFound();
			}
			return Ok(persons);
		}

        // GET: api/Person/5
		/// <summary>
		/// Returns a person based on ID
		/// </summary>
		/// <param name="id">ID of the person</param>
		/// <returns>Person object</returns>
        [ResponseType(typeof(Person))]
		[Route("api/person/{id:int}")]
		public IHttpActionResult GetPerson(int id)
        {
			IPerson person = personBuilder.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

		// GET: api/Person/name_fragment
		/// <summary>
		/// Returns one or more persons based on name fragment (first or last name)
		/// </summary>
		/// <param name="name">Substring of either first or last name</param>
		/// <returns>Collection of Person objects</returns>
		[ResponseType(typeof(List<Person>))]
		[Route("api/person/{name}")]
		public IHttpActionResult Get(string name)
		{
			ICollection<IPerson> persons = personBuilder.GetPersons(name);
			if (persons == null)
			{
				return NotFound();
			}
			return Ok(persons);
		}

    }
}