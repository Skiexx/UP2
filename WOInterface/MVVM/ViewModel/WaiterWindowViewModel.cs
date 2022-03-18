using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.MVVM.View;
using WOInterface.MVVM.View.NewWindows;

namespace WOInterface.MVVM.ViewModel;

public class WaiterWindowViewModel
{
    #region [CreateOrder]

    public RelayCommand<Window> CreateOrderCommand
    {
        get { return new RelayCommand<Window>(o => { CreateOrderWindow(o); }); }
    }

    private void CreateOrderWindow(Window window)
    {
        window.Hide();
        CreateOrder createOrder = new();
        createOrder.Show();
    }

    #endregion

    #region [Orders]

    public RelayCommand<Window> OrdersWindow
    {
        get
        {
            return new RelayCommand<Window>(o =>
            {
                o.Hide();
                ShowOrdersWindow();
            });
        }
    }

    private void ShowOrdersWindow()
    {
        Orders ordersWindow = new();
        ordersWindow.Show();
    }

    #endregion

    #region [Exit]

    public RelayCommand<Window> SelectExit
    {
        get
        {
            return new RelayCommand<Window>(o =>
            {
                MessageBoxResult result =
                    CustomMessageBox.Show("Выход", "Выберите способ выхода", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MainWindowViewModel.CloseApplication();
                        break;
                    case MessageBoxResult.No:
                        Exit(o);
                        break;
                }
            });
        }
    }

    private void Exit(Window window)
    {
        var mainWindow = new MainWindow();
        window.Close();
        mainWindow.Show();
    }

    #endregion
}