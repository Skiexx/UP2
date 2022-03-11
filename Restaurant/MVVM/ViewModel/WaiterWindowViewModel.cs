using WpfApp1.Core;

namespace WpfApp1.MVVM.ViewModel
{
    public class WaiterWindowViewModel : ObservableObject
    {
        public OrdersViewWaiterViewModel OrdersViewVM { get; set; }
        public CreateOrderWaiterViewModel CreateOrderViewVM { get; set; }
        public RelayCommand CreateOrderViewCommand { get; set; }
        public RelayCommand OrdersViewCommand { get; set; }
        private object? _currentView { get; set; }
        public object? CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public WaiterWindowViewModel()
        {
            OrdersViewVM = new();
            CreateOrderViewVM = new();
            CurrentView = OrdersViewVM;

            OrdersViewCommand = new(_ => CurrentView = OrdersViewVM);
            CreateOrderViewCommand = new(_ => CurrentView = CreateOrderViewVM);
        }
    }
}