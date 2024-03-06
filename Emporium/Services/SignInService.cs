using Emporium.Infrastructure.Based;
using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class SignInService : BaseService
    {
        public SignInService(ApplicationContext context) : base(context)
        {

        }

        public async Task<User> SignIn(string email, string password)
        {
            var user = await dbContext.Users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefaultAsync();

            return user;
        }
    }
}
