using System;

namespace _13CommandPelda
{
    public class ModositasParancs : IParancs
    {
        private string parameter;

        public string HasznalatiUtasitas { get { return string.Format("{0} paraméter", MagicValues.CommandTextModify); } }
        public string ParancsSzoveg { get { return MagicValues.CommandTextModify; } }

        public void ParameterBeallitas(string[] args)
        {
            //todo: ellenőrizzük, hogy van-e ilyen paraméter
            parameter = args[1];
        }

        public string Vegrehajtas()
        {
            //todo: tevékenység elvégzése (Modify)
            return string.Format(MagicValues.CommandResponseModify, parameter);
        }
    }
}