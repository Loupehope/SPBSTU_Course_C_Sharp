using System;
using System.Collections.Generic;

namespace Suhomlinov_Lab5
{
    /// <summary>
    /// Класс вычислителя
    /// </summary>
    public class SimpleCalculator: Calculator
    {
        /// <summary>
        /// Переменная для хранения операторов вычислителя
        /// </summary>
        private string[] operators = {"+", "-"};

        /// <summary>
        /// Переменная для хранения контекста
        /// </summary>
        private Context context;

        /// <summary>
        /// Переменная для хранения дерева вычислений
        /// </summary>
        private Expression expressionTree = new Number(0);

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">контекст</param>
        public SimpleCalculator(Context context)
        {
            if (context == null)
                throw new System.ArgumentNullException(nameof(context));

            this.context = context;
        }

        /// <summary>
        /// Функция вычисления математического выражения
        /// </summary>
        /// <param name="input">математическое выражение</param>
        /// <returns>double - результат выражения</returns>
        public double calculate(string input)
        {
            expressionTree = buildSyntaxTree(input);
            return expressionTree.interpret(context);
        }

        /// <summary>
        /// Функция, возвращающая операторы вычислителя
        /// </summary>
        /// <returns>string[] - набор поддерживаемых операторов вычислителя</returns>
        public string[] getOperators()
        {
            string[] copyOperators = new string[operators.Length];
            operators.CopyTo(copyOperators, 0);
            return copyOperators;
        }

        /// <summary>
        /// Функция построения дерева вычислений
        /// </summary>
        /// <param name="input">Выражение для разбора</param>
        /// <returns>Expression - дерево вычислений</returns>
        private Expression buildSyntaxTree(string input)
        {
            var expressionStack = new Stack<Expression>();
            var items = input.Split(" ");
            var index = 0;

            if (items.Length < 1) throw new System.ArgumentException();

            try
            {
                double numVal = Double.Parse(items[index]);
                expressionStack.Push(new Number(numVal));
            }
            catch
            {
                expressionStack.Push(new Variable(items[index]));
            }

            index += 1;

            while (index < items.Length)
            {
                switch (items[index])
                {
                    case "+":
                        expressionStack.Push(new PlusExpression(expressionStack.Pop(), getNextExpression(items, index)));

                        index += 2;
                        break;

                    case "-":
                        expressionStack.Push(new MinusExpression(expressionStack.Pop(), getNextExpression(items, index)));

                        index += 2;
                        break;

                    default:
                        throw new System.ArgumentException();
                }
            }

            return expressionStack.Pop();
        }

        /// <summary>
        /// Функция создания следующего выражения из элементов выражения
        /// </summary>
        /// <param name="items">Элементы выражения</param>
        /// <param name="index">Индекс элемента</param>
        private Expression getNextExpression(string[] items, int index)
        {
            string next = items[index + 1];
            Expression nextExpression;

            try
            {
                double numVal = Double.Parse(next);
                nextExpression = new Number(numVal);
            }
            catch
            {
                nextExpression = new Variable(next);
            }

            return nextExpression;
        }

    }
}
