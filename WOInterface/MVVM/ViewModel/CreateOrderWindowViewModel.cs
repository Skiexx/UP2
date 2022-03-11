using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;

namespace WOInterface.MVVM.ViewModel
{
    public class CreateOrderWindowViewModel
    {
        public Order? Order { get; set; }
        public ObservableCollection<Dish> Dishes { get; set; }

        public CreateOrderWindowViewModel()
        {
            Dishes = new(Service.Db.Dishes.ToList<Dish>());
        }
        public RelayCommand<Window> CancelCommand
        {
            get
            {
                return new RelayCommand<Window>(o =>
                {
                    ReturnToMain(o);
                });
            }
        }

        private void ReturnToMain(Window window)
        {
            window.Close();
            App.Current.Windows[0].Show();
        }
    }
}