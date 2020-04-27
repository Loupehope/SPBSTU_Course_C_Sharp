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
    public partial class FilterForm : Form
    {
        /// <summary>
        /// Строка поиска
        /// </summary>
        public string searchString = String.Empty;

        /// <summary>
        /// Кнопка поиска нажата
        /// </summary>
        public bool isSearch = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        public FilterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки сохранить
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void save_Click(object sender, EventArgs e)
        {
            searchString = searchBox.Text;
            isSearch = true;
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
