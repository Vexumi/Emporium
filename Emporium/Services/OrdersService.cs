using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class OrdersService : CRUDService<Order>
    {
        public OrdersService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<Order> GetAll()
        {
            return this.dbContext.Set<Order>()
                .AsNoTracking()
                .Include(p => p.Customer)
                    .ThenInclude(s => s.User)
                .Include(p => p.Employee)
                    .ThenInclude(s => s.User)
                .Include(p => p.OrderDetails);
        }

        public override IQueryable<Order?> FindById(int id)
        {
            return this.dbContext.Set<Order>().Where(p => p.OrderId == id);
        }
    }
}
