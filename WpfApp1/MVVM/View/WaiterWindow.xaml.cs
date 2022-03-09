using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
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