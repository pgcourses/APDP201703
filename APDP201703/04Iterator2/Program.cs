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
            var bejarhatoOsztaly = new BejarhatoOsztaly<SajatOsztaly>();
            bejarhatoOsztaly.Add(new SajatOsztaly("első bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("második bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("harmadik bejegyzés"));
            bejarhatoOsztaly.Add(new SajatOsztaly("negyedik bejegyzés"));

            foreach (var item in bejarhatoOsztaly)
            {
                Console.WriteLine("elem: {0}", item.Uzenet);
            }
            //Miután a foreach véget ér, meghívja a Dispose-t.

            //a foreach a következő mechanizmust hívja életre:
            //using (var bejaro = bejarhatoOsztaly.GetEnumerator()) is kifejtve:
            //var bejaro = bejarhatoOsztaly.GetEnumerator();
            //try
            //{
            //    var leszKovetkezo = true;
            //    do
            //    {
            //        leszKovetkezo = bejaro.MoveNext();
            //        var item = bejaro.Current;
            //        {
            //            //ez itt a ciklus belseje
            //        }
            //    } while (leszKovetkezo);
            //}
            //finally
            //{
            //    if (bejaro!=null)
            //    {
            //        ((IDisposable)bejaro).Dispose();
            //    }
            //}

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
        //public override string ToString()
        //{
        //    return Uzenet;
        //}
    }

    class BejarhatoOsztaly<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();

        internal void Add(T item)
        {
            list.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BejaroOsztaly<T>(list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        { //sima duplikáció, meghívom a típusos függvényt
            return this.GetEnumerator();
        }
    }

    class BejaroOsztaly<T> : IEnumerator<T>
    {
        private List<T> list;
        private int position = -1;

        public BejaroOsztaly(List<T> list)
        {
            this.list = list;
        }

        public T Current
        {
            get { return list[position]; }
        }

        //ez egyszerű duplikálás, csak meghívom a
        //típusos függvényt
        object IEnumerator.Current { get { return this.Current; } }

        public bool MoveNext() { return ++position < list.Count; }

        public void Reset() { position = -1; }

        public void Dispose() { } //nincs tennivalónk, nem csinál a Dispose semmit

        //Az IDisposable felület miatt ez kötelező, HA A Dispose valamit csinál
        //kötelező a finalizer
        //~BejaroOsztaly()
        //{
        //    Dispose(false);
        //}

        //private void Dispose(bool isManagedDispose)
        //{
        //    if (isManagedDispose)
        //    {
        //        //Itt takarítjuk a managed erőforrásokat!
        //        if (list != null)
        //        {
        //            list = null;
        //        }
        //    }
        //    //a nem managed erőforrások takarítása
        //}

        //public void Dispose()
        //{ 
        //    Dispose(true);
        //    //mivel takarítottunk, a finalizernek már nincs funkciója, jelezzük, hogy nem kell
        //    GC.SuppressFinalize(this);
        //}

    }
}
