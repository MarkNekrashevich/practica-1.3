using System;
using System.Windows.Forms;

namespace practica_1._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double v = 0.001; // заданное значение v
                double pi = Math.PI;

                label1.Text = ""; // Очищаем текст в label1

                double x1 = 5;
                double x2 = 2 * pi / 3;
                double x3 = pi / 6;

                if (double.TryParse(textBox1.Text, out double x))
                {
                    double f = CalculateF(x, pi, v);
                    label1.Text += $"Значение функции F({x}) равно {f:F4}\n";
                }
                else
                {
                    double f1 = CalculateF(x1, pi, v);
                    double f2 = CalculateF(x2, pi, v);
                    double f3 = CalculateF(x3, pi, v);

                    label1.Text += $"Значение функции F({x1}) равно {f1:F4}\n";
                    label1.Text += $"Значение функции F({x2}) равно {f2:F4}\n";
                    label1.Text += $"Значение функции F({x3}) равно {f3:F4}\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalculateF(double x, double pi, double v)
        {
            double f = 0; // Начальное значение функции F(x)

            double currentTerm;
            int n = 1; // Номер текущего члена ряда

            do
            {
                currentTerm = Math.Sin((2 * n - 1) * x) / ((2 * n - 1) * (2 * n - 1) * (2 * n - 1));
                f += currentTerm;
                n++;
            } while (Math.Abs(currentTerm) >= v);

            return f * 18 / pi + Math.Sin(x); // Вычисление значения функции F(x)
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
