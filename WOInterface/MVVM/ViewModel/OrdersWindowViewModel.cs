using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;
using WOInterface.Properties;
using WOInterface.MVVM.View.NewWindows;

namespace WOInterface.MVVM.ViewModel;

public class OrdersWindowViewModel : BaseViewModel
{
    private ObservableCollection<Order> _ordersGrid;
    public ObservableCollection<Order> OrdersGrid
    {
        get => _ordersGrid;
        set
        {
            _ordersGrid = value;
            OnPropertyChanged();
        }
    }

    public OrdersWindowViewModel()
    {
        OrdersGrid = new(Service.Db.Orders.Where(o => o.UserId == Settings.Default.UserId)
            .Include(q=> q.Status));
    }

    private Order _currentOrder;
    public Order CurrentOrder
    {
        get => _currentOrder;
        set
        {
            _currentOrder = value;
            OnPropertyChanged();
        }
    }
    public RelayCommand ChangeStatusId
    {
        get => new(() =>
        {
            if (_currentOrder == null)
            {
                CustomMessageBox.Show("Ошибка", "Вы не выбрали обьект", MessageBoxButton.OK);
                return;
            }
            MessageBoxResult result = CustomMessageBox
                .Show("Изменить", "Вы уверены, что\nхотите изменить статус?", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) return;
            ChangeStatusIdMethod();
            OnPropertyChanged();
        });
    }

    private void ChangeStatusIdMethod()
    {
        if (_currentOrder.StatusId == 1) _currentOrder.StatusId = 2;
        else _currentOrder.StatusId = 1;
        _currentOrder.Status = Service.Db.StatusOrders.Find(_currentOrder.StatusId);
        Service.Db.Orders.Update(_currentOrder);
        Service.Db.SaveChanges();
        OnPropertyChanged();
    }

    public RelayCommand<Window> CloseWindow
    {
        get => new(window =>
        {
            window.Close();
            Application.Current.Windows[0].Show();
        });
    }
}