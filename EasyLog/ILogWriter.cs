using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyLog
{
    public interface ILogWriter
    {
        void Write(string line);

        IEnumerable<string> ReadLines();
    }
}
