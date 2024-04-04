using calculator.Common;
using calculator.View;

namespace calculator
{
    public partial class Form1 : Form, ICaculatorView
    {
        public Form1()
        {
            InitializeComponent();
        }

        public event Action<char>? OperandPressed;
        public event Action<Operation>? OperatorPressed;
        public event Action<Operation>? SingleOperatorPressed;
        public event Action<bool>? ClearPressed;
        public event Action? CalculatePressed;

        public void UpdateView(string input)
        {
            textBox1.Text = input;
        }

        private void OnCEButtonClick(object sender, EventArgs e)
        {
            ClearPressed?.Invoke(false);
        }

        private void CButtonClick(object sender, EventArgs e)
        {
            ClearPressed?.Invoke(true);
        }

        private void OnZeroButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('0');
        }

        private void OnOneButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('1');
        }

        private void OnTwoButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('2');
        }

        private void OnThreeButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('3');
        }

        private void OnFourButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('4');
        }

        private void OnFiveButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('5');
        }

        private void OnSixButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('6');
        }

        private void OnSevenButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('7');
        }

        private void OnEightButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('8');
        }

        private void OnNineButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('9');
        }

        private void OnDotButtonClick(object sender, EventArgs e)
        {
            OperandPressed?.Invoke('.');
        }

        private void OnNegativeButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Neg);
        }

        private void OnPlusButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.Add);
        }

        private void OnMinusButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.Sub);
        }

        private void OnMultButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.Mul);
        }

        private void OnDivideButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.Div);
        }

        private void OnSqrtButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Sqrt);
        }

        private void OnPercentButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Percent);
        }

        private void OnInverseButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.OneDiv);
        }

        private void OnSinhButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Sinh);
        }

        private void OnSinButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Sin);
        }

        private void OnCoshButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Cosh);
        }

        private void OnCosButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Cos);
        }

        private void OnTanhButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Tanh);
        }

        private void OnTanButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Tan);
        }

        private void OnSqrtYButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.SqrtY);
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            CalculatePressed?.Invoke();
        }

        private void OnFactorialButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Factorial);
        }

        private void OnModButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.Mod);
        }

        private void OnCubeRootButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.CubeRoot);
        }

        private void OnSquareButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Square);
        }

        private void OnPowYButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke(Operation.PowY);
        }

        private void OnCubeButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Cube);
        }

        private void OnLogButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Log);
        }

        private void OnInvButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Inv);
        }

        private void OnLnButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Ln);
        }

        private void OnExpButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Exp);
        }

        private void OnPiButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke(Operation.Pi);
        }

    }
}