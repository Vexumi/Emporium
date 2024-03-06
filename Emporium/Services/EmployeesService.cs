using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class EmployeesService : CRUDService<Employee>
    {
        public EmployeesService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<Employee> GetAll(int offset = 0, int takeCount = 20)
        {
            return this.dbContext.Set<Employee>()
                .Include(p => p.User)
                .Include(p => p.PickupPoint)
                .Skip(offset)
                .Take(takeCount);
        }

        public override IQueryable<Employee?> FindById(int id)
        {
            return this.dbContext.Set<Employee>().Where(p => p.EmployeeId == id);
        }
    }
}
