using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_8
{
    public partial class FinalWorkForm : Form
    {
        /// <summary>
        /// Строка для поиска
        /// </summary>
        public string searchString = String.Empty;

        /// <summary>
        /// Кнопка поиска нажата
        /// </summary>
        public bool isSelected = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FinalWorkForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Чекбокс экзамена
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void examBox_CheckedChanged(object sender, EventArgs e)
        {
            if (creditBox.Checked && examBox.Checked)
            {
                creditBox.Checked = false;
            }
        }

        /// <summary>
        /// Обработчик поиска
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void find_Click(object sender, EventArgs e)
        {
            searchString = examBox.Checked ? "0,5" : "0,35";
            isSelected = true;
            Close();
        }

        /// <summary>
        /// Обработчик события
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Чекбокс зачета
        /// </summary>
        /// <param name="sender">Обработчик события</param>
        /// <param name="e">Событие</param>
        private void creditBox_CheckedChanged(object sender, EventArgs e)
        {
            if (examBox.Checked && creditBox.Checked)
            {
                examBox.Checked = false;
            }
        }
    }
}
