using Emporium.Infrastructure.Based;
using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class ProductsService: BaseService
    {
        public async Task<List<Product>> GetAllProducts(int takeCount = 20, int offset = 0)
        {
            return await this.dbContext.Products.Skip(offset).Take(takeCount).ToListAsync();
        }
    }
}
