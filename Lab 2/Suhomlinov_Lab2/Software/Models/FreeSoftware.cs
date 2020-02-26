using System;
namespace Suhomlinov_Lab2
{
    /// <summary>
    /// Класс свободного ПО.
    /// </summary>
    public class FreeSoftware: AbstractSoftware
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        public FreeSoftware(string name, string manufacturer) : base(name, manufacturer) { }

        /// <summary>
        /// Функция вывода в консоль информации о платном ПО
        /// </summary>
        public override void printInfo()
        {
            Console.WriteLine(baseInfo);
        }

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public override bool validate()
        {
            return true;
        }
    }
}
