using System;

namespace _13CommandPelda
{
    public class UjParancs : IParancs
    {
        public string HasznalatiUtasitas { get { return MagicValues.CommandTextNew; } }
        public string ParancsSzoveg { get { return MagicValues.CommandTextNew; } }

        public void ParameterBeallitas(string[] args)
        {
            //nem kalp paramétert, nincs implementáció
        }

        public string Vegrehajtas()
        {
            //todo: tevékenység elvégzése (New)
            return MagicValues.CommandResponseNew;
        }
    }
}