using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WOInterface.MVVM.View;

public partial class CustomMessageBox : Window
{
    public CustomMessageBox()
    {
        InitializeComponent();
    }
    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        base.OnMouseLeftButtonDown(e);
        DragMove();
    }

    void AddButtons(MessageBoxButton buttons) //выбираем тип кнопки
    {
        switch (buttons)
        {
            case MessageBoxButton.OK: //кнопка ok
                AddButton("ОК", MessageBoxResult.OK);
                break;
            case MessageBoxButton.OKCancel: //и т.д.
                AddButton("ОК", MessageBoxResult.OK);
                AddButton("Закрыть", MessageBoxResult.Cancel, isCancel: true);
                break;
            case MessageBoxButton.YesNo:
                AddButton("Да", MessageBoxResult.Yes);
                AddButton("Нет", MessageBoxResult.No);
                break;
            case MessageBoxButton.YesNoCancel:
                AddButton("Закрыть", MessageBoxResult.Yes);
                AddButton("Выйти", MessageBoxResult.No);
                AddButton("Отмена", MessageBoxResult.Cancel, isCancel: true);
                break;
            default:
                throw new ArgumentException("Unknown button value", "buttons");
        }
    }

    void AddButton(string text, MessageBoxResult result, bool isCancel = false) //а дальше я хз
    {
        var button = new Button() { Content = text, IsCancel = isCancel };
        button.Click += (o, args) => { Result = result; DialogResult = true; };
        ButtonContainer.Children.Add(button);
    }

    MessageBoxResult Result = MessageBoxResult.None;

    public static MessageBoxResult Show(string caption, string message,
                                        MessageBoxButton buttons)
    {
        var dialog = new CustomMessageBox() { Title = caption };
        dialog.MessageContainer.Text = message;
        dialog.AddButtons(buttons);
        dialog.ShowDialog();
        return dialog.Result;
    }
}