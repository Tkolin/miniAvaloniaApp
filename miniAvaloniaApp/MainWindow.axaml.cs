using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using miniAvaloniaApp.model;

namespace miniAvaloniaApp;

public partial class MainWindow : Window
{
    private List<Order> OrderListData { get; set; }
    private List<Order> OrderListView { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DownloadDataGrid();
    }
    public void DownloadDataGrid()
    {
        OrderListData = DataBaseManager.GetOrders();
        UpdateDataGrid();
    }

    private void UpdateDataGrid()
    {
        OrderListView = OrderListData; // Установка данных из базы в вид
        if (SearchBox.Text.Length >= 1) // Фильтрация
            OrderListView = OrderListView.Where(c =>
                c.ID.ToString().ToLower().Contains(SearchBox.Text.ToLower()) ||
                c.Soderjanie.ToLower().ToString().Contains(SearchBox.Text.ToLower()) ||
                c.Trebovania.ToLower().ToString().Contains(SearchBox.Text.ToLower()) ||
                c.Name.ToLower().ToString().Contains(SearchBox.Text.ToLower()))
            .ToList();
        DataGrid.ItemsSource = OrderListView;
    }

    private void SearchBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        UpdateDataGrid();
    }

    private void ResetBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        SearchBox.Text = "";
    }
}