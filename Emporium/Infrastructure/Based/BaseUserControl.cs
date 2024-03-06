using Emporium.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emporium.Infrastructure.Based
{
    public abstract class BaseUserControl : UserControl, ILoadable
    {
        public virtual async Task LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
