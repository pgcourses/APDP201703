using System;

namespace _12BuilderPelda
{
    public class PcDirectorForNormalPCWithoutApplications : AbstractPCDirector
    {
        public PcDirectorForNormalPCWithoutApplications(AbstractPCBuilder builder) 
            : base(builder)
        { }

        public override void BuildPC()
        {
            builder.BuildHardware();
            builder.InstallOS();
        }
    }
}