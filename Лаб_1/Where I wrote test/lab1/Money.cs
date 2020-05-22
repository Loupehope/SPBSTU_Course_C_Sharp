using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    /// <summary>
    /// Класс для работы с деньгами.</summary>
    /// <remarks>
    /// Основной класс для решения 1 лабораторной работы
    /// </remarks>
    public class Money
    {
        /// <summary>
        /// Указывает на количество денег.</summary>
        private int sum;

        /// <summary>
        /// Конструктор класса. </summary>
        public Money(int sum)
        {
            this.sum = sum;
        }

        /// <summary>
        /// Свойство денег. </summary>
        /// <value>
        /// Описывает количество текущих средств</value>
        public int Count
        {
            get { return sum; }
        }

        /// <summary>
        /// Функция для запуска рекурсивного расчета способов сдать сдачу для значений в отрезке [0;2000].</summary>
        /// <returns>
        /// Возвращает количество способов сдать сдачу</returns>
        public int OddMoney()
        {
            if (sum == 0) return 0;
            if (sum < 0 || sum > 2000)
            {
                throw new ArgumentOutOfRangeException("sum");
            }
            return CountOfComninations(sum, 5);
        }

        /// <summary>
        /// Рекурсивная функция для подсчета способов сдать сдачу.</summary>
        /// <param name="sum">Сумма, которую пытаемся сдать</param>
        /// <param name="kindsOfCoins">Тип монет, которыми сдаем сдачу</param>
        /// <returns>
        /// Возвращает количество способов сдать сдачу</returns>
        /// <seealso cref="OddMoney()"></seealso>
        private int CountOfComninations(int sum, int kindsOfCoins)
        {
            if (sum == 0)
                return 1;
            if (sum < 0 || kindsOfCoins == 0)
                return 0;
            else
                return CountOfComninations(sum, kindsOfCoins - 1) +
                CountOfComninations(sum - Denomination(kindsOfCoins), kindsOfCoins);

        }

        /// <summary>
        /// Содержит информацию о типах монет. </summary>
        /// <param name="kindsOfCoins">Тип монет, которыми сдаем сдачу</param>
        /// <returns>
        /// Возвращает ценность данного типа монеты</returns>
        /// <seealso cref="CountOfComninations(int sum, int kindsOfCoins)">
        /// Необходим для рекурсивной функции</seealso>
        private int Denomination(int kindsOfCoins)
        {
            switch (kindsOfCoins)
            {
                case 1:
                    return 1;
                case 2:
                    return 5;
                case 3:
                    return 10;
                case 4:
                    return 50;
                default:
                    return 100;
            }
        }
    }
}
