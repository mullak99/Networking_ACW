using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mullak99.ACW.NetworkACW.LCHLib
{
    public class Logging
    {
        private string _logPath = "";
        private bool _isDebug = false;

        public Logging(bool isDebugMode, string logPath = "")
        {
            _logPath = logPath;
            _isDebug = isDebugMode;
        }

        public void Log(string log, int severity = 1, bool rawOutput = false)
        {
            if (_isDebug)
            {
                if (severity == 0)
                {
                    IntLog(String.Format("[{0} DEBUG] {1}", CurrentTime(), log));
                }
                if (severity == 1)
                {
                    IntLog(String.Format("[{0} INFO] {1}", CurrentTime(), log));
                }
                else if (severity == 2)
                {
                    IntLog(String.Format("[{0} WARN] {1}", CurrentTime(), log));
                }
                else if (severity == 3)
                {
                    IntLog(String.Format("[{0} ERROR] {1}", CurrentTime(), log));
                }
            }
            else
            {
                if (rawOutput) IntLog(log, false, true);
                if (severity == 0 && _isDebug)
                {
                    IntLog(String.Format("[{0} DEBUG] {1}", CurrentTime(), log), rawOutput);
                }
                if (severity == 1)
                {
                    IntLog(String.Format("[{0} INFO] {1}", CurrentTime(), log), rawOutput);
                }
                else if (severity == 2)
                {
                    IntLog(String.Format("[{0} WARN] {1}", CurrentTime(), log), rawOutput);
                }
                else if (severity == 3)
                {
                    IntLog(String.Format("[{0} ERROR] {1}", CurrentTime(), log), rawOutput);
                }
            }
            
        }

        private void IntLog(string log, bool skipWriteLine = false, bool skipFileAppend = false)
        {
            if (!skipWriteLine) Console.WriteLine(log.TrimEnd('\r', '\n'));
            if (!String.IsNullOrEmpty(_logPath) && !skipFileAppend)
                File.AppendAllText(_logPath, log + Environment.NewLine);
        }

        private string CurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss.FFF");
        }
    }
}
