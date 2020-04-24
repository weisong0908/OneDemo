using OneDemo.EfCore.Models;

namespace OneDemo.EfCore.Persistence
{
    public class AnimalCommandService : IAnimalCommandService
    {
        private readonly AnimalContext _animalContext;

        public AnimalCommandService(AnimalContext animalContext)
        {
            _animalContext = animalContext;
        }

        public Animal AddAnimal(Animal animal)
        {
            _animalContext.Animals.Add(animal);

            _animalContext.SaveChanges();

            return animal;
        }

        public void UpdateAnimal(Animal animal)
        {
            _animalContext.Animals.Update(animal);

            _animalContext.SaveChanges();
        }

        public void RemoveAnimal(Animal animal)
        {
            _animalContext.Animals.Remove(animal);

            _animalContext.SaveChanges();
        }
    }
}