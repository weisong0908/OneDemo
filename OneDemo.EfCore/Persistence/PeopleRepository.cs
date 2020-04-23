using System.Collections.Generic;
using System.Linq;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleContext _peopleContext;

        public PeopleRepository(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _peopleContext.People.ToList();
        }
    }
}