using System;
namespace Suhomlinov_Lab4
{

    public class MySQLDB: DatabaseInterface
    {

        public DBConfigInterface config { get; set; }

        public MySQLDB(DBConfigInterface config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;
        }

        public void createDatabase(string title)
        {
            Console.WriteLine("MySQL: createDatabase()");
        }

        public void deleteDatabase(string title)
        {
            Console.WriteLine("MySQL: deleteDatabase()");
        }

        public void connectDatabase(string title)
        {
            Console.WriteLine("MySQL: connectDatabase()");
        }
    
        public void reconnectDatabase(string title)
        {
            Console.WriteLine("MySQL: reconnectDatabase()");
        }

        public void disconnectDatabase(string title)
        {
            Console.WriteLine("MySQL: disconnectDatabase()");
        }

        public void createTable(string title)
        {
            Console.WriteLine("MySQL: createTable()");
        }

        public void reloadTable(string title)
        {
            Console.WriteLine("MySQL: reloadTable()");
        }

        public void dropTable(string title)
        {
            Console.WriteLine("MySQL: dropTable()");
        }

        public void renameTable(string title, string newTitle)
        {
            Console.WriteLine("MySQL: renameTable()");
        }

        public void createView(string title)
        {
            Console.WriteLine("MySQL: createView()");
        }
    }
}
