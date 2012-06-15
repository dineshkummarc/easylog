using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyLog
{
    public class Log
    {
        /// <summary>
        /// A log severity level
        /// </summary>
        public enum Level
        {
            /// <summary>
            /// No log level
            /// </summary>
            None,

            /// <summary>
            /// Debug information
            /// </summary>
            Debug,

            /// <summary>
            /// Information
            /// </summary>
            Info,

            /// <summary>
            /// Warnings
            /// </summary>
            Warning,

            /// <summary>
            /// Errors
            /// </summary>
            Error,

            /// <summary>
            /// Critical errors
            /// </summary>
            Critical,
        }

        List<ILogWriter> writers;
        List<LogClient> clients;

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
        /// Queues a log write from a client
        /// </summary>
        internal void QueueWrite()
        {
            throw new NotImplementedException();
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
            if (name == null)
                return GetDefaultClient();

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
        /// Add a backend to the log
        /// </summary>
        /// <param name="writer">The log writer to add</param>
        public void AddBackend(ILogWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("backend", "The given log writer must not be null.");

            writers.Add(writer);
        }

        public Log()
        {
            writers = new List<ILogWriter>();
            clients = new List<LogClient>();
        }

        public Log(IEnumerable<ILogWriter> writers)
            : this()
        {
            foreach(var writer in writers)
                AddBackend(writer);
        }

        public Log(params ILogWriter[] writers)
            : this(writers as IEnumerable<ILogWriter>)
        {
        }
    }
}
