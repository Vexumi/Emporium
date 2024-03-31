using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Emporium.Services
{
    public class EmployeesService : CRUDService<Employee>
    {
        public EmployeesService():base(new ApplicationContext()) { }
        public EmployeesService(ApplicationContext context) : base(context)
        {

        }
        public override IQueryable<Employee> GetAll()
        {
            return this.dbContext.Set<Employee>()
                .AsNoTracking()
                .Include(p => p.User)
                .Include(p => p.PickupPoint);
        }

        public override IQueryable<Employee?> FindById(int id)
        {
            return this.dbContext.Set<Employee>().Include(x => x.User).Where(p => p.Id == id);
        }
    }
}
