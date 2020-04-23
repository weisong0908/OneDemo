namespace OneDemo.EfCore.Persistence
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}