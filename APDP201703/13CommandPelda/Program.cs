using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13CommandPelda
{
    /// <summary>
    /// Ebben a példában egy parancssori alkalmazást készítünk, 
    /// "megrendelést" dolgoz fel (persze a végletekig leegyszerűsített módon)
    /// ami a parancssorról vár bemenetet
    /// és a következő lehetőségeket biztosítja:
    /// 
    ///  - új (megrendelés) felvitele
    ///  - meglévő törlése
    ///  - meglévő módosítása
    ///  - ha nem adunk meg semmit, akkor kiírja a használati útmutatót
    ///  - ha pedig rossz parancsot adunk meg, akkor jelzi, hogy ismeretlen a parancs
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //írhatnánk ide parancsértelmezőt, de ekkor minden lépést kézzel kellene tesztelni.
            //ezért aztán helyette teszteket fogunk írni, és az alkalmazást egy osztályba fogjuk 
            //becsomagolni

            var alkalmazas = new Alkalmazas();
            var eredmeny = alkalmazas.Bevitel(args);
            Console.WriteLine(eredmeny);

            Console.ReadLine();

        }
    }
}
