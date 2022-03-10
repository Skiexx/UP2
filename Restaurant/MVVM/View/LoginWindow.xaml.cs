using System.Windows;
using Restaurant.MVVM.ViewModel;

namespace Restaurant.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new LoginWindowViewModel();
        }
    }
}