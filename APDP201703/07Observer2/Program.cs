using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Observer2
{
    /// <summary>
    /// Ugyanaz mint az előbb, csak a .Net IObserver/IObservable használatával
    /// 
    /// Az adatcsere DTO-n keresztül megoldott, így a megfigyelt el tudja küldeni
    /// az állapotváltozásának a részleteit.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var b = new BetoltoProgram();

            var f = new FelhasznaloiFelulet();
            var n = new NaplozoModul();

            using (var s1 = b.Subscribe(f))
            {
                using (var s2 = b.Subscribe(n))
                {
                    b.Start();
                }
            }
        }
    }

    internal class AllapotUzenet
    {
        private int allapot;
        public int Allapot { get { return allapot; } }
        public AllapotUzenet(int allapot)
        {
            this.allapot = allapot;
        }
    }

    internal class NaplozoModul : IObserver<AllapotUzenet>
    {
        public void OnCompleted()
        {
            Console.WriteLine("NaplozoModul.OnCompleted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("NaplozoModul.OnError: {0}", error.Message);
        }

        public void OnNext(AllapotUzenet allapot)
        {
            Console.WriteLine("NaplozoModul.OnNext: {0}", allapot.Allapot);
        }
    }

    internal class FelhasznaloiFelulet : IObserver<AllapotUzenet>
    {
        public void OnCompleted()
        {
            Console.WriteLine("FelhasznaloiFelulet.OnCompleted");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("FelhasznaloiFelulet.OnError: {0}", error.Message);
        }

        public void OnNext(AllapotUzenet allapot)
        {
            Console.WriteLine("FelhasznaloiFelulet.OnNext: {0}", allapot.Allapot);
        }
    }

    internal class BetoltoProgram : IObservable<AllapotUzenet>
    {
        private List<IObserver<AllapotUzenet>> megfigyelok
                        = new List<IObserver<AllapotUzenet>>();

        public IDisposable Subscribe(IObserver<AllapotUzenet> megfigyelo)
        {
            //A feliratkozót regisztráljuk
            if (!megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Add(megfigyelo);
            }
            //becsomagoljuk a feliratkozási információkat a leiratkozáshoz, majd visszaadjuk
            return new Feliratkozas(megfigyelok, megfigyelo);
        }

        internal void Start()
        {
            //csinál valami hosszabb folyamatot végez

            //20%
            Ertesites(20);

            //40%
            Ertesites(40);

            Hiba(new Exception("Itt pedig valamilyen hiba történt"));

            //70%
            Ertesites(70);

            //100%
            Ertesites(100);

            //VÉGE
            Vege();
        }

        private void Hiba(Exception exception)
        {
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.OnError(exception);
            }
        }

        private void Vege()
        {
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.OnCompleted();
            }
        }

        private void Ertesites(int allapot)
        {
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.OnNext(new AllapotUzenet(allapot: allapot));
            }
        }
    }        

    /// <summary>
    /// Ez az osztály becsomagolja a leiratkozáshoz szükséges információkat
    /// ez egy feliratkozás példány, amíg él, addig a feliratkozás is él, amikor
    /// megszűnik, az ő felelősségi köre a feliratkozás megszüntetése
    /// </summary>
    internal class Feliratkozas : IDisposable
    {
        private IObserver<AllapotUzenet> megfigyelo;
        private List<IObserver<AllapotUzenet>> megfigyelok;

        public Feliratkozas(List<IObserver<AllapotUzenet>> megfigyelok, IObserver<AllapotUzenet> megfigyelo)
        {
            this.megfigyelok = megfigyelok;
            this.megfigyelo = megfigyelo;
        }

        /// <summary>
        /// Ha vége a feliratkozás élettartamának, akkor itt
        /// kell megoldani, hogy az adminisztrációt elvégezzük
        /// </summary>
        public void Dispose()
        {
            Console.WriteLine("Feliratkozas.Dispose");
            if (megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Remove(megfigyelo);
            }
            else
            {
                throw new ObjectDisposedException("Ezt már leszedtük a feliratkozottak listájáról");
            }
        }
    }
}
