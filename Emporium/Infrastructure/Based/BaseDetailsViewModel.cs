using Emporium.Models;
using Emporium.Services;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Emporium.Infrastructure.Based
{
    public class BaseDetailsViewModel<T, S> : BaseViewModel
        where S : CRUDService<T> where T : BaseEntity
    {
        private Window _window;
        private T _item;
        protected S service;
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public T Item
        {
            get { return _item; }
            set
            {
                _item = value;
                OnPropertyChanged("Item");
            }
        }

        public Window CurrentWindow
        {
            get { return _window; }
            set
            {
                _window = value;
                OnPropertyChanged("CurrentWindow");
            }
        }

        public BaseDetailsViewModel(S service)
        {
            this.service = service;
            this.SaveCommand = new RelayCommand(async o => await Save());
            this.DeleteCommand = new RelayCommand(async o => await Delete());
        }

        public async Task Save()
        {
            if (Item.Id == null)
            {
                await this.service.Create(Item);
            }
            else
            {
                await this.service.Save(Item);
            }
            this._window.DialogResult = true;
        }

        public async Task Delete()
        {
            await this.service.Delete(Item);
            this._window.DialogResult = true;
        }
    }
}
