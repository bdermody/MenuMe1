using MenuMe1.Data;
using Microsoft.EntityFrameworkCore;

namespace MenuMe1.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public Repository(ApplicationDbContext context)
        {
            Context = (ApplicationDbContext)context;
            Set = Context.Set<TEntity>();
        }

        readonly ApplicationDbContext Context;
        readonly DbSet<TEntity> Set;

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public TEntity Get(int id)
        {
            return Set.Find(id);
        }

        public void Delete(int id)
        {
            Delete(Set.Find(id));
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public bool Has(int id)
        {
            return 
                Set.Find(id) != null;
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Set.Update(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
