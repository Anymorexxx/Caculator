namespace calculator.Common;

public static class CalculatorExtensions
{
    public static int Precedence(this Operation op)
    {
        switch (op)
        {
            case Operation.Add:
            case Operation.Sub:
                return 1;
            case Operation.Mul:
            case Operation.Div: 
            case Operation.Factorial:
                return 2;
            case Operation.PowY:
            case Operation.SqrtY:
                return 3;
            case Operation.Cube:
            case Operation.Pow:
            case Operation.Sqrt:
            case Operation.CubeRoot:
            case Operation.Square:
            case Operation.Log:
            case Operation.Ln:
            case Operation.Inv:
            case Operation.OneDiv:
            case Operation.Mod:
            case Operation.Neg:
            case Operation.Percent:
            case Operation.Sinh:
            case Operation.Sin:
            case Operation.Cosh:
            case Operation.Cos:
            case Operation.Tanh:
            case Operation.Tan:
                return 4;
            default:
            case Operation.OpenBracket:
            case Operation.CloseBracket:
                return 0;
        }
    }

    public static bool IsBigger(this Operation a, Operation b)
    {
        return Precedence(a) > Precedence(b);
    }
    
    public static bool IsLowerOrEqual(this Operation a, Operation b)
    {
        return Precedence(a) <= Precedence(b);
    }
}