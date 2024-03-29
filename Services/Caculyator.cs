using System.Globalization;

namespace calculator.Services
{
    internal class Caculyator : ICaculator
    {
        public string Calculate(string n, string m, string operation)
        {
            if (double.TryParse(n, out var numberone) == false)
                return string.Empty;
            if (double.TryParse(m, out var numbertwo) == false)
                return string.Empty;

            return ApplyOperator(operation, numberone, numbertwo).ToString("0.#####");
        }

        public string SingleOperation(string operand, string operation)
        {
            if (double.TryParse(operand, out var numberone) == false)
                return string.Empty;
            return ApplyOperator(operation, numberone).ToString("0.#####");
        }

        private static double ApplyOperator(string token, double operand1, double operand2)
        {
            switch (token)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                case "^":
                    return Math.Pow(operand1, operand2);
                default:
                    throw new ArgumentException($"Invalid operator: {token}");
            }
        }

        private static double ApplyOperator(string token, double operand1)
        {
            switch (token)
            {
                case "1/":
                    return 1 / operand1;
                case "√":
                    return Math.Sqrt(operand1);
                case "%":
                    return operand1 / 100;
                case "-1":
                    return operand1 * -1;
                default:
                    throw new ArgumentException($"Invalid operator: {token}");
            }
        }
    }
}