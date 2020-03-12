using System;
namespace Suhomlinov_Lab4
{

    public interface DBConfigInterface
    {

        public string name { get; set; }

        public string login { get; set; }

        public string password { get; set; }

        public string hostname { get; set; }

        public int port { get; set; }

        public string sid { get; set; }
    }
}
