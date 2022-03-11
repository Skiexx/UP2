using WpfApp1.Core;

namespace WpfApp1.MVVM.ViewModel
{
    public class LoginWindowViewModel
    {
        public RelayCommand BtnLogin { get; set; }
        public string Login { get; set; }
    }
}