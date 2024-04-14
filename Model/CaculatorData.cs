using calculator.Common;

namespace calculator.Model;

public class CaculatorData
{
    public string? Input { get; set; }
    public Stack<double?> Values { get; set; } = new();
    public Stack<Operation> Operations { get; set; } = new();
}