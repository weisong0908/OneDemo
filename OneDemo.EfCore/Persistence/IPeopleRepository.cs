using System.Collections.Generic;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public interface IPeopleRepository
    {
        IEnumerable<Person> GetPeople();
        void UpdatePerson(Person person);
        void AddPerson(Person person);
        void RemovePerson(Person person);
    }
}