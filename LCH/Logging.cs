using System;
using System.IO;

namespace mullak99.ACW.NetworkACW.LCHLib
{
    public class Logging
    {
        private string _logPath = "";
        private bool _isDevMode = false;

        private TextWriter _secondaryOutput = null;

        /// <summary>
        /// Handles the logging of all messages to a log-file and/or console
        /// </summary>
        /// <param name="isDevMode">Whether to enable verbose logging</param>
        /// <param name="logPath">Path of the log file (Leave blank for no log file)</param>
        public Logging(bool isDevMode, string logPath = "")
        {
            _logPath = logPath;
            _isDevMode = isDevMode;
        }

        /// <summary>
        /// Sets if verbose logging is enabled
        /// </summary>
        /// <param name="isDevMode">Whether to enable verbose logging</param>
        public void SetDeveloperMode(bool isDevMode)
        {
            _isDevMode = isDevMode;
        }

        /// <summary>
        /// Gets if verbose logging is enabled
        /// </summary>
        /// <returns>Whether to enable verbose logging</returns>
        public bool GetDeveloperMode()
        {
            return _isDevMode;
        }

        /// <summary>
        /// Set secondary console output
        /// </summary>
        /// <param name="tw">Custom TextWriter</param>
        public void SetConsoleOut(TextWriter tw)
        {
            _secondaryOutput = tw;
        }

        /// <summary>
        /// Resets Console Output to default
        /// </summary>
        public void ResetConsoleOut()
        {
            _secondaryOutput = null;
        }

        /// <summary>
        /// Sets the logging path
        /// </summary>
        /// <param name="logPath">Path of the log file (Leave blank for no log file)</param>
        public void SetLogPath(string logPath)
        {
            _logPath = logPath;
        }

        /// <summary>
        /// Gets the logging path
        /// </summary>
        /// <returns>Path of the log file</returns>
        public string GetLogPath()
        {
            return _logPath;
        }

        /// <summary>
        /// Adds the desired string to the log
        /// </summary>
        /// <param name="log">Raw logging message</param>
        /// <param name="severity">Severity of the log (0=Debug, 1=Info, 2=Warn, 3=Error)</param>
        /// <param name="rawOutput">If output should be logged in its raw form (don't include severity prefixes)</param>
        public void Log(string log, int severity = 1, bool rawOutput = false)
        {
            if (_isDevMode)
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
                if (severity == 0 && _isDevMode)
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

        /// <summary>
        /// Internal Logging Handler
        /// </summary>
        /// <param name="log">Raw logging message</param>
        /// <param name="skipWriteLine">Skip writing line to console</param>
        /// <param name="skipFileAppend">Skip writing line to log file</param>
        private void IntLog(string log, bool skipWriteLine = false, bool skipFileAppend = false)
        {
            if (!skipWriteLine)
            {
                Console.WriteLine(log.TrimEnd('\r', '\n'));
                if (_secondaryOutput != null) _secondaryOutput.WriteLine(log.TrimEnd('\r', '\n'));
            }
            if (!String.IsNullOrEmpty(_logPath) && !skipFileAppend)
                File.AppendAllText(_logPath, log + Environment.NewLine);
        }

        /// <summary>
        /// Current Time (HH:mm:ss.FFF)
        /// </summary>
        /// <returns>Current time in 'HH:mm:ss.FFF' format</returns>
        private string CurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss.FFF");
        }
    }
}
