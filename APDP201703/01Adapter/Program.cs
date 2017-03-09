using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Adapter
{
    /// <summary>
    /// Feladat: Körüzenet küldése az ügyfeleknek
    /// Ehhez rendelkezésre fog állni valamilyen adatbázis
    /// illetve valamilyen üzenetküldő szolgáltatás (e-mail, sms, chat)
    /// 
    /// Ezek közül egyenlőre nem áll rendelkezésünkre semmi, de később illeszkednünk kell hozzá
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            var example = new AdapterExample(new AddressTestRepository(), new MessageTestService());
            example.Start();
        }
    }
}
