using System;

namespace _10Bridge1
{
    public class MessageService
    {
        private AbstractMessageFactory messageFactory;
        private IPersonRepository repo;
        private EmailService service;
        private AbstractTemplating template;

        public MessageService(AbstractMessageFactory messageFactory)
        {
            this.messageFactory = messageFactory;
            this.service = messageFactory.EmailServiceFactory();
            this.repo = messageFactory.RepositoryFactory();
            this.template = messageFactory.TemplateFactory();
        }

        public void Run()
        {
            var persons = repo.GetPersonForMessages();
            foreach (var person in persons)
            {
                var message = template.GetMessageFor(person);
                service.Send(message);
                Console.WriteLine();
            }
        }
    }
}