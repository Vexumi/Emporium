using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class PickupPointsService : CRUDService<PickupPoint>
    {
        public PickupPointsService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<PickupPoint> GetAll()
        {
            return this.dbContext.Set<PickupPoint>()
                .AsNoTracking()
                .Include(p => p.Employees);
        }

        public override IQueryable<PickupPoint> FindById(int id)
        {
            return this.dbContext.Set<PickupPoint>().Include(e => e.Employees).Where(p => p.Id == id);
        }
    }
}
