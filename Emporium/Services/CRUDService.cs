using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class CRUDService<EntityType> : BaseService
        where EntityType : class
    {
        public CRUDService(ApplicationContext context) : base(context)
        {

        }

        public virtual async Task Save(EntityType entity)
        {
            this.dbContext.Set<EntityType>().Update(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(EntityType entity)
        {
            this.dbContext.Set<EntityType>().Remove(entity);
            await this.dbContext.SaveChangesAsync();
        }

        public virtual IQueryable<EntityType> GetAll(int offset = 0, int takeCount = 20)
        {
            return this.dbContext.Set<EntityType>().AsNoTracking().Skip(offset).Take(takeCount);
        }

        public virtual IQueryable<EntityType> GetAll(Paginator paginator)
        {
            return this.GetAll(paginator.Offset, paginator.TakeCount);
        }

        public virtual IQueryable<EntityType> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual int Count()
        {
            return this.dbContext.Set<EntityType>().Count();
        }
    }
}
