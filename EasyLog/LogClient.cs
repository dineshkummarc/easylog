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
        /// Gets or sets the log <see cref="Log.Level"/>
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

        /// <summary>
        /// Logs a debug level message
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Debug(string message)
        {
            owner.QueueWrite(this, Log.Level.Debug, message);
        }

        /// <summary>
        /// Logs a debug level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg">The first and only argument</param>
        public void Debug(string message, object arg)
        {
            Debug(String.Format(message, arg));
        }

        /// <summary>
        /// Logs a debug level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        public void Debug(string message, object arg1, object arg2)
        {
            Debug(String.Format(message, arg1, arg2));
        }

        /// <summary>
        /// Logs a debug level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments</param>
        public void Debug(string message, params object[] args)
        {
            Debug(String.Format(message, args));
        }

        /// <summary>
        /// Logs a info level message
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Info(string message)
        {
            owner.QueueWrite(this, Log.Level.Info, message);
        }

        /// <summary>
        /// Logs a info level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg">The first and only argument</param>
        public void Info(string message, object arg)
        {
            Info(String.Format(message, arg));
        }

        /// <summary>
        /// Logs a info level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        public void Info(string message, object arg1, object arg2)
        {
            Info(String.Format(message, arg1, arg2));
        }

        /// <summary>
        /// Logs a info level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments</param>
        public void Info(string message, params object[] args)
        {
            Info(String.Format(message, args));
        }

        /// <summary>
        /// Logs a warning level message
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Warn(string message)
        {
            owner.QueueWrite(this, Log.Level.Warning, message);
        }

        /// <summary>
        /// Logs a warning level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg">The first and only argument</param>
        public void Warn(string message, object arg)
        {
            Warn(String.Format(message, arg));
        }

        /// <summary>
        /// Logs a warning level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        public void Warn(string message, object arg1, object arg2)
        {
            Warn(String.Format(message, arg1, arg2));
        }

        /// <summary>
        /// Logs a warning level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments</param>
        public void Warn(string message, params object[] args)
        {
            Warn(String.Format(message, args));
        }

        /// <summary>
        /// Logs a error level message
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Error(string message)
        {
            owner.QueueWrite(this, Log.Level.Error, message);
        }

        /// <summary>
        /// Logs a error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg">The first and only argument</param>
        public void Error(string message, object arg)
        {
            Error(String.Format(message, arg));
        }

        /// <summary>
        /// Logs a error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        public void Error(string message, object arg1, object arg2)
        {
            Error(String.Format(message, arg1, arg2));
        }

        /// <summary>
        /// Logs a error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments</param>
        public void Error(string message, params object[] args)
        {
            Error(String.Format(message, args));
        }

        /// <summary>
        /// Logs a critical error level message
        /// </summary>
        /// <param name="message">The message to log</param>
        public void Critical(string message)
        {
            owner.QueueWrite(this, Log.Level.Critical, message);
        }

        /// <summary>
        /// Logs a critical error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg">The first and only argument</param>
        public void Critical(string message, object arg)
        {
            Critical(String.Format(message, arg));
        }

        /// <summary>
        /// Logs a critical error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        public void Critical(string message, object arg1, object arg2)
        {
            Critical(String.Format(message, arg1, arg2));
        }

        /// <summary>
        /// Logs a critical error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="args">The arguments</param>
        public void Critical(string message, params object[] args)
        {
            Critical(String.Format(message, args));
        }

        #endregion

        #region Conditional Log Writer Methods

        /// <summary>
        /// Writes a conditional debug level message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void DebugIf(string message, bool condition)
        {
            if (condition)
                Debug(message);
        }

        /// <summary>
        /// Writes a conditional debug level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg">The first and only argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void DebugIf(string message, bool condition, object arg)
        {
            if (condition)
                Debug(message, arg);
        }

        /// <summary>
        /// Writes a conditional debug level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void DebugIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Debug(message, arg1, arg2);
        }

        /// <summary>
        /// Writes a conditional debug level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="args">The arguments</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void DebugIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Debug(message, args);
        }

        /// <summary>
        /// Writes a conditional info level message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void InfoIf(string message, bool condition)
        {
            if (condition)
                Info(message);
        }

        /// <summary>
        /// Writes a conditional info level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg">The first and only argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void InfoIf(string message, bool condition, object arg)
        {
            if (condition)
                Info(message, arg);
        }

        /// <summary>
        /// Writes a conditional info level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void InfoIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Info(message, arg1, arg2);
        }

        /// <summary>
        /// Writes a conditional info level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="args">The arguments</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void InfoIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Info(message, args);
        }

        /// <summary>
        /// Writes a conditional warning level message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void WarnIf(string message, bool condition)
        {
            if (condition)
                Warn(message);
        }

        /// <summary>
        /// Writes a conditional warning level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg">The first and only argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void WarnIf(string message, bool condition, object arg)
        {
            if (condition)
                Warn(message, arg);
        }

        /// <summary>
        /// Writes a conditional warning level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void WarnIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Warn(message, arg1, arg2);
        }

        /// <summary>
        /// Writes a conditional warning level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="args">The arguments</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void WarnIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Warn(message, args);
        }

        /// <summary>
        /// Writes a conditional error level message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void ErrorIf(string message, bool condition)
        {
            if (condition)
                Error(message);
        }

        /// <summary>
        /// Writes a conditional error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg">The first and only argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void ErrorIf(string message, bool condition, object arg)
        {
            if (condition)
                Error(message, arg);
        }

        /// <summary>
        /// Writes a conditional error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void ErrorIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Error(message, arg1, arg2);
        }

        /// <summary>
        /// Writes a conditional error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="args">The arguments</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void ErrorIf(string message, bool condition, params object[] args)
        {
            if (condition)
                Error(message, args);
        }

        /// <summary>
        /// Writes a conditional critical error level message
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void CriticalIf(string message, bool condition)
        {
            if (condition)
                Critical(message);
        }

        /// <summary>
        /// Writes a conditional critical error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg">The first and only argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void CriticalIf(string message, bool condition, object arg)
        {
            if (condition)
                Critical(message, arg);
        }

        /// <summary>
        /// Writes a conditional critical error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="arg1">The first argument</param>
        /// <param name="arg2">The second argument</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
        public void CriticalIf(string message, bool condition, object arg1, object arg2)
        {
            if (condition)
                Critical(message, arg1, arg2);
        }

        /// <summary>
        /// Writes a conditional critical error level message with formatting
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="condition">The condition to check</param>
        /// <param name="args">The arguments</param>
        /// <remarks>
        /// The message will only be logged if the <paramref name="condition"/> argument evaluates to 'true'
        /// </remarks>
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
