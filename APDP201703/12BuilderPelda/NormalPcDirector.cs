using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12BuilderPelda
{
    /// <summary>
    /// A létrehozás magasabb színtű vezérlője, 
    /// a builder lépéseit irányítja
    /// </summary>
    public class NormalPcDirector
    {
        private AbstractPCBuilder builder;

        public NormalPcDirector(AbstractPCBuilder builder)
        {
            this.builder = builder;
        }

        public void BuildPC()
        {
            builder.CreatePC();
            builder.BuildHardware();
            builder.InstallOS();
            builder.InstallApplications();
        }

        public Computer GetPC()
        {
            return builder.GetPC();
        }
    }
}
