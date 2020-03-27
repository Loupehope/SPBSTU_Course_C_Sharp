namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Класс математического выражения - число
    /// </summary>
    public class Number : Expression
    {
        /// <summary>
        /// Переменная для хранения числа
        /// </summary>
        private double value;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="value">Число для хранения</param>
        public Number(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Функция интерпретации выражения в число
        /// </summary>
        /// <param name="context">контекст</param>
        /// <returns>double - результат выражения</returns>
        public double interpret(Context context)
        {
            return value;
        }
    }
}
