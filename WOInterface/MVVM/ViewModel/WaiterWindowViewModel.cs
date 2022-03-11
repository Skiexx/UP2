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
                    o.Hide();
                    CreateOrderWindow();
                });
            }
        }

        private void CreateOrderWindow()
        {
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

        public int ExitType { get; set; }
        public RelayCommand SelectExit
        {
            get
            {
                return new RelayCommand(() =>
                {
                    
                });
            }
        }

        #endregion
    }
}