using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class ProductsService : CRUDService<Product>
    {
        public ProductsService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<Product> GetAll(int offset = 0, int takeCount = 20)
        {
            return this.dbContext.Set<Product>()
                .Include(p => p.Seller)
                    .ThenInclude(s => s.User)
                .Skip(offset)
                .Take(takeCount);
        }

        public override IQueryable<Product?> FindById(int id)
        {
            return this.dbContext.Set<Product>().Where(p => p.ProductId == id);
        }
    }
}
