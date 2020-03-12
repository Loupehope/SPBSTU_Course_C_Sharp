using System;

namespace Suhomlinov_Lab4
{

    public interface DatabaseInterface
    {

        public DBConfigInterface config { get; set; }

        public void createDatabase(string title);

        public void deleteDatabase(string title);

        public void connectDatabase(string title);

        public void reconnectDatabase(string title);

        public void disconnectDatabase(string title);

        public void createTable(string title);

        public void reloadTable(string title);

        public void dropTable(string title);

        public void renameTable(string title, string newTitle);

        public void createView(string title);
    }
}