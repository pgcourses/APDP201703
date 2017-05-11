using System;

namespace _10Bridge1
{
    public class EmailService
    {
        private AbstractSendWith strategy;

        public EmailService(AbstractSendWith strategy)
        {
            this.strategy = strategy;
        }

        public void Send(EmailMessage message)
        {
            strategy.Send(message);
        }
    }
}