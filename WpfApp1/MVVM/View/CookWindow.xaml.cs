using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1.Views
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