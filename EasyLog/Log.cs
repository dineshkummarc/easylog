using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace EasyLog
{
    public class Log
    {
        /// <summary>
        /// Implements a collection of log writers
        /// </summary>
        public sealed class LogWriterCollection : Collection<ILogWriter>
        {
        }

        /// <summary>
        /// A log severity level
        /// </summary>
        public enum Level
        {
            /// <summary>
            /// No log level
            /// </summary>
            None = 0,

            /// <summary>
            /// Debug information
            /// </summary>
            Debug = 1,

            /// <summary>
            /// Information
            /// </summary>
            Info = 2,

            /// <summary>
            /// Warnings
            /// </summary>
            Warning = 3,

            /// <summary>
            /// Errors
            /// </summary>
            Error = 4,

            /// <summary>
            /// Critical errors
            /// </summary>
            Critical = 5,
        }

        /// <summary>
        /// The default value for <see cref="MaxQueuedItems"/>
        /// </summary>
        public const int DefaultMaxQueuedItems = 10;

        readonly List<LogClient> clients;
        readonly ConcurrentQueue<Tuple<LogClient, DateTime, Level, string>> queuedWrites;

        /// <summary>
        /// Gets or sets the log <see cref="Level"/>
        /// </summary>
        /// <remarks>
        /// This sets a minimum log level for all clients. 
        /// Log entires from clients with a lower priority 
        /// than the one sety will be ignored.
        /// </remarks>
        public Level LogLevel { get; set; }

        /// <summary>
        /// The threshold after which the log queue will be cleared.
        /// </summary>
        public int MaxQueuedItems { get; set; }

        /// <summary>
        /// The log writers connected to this log
        /// </summary>
        public LogWriterCollection Writers { get; private set; }

        IEnumerable<Tuple<LogClient, DateTime, Level, string>> Consume()
        {
            Tuple<LogClient, DateTime, Level, string> result;
            while (queuedWrites.TryDequeue(out result))
                yield return result;
        }

        void WriteQueuedLines()
        {
            lock (Writers)
            {
                Func<Tuple<LogClient, DateTime, Level, string>, string> Format = (tuple) =>
                {
                    if (!String.IsNullOrWhiteSpace(tuple.Item1.Name))
                        return String.Join(" - ", tuple.Item2, tuple.Item1.Name, tuple.Item3, tuple.Item4);
                    else
                        return String.Join(" - ", tuple.Item2, tuple.Item3, tuple.Item4);
                };

                var lines = from queuedLine in Consume()
                            select Format(queuedLine);
                foreach (var writer in Writers)
                    writer.Write(lines);
            }
        }

        /// <summary>
        /// Queues a log write from a client
        /// </summary>
        internal void QueueWrite(LogClient client, Level level, string line)
        {
            if ((int)level >= (int)LogLevel)
                queuedWrites.Enqueue(Tuple.Create(client, DateTime.Now, level, line));

            if (queuedWrites.Count > MaxQueuedItems)
            {
                Task.Factory.StartNew(() =>
                {
                    WriteQueuedLines();
                });
            }
        }

        /// <summary>
        /// Immediately empty the log queue and write back all queued lines
        /// </summary>
        public void Flush()
        {
            WriteQueuedLines();
        }

        /// <summary>
        /// Gets the default log client.
        /// </summary>
        /// <returns>Returns the default log client.</returns>
        /// <remarks>
        /// The default log client has no name.
        /// </remarks>
        public LogClient GetDefaultClient()
        {
            return GetClient(string.Empty);
        }

        /// <summary>
        /// Gets a log client by name or creates a new one if it does not yet exist.
        /// </summary>
        /// <param name="name">The name of the client</param>
        /// <returns>Returns the log client</returns>
        public LogClient GetClient(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
                name = string.Empty;

            var index = clients.FindIndex((n) => n.Name == name);
            if (index >= 0)
                return clients[index];
            else
            {
                var client = new LogClient(this, name);
                clients.Add(client);
                return client;
            }
        }

        /// <summary>
        /// Constructs a new Log.
        /// </summary>
        public Log()
        {
            Writers = new LogWriterCollection();
            clients = new List<LogClient>();
            queuedWrites = new ConcurrentQueue<Tuple<LogClient, DateTime, Level, string>>();
            MaxQueuedItems = DefaultMaxQueuedItems;
        }
    }
}
