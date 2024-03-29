namespace calculator.Services;

public interface ICaculator
{
    string Calculate(string op1, string op2, string operation);
    string SingleOperation(string operand, string operation);
}