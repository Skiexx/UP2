using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;
using WOInterface.MVVM.View;
using WOInterface.Properties;

namespace WOInterface.MVVM.ViewModel;

public class MainWindowViewModel
{
    public string? Login { get; set; }
    public CookWindow CookWindow { get; set; }
    public WaiterWindow WaiterWindow { get; set; }

    public RelayCommand<object> LoginCommand
    {
        get
        {
            return new RelayCommand<object>(o =>
                {
                    var password = o as PasswordBox;
                    User user = null;
                    try
                    {
                        user = Service.Db.Users.FirstOrDefault(x =>
                            x.Login == Login && x.Password == password.Password);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                    if (user != null)
                    {
                        Settings.Default.UserId = user.Id;
                        Settings.Default.Save();
                        SignIn(user);
                    }
                }
            );
        }
    }

    public RelayCommand<Window> Exit => new(_ => CloseApplication());

    public void SignIn(User user)
    {
        if (user.RoleId == 1)
        {
            CookWindow = new CookWindow();
            Application.Current.MainWindow.Close();
            CookWindow.Show();
        }
        else if (user.RoleId == 2)
        {
            WaiterWindow = new WaiterWindow();
            Application.Current.MainWindow.Close();
            WaiterWindow.Show();
        }
    }

    public static void CloseApplication()
    {
        Application.Current.Shutdown();
    }
}