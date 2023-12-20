using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using miniAvaloniaApp.model;

namespace miniAvaloniaApp;

public partial class MainWindow : Window
{
// Списки для хранения и вывода данных
    private List<Order> OrderListData { get; set; } // Хранения (Data)
    private List<Order> OrderListView { get; set; } // Вывод (View)
    
    public MainWindow()
    {
        InitializeComponent();
        DownloadDataGrid(); 
    }


    // Метод обновления СПИСКА ДАННЫХ ИЗ БАЗЫ
    public void DownloadDataGrid()
    {
        OrderListData = DataBaseManager.GetOrders();
        UpdateDataGrid();
    }

    // Метод отображения И фильтрации таблицы
    private void UpdateDataGrid()
    {
        OrderListView = OrderListData; // Установка данных ИЗ СПИСКА ХРАНЕНИЯ В СПИСОК ОТОБРАЖЕНИЯ
        if (SearchBox.Text.Length >= 1) // Фильтрация
            OrderListView = OrderListView.Where(c =>
                c.ID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) || // Поиск по ID
                c.Soderjanie.ToLower().ToString().Contains(SearchBox.Text.ToLower()) || // Поиск по содержанию
                c.Trebovania.ToLower().ToString().Contains(SearchBox.Text.ToLower()) ||
                c.Name.ToLower().ToString().Contains(SearchBox.Text.ToLower()))
            .ToList();
        DataGrid.ItemsSource = OrderListView;// Вывод таблицы
    }

    // Событие ввода текста в поле поиска
    private void SearchBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateDataGrid();
    }

    // Сброс поля поиска
    private void ResetBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        SearchBox.Text = "";
    }
}
