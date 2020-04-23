using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneDemo.EfCore.Persistence;

namespace OneDemo.EfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly PeopleContext _peopleContext;

        public PeopleController(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = _peopleContext.People.ToList();

            return Ok(people);
        }
    }
}