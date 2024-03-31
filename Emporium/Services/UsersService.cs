using Emporium.Models;

namespace Emporium.Services
{
    public class UsersService : CRUDService<User>
    {
        public UsersService(ApplicationContext context) : base(context) { }
    }
}
