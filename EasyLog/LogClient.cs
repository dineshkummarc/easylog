using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyLog
{
    /// <summary>
    /// A LogClient that writes lines to a <see cref="Log"/>
    /// </summary>
    public class LogClient
    {
        readonly Log owner;
        readonly string name;

        /// <summary>
        /// Gets or sets the log <see cref="Level"/>
        /// </summary>
        /// <remarks>
        /// This sets a minimum log level for this clients. 
        /// Log entries with a lower priority than the one set
        /// will be ignored.
        /// </remarks>
        public Log.Level LogLevel { get; set; }

        /// <summary>
        /// The client's name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        #region Log Writer Methods

        public void Debug(string message)
        {
            throw new NotImplementedException();
        }

        #endregion

        internal LogClient(Log log, string name)
        {
            if (log == null)
                throw new ArgumentNullException("Owning Log must not be null.");
            if (name == null)
                throw new ArgumentNullException("Name must not be null.");

            owner = log;
            this.name = name;
        }
    }
}
