using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public abstract class BaseService
    {
        protected readonly ApplicationContext dbContext;
        public BaseService()
        {
            dbContext = new ApplicationContext();
        }
    }
}
