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

            var director1 = new PcDirectorForNormalPCWithApplications(new PCBuilderForWindows());
            director1.BuildPC();
            var computer1 = director1.GetPC();
            computer1.Display();

            var director2 = new PcDirectorForNormalPCWithoutApplications(new PCBuilderForLinux());
            director2.BuildPC();
            var computer2 = director2.GetPC();
            computer2.Display();


            Console.ReadLine();
        }

    }
}
