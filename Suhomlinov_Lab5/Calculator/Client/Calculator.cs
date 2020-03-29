namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Интерфейс вычислителя
    /// </summary>
    public interface Calculator
    {
        /// <summary>
        /// Функция вычисления математического выражения
        /// </summary>
        /// <param name="input">математическое выражение</param>
        /// <returns>double - результат выражения</returns>
        public double calculate(string input);

        /// <summary>
        /// Функция, возвращающая операторы вычислителя
        /// </summary>
        /// <returns>string[] - набор поддерживаемых операторов вычислителя</returns>
        public string[] getOperators();
    }
}