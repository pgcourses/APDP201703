namespace _10Bridge1
{
    internal class EmailServiceProxy : EmailService
    {
        private EmailService service;

        public EmailServiceProxy(EmailService service, AbstractSendWith sendWith) 
            : base(sendWith)
        {
            this.service = service;
        }

        public new void Send(EmailMessage message)
        {
            //Itt tudunk jogosultságot ellenőrizni,
            //vagy cache-t implementálni

            service.Send(message);
        }
    }
}