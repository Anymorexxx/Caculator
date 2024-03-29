using calculator.Model;
using calculator.Services;
using calculator.View;

namespace calculator.Controller;

public class CaculatorController
{
    private readonly ICaculator _caculator;
    private readonly IInputService _inputService;
    private readonly ICaculatorView _view;
    private readonly CaculatorData _data;

    public CaculatorController(ICaculator caculator, IInputService inputService, ICaculatorView view,
        CaculatorData data)
    {
        _caculator = caculator;
        _inputService = inputService;
        _view = view;
        _data = data;

        _view.OperandPressed += OnOperandPressed;
        _view.OperatorPressed += OnOperatorPressed;
        _view.ClearPressed += OnFullClearPressed;
        _view.CalculatePressed += OnCalculatePressed;
        _view.SingleOperatorPressed += OnSingleOperationPressed;
        OnFullClearPressed();
    }

    private void OnSingleOperationPressed(string obj)
    {
        _data.Operation = null;
        if (_data.Operands.Count == 2 && _data.Caculated == false)
        {
            OnCalculatePressed();
        }

        _data.Caculated = true;
        _data.SingleOperation = obj;
        var operand = _data.Operands.Pop();
        _data.Operands.Push(_caculator.SingleOperation(operand, obj));
        _view.UpdateView(_data.Operands.Peek());
    }

    private void OnFullClearPressed()
    {
        Clear();
    }

    private void OnCalculatePressed()
    {
        if (_data.Operation is null)
            return;

        if (_data.SingleOperation is not null)
        {
            var singleOperand = _data.Operands.Pop();
            _data.Operands.Push(_caculator.SingleOperation(singleOperand, _data.SingleOperation));
            _view.UpdateView(_data.Operands.Peek());
            return;
        }

        if (_data.Operands.Count < 2)
        {
            var (lastOperand, lastOperation) = (_data.LastOperand, _data.Operation);
            if (lastOperand is not null && lastOperation is not null)
            {
                Calculate(_data.Operands.Pop(), lastOperand, lastOperation);
            }
            return;
        }

        var operand = _data.Operands.Pop();
        var operand2 = _data.Operands.Pop();
        Calculate(operand2, operand, _data.Operation);
    }

    private void Calculate(string operand1, string operand2, string operation)
    {
        _data.Caculated = true;
        _data.LastOperand = operand2;
        _data.Operands.Push(_caculator.Calculate(operand1, operand2, operation));
        _view.UpdateView(_data.Operands.Peek());
    }

    private void Clear(string value = "0", bool full = true)
    {
        if (full)
        {
            _data.Operands.Clear();
            _data.Operation = null;
            _data.SingleOperation = null;
        }
        else
        {
            _data.Operands.TryPop(out _);
        }
      
        _data.Caculated = false;
        _data.LastOperand = null;
        _data.Operands.Push(value);
        _view.UpdateView(_data.Operands.Peek());
    }

    private void OnOperatorPressed(string operation)
    {
        _data.SingleOperation = null;
        if (_data.LastOperand is not null && _data.Caculated == false)
        {
            OnCalculatePressed();
        }

        _data.Operation = operation;
    }

    private void OnOperandPressed(char obj)
    {

        if (_data is { Operands.Count: 1, Operation: not null })
        {
            _data.Operands.Push("0");
        }
        else if (_data is { Caculated: true })
        {
            Clear();
        }

        var operand = _data.Operands.Pop();


        _data.Operands.Push(_inputService.TryInput(operand + obj));
        _view.UpdateView(_data.Operands.Peek());
    }
}