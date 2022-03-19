using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Toolkit.Mvvm.Input;
using WOInterface.Core;
using WOInterface.MVVM.Model;
using WOInterface.MVVM.View.NewWindows;

namespace WOInterface.MVVM.ViewModel;

public class CookWindowViewModel : BaseViewModel
{
    private ObservableCollection<Position> _positionsGrid;

    public ObservableCollection<Position> PositionsGrid
    {
        get => _positionsGrid;
        set
        {
            _positionsGrid = value;
            OnPropertyChanged();
        }
    }

    public CookWindowViewModel()
    {
        PositionsGrid = new ObservableCollection<Position>(Service.Db.Positions.Where(p => p.StatusId == 1)
            .Include(x => x.Dish));
    }

    public RelayCommand UpdateCommand
    {
        get => new RelayCommand(() =>
        {
            PositionsGrid = new ObservableCollection<Position>(Service.Db.Positions.Where(p => p.StatusId == 1)
                .Include(x => x.Dish));
        });
    }

    public RelayCommand<Window> ExitCommand
    {
        get => new RelayCommand<Window>(w =>
        {
            {
                MessageBoxResult result =
                    CustomMessageBox.Show("Выход", "Выберите способ выхода", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MainWindowViewModel.CloseApplication();
                        break;
                    case MessageBoxResult.No:
                        Exit(w);
                        break;
                }
            }
        });
    }

    private void Exit(Window o)
    {
        var mainWindow = new MainWindow();
        o.Close();
        mainWindow.Show();
    }

    public Position UpdatePosition
    {
        get => null;
        set
        {
            UpdateSelectedPosition(value);
            OnPropertyChanged();
        }
    }

    private void UpdateSelectedPosition(Position value)
    {
        MessageBoxResult result =
            CustomMessageBox.Show("Готово?", $"Выбранное блюдо готово?", MessageBoxButton.YesNo);
        switch (result)
        {
            case MessageBoxResult.Yes:
                value.StatusId = 2;
                Service.Db.Update(value);
                Service.Db.SaveChanges();
                PositionsGrid.Remove(value);
                break;
            case MessageBoxResult.No:
                return;
        }
    }
}