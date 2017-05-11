using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10Bridge1
{
    public abstract class AbstractMessageFactory
    {
        public abstract IPersonRepository RepositoryFactory();
        public abstract AbstractTemplating TemplateFactory();
        public abstract EmailService EmailServiceFactory();

    }
}

