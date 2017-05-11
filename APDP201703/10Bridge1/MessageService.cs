using System;

namespace _10Bridge1
{
    public class MessageService
    {
        private IPersonRepository repo;
        private EmailService service;
        private Templating template;

        public MessageService(EmailService service, IPersonRepository repo, Templating template)
        {
            this.service = service;
            this.repo = repo;
            this.template = template;
        }

        public void Run()
        {
            var person = repo.GetBirthdayPersons();
            var message = template.GetMessageFor(person);
            service.Send(message);
        }
    }
}