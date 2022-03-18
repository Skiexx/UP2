using System.Windows;
using System.Windows.Input;

namespace WOInterface.MVVM.View;

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