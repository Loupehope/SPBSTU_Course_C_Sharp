using System;
namespace Suhomlinov_Lab2
{

    /// <summary>
    /// Класс условно-бесплатного ПО.
    /// </summary>
    public class SharewareSoftware: AbstractSoftware
    {
        /// <summary>
        /// Переменная для хранения даты установки ПО
        /// </summary>
        public DateTime installationDate;

        /// <summary>
        /// Переменная для хранения периода бесплатного использования ПО
        /// </summary>
        public int freeUsagePeriod;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Название ПО</param>
        /// <param name="manufacturer">Производитель</param>
        /// <param name="installationDate">Дата установки ПО</param>
        /// <param name="freeUsagePeriod">Период бесплатного использования</param>
        public SharewareSoftware(string name, string manufacturer,
            DateTime installationDate, int freeUsagePeriod) : base(name, manufacturer)
        {
            this.installationDate = installationDate;
            this.freeUsagePeriod = freeUsagePeriod;
        }

        /// <summary>
        /// Функция вывода в консоль информации о платном ПО
        /// </summary>
        public override void printInfo()
        {
            Console.WriteLine(baseInfo + "\nInstallation date: " + installationDate.ToString("dd.MM.yyyy") + "\n" +
                "Free period: " + freeUsagePeriod);
        }

        /// <summary>
        /// Функция для проверки возможности использования ПО на нынешнюю дату
        /// </summary>
        /// <returns>true - можно пользоваться, false - нельзя пользоваться</returns>
        public override bool validate()
        {
            return DateTime.Today.Subtract(installationDate).Days <= freeUsagePeriod;
        }
    }
}
