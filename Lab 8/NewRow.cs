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
    public partial class NewRow : Form
    {
        /// <summary>
        /// Новая запись
        /// </summary>
        public UniversityData data = null;

        /// <summary>
        /// Кнопка сохранить нажата
        /// </summary>
        public bool isSave = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        public NewRow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Кнопка отменить нажата
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
        /// Чекбокс зачета
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void finalWork_CheckedChanged(object sender, EventArgs e)
        {
            if (examBox.Checked && creditBox.Checked)
            {
                examBox.Checked = false;
            }
        }

        /// <summary>
        /// Кнопка сохранить нажата
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (subjectIdBox.Text.All(Char.IsDigit) && subjectNameBox.Text.All(c => Char.IsLetter(c)
                    || c == '(' || c == ')'|| c == ' ' || c == '-')
                    && teacherBox.Text.All(Char.IsLetter) && countBox.Text.All(Char.IsDigit)
                    && groupIdBox.Text.All(c => Char.IsDigit(c) || c == '/')
                    && lectureBox.Text.All(Char.IsDigit) && practicBox.Text.All(Char.IsDigit) 
                    && !String.IsNullOrEmpty(subjectIdBox.Text) && !String.IsNullOrEmpty(subjectNameBox.Text)
                    && !String.IsNullOrEmpty(teacherBox.Text) && !String.IsNullOrEmpty(countBox.Text)
                    && !String.IsNullOrEmpty(groupIdBox.Text)
                    && !String.IsNullOrEmpty(lectureBox.Text) && !String.IsNullOrEmpty(practicBox.Text)
                    && (examBox.Checked || creditBox.Checked))
            {
                string finalCheckWork;

                if (examBox.Checked)
                {
                    finalCheckWork = "0,5";
                }
                else
                {
                    finalCheckWork = "0,35";
                }

                data = new UniversityData(subjectIdBox.Text, subjectNameBox.Text, teacherBox.Text, groupIdBox.Text,
                    countBox.Text, lectureBox.Text, practicBox.Text, finalWorkEnabled.Checked ? "true" : "false",
                    finalCheckWork);
                isSave = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные",
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }
    }
}
