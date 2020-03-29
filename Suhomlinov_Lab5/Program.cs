using System;
using System.Collections.Generic;

namespace Suhomlinov_Lab5
{
    class Program
    {
        /// <summary>
        /// Точка входа для приложения
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            Dictionary<string, double> consts = new Dictionary<string, double>();
            consts["pi"] = 3.14;
            consts["e"] = 2.71;
            consts["zero"] = 0;

            Context context;
            Calculator calc;

            try
            {
                context = new Context(createConstExpressions(consts));
                calc = new SimpleCalculator(context);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                return;
            }

            Console.WriteLine("You can use constants in expression:");

            foreach(var value in consts)
            {
                Console.WriteLine(value.Key + ": " + value.Value);
            }

            Console.WriteLine("\nYou can use operators in expression:");

            foreach (var value in calc.getOperators())
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("\nWrite your expression:");
            string input = Console.ReadLine().ToLower().Trim();

            if (input.Length == 0)
            {
                Console.WriteLine("Empty expression!");
                return;
            }

            double result;

            try
            {
                result = calc.calculate(input);
            }
            catch (System.ArgumentException)
            {
                Console.WriteLine("Invalid expression!");
                return;
            }
            catch (Exception error)
            {
                Console.WriteLine("Oops, something went wrong: " + error.Message);
                return;
            }

            double formattedResult = Math.Round(result, 2);

            Console.WriteLine("Result: " + formattedResult.ToString());
        }

        /// <summary>
        /// Функция для получения словаря именнованных выражений
        /// </summary>
        /// <param name="consts">Словарь именнованных чисел</param>
        /// <returns>Dictionary<string, Expression> - словарь именнованных выражений</returns>
        private static Dictionary<string, Expression> createConstExpressions(Dictionary<string, double> consts)
        {
            Dictionary<string, Expression> constExpressions = new Dictionary<string, Expression>();

            foreach (var constVal in consts)
            {
                constExpressions[constVal.Key] = new Number(constVal.Value);
            }

            return constExpressions;
        }
    }
}
