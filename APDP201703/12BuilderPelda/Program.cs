using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12BuilderPelda
{
    /// <summary>
    /// Az ÉPÍTŐ minta
    /// 
    /// Ennek a példának a lényege, hogy számítógépeket fogunk "összeszerelni":
    /// vagyis különböző konfigurációink vannak, és ezeknek a konfigurációk létrehozásához
    /// készítünk induló kódot
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var computer = new Computer();

            computer.Processor = Processor.x64;
            computer.OS = OS.Windows7;
            computer.HDD = 120;
            computer.HasDVD = true;
            computer.HasSoundCard = true;
            computer.HasUSB = true;
            computer.Applications = new List<string> { "MSSQL", "VisualStudio", "VLC" };
            computer.Display();

            Console.ReadLine();
        }
    }
}
