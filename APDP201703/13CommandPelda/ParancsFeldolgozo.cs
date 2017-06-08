using System;
using System.Collections.Generic;
using System.Linq;

namespace _13CommandPelda
{
    public class ParancsFeldolgozo
    {
        private List<IParancs> parancslista;

        public ParancsFeldolgozo(List<IParancs> parancslista)
        {
            this.parancslista = parancslista;
        }

        public string Vegrehajtas(string[] args)
        {
            //Megtehetem, mert az alkalmazásban kizártam, hogy nincs egy paraméter sem
            var parancsszoveg = args[0];
            var parancs = ParancsKereseseParacsszovegAlapjan(parancsszoveg);
            parancs.ParameterBeallitas(args);
            return parancs.Vegrehajtas();
        }

        private IParancs ParancsKereseseParacsszovegAlapjan(string parancsszoveg)
        {
            //pontosan egy parancsra van szükségem a végrehajtáshoz,
            //nem pedig listára
            //ezért Single a Where helyett
            var parancs = parancslista.SingleOrDefault(p => p.ParancsSzoveg == parancsszoveg);
            if (parancs == null)
            {
                parancs = new NincsIlyenParancs();
            }

            return parancs;
        }
    }
}