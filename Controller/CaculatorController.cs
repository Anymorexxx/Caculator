using calculator.Common;
using calculator.Model;
using calculator.Services;
using calculator.View;
using System.Runtime.InteropServices;

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
        _view.ClearPressed += OnClearPressed;
        _view.CalculatePressed += OnCalculatePressed;
        _view.SingleOperatorPressed += OnSingleOperationPressed;
        _view.Constants += OnConstantsPressed;
        OnClearPressed(true);
    }

    private void OnSingleOperationPressed(Operation operation)
    {
        if (double.TryParse(_data.Input, out var value) == false)
        {
            if (_data.Values.Count > 0)
            {
                value = _data.Values.Pop()!.Value;
            }
            else { return; }
        }

        _data.Values.Push(_caculator.Calculate(operation, value));
        UpdateView(_data.Values.Peek()!.Value);
        _data.Input = null;
    }

    private void OnClearPressed(bool full)
    {
        Clear(full: full);
    }

    private void Calculate(bool fullAnswer = true)
    {
        if (_data.Operations.Count == 0)
            return;

        if (_data.Values.Count == 0)
            return;

        if (TryGetValueFromInput() == false)
            return;

        PerformCalculation(fullAnswer);

        UpdateView(_data.Values.Peek()!.Value);
    }

    private void OnCalculatePressed()
    {
        Calculate();
    }

    private void PerformCalculation(bool fullAnswer = true)
    {
        while (true)
        {
            while (_data.Operations.Count > 0 && _data.Operations.Peek() != Operation.OpenBracket)
            {
                var b = _data.Values.Pop();
                var a = _data.Values.Pop();
                _data.Values.Push(_caculator.Calculate(_data.Operations.Pop(), a!.Value, b!.Value));
            }

            if (_data.Operations.Count > 0 && _data.Operations.Peek() == Operation.OpenBracket && fullAnswer)
            {
                _data.Operations.Pop();
            }

            if (_data.Operations.Count > 0 && fullAnswer)
            {
                continue;
            }

            break;
        }
    }

    private void Clear(string value = "0", bool full = true)
    {
        if (full)
        {
            _data.Values.Clear();
            _data.Operations.Clear();
        }

        _data.Input = null;
        _view.UpdateView(value);
    }

    private void OnOperatorPressed(Operation operation)
    {
        if (_data.Operations.Count > 0)
        {
            if (operation == Operation.CloseBracket)
            {
                Calculate(false);
                return;
            }

            if (operation != Operation.OpenBracket && operation.IsLowerOrEqual(_data.Operations.Peek()))
            {
                Calculate(false);
            }
        }

        _data.Operations.Push(operation);

        TryGetValueFromInput();
    }

    private bool TryGetValueFromInput()
    {
        if (_data.Input is not null)
        {
            if (double.TryParse(_data.Input, out var value) == false)
            {
                return false;
            }

            _data.Values.Push(value);
        }

        _data.Input = null;
        return true;
    }

    private void OnOperandPressed(char obj)
    {
        if (_data.Operations.Count == 0 && _data.Input == null)
        {
            Clear(full: true);
        }

        _data.Input = _inputService.TryInput(_data.Input + obj);
        UpdateView(_data.Input);
    }

    private void UpdateView(double input)
    {
        _view.UpdateView(input.ToString("0.#####"));
    }

    private void UpdateView(string input)
    {
        _view.UpdateView(input);
    }

    private void OnConstantsPressed(Constants constants)
    {
        if (_data.Operations.Count == 0 && _data.Input == null)
        {
            Clear(full: true);
        }

        double output = 0;
        switch (constants)
        {
            case Constants.Pi:
                output = Math.PI;
                    break;
            case Constants.Exp:
                output = Math.E;
                    break;
        }
        _data.Input = output.ToString("0.#####");
        UpdateView(output);
    }
}

