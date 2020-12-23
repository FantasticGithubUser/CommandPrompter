using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CommandPrompterServer.Helpers
{
    public class SimpleFileLogger : ILogger
    {
        private IConfiguration _configuration { get; set; }
        private static SimpleFileLogger Instance = null;
        public SimpleFileLogger()
        {
            if (Instance == null)
            {
                //logPosition = _configuration["LogPosition"];
                Instance = this;
            }
        }
        
        private static object locker = new object();
        private static Stack<string> logCache = new Stack<string>();
        private static string logPosition;
        public void Log(string message)
        {
            logPosition = _configuration["LogPosition"];
            Instance.WriteToFile(message);
        }

        private void WriteToFile(string message)
        {
            lock (locker)
            {
                var str = "";
                logCache.Push(message);
                while(logCache.Count != 0)
                {
                    str = logCache.Peek();
                    try
                    {
                        File.AppendAllText(logPosition, $"{DateTime.Now}: {message}\n");
                        logCache.Pop();
                    }catch(IOException es)
                    {
                        //The file has been occupied.
                        logCache.Push(es.ToString());
                    }
                }
                
            }
        }
    }
}
