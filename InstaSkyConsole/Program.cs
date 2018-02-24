using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaSharper.API;

namespace InstaSkyConsole
{
    class Program
    {
        private static IInstaApi _instaApi;

        static void Main(string[] args)
        {
            Log log = new Log();

            Login login = new Login(_instaApi);
            login.LoadAccountInfo();
            log.MessageToCOnsole("Load account info");
            login.LoginToInstagramAsync();

            Console.ReadKey();
        }
    }
}
