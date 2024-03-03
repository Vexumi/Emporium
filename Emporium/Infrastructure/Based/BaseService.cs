using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emporium.Infrastructure.Based
{
    public abstract class BaseService
    {
        protected readonly ApplicationContext dbContext;
        public BaseService(ApplicationContext context)
        {
            dbContext = context;
        }
    }
}
