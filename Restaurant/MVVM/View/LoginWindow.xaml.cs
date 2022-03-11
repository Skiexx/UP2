using System.Windows;
using System.Windows.Input;
using WpfApp1.MVVM.ViewModel;

namespace WpfApp1.MVVM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}