using System;

namespace _13CommandPelda
{
    public class TorlesParancs : IParancs
    {
        private string parameter;

        public string HasznalatiUtasitas { get { return string.Format("{0} paraméter", MagicValues.CommandTextDelete); } }
        public string ParancsSzoveg { get { return MagicValues.CommandTextDelete; } }

        public void ParameterBeallitas(string[] args)
        {
            //todo: ellenőrizni, hogy van-e ilyen paraméter
            parameter = args[1];
        }

        public string Vegrehajtas()
        {
            //todo: tevékenység elvégzése (Delete)
            return string.Format(MagicValues.CommandResponseDelete, parameter);
        }
    }
}