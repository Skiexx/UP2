using System.Windows;
using WpfApp1.MVVM.ViewModel;

namespace WpfApp1.MVVM.View
{
    public partial class CookWindow : Window
    {
        public CookWindow()
        {
            InitializeComponent();
            DataContext = new CookWindowViewModel();
        }
    }
}