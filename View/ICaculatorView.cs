namespace calculator.View;

public interface ICaculatorView
{
    public event Action<char> OperandPressed;
    public event Action<string> OperatorPressed;
    public event Action<string> SingleOperatorPressed;
    public event Action ClearPressed;
    public event Action CalculatePressed;
    public void UpdateView(string input);
}