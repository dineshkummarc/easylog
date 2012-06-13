using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyLog.Formatters;

namespace EasyLog
{
    public class Log
    {
        List<ILogWriter> writers;

        public ILogFormatter Formatter { get; set; }

        public void AddBackend(ILogWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("backend", "The given log writer must not be null.");

            writers.Add(writer);
        }

        public Log()
        {
            writers = new List<ILogWriter>();
            Formatter = new DefaultFormatter();
        }

        public Log(IEnumerable<ILogWriter> writers)
            : this()
        {
            foreach(var writer in writers)
                AddBackend(writer);
        }

        public Log(params ILogWriter[] writers)
            : this(writers as IEnumerable<ILogWriter>)
        {
        }
    }
}
