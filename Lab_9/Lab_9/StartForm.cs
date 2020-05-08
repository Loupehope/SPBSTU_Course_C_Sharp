using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_9
{
    public partial class StartForm : Form
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public StartForm()
        {
            InitializeComponent();

            for (int i = 1; i < 20; i *= 2)
                threadCountBox.Items.Add(i.ToString());
            threadCountBox.Items.Add("20");

            for (int i = 10; i < 5000; i *= 5)
                sleepTimeBox.Items.Add(i.ToString());

            threadCountBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sleepTimeBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Обработчик старта эксперимента
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void start_Click(object sender, EventArgs e)
        {
            ExperimentConfiguration config;

            if (radius.Text.All(Char.IsDigit) && threadCountBox.Text.All(Char.IsDigit) && sleepTimeBox.Text.All(Char.IsDigit) &&
                !String.IsNullOrEmpty(radius.Text) && !String.IsNullOrEmpty(radius.Text) && !String.IsNullOrEmpty(radius.Text))
            {
                if (int.Parse(radius.Text) < 25 || int.Parse(radius.Text) > 300)
                {
                    MessageBox.Show("Радиус должен быть от 25 до 300", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    config = new ExperimentConfiguration(int.Parse(radius.Text), int.Parse(threadCountBox.Text), int.Parse(sleepTimeBox.Text));
                    ExperimentForm dialog = new ExperimentForm(config);
                    dialog.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            config = null;
        }
    }
}
