using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08Observer3
{
    class Program
    {
        /// <summary>
        /// A feladat ugyanaz, mint eddig
        /// csak most megnézzük eseményekkel
        /// 
        /// Az állapot változását a megfigyelt közölheti DTOn keresztül,
        /// de a teljes megfigyelt példány utazik a paraméterlistán, így
        /// a megfigyelő mindenhez hozzá is fér.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var b = new BetoltoProgram();

            var f = new FelhasznaloiFelulet();
            var n = new NaplozoModul();

            //feliratkozások
            //Átlagos eseményvezérlő: nekünk most nem ez kell.
            //b.AllapotValtozasTortent += B_AllapotValtozasTortent;

            //anonymous delegat-tel 
            //Így is lehetne, akkor nálam van a lehetőség, hogy össze nem 
            //kapcsolható függvényekkel is tudok játszani
            //b.AllapotValtozasTortent += (object o, AllapotUzenet e) => { f.Uzenet(e); };
            //b.AllapotValtozasTortent += (object o, AllapotUzenet e) => { n.Uzenet(e.Allapot); };

            //vagy csak simán megismétlem a hívást
            //b.AllapotValtozasTortent += (object o, AllapotUzenet e) => { f.Uzenet(o, e); };
            //b.AllapotValtozasTortent += (object o, AllapotUzenet e) => { n.Uzenet(o, e); };

            b.AllapotValtozasTortent += f.Uzenet;
            b.AllapotValtozasTortent += n.Uzenet;

            b.Start();

            b.AllapotValtozasTortent -= f.Uzenet;
            b.AllapotValtozasTortent -= n.Uzenet;

        }

        //Átlagos eseményvezérlő: nekünk most nem ez kell.
        //private static void B_AllapotValtozasTortent(object sender, AllapotUzenet e)
        //{
        //    throw new NotImplementedException();
        //}
    }

    internal class NaplozoModul
    {
        internal void Uzenet(object o, AllapotUzenet e)
        {
            Console.WriteLine("NaplozoModul: {0}", e.Allapot);
        }
    }

    internal class FelhasznaloiFelulet
    {
        internal void Uzenet(object o, AllapotUzenet e)
        {
            Console.WriteLine("FelhasznaloiFelulet: {0}", e.Allapot);
        }
    }

    internal class BetoltoProgram
    {
        /// <summary>
        /// Az események .Net alatt
        /// 1. (az osztályon) kívülről nem kiváltható
        /// 2. Nem adható neki érték az osztályon kívülről nem adható neki érték 
        /// 3. Osztályon kívülről csak fel és leiratkozni lehet erre a listára
        /// </summary>
        public event EventHandler<AllapotUzenet> AllapotValtozasTortent;
        private void OnAllapotValtozasTortent(int allapot)
        {
            AllapotValtozasTortent?.Invoke(this, new AllapotUzenet(allapot));
        }

        internal void Start()
        {
            //csinál valami hosszabb folyamatot végez

            //20%
            Ertesites(20);

            //40%
            Ertesites(40);

            //Hiba(new Exception("Itt pedig valamilyen hiba történt"));

            //70%
            Ertesites(70);

            //100%
            Ertesites(100);

            //VÉGE
            //Vege();
        }
        private void Ertesites(int allapot)
        {
            OnAllapotValtozasTortent(allapot);
        }

        private void Hiba(Exception exception)
        {
            throw new NotImplementedException();
        }

        private void Vege()
        {
            throw new NotImplementedException();
        }

    }

    /// <summary>
    /// .Net konvenció: az esemény argumentumaként szereplő DTO-kat
    /// le kell származtatni az EventArgs osztályból
    /// </summary>
    public class AllapotUzenet : EventArgs
    {
        private int allapot;

        public int Allapot { get { return allapot; } }

        public AllapotUzenet(int allapot)
        {
            this.allapot = allapot;
        }
    }
}
