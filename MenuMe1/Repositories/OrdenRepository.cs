using MenuMe1.Data;
using MenuMe1.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuMe1.Repositories
{
    public class OrdenRepository : Repository<Orden>, IRepository<Orden>
    {
        public OrdenRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
