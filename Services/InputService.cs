namespace calculator.Services
{
    internal class InputService : IInputService
    {
        public string TryInput(string input)
        {
            //если есть знак "бесконечность" - не даёт писать цифры после него
            if (input.Contains('∞'))
            {
                input = input[..^1];
            }

            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (input[0] == '0' && (input.IndexOf(".", StringComparison.Ordinal) != 1))
            {
                input = input.Remove(0, 1);
            }

            return input;
        }

    }
}
