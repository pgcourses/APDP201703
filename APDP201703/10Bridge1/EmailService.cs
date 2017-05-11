using System;

namespace _10Bridge1
{
    public class EmailService
    {
        private ISendWith strategy;

        public EmailService(ISendWith strategy)
        {
            this.strategy = strategy;
        }

        public void Send(EmailMessage message)
        {
            strategy.Send(message);
        }
    }
}