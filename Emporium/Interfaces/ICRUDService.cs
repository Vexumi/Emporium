using Emporium.Infrastructure;
using Emporium.Infrastructure.Based;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Interfaces
{
    public interface ICRUDService
    {
        Task Save(BaseEntity entity);

        Task Delete(BaseEntity entity);

        IQueryable GetAll();

        IQueryable<BaseEntity> GetAll(Paginator paginator);

        IQueryable<BaseEntity> FindById(int id);

        int Count();
    }
}
