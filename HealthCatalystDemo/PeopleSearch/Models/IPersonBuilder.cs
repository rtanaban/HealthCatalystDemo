using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Models
{
	public interface IPersonBuilder
	{
		ICollection<IPerson> GetPersons();
		IPerson GetPerson(int id);
		ICollection<IPerson> GetPersons(string name);

	}
}
