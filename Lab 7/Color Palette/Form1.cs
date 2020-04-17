using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Palette
{
    public partial class ColorPicker : Form
    {
        /// <summary>
        /// Подсказка
        /// </summary>
        ToolTip toolTip = new ToolTip();

        /// <summary>
        /// Цвет, выбранный в данный момент
        /// </summary>
        Color currentColor;

        /// <summary>
        /// Код цвета, выбранного в данный момент
        /// </summary>
        string currentHexCode
        {
            get
            {
                return "#" + currentColor.R.ToString("X2")
                    + currentColor.G.ToString("X2") 
                    + currentColor.B.ToString("X2");
            }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ColorPicker()
        {
            InitializeComponent();
            onColorChanged(null, null);
        }

        /// <summary>
        /// Обработчик события изменения значений 
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void onColorChanged(object sender, EventArgs e)
        {
            currentColor = Color.FromArgb(redBar.Value, greenBar.Value, blueBar.Value);
            context.BackColor = currentColor;
            Clipboard.SetText(currentHexCode);
        }

        /// <summary>
        /// Обработчик события попадания курсора на холст
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void context_MouseMove(object sender, MouseEventArgs e)
        {
            toolTip.SetToolTip(context, currentHexCode);
        }
    }
}
