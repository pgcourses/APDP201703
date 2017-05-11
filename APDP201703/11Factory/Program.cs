using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11Factory
{
    /// <summary>
    /// A gyártó minta azt a célt szolgálja, hogy mindenhol a kódban szétszórva példányosítsunk osztályokat,
    /// hanem ennek legyen egy (újrafelhasználható) struktúrája.
    /// 
    /// Kiküszöbölendő az "új létrehozásával való összekapcsolás" problémáját
    /// 
    /// Ahol new kulcsszó szerepel, ott azonnal létrehozunk egy erős csatolást a létrehozó és a létrehozott között.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
