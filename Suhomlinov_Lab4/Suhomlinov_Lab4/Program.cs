using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;

namespace Suhomlinov_Lab4
{
    class Program
    {
        // <summary>
        /// Переменная для хранения названия файла c xml
        /// </summary>
        private static string readFile = "input.txt";

        /// <summary>
        /// Точка входа для приложения
        /// </summary>
        /// <param name="args"> Список аргументов командной строки</param>
        static void Main(string[] args)
        {
            StreamReader sr;
            try
            {
                sr = new StreamReader(readFile);
            }
            catch
            {
                Console.WriteLine("Can't read file");
                return;
            }

            string databaseName;

            try
            {
                databaseName = sr.ReadLine();
            }
            catch
            {
                Console.WriteLine("Can't get database name");
                sr.Close();
                return;
            }

            DBConfig config = new DBConfig();
            DatabaseInterface database;

            try
            {
                database  = parseDatabaseName(databaseName, config);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Wrong database name");
                sr.Close();
                return;
            }

            DBManager dBManager;

            try
            {
               dBManager = new DBManager(database);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                sr.Close();
                return;
            }

            List<string> commands = new List<string>();

            string command;

            while ((command = sr.ReadLine()) != null)
            {
                commands.Add(command);
            }

            sr.Close();

            foreach (string someCommand in commands)
            {
                parseAndCompleteDatabaseMethods(someCommand, dBManager);
            }
        }

        /// <summary>
        /// Метод для создания экземпляра бд по строке
        /// </summary>
        /// <param name="name">Название вида бд</param>
        /// <param name="config">Конфигурация для подключения к бд</param>
        static DatabaseInterface parseDatabaseName(string name, DBConfig config)
        {
            switch(name)
            {
                case "Oracle":
                    return new OracleDB(config);
                case "MySQL":
                    return new MySQLDB(config);
                case "PostgreSQL":
                    return new PostgreSQLDB(config);
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Метод для вызова метода экземпляра бд по строке
        /// </summary>
        /// <param name="parseString">Строка с названием метода и его параметрами</param>
        /// <param name="database">База данных</param>
        static void parseAndCompleteDatabaseMethods(string parseString, DBManager database)
        {
            string[] callParams = parseString.Split("|");

            if (callParams.Length < 1)
            {
                Console.WriteLine("No params");
                return;
            }

            string methodName = callParams[0];
            object[] methodParams = null;

            if (callParams.Length >= 2)
            {
                methodParams = new object[callParams.Length - 1];
                for (int i = 1; i <= methodParams.Length; i++)
                {
                    methodParams[i - 1] = callParams[i];
                }
            }

            Type type = database.GetType();
            MethodInfo method = type.GetMethod(methodName);

            try
            {
                method.Invoke(database, methodParams);
            }
            catch (Exception error)
            {
                Console.WriteLine("Try to call method: " + methodName + ", but get error: " + error.Message);
            }
        }
    }
}
