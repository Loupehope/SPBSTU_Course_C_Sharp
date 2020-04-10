using System;
using System.Windows.Forms;

namespace SuperCalculator
{
    public partial class Calculator : Form
    {
        /// <summary>
        /// Флаг того, что кнопка оператора была нажата
        /// </summary>
        private bool isOperatorTapped;

        /// <summary>
        /// Флаг заполнения второго операнда
        /// </summary>
        private bool isSecondValue = false;

        /// <summary>
        /// Переменная для хранения знака оператора
        /// </summary>
        private string operatorString;

        /// <summary>
        /// Переменная для хранения результата вычисления
        /// </summary>
        private Double result;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public Calculator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            clearState();
        }

        /// <summary>
        /// Обработчик отрисовки таблицы-разметки
        /// </summary>
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            inputTextBox.SelectionLength = 0;
        }

        /// <summary>
        /// Обработчик нажатий на кнопки операндов 0 1 2 3 4 5 6 7 8 9
        /// </summary>
        /// <param name="sender"> Отправитель события </param>
        /// <param name="e"> Событие </param>
        private void operand_Click(object sender, EventArgs e)
        {
            if (inputTextBox.Text.Equals("0") || isOperatorTapped)
            {
                inputTextBox.Text = String.Empty;
            }

            if (isOperatorTapped)
            {
                isOperatorTapped = false;
                isSecondValue = true;
            }

            Button button = (Button)sender;
            inputTextBox.Text += button.Text;

            if (!isSecondValue)
            {
                result = Double.Parse(inputTextBox.Text.Replace(".", ","));
            }
        }

        /// <summary>
        /// Обработчик нажатий на кнопки операций + - / *
        /// </summary>
        /// <param name="sender"> Отправитель события </param>
        /// <param name="e"> Событие </param>
        private void operator_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(operatorString) && isSecondValue)
            {
                performCalculation();
            } 

            Button button = (Button)sender;
            operatorString = button.Text;

            isOperatorTapped = true;
        }

        /// <summary>
        /// Обработчик нажатий на кнопку отчистить - обнуляет переменные и поле ввода
        /// </summary>
        /// <param name="sender"> Отправитель события </param>
        /// <param name="e"> Событие </param>
        private void clear_Click(object sender, EventArgs e)
        {
            clearState();
        }

        /// <summary>
        /// Обработчик нажатий на кнопку точки - добавляет в поле ввода точку
        /// </summary>
        /// <param name="sender"> Отправитель события </param>
        /// <param name="e"> Событие </param>
        private void dot_Click(object sender, EventArgs e)
        {
            if (!hasDot() && !Double.IsInfinity(result))
            {
                Button button = (Button)sender;
                inputTextBox.Text += ".";
            }

            if (isOperatorTapped)
            {
                inputTextBox.Text = "0.";
                isOperatorTapped = false;
                isSecondValue = true;
            }
        }

        /// <summary>
        /// Проверяет наличие точки в поле ввода
        /// </summary>
        /// <returns>Bool - есть ли точка в вырежении в поле ввода</returns>
        private bool hasDot()
        {
            return inputTextBox.Text.Contains(".");
        }

        /// <summary>
        /// Обработчик нажатий на кнопку вычислить - вычисляет выражение и ввыводит его на экран
        /// </summary>
        /// <param name="sender"> Отправитель события </param>
        /// <param name="e"> Событие </param>
        private void equal_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(operatorString) && isSecondValue)
            {
                performCalculation();
            }
            operatorString = String.Empty;
        }

        /// <summary>
        /// Обработчик нажатий с клавиатуры в поле ввода
        /// </summary>
        /// <param name="sender"> Отправитель события </param>
        /// <param name="e"> Событие </param>
        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char symbol = e.KeyChar;

            if (hasDot() && symbol == 46)
            {
                e.Handled = true;
            }

            if ((inputTextBox.Text.Length == 1 || inputTextBox.Text.Length == 2 && inputTextBox.Text == "-") 
                && symbol == 8)
            {
                inputTextBox.Text = "0";

                if (!isOperatorTapped)
                {
                    result = 0;
                }

                e.Handled = true;
            }
            else if (symbol == 8 && !isOperatorTapped)
            {
                result = Double.Parse(inputTextBox.Text.Substring(0, inputTextBox.Text.Length - 1).Replace(".", ","));
            }
            else if (symbol == 8 && isOperatorTapped)
            {
                isOperatorTapped = false;
                isSecondValue = true;
            }

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                if (inputTextBox.Text.Equals("0") || isOperatorTapped)
                {
                    inputTextBox.Text = String.Empty;
                }

                if (isOperatorTapped)
                {
                    isOperatorTapped = false;
                    isSecondValue = true;
                }

                if (!isSecondValue)
                {
                    result = Double.Parse((inputTextBox.Text + symbol).Replace(".", ","));
                }
            }

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && symbol != 8 && symbol != 46)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Производит вычисдение выражение и обновление свойств переменных
        /// </summary>
        private void performCalculation()
        {
            result = Math.Round(calculate(), 6);
            Clipboard.SetData(DataFormats.Text, (Object)result.ToString());

            inputTextBox.Text = result.ToString().Replace(",", ".");
            isSecondValue = false;
        }

        /// <summary>
        /// Вычисление выражения
        /// </summary>
        /// <returns>Double - результат вычисления</returns>
        private Double calculate()
        {
            double rightValue = Double.Parse(inputTextBox.Text.Replace(".", ","));

            switch (operatorString)
            {
                case "+":
                    result += rightValue;
                    break;
                case "-":
                    result -= rightValue;
                    break;
                case "/":
                    result /= rightValue;
                    break;
                case "*":
                    result *= rightValue;
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// Обнуляет переменные и поле ввода
        /// </summary>
        private void clearState()
        {
            result = 0;
            operatorString = String.Empty;
            inputTextBox.Text = "0";
            isOperatorTapped = false;
            isSecondValue = false;
        }
    }
}
