using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.locationserver
{
    public class Logging
    {
        public Logging()
        { }

        public static void Log(string log, int severity = 0)
        {
            if (severity < 1)
            {
                Console.WriteLine("[{0} INFO] {1}", CurrentTime(), log);
            }
            else if (severity == 2)
            {
                Console.WriteLine("[{0} WARN] {1}", CurrentTime(), log);
            }
            else
            {
                Console.WriteLine("[{0} ERROR] {1}", CurrentTime(), log);
            }
        }

        private static string CurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
