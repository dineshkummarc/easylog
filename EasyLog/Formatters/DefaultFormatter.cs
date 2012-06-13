using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyLog.Formatters
{
    public class DefaultFormatter : ILogFormatter
    {
        public string Format(string line, IEnumerable<object> parameters)
        {
            return string.Format(line, parameters);
        }
    }
}
