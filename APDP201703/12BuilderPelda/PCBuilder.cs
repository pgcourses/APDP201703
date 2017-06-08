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
            computer.Processor = Processor.x64;
            computer.OS = OS.Windows7;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
            computer.Applications = new List<string> { "MSSQL", "VisualStudio", "VLC" };
        }


        public Computer GetPC()
        {
            return computer;
        }
    }
}