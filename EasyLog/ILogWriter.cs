using System.Collections.Generic;

namespace EasyLog
{
    /// <summary>
    /// Defines an interface for log writers
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Will be called by the owning log when there are enough lines to write.
        /// </summary>
        /// <param name="lines">The lines to write</param>
        /// <remarks>
        /// The individual lines will usually not end in a linebreak.
        /// </remarks>
        void Write(IEnumerable<string> lines);
    }
}
