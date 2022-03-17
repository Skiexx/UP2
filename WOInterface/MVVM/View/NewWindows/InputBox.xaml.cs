using System;
using System.Windows;
using System.Windows.Input;

namespace WOInterface.MVVM.View.NewWindows;

public partial class InputBox : Window
{
    public InputBox()
    {
        InitializeComponent();
    }
    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }

    private int _countOf = 1;
    private void BtnSave(object sender, RoutedEventArgs e)
    {
        int temp;
        
        try
        {
            temp = int.Parse(CountOf.Text);
        }
        catch
        {
            CustomMessageBox.Show("Ошибка", "Неверно указанно кол-во", MessageBoxButton.OK);
            return;
        }
        
        if (temp <= 0)
        {
            CustomMessageBox.Show("Ошибка", "Неверно указанно кол-во", MessageBoxButton.OK);
            return;
        }

        _countOf = temp;
        Window.Close();
    }

    public int GetCount()
    {
        return _countOf;
    }

    private void BtnCancel(object sender, RoutedEventArgs e)
    {
        Window.Close();
    }
}