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
        public async Task<Product[]> GetAllProducts()
        {
            return await this.dbContext.Products.ToArrayAsync();
        }
    }
}
