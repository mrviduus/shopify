using System.Text.Json;

namespace App;
//claude --dangerously-skip-permissions
public record Order(string Id, string Customer, List<Item> Items);
public record Item(string Sku, int Quantity);


public class Program
{
    public static async Task Main(string[] args)
    {
        var json = await File.ReadAllTextAsync("input.json");
        var orders = JsonSerializer.Deserialize<List<Order>>(json);

        foreach (var order in orders!)
        {
            Console.WriteLine($"Order {order.Id}: {order.Customer}, {order.Items.Count} items");
        }
    }
}
