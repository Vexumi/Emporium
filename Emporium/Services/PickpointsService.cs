using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class PickPointsService : CRUDService<PickupPoint>
    {
        public PickPointsService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<PickupPoint> GetAll(int offset = 0, int takeCount = 20)
        {
            return this.dbContext.Set<PickupPoint>()
                .Include(p => p.Employees)
                .Skip(offset)
                .Take(takeCount);
        }

        public override IQueryable<PickupPoint> FindById(int id)
        {
            return this.dbContext.Set<PickupPoint>().Where(p => p.PickupPointId == id);
        }
    }
}
