using System.Collections.Generic;

namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Класс контекста
    /// </summary>
    public class Context
    {
        /// <summary>
        /// Переменная для хранения выражений по имени 
        /// </summary>
        private Dictionary<string, Expression> variables;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="variables">Словарь именновынных выражений</param>
        public Context(Dictionary<string, Expression> variables)
        {
            if (variables == null)
                throw new System.ArgumentNullException(nameof(variables));

            this.variables = variables;
        }

        /// <summary>
        /// Функция для получения выражения по имени
        /// </summary>
        /// <param name="name">Имя выражения</param>
        /// <returns>Expression - выражение</returns>
        public Expression getExpression(string name)
        {
            Expression expression;

            try
            {
                expression = variables[name];
            }
            catch
            {
                throw new System.ArgumentException();
            }

            return expression;
        }
    }
}
