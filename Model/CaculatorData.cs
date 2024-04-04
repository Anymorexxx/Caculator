using calculator.Common;

namespace calculator.Model;

public class CaculatorData
{
    public string? Input { get; set; }
    public double? Value { get; set; }
    public Operation? Operation { get; set; }
    public bool Caculated { get; set; }
}