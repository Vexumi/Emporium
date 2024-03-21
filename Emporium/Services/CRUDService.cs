using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using Emporium.Infrastructure.Extensions;
using Emporium.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class CRUDService<EntityType> : BaseService, ICountable
        where EntityType : BaseEntity
    {
        public CRUDService(ApplicationContext context) : base(context) { }

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

        public virtual IQueryable<EntityType> GetAll()
        {
            return this.dbContext.Set<EntityType>().AsNoTracking();
        }

        public virtual IQueryable<EntityType> GetAll(Paginator paginator)
        {
            return this.GetAll()
                .ApplyFilters(paginator.SortSettings, paginator.FilterSettings, paginator.FilterOption)
                .ApplyOffset(paginator.Offset, paginator.TakeCount);
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
