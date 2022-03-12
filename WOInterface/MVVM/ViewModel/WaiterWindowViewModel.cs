using System;
using System.Configuration;
using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.MVVM.View;

namespace WOInterface.MVVM.ViewModel
{
    public class WaiterWindowViewModel
    {
        #region [CreateOrder]

        public RelayCommand<Window> CreateOrderCommand
        {
            get
            {
                return new RelayCommand<Window>(o =>
                {
                    CreateOrderWindow(o);
                });
            }
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
                    MessageBoxResult result = CustomMessageBox.Show("Выход","Выберите способ выхода", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Yes)
                    {
                        Exit();
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        Exit(o);
                    }
                });
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }

        private void Exit(Window window)
        {
            MainWindow mainWindow = new MainWindow();
            window.Close();
            mainWindow.Show();
        }

        #endregion
    }
}