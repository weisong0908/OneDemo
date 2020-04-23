using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneDemo.EfCore.Models;
using OneDemo.EfCore.Persistence;

namespace OneDemo.EfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PeopleController(IPeopleRepository peopleRepository, IUnitOfWork unitOfWork)
        {
            _peopleRepository = peopleRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _peopleRepository.GetPeople();

            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            var person = _peopleRepository.GetPeople().SingleOrDefault(p => p.Id == id);

            return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPeople([FromBody] Person person)
        {
            _peopleRepository.AddPerson(person);
            _unitOfWork.SaveChanges();

            return CreatedAtAction(nameof(GetPerson), new { id = person.Id }, person);
        }

        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            _peopleRepository.UpdatePerson(person);

            _unitOfWork.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePerson(int id)
        {
            var person = _peopleRepository.GetPeople().SingleOrDefault(p => p.Id == id);

            _peopleRepository.RemovePerson(person);

            _unitOfWork.SaveChanges();

            return Ok();
        }
    }
}