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
