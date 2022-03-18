using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;
using WOInterface.MVVM.View.NewWindows;
using WOInterface.Properties;

namespace WOInterface.MVVM.ViewModel;

public class CreateOrderWindowViewModel : BaseViewModel
{
    public Order? Order { get; set; }

    #region [ДатаГриды]

    private ObservableCollection<Dish> _dishesInOrder = new(); // Правый датагрид
    public ObservableCollection<Dish> Dishes { get; set; } // Левый датагрид

    public CreateOrderWindowViewModel() // К-тор ViewModel'и где заполняем левый датагрид 
    {
        Dishes = new ObservableCollection<Dish>(Service.Db.Dishes.ToList());
    }

    public ObservableCollection<Dish> DishesInOrder // Свойство заполнения
    {
        get => _dishesInOrder;
        set
        {
            _dishesInOrder = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region [Кнопка отмены заказа]

    public RelayCommand<Window> CancelCommand => new(ReturnToMain); // Вызов метода закрытия окна

    private void ReturnToMain(Window window)
    {
        window.Close(); // Закрытие текущего окна
        Application.Current.Windows[0]?.Show(); // Открытие окна Официанта
    }

    #endregion

    #region [Добавление и удаления блюд в DataGrid]

    public Dish AddDish // Свойство перемещения из левого в правый
    {
        get => null;
        set
        {
            AddDishInOrder(value);
            OnPropertyChanged();
        }
    }

    public Dish RemoveDish // Свойство перемещения из правого в левый
    {
        get => null;
        set
        {
            RemoveDishInOrder(value);
            OnPropertyChanged();
        }
    }

    private void AddDishInOrder(Dish dish) // Метод перемещения в правый
    {
        InputBox inputBox = new(); // Кастомный ИнпутБокс
        inputBox.ShowDialog();
        dish.Count = inputBox.GetCount(); // Забираем число из ИнпутБокса
        DishesInOrder.Add(dish);
        Dishes.Remove(dish);
    }

    private void RemoveDishInOrder(Dish dish) // Метод перемещения в левый
    {
        DishesInOrder.Remove(dish);
        Dishes.Add(dish);
    }

    #endregion

    #region [Сохранение заказа]

    public MessageBoxResult CreateResult { get; set; }

    public RelayCommand<Window> CreateOrderCommand =>
        new(o =>
        {
            CreateOrder();
            if (CreateResult == MessageBoxResult.OK) ReturnToMain(o);
        });

    private void CreateOrder()
    {
        if (DishesInOrder.Count == 0)
        {
            CustomMessageBox.Show("Ошибка", "Невозможно создать заказ.\nСписок пуст", MessageBoxButton.OK);
            return;
        }

        Order = new Order
        {
            CreationDateTime = DateTime.Now,
            UserId = Settings.Default.UserId,
            StatusId = 1
        };
        Service.Db.Orders.Add(Order);
        Service.Db.SaveChanges();
        var dishesList = DishesInOrder.ToList();
        for (var i = 0; i < dishesList.Count; i++)
        {
            var position = new Position
            {
                OrderId = Order.Id,
                DishId = dishesList[i].Id,
                Count = dishesList[i].Count,
                StatusId = 1
            };
            Service.Db.Positions.Add(position);
            Service.Db.SaveChanges();
        }

        CreateResult = CustomMessageBox.Show("Успешно", $"Успешно сохранено\nНомер заказ - {Order.Id}", MessageBoxButton.OK);
    }

    #endregion
}