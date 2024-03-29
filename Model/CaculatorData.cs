namespace calculator.Model;

public class CaculatorData
{
    public Stack<string> Operands { get; set; } = new();
    public string? Operation { get; set; }
    public string? SingleOperation { get; set; }
    public bool Caculated { get; set; }
    public string? LastOperand { get; set; }
}