using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12BuilderPelda
{
    public class PCBuilderForLinux : AbstractPCBuilder
    {
        public override void BuildHardware()
        {
            computer.Processor = Processor.amd64;
            computer.HasSoundCard = false;
            computer.HasDVD = false;
            computer.HDD = 240;
            computer.HasUSB = true;
        }

        public override void InstallApplications()
        {
            computer.Applications = new List<string> { "Firefox", "Thunderbird", "VLC", "Visual Studio Code" };
        }

        public override void InstallOS()
        {
            computer.OS = OS.Ubuntu16_10;
        }
    }
}
