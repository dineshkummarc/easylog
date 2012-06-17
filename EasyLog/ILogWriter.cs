using System.Collections.Generic;

namespace EasyLog
{
    /// <summary>
    /// Defines an interface for log writers
    /// </summary>
    public interface ILogWriter
    {
        void Write(IEnumerable<string> line);
    }
}
