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
            var builder1 = new PCBuilderForWindows();

            builder1.CreatePC();
            builder1.BuildPC();
            var computer1 = builder1.GetPC();

            computer1.Display();

            var builder2 = new PCBuilderForLinux();

            builder2.CreatePC();
            builder2.BuildPC();
            var computer2 = builder2.GetPC();

            computer2.Display();

            Console.ReadLine();
        }

    }
}
