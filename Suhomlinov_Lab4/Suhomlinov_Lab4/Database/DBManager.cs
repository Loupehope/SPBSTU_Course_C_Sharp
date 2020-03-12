using System;
namespace Suhomlinov_Lab4
{
    public class DBManager
    {

        private readonly DatabaseInterface database;

        public DBManager(DatabaseInterface database)
        {
            if (database == null)
                throw new ArgumentNullException(nameof(database));

            this.database = database;
        }

        public void createDatabase(string title)
        {
            database.createDatabase(title);
        }

        public void deleteDatabase(string title)
        {
            database.deleteDatabase(title);
        }

        public void connectDatabase(string title)
        {
            database.connectDatabase(title);
        }

        public void reconnectDatabase(string title)
        {
            database.reconnectDatabase(title);
        }

        public void disconnectDatabase(string title)
        {
            database.disconnectDatabase(title);
        }

        public void createTable(string title)
        {
            database.createTable(title);
        }

        public void reloadTable(string title)
        {
            database.reloadTable(title);
        }

        public void dropTable(string title)
        {
            database.dropTable(title);
        }

        public void renameTable(string title, string newTitle)
        {
            database.renameTable(title, newTitle);
        }

        public void createView(string title)
        {
            database.createView(title);
        }
    }
}
