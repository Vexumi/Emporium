using Emporium.Infrastructure.Based;
using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Emporium.Infrastructure;

namespace Emporium.Services
{
    public class CRUDService<EntityType> : BaseService
        where EntityType : class
    {
        public async Task Save(EntityType entity)
        {
            this.dbContext.Set<EntityType>().Update(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(EntityType entity)
        {
            this.dbContext.Set<EntityType>().Remove(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<List<EntityType>> GetAll(int offset = 0, int takeCount = 20)
        {
            return await this.dbContext.Set<EntityType>().Skip(offset).Take(takeCount).ToListAsync();
        }

        public async Task<List<EntityType>> GetAll(Paginator paginator)
        {
            return await this.dbContext.Set<EntityType>().Skip(paginator.Offset).Take(paginator.TakeCount).ToListAsync();
        }

        public int Count()
        {
            return this.dbContext.Set<EntityType>().Count();
        }
    }
}
