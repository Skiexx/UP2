using System.Collections.ObjectModel;
using System.Linq;
using System.Printing;
using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;

namespace WOInterface.MVVM.ViewModel
{
    public class CreateOrderWindowViewModel : BaseViewModel
    {
        public Order? Order { get; set; }
        private Dish currentDish;
        private ObservableCollection<Dish> _dishesInOrder = new();
        public ObservableCollection<Dish> Dishes { get; set; }

        public CreateOrderWindowViewModel()
        {
            Dishes = new(Service.Db.Dishes.ToList<Dish>());
        }
        public RelayCommand<Window> CancelCommand
        {
            get
            {
                return new RelayCommand<Window>(o => ReturnToMain(o) );
            }
        }
        
        private void ReturnToMain(Window window)
        {
            window.Close();
            App.Current.Windows[0].Show();
        }

        public ObservableCollection<Dish> DishesInOrder
        {
            get => _dishesInOrder;
            set
            {
                _dishesInOrder = value;
                OnPropertyChanged();
            }
        }
        
        public Dish AddDish
        {
            set
            {
                value.Count = 2;
                AddDishInOrder(value);
                OnPropertyChanged();
            }
        }

        public Dish RemoveDish
        {
            set
            {
                RemoveDishInOrder(value);
                OnPropertyChanged();
            }
        }

        public void AddDishInOrder(Dish dish)
        {
            DishesInOrder.Add(dish);
            Dishes.Remove(dish);
        }
        public void RemoveDishInOrder(Dish dish)
        {
            DishesInOrder.Remove(dish);
            Dishes.Add(dish);
        }
    }
}