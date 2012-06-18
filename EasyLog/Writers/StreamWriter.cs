using System;
using System.Collections.Generic;
using IO = System.IO;

namespace EasyLog.Writers
{
    /// <summary>
    /// Log writer that writes to a stream
    /// </summary>
    /// <remarks>
    /// The given stream has to be writable and must not be closed unexpectedly.
    /// </remarks>
    public class StreamWriter : ILogWriter, IDisposable
    {
        IO.StreamWriter stream;

        #region IDisposable

        bool disposed;

        /// <summary>
        /// Closes the StreamWriter's stream
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (stream != null)
                        stream.Dispose();
                }
                stream = null;
                disposed = true;
            }
        }

        #endregion

        /// <summary>
        /// Writes the given lines to a stream
        /// </summary>
        /// <param name="lines"></param>
        public void Write(IEnumerable<string> lines)
        {
            foreach (var line in lines)
                stream.WriteLine(line);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">The stream </param>
        public StreamWriter(IO.Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream", "The given stream must not be null.");
            if (!stream.CanWrite)
                throw new ArgumentException("The given stream must be writable.", "stream");

            this.stream = new IO.StreamWriter(stream);
        }
    }
}
