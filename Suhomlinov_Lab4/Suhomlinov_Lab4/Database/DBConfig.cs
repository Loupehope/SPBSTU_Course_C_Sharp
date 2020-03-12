using System;
namespace Suhomlinov_Lab4
{

    public class DBConfig: DBConfigInterface
    {

        public string name { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public string hostname { get; set; }

        public int port { get; set; }

        public string sid { get; set; }

        public DBConfig()
        {
            this.name = String.Empty;
            this.login = String.Empty;
            this.password = String.Empty;
            this.hostname = String.Empty;
            this.port = 0;
            this.sid = String.Empty;
        }

        public DBConfig(string name, string login, string password, string hostname, int port, string sid)
        {
            this.name = name;
            this.login = login;
            this.password = password;
            this.hostname = hostname;
            this.port = port;
            this.sid = sid;
        }
    }
}
