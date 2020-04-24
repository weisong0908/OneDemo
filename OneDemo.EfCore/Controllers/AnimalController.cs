using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneDemo.EfCore.Models;
using OneDemo.EfCore.Persistence;

namespace OneDemo.EfCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalQueryService _animalQueryService;
        private readonly IAnimalCommandService _animalCommandService;

        public AnimalController(IAnimalQueryService animalQueryService, IAnimalCommandService animalCommandService)
        {
            _animalQueryService = animalQueryService;
            _animalCommandService = animalCommandService;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animals = _animalQueryService.GetAnimals();

            return Ok(animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _animalQueryService.GetAnimals().SingleOrDefault(a => a.Id == id);

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            _animalCommandService.AddAnimal(animal);

            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut]
        public IActionResult UpdateAnimal([FromBody] Animal animal)
        {
            _animalCommandService.UpdateAnimal(animal);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = _animalQueryService.GetAnimals().SingleOrDefault(a => a.Id == id);

            _animalCommandService.RemoveAnimal(animal);

            return Ok();
        }
    }
}