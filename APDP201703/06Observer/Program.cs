using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06Observer
{
    /// <summary>
    /// Készítsünk egy olyan programot, ami hosszan dolgozik,
    /// és időről időre szól, hogy hol tart.
    /// 
    /// 
    /// Megfigyelő minta megjegyzések
    /// Amikor a megfigyelt értesíti a megfigyelőket, akkor nem lehet tudni, hogy mekkora 
    /// folyamat indul el
    /// 
    /// Az, hogy kiderüljön mi változott, külön megoldás kell
    /// A törlést azt implementálni kell
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

            var f = new FelhasznaloiFelulet();
            var n = new NaplozoModul();

            //var b = new BetoltoProgram(f,n);
            var b = new BetoltoProgram();
            b.Feliratkozas(f);
            b.Feliratkozas(n);

            b.Start();

            Console.WriteLine("Program vége");

            b.Leiratkozas(f);
            b.Leiratkozas(n);

        }
    }

    public interface IUzenet
    {
        void Uzenet(IAllapot allapot);
    }

    public class NaplozoModul : IUzenet
    {
        public void Uzenet(IAllapot allapot)
        {
            Console.WriteLine("NaplozoModul.Uzenet: {0}", allapot.Allapot);
        }
    }

    class FelhasznaloiFelulet : IUzenet
    {
        public void Uzenet(IAllapot allapot)
        {
            Console.WriteLine("FelhasznaloiFelulet.Uzenet: {0}", allapot.Allapot);
        }
    }

    public interface IAllapot
    {
        int Allapot { get; } 
    }
    class BetoltoProgram : IAllapot
    {
        private List<IUzenet> megfigyelok = new List<IUzenet>();

        //Ez túlságosan statikus megoldás, ennél a kapcsolatokat
        //jó lenne dinamikusabban változtatni

        //public BetoltoProgram(params IUzenet[] megfigyelok)
        //{
        //    foreach (var megfigyelo in megfigyelok)
        //    {
        //        this.megfigyelok.Add(megfigyelo);
        //    }
        //}

        public void Feliratkozas(IUzenet megfigyelo)
        {
            if (!megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Add(megfigyelo);
            }
        }

        public void Leiratkozas(IUzenet megfigyelo)
        {
            if (!megfigyelok.Contains(megfigyelo))
            {
                megfigyelok.Remove(megfigyelo);
            }
        }

        internal void Start()
        {
            //csinál valami hosszabb folyamatot végez

            //20%
            Ertesites(20);

            //40%
            Ertesites(40);

            //70%
            Ertesites(70);

            //100%
            Ertesites(100);

            //VÉGE
            //Ertesites();
        }

        private void Ertesites(int allapot)
        {
            this.allapot = allapot;
            foreach (var megfigyelo in megfigyelok)
            {
                megfigyelo.Uzenet(this);
            }
        }

        private int allapot;
        public int Allapot { get { return allapot; } }
    }

}
