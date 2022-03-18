using System.Windows;
using System.Windows.Input;

namespace WOInterface.MVVM.View;

public partial class CookWindow : Window
{
    public CookWindow()
    {
        InitializeComponent();
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }
}