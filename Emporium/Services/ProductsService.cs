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
        public override async Task<List<Product>> GetAll(int offset = 0, int takeCount = 20)
        {
            return await this.dbContext.Set<Product>()
                .Include(p => p.Seller)
                    .ThenInclude(s => s.User)
                .Skip(offset)
                .Take(takeCount)
                .ToListAsync();
        }
    }
}
