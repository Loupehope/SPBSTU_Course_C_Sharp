using System;
namespace Suhomlinov_Lab4
{
    public class OracleDB: DatabaseInterface
    {
        /// <summary>
        /// Переменная для хранения конфигурации подключения Базы данных
        /// </summary>
        public DBConfigInterface config { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="config">конфигурация для подключения к бд</param>
        public OracleDB(DBConfigInterface config)
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
            Console.WriteLine("Oracle: createDatabase()");
        }

        /// <summary>
        /// Функция для удаления базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void deleteDatabase(string title)
        {
            Console.WriteLine("Oracle: deleteDatabase()");
        }

        /// <summary>
        /// Функция для подключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void connectDatabase(string title)
        {
            Console.WriteLine("Oracle: connectDatabase()");
        }

        /// <summary>
        /// Функция для переподключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void reconnectDatabase(string title)
        {
            Console.WriteLine("Oracle: reconnectDatabase()");
        }

        /// <summary>
        /// Функция для отключения от базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void disconnectDatabase(string title)
        {
            Console.WriteLine("Oracle: disconnectDatabase()");
        }

        /// <summary>
        /// Функция для создания таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void createTable(string title)
        {
            Console.WriteLine("Oracle: createTable()");
        }

        /// <summary>
        /// Функция для перезагрузки таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void reloadTable(string title)
        {
            Console.WriteLine("Oracle: reloadTable()");
        }

        /// <summary>
        /// Функция для удаления таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void dropTable(string title)
        {
            Console.WriteLine("Oracle: dropTable()");
        }

        /// <summary>
        /// Функция для переименования таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        /// <param name="newTitle">Новое название таблицы</param>
        public void renameTable(string title, string newTitle)
        {
            Console.WriteLine("Oracle: renameTable()");
        }

        /// <summary>
        /// Функция для создания пердставления
        /// </summary
        /// <param name="title">Название представления</param>
        public void createView(string title)
        {
            Console.WriteLine("Oracle: createView()");
        }
    }
}
