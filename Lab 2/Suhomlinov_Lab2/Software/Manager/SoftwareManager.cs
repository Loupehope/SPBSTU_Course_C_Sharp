using System;
using System.Globalization;

namespace Suhomlinov_Lab2
{
    public class SoftwareManager
    {
        /// <summary>
        /// Переменная для хранения числа ПО, которое будет храниться  
        /// </summary>
        private int softCount;

        /// <summary>
        /// Переменная для хранения объектов ПО
        /// </summary>
        private AbstractSoftware[] softs;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="softCount">число ПО, которое будет храниться</param>
        public SoftwareManager(int softCount)
        {
            this.softCount = softCount;
            this.softs = new AbstractSoftware[softCount];
        }

        /// <summary>
        /// Метод для вывода информации о ПО и возмодности его использования в консоль 
        /// </summary>
        public void printAllSoftInfoAndValidation()
        {
            foreach (AbstractSoftware soft in softs)
            {
                if (soft is null)
                {
                    Console.Write("Incorrect value\n");
                    Console.WriteLine();
                }
                else
                {
                    soft.printInfo();
                    if (soft.validate())
                    {
                        Console.Write("It can be used today\n");
                    }
                    else
                    {
                        Console.Write("It can't be used today\n");
                    }
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Метод для добавления массива данных о ПО в массив ПО 
        /// </summary>
        /// <param name="softData">Массив данных о ПО</param>
        /// <param name="index">Индекс массива для вставки ПО</param>
        public void addSoft(string[] softData, int index)
        {
            AbstractSoftware element = convertArrayInfoToSoftware(softData);

            if (element is null)
            {
                Console.WriteLine("Data is not correct in line " + index);
            }
            else if (index > -1 && index < softCount)
            {
                softs[index] = element;
            }
            else
            {
                Console.WriteLine("Wrong index " + index);
            }
        }

        /// <summary>
        /// Метод для ковертирования строк данных в объект ПО
        /// </summary>
        /// <param name="info">Массив данных о ПО</param>
        /// <returns>AbstractSoftware - если получилось проинициализорвать данные, иначе - null</returns>
        private AbstractSoftware convertArrayInfoToSoftware(string[] info)
        {
            string softwareType = info[0].ToLower();
            switch (softwareType)
            {
                case "freesoftware":
                    return new FreeSoftware(info[1], info[2]);
                case "sharewaresoftware":
                    return new SharewareSoftware(info[1], info[2],
                        DateTime.ParseExact(info[3], "dd.MM.yyyy", CultureInfo.InvariantCulture), Convert.ToInt32(info[4]));
                case "commercialsoftware":
                    return new CommercialSoftware(info[1], info[2], Convert.ToDouble(info[3]),
                        DateTime.ParseExact(info[4], "dd.MM.yyyy", CultureInfo.InvariantCulture), Convert.ToInt32(info[5]));
                default:
                    return null;
            }

        }
    }
}
