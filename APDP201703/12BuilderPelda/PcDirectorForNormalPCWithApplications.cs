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
    public class PcDirectorForNormalPCWithApplications : AbstractPCDirector
    {
        public PcDirectorForNormalPCWithApplications(AbstractPCBuilder builder) 
            : base(builder)
        { }

        public override void BuildPC()
        {
            builder.BuildHardware();
            builder.InstallOS();
            builder.InstallApplications();
        }

    }
}
