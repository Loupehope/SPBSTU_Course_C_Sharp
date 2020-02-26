using System;
namespace Suhomlinov_Lab2
{

    /// <summary>
    /// Класс коммерческого ПО.
    /// </summary>
    public class CommercialSoftware : AbstractSoftware
    {
        /// <summary>
        /// Переменная для хранения стоимости ПО
        /// </summary>
        public double cost;

        /// <summary>
        /// Переменная для хранения даты установки ПО
        /// </summary>
        public DateTime installationDate;

        /// <summary>
        /// Переменная для хранения периода использования ПО
        /// </summary>
        public int usagePeriod;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        /// <param name="cost">Стоимость ПО</param>
        /// <param name="installationDate">Дата установки ПО</param>
        /// <param name="usagePeriod">Период использования</param>
        public CommercialSoftware(string name, string manufacturer,
            double cost, DateTime installationDate, int usagePeriod) : base(name, manufacturer)
        {
            this.cost = cost;
            this.installationDate = installationDate;
            this.usagePeriod = usagePeriod;
        }

        /// <summary>
        /// Функция вывода в консоль информации о платном ПО
        /// </summary>
        public override void printInfo()
        {
            Console.WriteLine(baseInfo + "\nInstallation date: " + installationDate.ToString("dd.MM.yyyy") +
                "\nCost: " + cost + "\nUse period: " + usagePeriod);
        }

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public override bool validate()
        {
            return DateTime.Today.Subtract(installationDate).Days <= usagePeriod;
        }
    }
}
