using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeopleSearch.Helpers;

namespace PeopleSearch.Models
{
	public class Person : IPerson
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public System.DateTime Birthday { get; set; }
		public string Picture { get; set; }

		public ICollection<Interest> Interests { get; set; }

		public Person()
		{
			this.Interests = new List<Interest>();
		}

		public int Age
		{
			get
			{
				return this.GetAgeFromBirthday();
			}
		}
		
		private int GetAgeFromBirthday()
		{
			return AgeCalculator.GetAgeFromBirthday(this.Birthday);
		}

	}
}