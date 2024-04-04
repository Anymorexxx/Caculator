using calculator.Common;
using calculator.Model;
using calculator.Services;

namespace calculator.Commands;

public class CalculateCommand : ICommand
{
    private readonly ICaculator _caculator;
    private readonly CaculatorData _data;
    private readonly double? _b;
    private readonly Operation _operation;
    private double? _previousValue;

    public CalculateCommand(ICaculator caculator, CaculatorData data)
    {
        _caculator = caculator;
        _data = data;
        _operation = data.Operation.Value;
        
        if (double.TryParse(data.Input, out var b)) 
            _b = b;
    }

    public void Execute()
    {
        if (_data.Value is null)
            return;
        _previousValue = _data.Value;
        _data.Value = _caculator.Calculate(_operation, _data.Value.Value, _b);
        _data.Input = null;
    }

    public void Undo()
    {
        _data.Value = _previousValue;
    }
}