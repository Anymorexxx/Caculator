using calculator.Common;

namespace calculator.View;

public interface ICaculatorView
{
    public event Action<char> OperandPressed;
    public event Action<Operation> OperatorPressed;
    public event Action<bool> ClearPressed;
    public event Action CalculatePressed;
    public event Action<Operation> SingleOperatorPressed;
    public void UpdateView(string input);
}