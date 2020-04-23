namespace OneDemo.EfCore.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeopleContext _peopleContext;

        public UnitOfWork(PeopleContext peopleContext)
        {
            _peopleContext = peopleContext;
        }

        public void SaveChanges()
        {
            _peopleContext.SaveChanges();
        }
    }
}