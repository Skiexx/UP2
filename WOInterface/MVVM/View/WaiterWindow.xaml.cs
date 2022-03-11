using System;
using System.Windows;
using System.Windows.Input;
using WOInterface.MVVM.ViewModel;

namespace WOInterface.MVVM.View
{
    public partial class WaiterWindow : Window
    {
        public WaiterWindow()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}