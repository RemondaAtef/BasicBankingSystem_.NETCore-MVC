using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPPproject2.Services
{
    public class NullMailService : IMailService
    {
        private readonly ILogger<NullMailService> logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            this.logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {
            // log the message
            this.logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }
    }
}
