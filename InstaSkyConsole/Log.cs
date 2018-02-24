using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace InstaSkyConsole
{
    class Log
    {
        public void MessageToCOnsole(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss") + " " + message);
        }

        internal void MessageToCOnsole()
        {
            throw new NotImplementedException();
        }
    }
}
