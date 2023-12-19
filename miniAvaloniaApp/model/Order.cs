namespace miniAvaloniaApp.model;

public class Order
{
    public int ID { get; set; }
    public string Trebovania { get; set; }
    public string Soderjanie { get; set; }
    public string Name { get; set; }
   
    public Order(){}

    public Order(int id, string trebovania, string soderjanie, string name)
    {
        ID = id;
        Trebovania = trebovania;
        Soderjanie = soderjanie;
        Name = name;

    }
}