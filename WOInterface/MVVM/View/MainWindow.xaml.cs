using System.Windows;
using System.Windows.Input;
using WOInterface.Core;

namespace WOInterface;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        var context = new Context();
        InitializeComponent();
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        DragMove();
    }
}