using System;
using System.Collections.Generic;

namespace _12BuilderPelda
{
    public class PCBuilder
    {
        private Computer computer;

        public void CreatePC()
        {
            computer = new Computer();
        }

        public void BuildPC()
        {
            BuildHardware();
            InstallOS();
            InstallApplications();
        }

        private void InstallApplications()
        {
            computer.Applications = new List<string> { "MSSQL", "VisualStudio", "VLC" };
        }

        private void InstallOS()
        {
            computer.OS = OS.Windows7;
        }

        private void BuildHardware()
        {
            computer.Processor = Processor.x64;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
        }

        public Computer GetPC()
        {
            return computer;
        }
    }
}