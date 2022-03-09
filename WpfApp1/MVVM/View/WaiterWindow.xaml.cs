using System.Windows;
using WpfApp1.MVVM.ViewModel;

namespace WpfApp1.MVVM.View
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