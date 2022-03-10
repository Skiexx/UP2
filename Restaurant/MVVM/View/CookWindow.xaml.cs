using System.Windows;
using Restaurant.MVVM.ViewModel;

namespace Restaurant.MVVM.View
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