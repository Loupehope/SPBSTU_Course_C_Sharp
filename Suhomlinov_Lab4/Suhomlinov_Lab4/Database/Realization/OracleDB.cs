using System;
namespace Suhomlinov_Lab4
{
    public class OracleDB: DatabaseInterface
    {

        public DBConfigInterface config { get; set; }

        public OracleDB(DBConfigInterface config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            this.config = config;
        }

        public void createDatabase(string title)
        {
            Console.WriteLine("Oracle: createDatabase()");
        }

        public void deleteDatabase(string title)
        {
            Console.WriteLine("Oracle: deleteDatabase()");
        }

        public void connectDatabase(string title)
        {
            Console.WriteLine("Oracle: connectDatabase()");
        }

        public void reconnectDatabase(string title)
        {
            Console.WriteLine("Oracle: reconnectDatabase()");
        }

        public void disconnectDatabase(string title)
        {
            Console.WriteLine("Oracle: disconnectDatabase()");
        }

        public void createTable(string title)
        {
            Console.WriteLine("Oracle: createTable()");
        }

        public void reloadTable(string title)
        {
            Console.WriteLine("Oracle: reloadTable()");
        }

        public void dropTable(string title)
        {
            Console.WriteLine("Oracle: dropTable()");
        }

        public void renameTable(string title, string newTitle)
        {
            Console.WriteLine("Oracle: renameTable()");
        }

        public void createView(string title)
        {
            Console.WriteLine("Oracle: createView()");
        }
    }
}
