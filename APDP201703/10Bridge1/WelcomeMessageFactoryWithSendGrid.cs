using Ninject;

namespace _10Bridge1
{
    public class WelcomeMessageFactoryWithSendGrid : AbstractMessageFactory
    {
        private readonly StandardKernel kernel;

        //var send = AbstractSendWith.Factory<SendWithExchange>();
        //var service = new EmailService(send);
        //var repo = kernel.Get<IPersonRepository>();
        //var template = new Templating();
        public WelcomeMessageFactoryWithSendGrid()
        {
            kernel = new StandardKernel();
            kernel.Bind<IPersonRepository>()
                  .To<PersonRepositoryTestData>()
                  //.To<PersonRepositorySimpleData>()
                  .InSingletonScope();
        }

        public override IPersonRepository RepositoryFactory()
        {
            return kernel.Get<IPersonRepository>();
        }

        public override AbstractTemplating TemplateFactory()
        {
            return new WelcomeTemplating();
        }

        public override EmailService EmailServiceFactory()
        {
            var send = AbstractSendWith.Factory<SendWithSendGrid>();
            return new EmailService(send);
        }
    }
}