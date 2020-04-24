using System.Collections.Generic;
using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public interface IAnimalQueryService
    {
        IEnumerable<Animal> GetAnimals();
    }
}