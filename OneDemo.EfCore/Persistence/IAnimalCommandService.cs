using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public interface IAnimalCommandService
    {
        Animal AddAnimal(Animal animal);
        void UpdateAnimal(Animal animal);
        void RemoveAnimal(Animal animal);
    }
}