using System.Collections.Generic;
using System.IO;

namespace EasyLog.Writers
{
    public class FileWriter : ILogWriter
    {
        string file;

        public void Write(IEnumerable<string> lines)
        {
            using(var writer = new StreamWriter(File.Open(file, FileMode.Append, FileAccess.Write, FileShare.Read)))
                foreach(var line in lines)
                    writer.WriteLine(line);
        }

        public FileWriter(string file)
        {
            this.file = file;
        }
    }
}
