using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyLog
{
    public interface ILogFormatter
    {
        string Format(string line, IEnumerable<object> parameters);
    }
}
