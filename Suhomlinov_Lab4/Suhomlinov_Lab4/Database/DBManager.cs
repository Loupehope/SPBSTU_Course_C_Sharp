using System;
namespace Suhomlinov_Lab4
{
    public class DBManager
    {
        /// <summary>
        /// Переменная для хранения экземпляра базы данных
        /// </summary>
        private DatabaseInterface database;

        /// <summary>
        /// Переменная для хранения конфигурации подключения Базы данных
        /// </summary>
        private DBConfigInterface config;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="config">конфигурация для подключения к бд</param>
        /// <param name="database">бд</param>
        public DBManager(DatabaseInterface database, DBConfigInterface config)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.database = database;
            this.config = config;
        }

        /// <summary>
        /// Функция для создания базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void createDatabase(string title)
        {
            database.createDatabase(title);
        }

        /// <summary>
        /// Функция для удаления базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void deleteDatabase(string title)
        {
            database.deleteDatabase(title);
        }

        /// <summary>
        /// Функция для подключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void connectDatabase(string title)
        {
            database.connectDatabase(title);
        }

        /// <summary>
        /// Функция для переподключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void reconnectDatabase(string title)
        {
            database.reconnectDatabase(title);
        }

        /// <summary>
        /// Функция для отключения от базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void disconnectDatabase(string title)
        {
            database.disconnectDatabase(title);
        }

        /// <summary>
        /// Функция для создания таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void createTable(string title)
        {
            database.createTable(title);
        }

        /// <summary>
        /// Функция для перезагрузки таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void reloadTable(string title)
        {
            database.reloadTable(title);
        }

        /// <summary>
        /// Функция для удаления таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void dropTable(string title)
        {
            database.dropTable(title);
        }

        /// <summary>
        /// Функция для переименования таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        /// <param name="newTitle">Новое название таблицы</param>
        public void renameTable(string title, string newTitle)
        {
            database.renameTable(title, newTitle);
        }

        /// <summary>
        /// Функция для создания пердставления
        /// </summary>
        /// <param name="title">Название представления</param>
        public void createView(string title)
        {
            database.createView(title);
        }
    }
}