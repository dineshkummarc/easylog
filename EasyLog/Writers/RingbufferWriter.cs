using System;
using System.Collections.Generic;

namespace EasyLog.Writers
{
    /// <summary>
    /// A log writer that writes to a ringbuffer
    /// </summary>
    /// <remarks>
    /// This log writer will not save logged information permanently.
    /// With a ringbuffer size of N, it will only save the latest N entries.
    /// </remarks>
    public class RingbufferWriter : ILogWriter
    {
        /// <summary>
        /// The default size of the ringbuffer.
        /// </summary>
        public const int DefaultSizeLimit = 50;

        int sizeLimit;
        Queue<string> buffer;

        /// <summary>
        /// Gets or sets the size of the ringbuffer.
        /// </summary>
        public int SizeLimit
        {
            get { return sizeLimit; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The given value cannot be smaller than 1.", "value");
                sizeLimit = value;
                buffer.TrimExcess();
            }
        }

        /// <summary>
        /// Writes the given lines to the buffer
        /// </summary>
        /// <param name="lines"></param>
        public void Write(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                buffer.Enqueue(line);
                if (buffer.Count > SizeLimit)
                    buffer.Dequeue();
            }
        }

        /// <summary>
        /// Gets the log entries saved in the buffer, from newest to oldest.
        /// </summary>
        /// <returns>Returns the log entries in the buffer.</returns>
        public IEnumerable<string> GetEntries()
        {
            return buffer;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public RingbufferWriter()
        {
            buffer = new Queue<string>(DefaultSizeLimit);
            SizeLimit = DefaultSizeLimit;
        }
    }
}
