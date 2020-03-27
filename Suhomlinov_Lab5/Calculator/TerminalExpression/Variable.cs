using System;
namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Класс математического выражения - переменная  
    /// </summary>
    public class Variable : Expression
    {
        /// <summary>
        /// Переменная для хранения имени переменной
        /// </summary>
        private String name;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя переменной</param>
        public Variable(String name)
        {
            this.name = name;
        }

        /// <summary>
        /// Функция интерпретации выражения в число
        /// </summary>
        /// <param name="context">контекст</param>
        /// <returns>double - результат выражения</returns>
        public double interpret(Context context)
        {
            Expression expression = context.getExpression(name);

            if (expression == null) throw new System.ArgumentException();

            return expression.interpret(context);
        }
    }

}
