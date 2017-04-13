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
                //a bejáró nem teljes gyűjteményelérés, ezért ilyet nem tudok mondani:
                //bejarhatoOsztaly.Remove(item);
                //DE HA MÉGIS:
                bejarhatoOsztaly.Remove(item);
                //tudnom kell arról, hogy ha az adatokat módosítják, 
                //nem értesülök róla, és csak akkor tudok ellene tenni,
                //ha erre a forgatókönyvre felkészülök.

                //1. Nem teszünk listát az ablakba (nem tesszük elérhetővé a lista 
                //   adatainkat kívülről
                //2. Így értesülünk a módosításról, és kezelni tudjuk
                //3. Helyzettől függ, hogy engedjük a módosítást és értesítjük a bejáró(kat), vagy
                //   vagy már a módosítást sem engedjük
                //4. Párhuzamos bejárásokra a saját bejáróval lehet a legegyszerűbben felkészülni
                //5. Ha a bejáró és a bejárandó egy osztályba kerül, akkor a dispose implementációja érdekes lehet
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

            //var lista = new List<string>(new string[] { "egy", "kettő", "három" });

            ////Nagyon fontos annak kezelése, hogy a bejárható példány elemei módosultak-e?
            ////mert ha igen, akkor valamit tenni kell.
            ////a List<T> Enumerator-a például ilyenkor exception-t dob:
            ////System.InvalidOperationException: Collection was modified; enumeration operation may not execute.
            //foreach (var item in lista)
            //{
            //    Console.WriteLine("elem: {0}", item);
            //    lista.Remove(item);
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
        //Antipattern  példa: listát nem osztunk meg!
        List<T> list = new List<T>();

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Remove(T item)
        {
            list.Remove(item);
            //értesítenem kell a bejáróimat, hogy 
            //helyzet van!!!!!!
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
