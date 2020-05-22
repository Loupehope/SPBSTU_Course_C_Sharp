using System;
using System.IO;

namespace lab1
{
    class Program
    {
        /// <summary>
        /// Точка входа для приложения.
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {

            TextWork txt = new TextWork("input.txt");
            txt.Reading();
            Money cash = new Money(txt.RetInt());
            txt.Writing(Convert.ToString(cash.OddMoney()), "output.txt");
        }
    }
}
