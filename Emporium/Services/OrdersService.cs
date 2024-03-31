using AutoMapper;
using Emporium.Models;
using Emporium.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class OrdersService : CRUDService<Order>
    {
        private readonly IMapper mapper;
        public OrdersService(ApplicationContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
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

        public IEnumerable<OrderDetailDto> GetOrderDetails(Order order)
        {
            var orderDetails = this.mapper.Map<OrderDetailDto[]>(order.OrderDetails);
            return orderDetails;
        }

        public override IQueryable<Order?> FindById(int id)
        {
            return this.dbContext.Set<Order>()
                .Include(d => d.OrderDetails)
                    .ThenInclude(o => o.PickupPoint)
                .Include(d => d.OrderDetails)
                    .ThenInclude(o => o.Product)
                .Where(p => p.Id == id);
        }
    }
}
