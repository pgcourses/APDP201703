using System;

namespace _13CommandPelda
{
    internal class NincsIlyenParancs : IParancs
    {
        private string parameter;

        public string HasznalatiUtasitas { get { throw new NotImplementedException(); } }
        public string ParancsSzoveg { get { throw new NotImplementedException(); } }

        public void ParameterBeallitas(string[] args)
        {
            parameter = args[0];
        }

        public string Vegrehajtas()
        {
            return string.Format( MagicValues.CommandResponseInvalid, parameter);
        }
    }
}