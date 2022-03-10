using System.Windows;
using Restaurant.MVVM.ViewModel;

namespace Restaurant.MVVM.View
{
    public partial class WaiterWindow : Window
    {
        public WaiterWindow()
        {
            InitializeComponent();
            DataContext = new WaiterWindowViewModel();
        }
    }
}