using calculator.Commands;
using calculator.Common;
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
    private ICommand? _currentCommand;

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
        OnClearPressed(true);
    }

    private void OnSingleOperationPressed(Operation operation)
    {
        OnOperatorPressed(operation);
        _currentCommand = new CalculateCommand(_caculator, _data);
        OnCalculatePressed();
    }

    private void OnClearPressed(bool full)
    {
        Clear(full: full);
    }

    private void OnCalculatePressed()
    {
        if (_data.Operation is null)
            return;

        if (_data.Value is null)
            return;

        if (_data is not { Caculated: true, Input: null } || _currentCommand == null)
        {
            _currentCommand = new CalculateCommand(_caculator, _data);
        }
 
        _currentCommand?.Execute();
        _data.Caculated = true;
        UpdateView(_data.Value.Value);
    }

    private void Clear(string value = "0", bool full = true)
    {
        if (full)
        {
            _data.Value = null;
            _data.Operation = null;
        }
        
        _data.Caculated = false;
        _data.Input = null;
        _view.UpdateView(value);
    }

    private void OnOperatorPressed(Operation operation)
    {
        if (_data.Input == null && _data.Value == null)
            return;

        if (_data is { Caculated: false, Input: not null, Value: not null })
        {
            OnCalculatePressed();
        }

        _data.Operation = operation;

        if (_data.Input != null)
        {
            _data.Value = double.Parse(_data.Input);
        }

        _data.Input = null;
    }

    private void OnOperandPressed(char obj)
    {
        if (_data.Caculated)
        {
            Clear(full: false);
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
}