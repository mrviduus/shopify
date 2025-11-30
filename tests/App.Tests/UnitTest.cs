using System.Text.Json;
using Xunit;
using App;

namespace App.Tests;

public class UnitTest
{
    [Fact]
    public void Deserialize_Orders_ReturnsCorrectCount()
    {
        var json = """
        [
          { "Id": "1", "Customer": "Alice", "Items": [{ "Sku": "A", "Quantity": 2 }] },
          { "Id": "2", "Customer": "Bob", "Items": [] }
        ]
        """;

        var orders = JsonSerializer.Deserialize<List<Order>>(json);

        Assert.Equal(2, orders!.Count);
    }

    [Fact]
    public void Deserialize_Order_ParsesFields()
    {
        var json = """[{ "Id": "ORD-1", "Customer": "Alice", "Items": [{ "Sku": "SKU-A", "Quantity": 3 }] }]""";

        var orders = JsonSerializer.Deserialize<List<Order>>(json);
        var order = orders![0];

        Assert.Equal("ORD-1", order.Id);
        Assert.Equal("Alice", order.Customer);
        Assert.Single(order.Items);
        Assert.Equal("SKU-A", order.Items[0].Sku);
        Assert.Equal(3, order.Items[0].Quantity);
    }
}
