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

            var director = new NormalPcDirector(new PCBuilderForWindows());

            director.BuildPC();
            var computer = director.GetPC();

            computer.Display();

            Console.ReadLine();
        }

    }
}
