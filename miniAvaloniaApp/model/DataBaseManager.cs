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
   // Получение списка заказов
    public static List<Order> GetOrders()
    {
        List<Order> data = new List<Order>();

        using (var connection = new MySqlConnection(ConnectionString.ConnectionString))
        {
            connection.Open();

            using (var comand = connection.CreateCommand())
            {
                comand.CommandText = "SELECT * FROM заказ";

                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        data.Add(
                            new Order(
                                reader.GetInt32("ID"),
                                reader.GetString("Требование"),
                                reader.GetString("Содержание"),
                                reader.GetString("Название")));
                    }
                }
            }
            connection.Close();
        }
        return data;
    }

}