using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in BejarhatoFuggveny())
            {
                Console.WriteLine("eredmény: {0}", item);
            }

            var bejarhatoOsztaly = new BejarhatoOsztaly();
            bejarhatoOsztaly.Add("első elem");
            bejarhatoOsztaly.Add("második elem");
            bejarhatoOsztaly.Add("harmadik elem");
            bejarhatoOsztaly.Add("negyedik elem");

            //ez egy kis csalás, mert System.Object jön a ciklusváltozóba
            foreach (var item in bejarhatoOsztaly)
            {
                //de string esetén a ToString() metódus éppen jót végez,
                //így ez nem szúr elsőre feltétlenül szemet.
                Console.WriteLine("ciklus: {0}", item);
            }

        }

        /// <summary>
        /// Ez egy ciklussal bejárható függvény. Vagy visszatér egy bejárható 
        /// osztálypéldánnyal, vagy önmagában tényleg bejárható.
        /// 
        /// A névben szereplő ellentmondás feloldását a fordító oldja meg, és 
        /// egy állapotgépet gyárt a föggvényhívás mögé, ami szimulálja a bejárható
        /// példány működését.
        /// 
        /// </summary>
        /// <returns>vagy egy bejárható objektum, VAGY a föggvény yeild return-ökkel szimulálja a bejárhatóságot</returns>
        private static IEnumerable<string> BejarhatoFuggveny()
        {
            yield return "egy";
            yield return "kettő";
            yield return "három";
        }
    }


    /// <summary>
    /// Ezen az osztályon lehet ciklussal végigmenni, vagyis BEJÁRHATÓ az osztály
    /// </summary>
    class BejarhatoOsztaly : IEnumerable //, IEnumerator //ezzel egy osztály oldaná meg az adattárolást és a bejárást
    {
        //kisebb csalás következik, ugyanis a 
        //bejárható osztálynak kell tartalom, amin végig lehet menni
        List<string> list = new List<string>();

        /// <summary>
        /// Ehhez egy gyártófüggvényt kell implementálni
        /// ami előállítja a Bejáró példányt
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            //ahhoz, hogy végig tudjunk menni az adatokon, meg kell osztani az információt
            //return new BejaroOsztaly(list);
            return new VisszafeleBejaroOsztaly(list);
        }

        internal void Add(string elem)
        {
            list.Add(elem);
        }
    }

    /// <summary>
    /// Bejáró definíció, ami a bejátható osztály egyes elemein fog végiglépkedni.
    /// </summary>
    class BejaroOsztaly : IEnumerator
    {
        private List<string> list;
        private int position = -1;

        public BejaroOsztaly(List<string> list)
        {
            this.list = list;
        }

        /// <summary>
        /// Léptet egyet a bejárandó elemeken, és visszatér a léptetés eredményével.
        /// Ha sikerült új elemre lépni, akkor a léptetés eredményes,
        /// ha nincs további elem, akkor a léptetés sikertelen.
        /// </summary>
        /// <returns>true, ha a léptetés sikeres, false, ha nem</returns>
        public bool MoveNext()
        {
            position = position + 1;
            var erdemesUjraHivni = position < list.Count;
            Console.WriteLine("    BejaroOsztaly.MoveNext: {0}, {1}", position, erdemesUjraHivni);
            return erdemesUjraHivni;
        }

        /// <summary>
        /// (Sikeres léptetés után hívható)
        /// Visszatér az aktuális elemmel
        /// </summary>
        public object Current
        {
            get
            {
                if (position==-1)
                {
                    throw new ArgumentOutOfRangeException("A bejáráshoz először léptetni kell!");
                }
                if (position>list.Count-1)
                {
                    throw new ArgumentOutOfRangeException("Túlmentünk a lehetséges elemeken!");
                }

                var current = list[position];
                Console.WriteLine("    BejaroOsztaly.Current: {0}, {1}", position, current);
                return current;
            }
        }

        /// <summary>
        /// Visszaállít mindent az elejére
        /// </summary>
        public void Reset()
        {
            Console.WriteLine("    BejaroOsztaly.Reset");
            position = -1;
        }
    }

    class VisszafeleBejaroOsztaly : IEnumerator
    {
        private List<string> list;
        private int position = -1;

        public VisszafeleBejaroOsztaly(List<string> list)
        {
            //Névsor szerint fordított sorrendben megyünk végig az elemeken
            this.list = list.OrderByDescending(x=>x)
                            .ToList();
        }

        /// <summary>
        /// Léptet egyet a bejárandó elemeken, és visszatér a léptetés eredményével.
        /// Ha sikerült új elemre lépni, akkor a léptetés eredményes,
        /// ha nincs további elem, akkor a léptetés sikertelen.
        /// </summary>
        /// <returns>true, ha a léptetés sikeres, false, ha nem</returns>
        public bool MoveNext()
        {
            position = position + 1;
            var erdemesUjraHivni = position < list.Count;
            Console.WriteLine("    BejaroOsztaly.MoveNext: {0}, {1}", position, erdemesUjraHivni);
            return erdemesUjraHivni;
        }

        /// <summary>
        /// (Sikeres léptetés után hívható)
        /// Visszatér az aktuális elemmel
        /// </summary>
        public object Current
        {
            get
            {
                if (position == -1)
                {
                    throw new ArgumentOutOfRangeException("A bejáráshoz először léptetni kell!");
                }
                if (position > list.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Túlmentünk a lehetséges elemeken!");
                }

                var current = list[position];
                Console.WriteLine("    BejaroOsztaly.Current: {0}, {1}", position, current);
                return current;
            }
        }

        /// <summary>
        /// Visszaállít mindent az elejére
        /// </summary>
        public void Reset()
        {
            Console.WriteLine("    BejaroOsztaly.Reset");
            position = -1;
        }
    }
}
