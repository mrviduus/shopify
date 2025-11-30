using System.Text.Json;
using System.Text.RegularExpressions;

namespace App;
//claude --dangerously-skip-permissions

public class Program
{
    public static void Main(string[] args)
    {
        var json = File.ReadAllText("input.json");
        // var models = JsonSerializer.Deserialize<List<Model>>(json);
    }
}
