using System;
using System.IO;

namespace Suhomlinov_Lab2
{
    /// <summary>
    /// Класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа для приложения
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader("input.txt");
            }
            catch
            {
                Console.WriteLine("Can't read file");
                return;
            }

            int softCount;

            try
            {
                softCount = Int32.Parse(sr.ReadLine());
            }
            catch
            {
                Console.WriteLine("Can't get number of software");
                return;
            }

            if (softCount <= 0)
            {
                Console.WriteLine("Number of software must be bigger than zero");
                return;
            }

            SoftwareManager softManager = new SoftwareManager(softCount);

            for (int i = 0; i < softCount; i++)
            {
                string[] softInfoArray;

                try
                {
                    softInfoArray = sr.ReadLine().Split("|");
                }
                catch
                {
                    Console.WriteLine("Cannot read line " + i);
                    break;
                }

                softManager.addSoft(softInfoArray, i);
            }

            sr.Close();
            softManager.printAllSoftInfoAndValidation();
        }
    }
}
