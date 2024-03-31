using Emporium.Interfaces;
using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class ProductsService : CRUDService<Product>
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
            return this.dbContext.Set<Product>().Include(p => p.Seller).Where(p => p.Id == id);
        }

        public override async Task Delete(Product entity)
        {
            this.dbContext.Set<Product>().Remove(entity);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
