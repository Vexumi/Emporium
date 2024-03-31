using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class SellersService : CRUDService<Seller>
    {
        public SellersService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<Seller> GetAll()
        {
            return this.dbContext.Set<Seller>()
                .AsNoTracking()
                .Include(s => s.User);
        }

        public override IQueryable<Seller?> FindById(int id)
        {
            return this.dbContext.Set<Seller>().Include(s=>s.User).Where(p => p.Id == id);
        }
    }
}
