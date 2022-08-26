using MenuMe1.Data;
using MenuMe1.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuMe1.Repositories
{
    public class OrdenRepository : Repository<Orden>
    {
        public OrdenRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Orden> GetAll()
        {
            return Set.Include(o => o.MenuItem).ToList();
        }
    }
}
