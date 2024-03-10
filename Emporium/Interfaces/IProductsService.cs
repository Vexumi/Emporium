using Emporium.Infrastructure;
using Emporium.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Interfaces
{
    public interface IProductsService
    {
        Task Save(Product entity);

        Task Delete(Product entity);

        IQueryable<Product> GetAll();

        IQueryable<Product> GetAll(Paginator paginator);

        IQueryable<Product> FindById(int id);

        int Count();
    }
}
