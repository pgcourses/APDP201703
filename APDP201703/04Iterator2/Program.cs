using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04Iterator2
{
    class Program
    {
        static void Main(string[] args)
        {
            var bejarhatoOsztaly = new BejarhatoOsztaly();
            bejarhatoOsztaly.Add(new SajatOsztaly("első bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("második bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("harmadik bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("negyedik bejegyzés"));

            foreach (var item in bejarhatoOsztaly)
            {
                Console.WriteLine("elem: {0}", item);
                //ha én tudom, hogy ez az elem SajatOsztaly, csak akkor tudok ilyesmit csinálni
                //ha konvertálok, és elkérem a SajatOsztaly felületet
                if (((SajatOsztaly)item).Created.DayOfWeek == DayOfWeek.Friday)
                {

                }
            }
        }
    }

    class SajatOsztaly
    {
        public SajatOsztaly(string uzenet)
        {
            Uzenet = uzenet;
        }

        public string Uzenet { get; set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }

        /// <summary>
        /// Ezzel elérhetjük, hogy ha ToString()-gel kiiratunk,
        /// akkor az Uzenet property-t adja vissza
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Uzenet;
        }
    }

    class BejarhatoOsztaly : IEnumerable
    {
        List<SajatOsztaly> list = new List<SajatOsztaly>();
        public IEnumerator GetEnumerator()
        {
            return new BejaroOsztaly(list);
        }

        internal void Add(SajatOsztaly sajatOsztaly)
        {
            list.Add(sajatOsztaly);
        }
    }

    class BejaroOsztaly : IEnumerator
    {
        private List<SajatOsztaly> list;
        private int position = -1;

        public BejaroOsztaly(List<SajatOsztaly> list)
        {
            this.list = list;
        }

        public object Current
        {
            get
            {
                return list[position];
            }
        }

        public bool MoveNext()
        {
            return ++position < list.Count;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
