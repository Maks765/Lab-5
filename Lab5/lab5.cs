using System;
using System.Windows.Forms;

namespace YourNamespace
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення та відображення форми для введення числа
            Application.Run(new NumberInputForm());
        }
    }

    class NumberInputForm : Form
    {
        private TextBox textBox;
        private Button button;

        public NumberInputForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(50, 50);
            textBox.Size = new System.Drawing.Size(100, 20);

            button = new Button();
            button.Location = new System.Drawing.Point(50, 100);
            button.Size = new System.Drawing.Size(100, 30);
            button.Text = "Ввести";
            button.Click += Button_Click;

            Controls.Add(textBox);
            Controls.Add(button);

            Text = "Введення числа";
            Size = new System.Drawing.Size(200, 200);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int k;
            if (!int.TryParse(textBox.Text, out k) || k < 100 || k > 999)
            {
                MessageBox.Show("Введіть коректне трьохзначне число!");
                return;
            }

            int leftDigit = k / 100;
            int middleDigit = (k / 10) % 10;
            int rightDigit = k % 10;

            char C2 = Convert.ToChar('0' + leftDigit);
            char C1 = Convert.ToChar('0' + middleDigit);
            char C0 = Convert.ToChar('0' + rightDigit);

            MessageBox.Show($"Ліва цифра: {C2}\n" +
                            $"Середня цифра: {C1}\n" +
                            $"Права цифра: {C0}");
        }
    }
}
