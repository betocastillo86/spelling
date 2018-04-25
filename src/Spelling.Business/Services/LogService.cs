//-----------------------------------------------------------------------
// <copyright file="LogService.cs" company="Gabriel Castillo">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Spelling.Business.Services
{
    using System;
    using System.Threading.Tasks;
    using Beto.Core.Data;
    using Beto.Core.Exceptions;
    using Beto.Core.Helpers;
    using Microsoft.Extensions.Logging;
    using Spelling.Business.Security;
    using Spelling.Domain;

    /// <summary>
    /// Log Service
    /// </summary>
    /// <seealso cref="Beto.Core.Exceptions.ILoggerService" />
    public class LogService : ILoggerService
    {
        /// <summary>
        /// The HTTP context helper
        /// </summary>
        private readonly IHttpContextHelper httpContextHelper;

        /// <summary>
        /// The log repository
        /// </summary>
        private readonly IRepository<Log> logRepository;

        /// <summary>
        /// The work context
        /// </summary>
        private readonly IWorkContext workContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogService"/> class.
        /// </summary>
        /// <param name="logRepository">The log repository.</param>
        /// <param name="workContext">The work context.</param>
        /// <param name="httpContextHelper">The HTTP context helper.</param>
        public LogService(
            IRepository<Log> logRepository,
            IWorkContext workContext,
            IHttpContextHelper httpContextHelper)
        {
            this.logRepository = logRepository;
            this.workContext = workContext;
            this.httpContextHelper = httpContextHelper;
        }

        /// <summary>
        /// Inserts the specified short message.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        public void Insert(string shortMessage, string fullMessage = "")
        {
            this.Insert(shortMessage, fullMessage);
        }

        /// <summary>
        /// Inserts the specified short message.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="logLevel">The log level.</param>
        public void Insert(string shortMessage, string fullMessage = "", LogLevel logLevel = LogLevel.Error)
        {
            var log = this.GetLog(shortMessage, logLevel, fullMessage);
            this.logRepository.Insert(log);
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task InsertAsync(string shortMessage, string fullMessage = "")
        {
            await this.InsertAsync(shortMessage, fullMessage);
        }

        /// <summary>
        /// Inserts the asynchronous.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <param name="logLevel">The log level.</param>
        /// <returns>
        /// the task
        /// </returns>
        public async Task InsertAsync(string shortMessage, string fullMessage = "", LogLevel logLevel = LogLevel.Error)
        {
            var log = this.GetLog(shortMessage, logLevel, fullMessage);
            await this.logRepository.InsertAsync(log);
        }

        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <param name="shortMessage">The short message.</param>
        /// <param name="logLevel">The log level.</param>
        /// <param name="fullMessage">The full message.</param>
        /// <returns>the log</returns>
        private Log GetLog(string shortMessage, LogLevel logLevel, string fullMessage = "")
        {
            return new Log
            {
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                CreationDate = DateTime.UtcNow,
                LogLevel = logLevel,
                IpAddress = this.httpContextHelper.GetCurrentIpAddress(),
                UserId = this.workContext.CurrentUser?.Id,
                PageUrl = this.httpContextHelper.GetThisPageUrl(true)
            };
        }
    }
}