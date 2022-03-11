using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;
using WOInterface.MVVM.View;

namespace WOInterface.MVVM.ViewModel
{
    public class MainWindowViewModel
    {
        public string? Login { get; set; }
        public User? User { get; set; }
        public CookWindow CookWindow { get; set; }
        public WaiterWindow WaiterWindow { get; set; }
        public RelayCommand<object> LoginCommand
        {
            get
            {
                return new RelayCommand<object>(execute: o => 
                    {
                        PasswordBox password = o as PasswordBox;
                        var user = Service.Db.Users.FirstOrDefault(x => x.Login == Login && x.Password == password.Password);
                        if (user != null)
                        {
                            SignIn(user);
                        }
                    }
                );      
            }
        }

        public void SignIn(User user)
        {
            if (user.RoleId == 1)
            {
                CookWindow = new();
                Application.Current.MainWindow.Close();
                CookWindow.Show();
            }
            else if (user.RoleId == 2)
            {
                WaiterWindow = new();
                Application.Current.MainWindow.Close();
                WaiterWindow.Show();
            }
        }
    }
}