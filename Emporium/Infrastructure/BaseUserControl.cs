using Emporium.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Emporium.Infrastructure
{
    public abstract class BaseUserControl: UserControl, ILoadable
    {
        public virtual async Task LoadData()
        {
            throw new NotImplementedException();
        }
    }
}
