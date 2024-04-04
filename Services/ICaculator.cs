using calculator.Common;

namespace calculator.Services;

public interface ICaculator
{
    double Calculate(Operation operation, double a, double? b = null);
}