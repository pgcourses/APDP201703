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
        void Uzenet(int allapot);
    }

    public class NaplozoModul : IUzenet
    {
        public void Uzenet(int allapot)
        {
            Console.WriteLine("NaplozoModul.Uzenet: {0}", allapot);
        }
    }

    class FelhasznaloiFelulet : IUzenet
    {
        public void Uzenet(int allapot)
        {
            Console.WriteLine("FelhasznaloiFelulet.Uzenet: {0}", allapot);
        }
    }

    class BetoltoProgram
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
                megfigyelo.Uzenet(allapot);
            }
        }

        private int allapot;
        public int Allapot { get { return allapot; } }
    }
}
