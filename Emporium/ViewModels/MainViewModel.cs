using Emporium.Models;

namespace Emporium.ViewModels
{
    public class MainViewModel
    {
        private readonly User _user;
        public MainViewModel(User user)
        {
            _user = user;
        }
    }
}
