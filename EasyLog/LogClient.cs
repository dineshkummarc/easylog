using System;

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
            owner.QueueWrite(this, Log.Level.Debug, message);
        }

        public void Debug(string message, object arg)
        {
            Debug(String.Format(message, arg));
        }

        public void Debug(string message, object arg1, object arg2)
        {
            Debug(String.Format(message, arg1, arg2));
        }

        public void Debug(string message, params object[] args)
        {
            Debug(String.Format(message, args));
        }

        public void Info(string message)
        {
            owner.QueueWrite(this, Log.Level.Info, message);
        }

        public void Info(string message, object arg)
        {
            Info(String.Format(message, arg));
        }

        public void Info(string message, object arg1, object arg2)
        {
            Info(String.Format(message, arg1, arg2));
        }

        public void Info(string message, params object[] args)
        {
            Info(String.Format(message, args));
        }

        public void Warn(string message)
        {
            owner.QueueWrite(this, Log.Level.Warning, message);
        }

        public void Warn(string message, object arg)
        {
            Warn(String.Format(message, arg));
        }

        public void Warn(string message, object arg1, object arg2)
        {
            Warn(String.Format(message, arg1, arg2));
        }

        public void Warn(string message, params object[] args)
        {
            Warn(String.Format(message, args));
        }

        public void Error(string message)
        {
            owner.QueueWrite(this, Log.Level.Error, message);
        }

        public void Error(string message, object arg)
        {
            Error(String.Format(message, arg));
        }

        public void Error(string message, object arg1, object arg2)
        {
            Error(String.Format(message, arg1, arg2));
        }

        public void Error(string message, params object[] args)
        {
            Error(String.Format(message, args));
        }

        public void Critical(string message)
        {
            owner.QueueWrite(this, Log.Level.Critical, message);
        }

        public void Critical(string message, object arg)
        {
            Critical(String.Format(message, arg));
        }

        public void Critical(string message, object arg1, object arg2)
        {
            Critical(String.Format(message, arg1, arg2));
        }

        public void Critical(string message, params object[] args)
        {
            Critical(String.Format(message, args));
        }

        #endregion

        #region Conditional Log Writer Methods

        public void DebugIf(string message, bool condition)
        {
            if (condition)
                Debug(message);
        }

        public void DebugIf(string message, bool condition, object arg)
        {
            if (condition)
                Debug(message, arg);
        }

        public void DebugIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Debug(message, arg1, arg2);
        }

        public void DebugIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Debug(message, args);
        }

        public void InfoIf(string message, bool condition)
        {
            if (condition)
                Info(message);
        }

        public void InfoIf(string message, bool condition, object arg)
        {
            if (condition)
                Info(message, arg);
        }

        public void InfoIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Info(message, arg1, arg2);
        }

        public void InfoIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Info(message, args);
        }

        public void WarnIf(string message, bool condition)
        {
            if (condition)
                Warn(message);
        }

        public void WarnIf(string message, bool condition, object arg)
        {
            if (condition)
                Warn(message, arg);
        }

        public void WarnIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Warn(message, arg1, arg2);
        }

        public void WarnIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Warn(message, args);
        }

        public void ErrorIf(string message, bool condition)
        {
            if (condition)
                Error(message);
        }

        public void ErrorIf(string message, bool condition, object arg)
        {
            if (condition)
                Error(message, arg);
        }

        public void ErrorIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Error(message, arg1, arg2);
        }

        public void ErrorIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Error(message, args);
        }

        public void CriticalIf(string message, bool condition)
        {
            if (condition)
                Critical(message);
        }

        public void CriticalIf(string message, bool condition, object arg)
        {
            if (condition)
                Critical(message, arg);
        }

        public void CriticalIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Critical(message, arg1, arg2);
        }

        public void CriticalIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Critical(message, args);
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
