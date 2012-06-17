using System.Collections.Generic;
using System.Diagnostics;

namespace EasyLog.Writers
{
    /// <summary>
    /// A Log Writer that writes to <see cref="System.Diagnostics.Debug"/>
    /// </summary>
    public class DebugWriter : ILogWriter
    {
        public void Write(IEnumerable<string> lines)
        {
            foreach (var line in lines)
                Debug.WriteLine(line);
        }
    }
}
