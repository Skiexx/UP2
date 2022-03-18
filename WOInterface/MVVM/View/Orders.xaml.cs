using System.Windows;
using System.Windows.Input;

namespace WOInterface.MVVM.View;

public partial class Orders : Window
{
    public Orders()
    {
        InitializeComponent();
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }
}