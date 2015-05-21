using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace Ccom.Common.Utils
{
    //LogManager log = new LogManager(logpath);
    //LogManager.AddToLog(ex.Message);
    public class LogManager
    {
        private static readonly Stack<string> logs = new Stack<string>();
        private string LogFile = string.Empty;

        public LogManager(string path)
        {
            try
            {
                LogFile = path + "\\ErrorLog.txt";
                if (!File.Exists(LogFile))
                {
                    File.Create(LogFile).Close();
                }

                Timer _timer = new Timer(20000);
                _timer.Elapsed += _timer_Elapsed;
                _timer.Start();
            }
            catch
            {
            }
        }

        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                while (logs.Count > 0)
                {
                    string logmsg = logs.Pop();
                    //var strm = File.OpenWrite(LogFile);
                    List<string> line = new List<string>();
                    line.Add(DateTime.Now.ToString() + "|" + logmsg + "\n");
                    File.AppendAllLines(LogFile, line, Encoding.Default);
                }
            }
            catch
            {
            }
        }

        public static void AddToLog(string text)
        {
            logs.Push(text);
        }
    }
}
