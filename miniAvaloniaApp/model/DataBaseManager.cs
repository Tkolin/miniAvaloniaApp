using System.Collections.Generic;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using MySqlConnector;

namespace miniAvaloniaApp.model;

public class DataBaseManager
{
    /// Настройки подключения
    public static MySqlConnectionStringBuilder ConnectionString =
        new MySqlConnectionStringBuilder
        {
            Server = "localhost",
            Database = "minidb",
            UserID = "root",
            Password = "tkl909" // "tkl909"//"nrjkby99"
        };
   // Получение списка заказов ИЗ БАЗЫ
    public static List<Order> GetOrders()
    {
        List<Order> data = new List<Order>(); // Список данных для вывода

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString)) // Создание переменной подключения
        {
            connection.Open();// Подключение к базе

            using (var comand = connection.CreateCommand()) // Создание переменной команды SQL
            {
                comand.CommandText = "SELECT * FROM заказ";// Запрос на получения таблицы ЗАКАЗ

                using (var reader = comand.ExecuteReader())// Выполнение запроса в переменную reader
                {
                    while (reader.Read())// Чтение каждой полученной строки
                    {
                        // Добавление в список заказов
                        data.Add(
                            // Конструктор заказа ->
                            new Order(
                                reader.GetInt32("ID"),
                                reader.GetString("Требование"),
                                reader.GetString("Содержание"),
                                reader.GetString("Название")));
                    }
                }
            }
            connection.Close(); // Закрытие подключения к базе
        }
        return data; // Возвращение заполненого списка
    }

}
