using System.Collections.Generic;
using System.Linq;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public class AnimalQueryService : IAnimalQueryService
    {
        private readonly AnimalContext _animalContext;
        public AnimalQueryService(AnimalContext animalContext)
        {
            _animalContext = animalContext;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animalContext.Animals.ToList();
        }
    }
}