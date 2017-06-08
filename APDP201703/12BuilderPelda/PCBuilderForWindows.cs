using System;
using System.Collections.Generic;

namespace _12BuilderPelda
{
    public class PCBuilderForWindows : AbstractPCBuilder
    {

        public override void InstallApplications()
        {
            computer.Applications = new List<string> { "MSSQL", "VisualStudio", "VLC" };
        }

        public override void InstallOS()
        {
            computer.OS = OS.Windows7;
        }

        public override void BuildHardware()
        {
            computer.Processor = Processor.x64;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
        }
    }
}