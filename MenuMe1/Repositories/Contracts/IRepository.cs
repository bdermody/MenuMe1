namespace MenuMe1.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAll();  

        TEntity Get(int id);

        bool Has(int id);

        void Delete(int id);

        void Update(TEntity entity);

        void Insert(TEntity entity);

        void Save();
    }
}
