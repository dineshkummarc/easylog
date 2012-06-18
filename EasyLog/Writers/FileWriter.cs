using System.Collections.Generic;
using IO = System.IO;

namespace EasyLog.Writers
{
    /// <summary>
    /// A log writer that writes to a file
    /// </summary>
    /// <remarks>
    /// The given file will be opened for writing at more or less random times (i.e. whenever <see cref="FileWriter.Write"/> is called.
    /// </remarks>
    public class FileWriter : ILogWriter
    {
        string file;

        /// <summary>
        /// Writes the given lines to a file
        /// </summary>
        /// <param name="lines"></param>
        public void Write(IEnumerable<string> lines)
        {
            using (var writer = new IO.StreamWriter(IO.File.Open(file, IO.FileMode.Append, IO.FileAccess.Write, IO.FileShare.Read)))
                foreach (var line in lines)
                    writer.WriteLine(line);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="file">The path of the file to write to</param>
        public FileWriter(string file)
        {
            this.file = file;
        }
    }
}
