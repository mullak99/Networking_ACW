﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.location
{
    public class Logging
    {
        public Logging()
        { }

        public static void Log(string log, int severity = 1)
        {
            if (severity == 0 && Program.GetDebug())
            {
                Console.WriteLine("[{0} DEBUG] {1}", CurrentTime(), log);
            }
            if (severity == 1)
            {
                Console.WriteLine("[{0} INFO] {1}", CurrentTime(), log);
            }
            else if (severity == 2)
            {
                Console.WriteLine("[{0} WARN] {1}", CurrentTime(), log);
            }
            else if (severity == 3)
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
