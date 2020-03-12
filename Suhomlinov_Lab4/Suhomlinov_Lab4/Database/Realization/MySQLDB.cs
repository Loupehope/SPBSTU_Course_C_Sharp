using System;
namespace Suhomlinov_Lab4
{
    /// <summary>
    /// Класс базы данных MySQL
    /// </summary>
    public class MySQLDB: DatabaseInterface
    {
        /// <summary>
        /// Переменная для хранения конфигурации подключения Базы данных
        /// </summary>
        public DBConfigInterface config { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="config">конфигурация для подключения к бд</param>
        public MySQLDB(DBConfigInterface config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;
        }

        /// <summary>
        /// Функция для создания базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void createDatabase(string title)
        {
            Console.WriteLine("MySQL: createDatabase()");
        }

        /// <summary>
        /// Функция для удаления базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void deleteDatabase(string title)
        {
            Console.WriteLine("MySQL: deleteDatabase()");
        }

        /// <summary>
        /// Функция для подключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void connectDatabase(string title)
        {
            Console.WriteLine("MySQL: connectDatabase()");
        }

        /// <summary>
        /// Функция для переподключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void reconnectDatabase(string title)
        {
            Console.WriteLine("MySQL: reconnectDatabase()");
        }

        /// <summary>
        /// Функция для отключения от базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void disconnectDatabase(string title)
        {
            Console.WriteLine("MySQL: disconnectDatabase()");
        }

        /// <summary>
        /// Функция для создания таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void createTable(string title)
        {
            Console.WriteLine("MySQL: createTable()");
        }

        /// <summary>
        /// Функция для перезагрузки таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void reloadTable(string title)
        {
            Console.WriteLine("MySQL: reloadTable()");
        }

        /// <summary>
        /// Функция для удаления таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void dropTable(string title)
        {
            Console.WriteLine("MySQL: dropTable()");
        }

        /// <summary>
        /// Функция для переименования таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        /// <param name="newTitle">Новое название таблицы</param>
        public void renameTable(string title, string newTitle)
        {
            Console.WriteLine("MySQL: renameTable()");
        }

        /// <summary>
        /// Функция для создания пердставления
        /// </summary
        /// <param name="title">Название представления</param>
        public void createView(string title)
        {
            Console.WriteLine("MySQL: createView()");
        }
    }
}
