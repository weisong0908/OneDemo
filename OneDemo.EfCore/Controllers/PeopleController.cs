using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneDemo.EfCore.Persistence;

namespace OneDemo.EfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;

        public PeopleController(IPeopleRepository peopleRepository)
        {
            _peopleRepository = peopleRepository;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _peopleRepository.GetPeople();

            return Ok(people);
        }
    }
}