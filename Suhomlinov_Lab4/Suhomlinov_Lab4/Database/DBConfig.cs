using System;
namespace Suhomlinov_Lab4
{
    /// <summary>
    /// Класс кунфигурации для подключения к бд
    /// </summary>
    public class DBConfig: DBConfigInterface
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

        /// <summary>
        /// Базовый конструктор класса
        /// </summary>
        /// <param name="config">конфигурация для подключения к бд</param>
        public DBConfig()
        {
            this.name = String.Empty;
            this.login = String.Empty;
            this.password = String.Empty;
            this.hostname = String.Empty;
            this.port = 0;
            this.sid = String.Empty;
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="name">Имя подключения к бд</param>
        /// <param name="login">Логин для подключения к бд</param>
        /// <param name="password">Пароль для подключения к бд</param>
        /// <param name="hostname">Имя хоста для подключения к бд</param>
        /// <param name="port">Номера порта для подключения к бд</param>
        /// <param name="sid">SID для подключения к бд</param>
        public DBConfig(string name, string login, string password, string hostname, int port, string sid)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.hostname = hostname;
            this.port = port;
            this.sid = sid;
        }
    }
}
