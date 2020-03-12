using System;
namespace Suhomlinov_Lab4
{
    public class PostgreSQLDB: DatabaseInterface
    {

        public DBConfigInterface config { get; set; }

        public PostgreSQLDB(DBConfigInterface config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;
        }

        public void createDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: createDatabase()");
        }

        public void deleteDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: deleteDatabase()");
        }

        public void connectDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: connectDatabase()");
        }

        public void reconnectDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: reconnectDatabase()");
        }

        public void disconnectDatabase(string title)
        {
            Console.WriteLine("PostgreSQL: disconnectDatabase()");
        }

        public void createTable(string title)
        {
            Console.WriteLine("PostgreSQL: createTable()");
        }

        public void reloadTable(string title)
        {
            Console.WriteLine("PostgreSQL: reloadTable()");
        }

        public void dropTable(string title)
        {
            Console.WriteLine("PostgreSQL: dropTable()");
        }

        public void renameTable(string title, string newTitle)
        {
            Console.WriteLine("PostgreSQL: renameTable()");
        }

        public void createView(string title)
        {
            Console.WriteLine("PostgreSQL: createView()");
        }
    }
}
