using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05Iterator3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Antipattern: gyűjtemények közzététele az osztályunk felületén
            var szmla = new BankSzmla();
            szmla.Atutalas(1, 200);
            szmla.Atutalas(2, 100);
            szmla.Atutalas(3, 300);
            szmla.Atutalas(4, 250);

            foreach (var item in szmla.Atutalasok)
            {
                Console.WriteLine("{0}. Összeg: {1}", item.Id, item.Osszeg);
            }

            Console.WriteLine("Egyenleg: {0}", szmla.Egyenleg);

            //Ez futási hibára fut, ha ReadOnlyCollection-t használunk
            ((List<Atutalas>)szmla.Atutalasok).Remove(((List<Atutalas>)szmla.Atutalasok)[0]);

            Console.WriteLine();
            Console.WriteLine("Törlés -----------------------------------------");
            Console.WriteLine();

            foreach (var item in szmla.Atutalasok)
            {
                Console.WriteLine("{0}. Összeg: {1}", item.Id, item.Osszeg);
            }

            Console.WriteLine("Egyenleg: {0}", szmla.Egyenleg);

        }

        class BankSzmla
        {
            //Ha listát kell közzétennünk, akkor
            //használjunk read only felületet
            private List<Atutalas> atutalasok = new List<Atutalas>();
            public IEnumerable<Atutalas> Atutalasok
            {
                get
                {
                    //return atutalasok.AsEnumerable(); //ez nem oldja meg a problémát, a példány marad, tehát visszaalakítható
                    return new ReadOnlyCollection<Atutalas>(atutalasok);
                }
            }

            private decimal egyenleg = 0;
            public decimal Egyenleg { get { return egyenleg; } }

            public void Atutalas(int id, decimal osszeg)
            {
                atutalasok.Add(new Atutalas(id, osszeg));
                egyenleg += osszeg;
            }

        }

        class Atutalas
        {
            public Atutalas(int id, decimal osszeg)
            {
                Id = id;
                Osszeg = osszeg;
            }

            public int Id { get; }
            public decimal Osszeg { get; }
        }

        //Automapper segítségével így lehet elmenteni EF CodeFirst segítségével az adatokat:
        //átmásoljuk őket ilyen osztálypéldányokba
        class BankSzmlaMentes
        {
            public decimal Osszeg { get; set; }
            public ICollection<Atutalas> Atutalasok { get; set; }
        }

        class AtutalasMentes
        {
            public int Id { get; set; }
            public decimal Osszeg { get; set; }
        }

    }
}
