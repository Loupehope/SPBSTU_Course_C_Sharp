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
    public partial class IsCourseWorkForm : Form
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
        public IsCourseWorkForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик поиска
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void find_Click(object sender, EventArgs e)
        {
            searchString = isCourseBox.Checked ? "true" : "false";
            isSelected = true;
            Close();
        }

        /// <summary>
        /// Обработчик отмены
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
