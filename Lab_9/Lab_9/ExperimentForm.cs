using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace Lab_9
{
    public partial class ExperimentForm : Form
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static Random randomGenerator = new Random();

        /// <summary>
        /// Переменная разрешающаю отрисовку точек
        /// </summary>
        private static bool shoudDraw = true;

        /// <summary>
        /// Число точек на полотне
        /// </summary>
        private int dotCounts = 0;

        /// <summary>
        /// Число точек в окружности
        /// </summary>
        private int dotInCircleCounts = 0;

        /// <summary>
        /// Конфигурация эксперимента
        /// </summary>
        private ExperimentConfiguration config;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="config">Конфигурация эксперимента</param>
        public ExperimentForm(ExperimentConfiguration config)
        {
            this.config = config;
            InitializeComponent(); 
        }

        /// <summary>
        /// Обработчик загрузки формы
        /// </summary>
        /// <param name="sender">Посылатель события</param>
        /// <param name="e">Событие</param>
        private void ExperimentForm_Load(object sender, EventArgs e)
        {
            shoudDraw = true;
        }

        /// <summary>
        /// Метод отрисовки точки
        /// </summary>
        /// <param name="color">Цвет точки</param>
        private void drawDot(object color)
        {
            while (shoudDraw)
            {
                Point dPoint = new Point(randomGenerator.Next(pictureBox.Width), randomGenerator.Next(pictureBox.Height));
                Point calc = new Point(pictureBox.Left + dPoint.X, pictureBox.Top + dPoint.Y);
                Point circleCenter = new Point(pictureBox.Location.X + pictureBox.Width / 2, pictureBox.Location.Y + pictureBox.Height / 2);

                Interlocked.Increment(ref dotCounts);

                if (Math.Pow(calc.X - circleCenter.X, 2) + Math.Pow(calc.Y - circleCenter.Y, 2) <= Math.Pow(config.radius, 2))
                    Interlocked.Increment(ref dotInCircleCounts);

                try
                {
                    this.Invoke(new Action(() => { drawDot(dPoint.X, dPoint.Y, (Color)color); drawCircle(); }));
                }
                catch{ }
                
                Thread.Sleep(config.sleepTime * (config.threadsCount / 10 == 0 ? 1 : 2));
            }
        }

        /// <summary>
        /// Функция-генератор случайного цвета
        /// </summary>
        /// <returns></returns>
        private Color getRandomColor()
        {
            return Color.FromArgb(randomGenerator.Next(254), randomGenerator.Next(254), randomGenerator.Next(254));
        }

        /// <summary>
        /// Процедура отричовки точки
        /// </summary>
        /// <param name="x">Координата точки Х</param>
        /// <param name="y">Координата точки Y</param>
        /// <param name="color">Цвет точки</param>
        private void drawDot(int x, int y, Color color)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.DrawRectangle(new Pen(color, 1f), x, y, 1, 1);
            g.Dispose();
        }

        /// <summary>
        /// ПРоцедура отрисовки окружности
        /// </summary>
        private void drawCircle()
        {
            Graphics g = pictureBox.CreateGraphics();
            g.DrawEllipse(new Pen(Color.Black, 4f), 0, 0, pictureBox.Size.Width - 1, pictureBox.Size.Height - 1);
            g.Dispose();
        }

        /// <summary>
        /// Обработчик события остановки эксперимента
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void stop_Click(object sender, EventArgs e)
        {
            shoudDraw = false;

            resultLabel.Text = "Площадь равна: " + Math.Round((double)(pictureBox.Width * pictureBox.Height) * (double)dotInCircleCounts / dotCounts, 3);
            stop.Enabled = false;
        }

        /// <summary>
        /// Обработчик показа формы
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void ExperimentForm_Shown(object sender, EventArgs e)
        {
            if (config.radius * 2 < 400)
            {
                Size = new Size(400, 500);
            }
            else
            {
                Size = new Size(config.radius * 2 + 100, config.radius * 2 + 100 + stop.Height);
            }

            MinimumSize = Size;
            MaximumSize = Size;

            pictureBox.Size = new Size(config.radius * 2, config.radius * 2);

            for (int i = 0; i < config.threadsCount; i++)
            {
                Thread thread = new Thread(drawDot);
                thread.IsBackground = true;
                thread.Start(getRandomColor());
            }
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void ExperimentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            shoudDraw = false;
        }
    }
}

