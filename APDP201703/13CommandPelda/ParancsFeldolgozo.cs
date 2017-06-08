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

            //pontosan egy parancsra van szükségem a végrehajtáshoz,
            //nem pedig listára
            //ezért Single a Where helyett
            var parancs = parancslista.SingleOrDefault(p => p.ParancsSzoveg == parancsszoveg);

            //todo: a null használatát megszüntetni
            if (parancs==null)
            {
                return MagicValues.CommandResponseInvalid;
            }

            parancs.ParameterBeallitas(args);
            return parancs.Vegrehajtas();
        }
    }
}