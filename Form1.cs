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
        public event Action<string>? OperatorPressed;
        public event Action<string>? SingleOperatorPressed;
        public event Action? ClearPressed;
        public event Action? CalculatePressed;

        public void UpdateView(string input)
        {
            textBox1.Text = input;
        }

        private void OnCEButtonClick(object sender, EventArgs e)
        {
            ClearPressed?.Invoke();
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
            SingleOperatorPressed?.Invoke("-1");
        }

        private void OnPlusButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke("+");
        }

        private void OnMinusButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke("-");
        }

        private void OnMultButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke("*");
        }

        private void OnDivideButtonClick(object sender, EventArgs e)
        {
            OperatorPressed?.Invoke("/");
        }

        private void OnSqrtButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke("√");
        }

        private void OnPercentButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke("%");
        }

        private void OnInverseButtonClick(object sender, EventArgs e)
        {
            SingleOperatorPressed?.Invoke("1/");
        }

        private void OnEqualButtonClick(object sender, EventArgs e)
        {
            CalculatePressed?.Invoke();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            
        }
    }
}