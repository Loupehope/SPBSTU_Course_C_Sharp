namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Интерфейс выражения
    /// </summary>
    public interface Expression
    {
        /// <summary>
        /// Функция интерпретации выражения в число
        /// </summary>
        /// <param name="context">контекст</param>
        /// <returns>double - результат выражения</returns>
        public double interpret(Context context);
    }
}
