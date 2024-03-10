using Emporium.Interfaces;
using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class ProductsService : CRUDService<Product>, IProductsService
    {
        public ProductsService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<Product> GetAll()
        {
            return this.dbContext.Set<Product>()
                .AsNoTracking()
                .Include(p => p.Seller)
                    .ThenInclude(s => s.User);
        }

        public override IQueryable<Product?> FindById(int id)
        {
            return this.dbContext.Set<Product>().Where(p => p.ProductId == id);
        }
    }
}
