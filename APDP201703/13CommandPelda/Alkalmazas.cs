using System;
using System.Collections.Generic;

namespace _13CommandPelda
{
    public class Alkalmazas
    {
        private List<IParancs> parancslista = new List<IParancs>();

        public string Bevitel(string[] args)
        {

            parancslista = new List<IParancs>(new IParancs[] {
                new UjParancs(),
                new ModositasParancs(),
                new TorlesParancs()
            });

            //figyelem, előre generálni kell a parancslistát, hogy ez működjön!
            if (args.Length == 0)
            { //
                return HasznalatiUtasitas();
            }

            var feldolgozo = new ParancsFeldolgozo(parancslista);
            return feldolgozo.Vegrehajtas(args);
        }

        public string HasznalatiUtasitas()
        {
            var hUtasitas = string.Format("Használat: CommandPelda[.Exe] parancs paraméterek{0}", Environment.NewLine);

            foreach (var parancs in parancslista)
            {
                hUtasitas = string.Format("{0}{1}{2}", hUtasitas, parancs.HasznalatiUtasitas, Environment.NewLine);
            }
            return hUtasitas;
        }
    }
}