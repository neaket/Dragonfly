#define LOGGER_INFO
#define LOGGER_WARNING
#define LOGGER_DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indicle.Logging
{
    public partial class Logger
    {
        private string _name;
        
        public Logger(Type type) : this(type.FullName)
        {

        }

        public Logger(string name)
        {
            _name = name;
        }

        public void Info(string message)
        {
#if LOGGER_INFO
            write(LogType.Info, message);
#endif
        }

        public void InfoFormat(string format, params object[] args)
        {
#if LOGGER_INFO
            write(LogType.Info, String.Format(format, args));
#endif
        }


        public void Warning(string message)
        {
#if LOGGER_WARNING
            write(LogType.Warning, message);
#endif
        }

        public void WarningFormat(string format, params object[] args)
        {
#if LOGGER_WARNING
            write(LogType.Warning, String.Format(format, args));
#endif
        }


        public void Debug(string message)
        {
#if LOGGER_DEBUG
            write(LogType.Debug, message);
#endif
        }

        public void DebugFormat(string format, params object[] args)
        {
#if LOGGER_DEBUG
            write(LogType.Info, String.Format(format, args));
#endif
        }

        private void write(LogType logType, string message)
        {

            System.Diagnostics.Debug.WriteLine(String.Format("{0} [{1}] - {2} - {3}", logType.ToString(), DateTime.Now, _name, message));
        }

        private enum LogType 
        {
            Info,
            Warning,
            Debug
        
        }
    }
}
