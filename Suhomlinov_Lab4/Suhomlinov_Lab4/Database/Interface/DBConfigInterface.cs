using System;
namespace Suhomlinov_Lab4
{
    /// <summary>
    /// Абстрактный класс кунфигурации для подключения к бд
    /// </summary>
    public interface DBConfigInterface
    {
        /// <summary>
        /// Переменная для хранения имени подключения к бд
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Переменная для хранения логина для подключения к бд
        /// </summary>
        public string login { get; set; }

        /// <summary>
        /// Переменная для хранения пароля для подключения к бд
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Переменная для хранения имени хоста для подключения к бд
        /// </summary>
        public string hostname { get; set; }

        /// <summary>
        /// Переменная для хранения номера порта для подключения к бд
        /// </summary>
        public int port { get; set; }

        /// <summary>
        /// Переменная для хранения sid для подключения к бд
        /// </summary>
        public string sid { get; set; }
    }
}
