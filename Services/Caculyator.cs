using calculator.Common;

namespace calculator.Services
{
    internal class Caculyator : ICaculator
    {
        public double Calculate(Operation operation, double a, double? b = null)
        {
            return b is null
                ? ApplyOperator(operation, a)
                : ApplyOperator(operation, a, b.Value);
        }

        private static double ApplyOperator(Operation token, double a, double b)
        {
            switch (token)
            {
                case Operation.Add:
                    return a + b;
                case Operation.Sub:
                    return a - b;
                case Operation.Mul:
                    return a * b;
                case Operation.Div:
                    return a / b;
                case Operation.Pow:
                    return Math.Pow(a, b);
                case Operation.SqrtY:
                    return Math.Pow(a, 1 / b);
                case Operation.PowY:
                    return Math.Pow(a, b);
                case Operation.Mod:
                    return a % b;
                default:
                    throw new ArgumentException($"Invalid operator: {token}");
            }
        }

        private static double Factorial(double n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }

        private static double ApplyOperator(Operation token, double a)
        {
            switch (token)
            {
                case Operation.OneDiv:
                    return 1 / a;
                case Operation.Sqrt:
                    return Math.Sqrt(a);
                case Operation.Percent:
                    return a / 100;
                case Operation.Neg:
                    return a * -1;
                case Operation.Sinh:
                    return Math.Sinh(a);
                case Operation.Sin:
                    return Math.Sin(a);
                case Operation.Cosh:
                    return Math.Cosh(a);
                case Operation.Cos:
                    return Math.Cos(a);
                case Operation.Tanh:
                    return Math.Tanh(a);
                case Operation.Tan:
                    return Math.Tan(a);
                case Operation.Factorial:
                    return Factorial(a);
                case Operation.Square:
                    return Math.Pow(a, 2);
                case Operation.Cube:
                    return Math.Pow(a, 3);
                case Operation.CubeRoot:
                    return Math.Pow(a, 1 / 3);
                case Operation.Log:
                    return Math.Log10(a);
                case Operation.Ln:
                    return Math.Log(a);
                case Operation.Exp:
                    return Math.Exp(a);
                case Operation.Inv:
                    return 1 / a;
                case Operation.Pi:
                    return Math.PI;
                default:
                    throw new ArgumentException($"Invalid operator: {token}");
            }
        }
    }
}