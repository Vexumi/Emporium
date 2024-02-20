using Emporium.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Emporium.Services
{
    public class SignInService
    {
        private readonly ApplicationContext dbContext;
        public SignInService()
        {
            dbContext = new ApplicationContext();
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
