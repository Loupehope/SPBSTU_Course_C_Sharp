using System;
namespace Suhomlinov_Lab4
{
    public class PostgreSQLDB : DatabaseInterface
    {
        /// <summary>
        /// Функция для создания базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void createDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: createDatabase()");
        }

        /// <summary>
        /// Функция для удаления базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void deleteDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: deleteDatabase()");
        }

        /// <summary>
        /// Функция для подключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void connectDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: connectDatabase()");
        }

        /// <summary>
        /// Функция для переподключения к базе данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void reconnectDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: reconnectDatabase()");
        }

        /// <summary>
        /// Функция для отключения от базы данных
        /// </summary>
        /// <param name="title">Название бд</param>
        public void disconnectDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: disconnectDatabase()");
        }

        /// <summary>
        /// Функция для создания таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void createTable(string title)
        {
            Console.WriteLine("PostgreSQL: createTable()");
        }

        /// <summary>
        /// Функция для перезагрузки таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void reloadTable(string title)
        {
            Console.WriteLine("PostgreSQL: reloadTable()");
        }

        /// <summary>
        /// Функция для удаления таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        public void dropTable(string title)
        {
            Console.WriteLine("PostgreSQL: dropTable()");
        }

        /// <summary>
        /// Функция для переименования таблицы
        /// </summary>
        /// <param name="title">Название таблицы</param>
        /// <param name="newTitle">Новое название таблицы</param>
        public void renameTable(string title, string newTitle)
        {
            Console.WriteLine("PostgreSQL: renameTable()");
        }

        /// <summary>
        /// Функция для создания пердставления
        /// </summary
        /// <param name="title">Название представления</param>
        public void createView(string title)
        {
            Console.WriteLine("PostgreSQL: createView()");
        }
    }
}