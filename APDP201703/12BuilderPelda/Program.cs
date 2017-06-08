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
            var builder = new PCBuilderForWindows();

            builder.CreatePC();
            builder.BuildPC();
            var computer = builder.GetPC();

            computer.Display();

            Console.ReadLine();
        }

    }
}
