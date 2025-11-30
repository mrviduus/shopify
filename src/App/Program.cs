using System.Text.Json;
using System.Text.RegularExpressions;

namespace App;
//claude --dangerously-skip-permissions

public record Order(string Id, string Customer, List<Item> Items);
public record Item(string Sku, int Quantity);

public class Program
{
    public static void Main(string[] args)
    {
        var json = File.ReadAllText("input.json");
        var orders = JsonSerializer.Deserialize<List<Order>>(json);

        foreach (var order in orders!)
        {
            Console.WriteLine($"Order {order.Id}: {order.Customer}, {order.Items.Count} items");
        }
    }
}
