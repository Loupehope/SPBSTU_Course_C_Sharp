namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Класс математического выражения - разницы
    /// </summary>
    public class MinusExpression : Expression
    {
        /// <summary>
        /// Переменная для хранения левого операнда разницы
        /// </summary>
        private Expression left;

        /// <summary>
        /// Переменная для хранения правого операнда разницы
        /// </summary>
        private Expression right;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="left">Левый операнд разницы</param>
        /// <param name="right">Правый операнд разницы</param>
        public MinusExpression(Expression left, Expression right)
        {
            if (left == null || right == null)
                throw new System.ArgumentNullException();

            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Функция интерпретации выражения в число
        /// </summary>
        /// <param name="context">контекст</param>
        /// <returns>double - результат выражения</returns>
        public double interpret(Context context)
        {
            return left.interpret(context) - right.interpret(context);
        }
    }

}
