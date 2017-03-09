using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Strategy
{
    /// <summary>
    /// A feladat: különböző algoritmusok beépítése a rendszerbe
    /// - kérjük le, hogy hány e-mail-t küldtünk már eddig
    /// - kérdezzük, hogy átlagosan hány e-mailt küldtünk egy-egy címzettnek
    /// - e-mail küldés csak egy meghatározott csoportnak
    /// - az üzenet szövege plain text legyen
    /// - az elküldött üzenet html legyen
    /// - ...
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Nem jó megoldások

            var service = new DataService(new AddressStrategyTestRepo());

            //kérjük le, hogy hány e-mail-t küldtünk már eddig

            var count = service.GetSumEmailCount();
            Console.WriteLine("E-mail-ek összes száma: {0}", count);

            /// - kérdezzük, hogy átlagosan hány e-mailt küldtünk egy-egy címzettnek
            var avg = service.GetAvgEmailCount();
            Console.WriteLine("E-mail-ek átlagos száma: {0}", avg);
            Console.WriteLine();

            count = service.Report(ReportType.Sum);
            Console.WriteLine("E-mail-ek összes száma: {0}", count);
            Console.WriteLine();

            /// - kérdezzük, hogy átlagosan hány e-mailt küldtünk egy-egy címzettnek
            avg = service.Report(ReportType.Average);
            Console.WriteLine("E-mail-ek átlagos száma: {0}", avg);

            var service2 = new DataService2(new AddressStrategyTestRepo());
            count = service2.Report(ReportType.Sum);
            Console.WriteLine("E-mail-ek összes száma (VIP): {0}", count);
            Console.WriteLine();
            //nem jó megoldások vége

            //Jó megoldások: Stratégia minta
            //////////////////////////////////////////////////////////////////////////////////

            var service3 = new DataService(new AddressStrategyTestRepo(), new SumStrategy());

            //lehet ilyet implementálni, csak a null értékekre figyelni kell
            //service3.SetStrategy(new SumStrategy());

            count = service3.ReportWithStrategy();

            Console.WriteLine("E-mail-ek összes száma: {0}", count);
            Console.WriteLine();

            //ilyet is lehetne implementálni, szintén a nullre figyelni
            //count = service3.ReportWithStrategy(new AvgStrategy());

            //////////////////////////////////////////////////////////////////////
            //A nehéztüzérség: .NET
            /////////////////////////////////////////////////////////////////////
            Console.WriteLine("E-mail-ek összes száma: {0}", service.ReportWithDelegate(
                list =>
                {
                    var sum = 0;
                    foreach (var addr in list)
                    {
                        sum += addr.EmailCount;
                    }

                    return sum;
                }
            ));
            Console.WriteLine("E-mail-ek átlagos száma: {0}", service.ReportWithDelegate( 
                list => (int)list.Average(x => x.EmailCount) //Ő a stratégiát leíró delegate
            ));
            Console.WriteLine();


            Console.ReadLine();

        }
    }
}
