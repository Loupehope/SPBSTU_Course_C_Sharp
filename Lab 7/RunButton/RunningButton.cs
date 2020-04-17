using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunButton
{
    public partial class RunningButton : Form
    {
        /// <summary>
        /// Перечисление направлений движения курсора
        /// </summary>
        private enum MouseDirection
        {
            Top, Left, Right, Bottom, None
        }

        /// <summary>
        /// Переменная для хранения прошлой позиции курсора
        /// </summary>
        private Point previousMousePosition;

        /// <summary>
        /// Переменная для хранения прошлого размера окна
        /// </summary>
        private Size previousFormSize;

        /// <summary>
        /// Переменная для хранения прошлого рассстояния от кнопки до курсора
        /// </summary>
        private double previousDistance = 0;

        /// <summary>
        /// Переменная указывающая на то, что курсор был за пределами окна - начальное состояние
        /// </summary>
        private bool isInitial = true;

        /// <summary>
        /// Конструктор
        /// </summary>
        public RunningButton()
        {
            InitializeComponent();

            pushButton.Left = (ClientSize.Width - pushButton.Width) / 2;
            pushButton.Top = (ClientSize.Height - pushButton.Height) / 2;
            previousFormSize = ClientSize;
        }

        /// <summary>
        /// Обработчик событий движения курсора в области формы
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Point buttonCenter = new Point(pushButton.Location.X + pushButton.Width / 2, pushButton.Location.Y + pushButton.Height / 2);
            double currentDistance = getDistance(e.Location, buttonCenter);

            MouseDirection direction = getMouseDirection(e.Location);

            if (currentDistance < previousDistance 
                && !pushButton.Bounds.Contains(e.Location) 
                && currentDistance < pushButton.Width)
            {
                moveButton(direction, getDistance(e.Location, previousMousePosition));
            }
            
            previousMousePosition = e.Location;
            previousDistance = currentDistance;
        }

        /// <summary>
        /// Функция подсчета расстояния между двумя точками
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private double getDistance(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
        }

        /// <summary>
        /// Процедура передвигающая кнопку
        /// </summary>
        /// <param name="direction">Направление движения курсора</param>
        /// <param name="speed">Скорость движения</param>
        private void moveButton(MouseDirection direction, double speed)
        {
            int moveDistance = (SystemInformation.MouseSpeed / 10 + 1) * (int)(speed);
            
            switch (direction)
            {
                case MouseDirection.Top:
                    if (pushButton.Top > 0)
                        pushButton.Top -= pushButton.Top - moveDistance < 0 
                            ? pushButton.Top
                            : moveDistance;
                    break;
                case MouseDirection.Left:
                    if (pushButton.Location.X > 0)
                        pushButton.Left -= pushButton.Left - moveDistance < 0 
                            ? pushButton.Left 
                            : moveDistance;
                    break;
                case MouseDirection.Right:
                    if (pushButton.Left + pushButton.Width < ClientSize.Width)
                        pushButton.Left += pushButton.Left + pushButton.Width + moveDistance < ClientSize.Width
                            ? moveDistance 
                            : ClientSize.Width - pushButton.Left - pushButton.Width;
                    break;
                case MouseDirection.Bottom:
                    if (pushButton.Top + pushButton.Height < ClientSize.Height)
                        pushButton.Top += pushButton.Top + pushButton.Height + moveDistance < ClientSize.Height
                            ?  moveDistance 
                            : ClientSize.Height - pushButton.Top - pushButton.Height;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Функция расчета направления движения курсора
        /// </summary>
        /// <param name="currentPosition">Позоиция курсора</param>
        /// <returns>Направление движения</returns>
        private MouseDirection getMouseDirection(Point currentPosition)
        {
            if (isInitial)
            {
                isInitial = false;
                return MouseDirection.None;
            }

            double diffX = previousMousePosition.X - currentPosition.X;
            double diffY = previousMousePosition.Y - currentPosition.Y;

            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                return diffX < 0 ? MouseDirection.Right : MouseDirection.Left;
            }
            else
            {
                return diffY < 0 ? MouseDirection.Bottom : MouseDirection.Top;
            }
        }

        /// <summary>
        /// Обработчик изменения размера формы
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                return;

            int diffWidth = (ClientSize.Width - previousFormSize.Width) / 2;
            int diffHeight = (ClientSize.Height - previousFormSize.Height) / 2;

            if (pushButton.Left + diffWidth < 0)
            {
                pushButton.Left = 0;
            }
            else
            {
                pushButton.Left += diffWidth;
            }

            pushButton.Left = pushButton.Left + pushButton.Width > ClientSize.Width
                ? ClientSize.Width - pushButton.Width
                : pushButton.Left;

            if (pushButton.Top + diffHeight < 0)
            {
                pushButton.Top = 0;
            }
            else
            {
                pushButton.Top += diffHeight;
            }

            pushButton.Top = pushButton.Top + pushButton.Height > ClientSize.Height
                ? ClientSize.Height - pushButton.Height
                : pushButton.Top;

            previousFormSize = ClientSize;
        }

        /// <summary>
        /// Обработчик событий нажатия на кнопку
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void pushButton_Click(object sender, EventArgs e)
        {
            Dialog dialog = new Dialog();
            dialog.ShowDialog();
        }

        /// <summary>
        /// Обработчик события ухода курсора за пределы формы
        /// </summary>
        /// <param name="sender">Отправитель события</param>
        /// <param name="e">Событие</param>
        private void RunningButton_MouseLeave(object sender, EventArgs e)
        {
            isInitial = true;
        }
    }
}
