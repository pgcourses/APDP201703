using System;

namespace _13CommandPelda
{
    public class ParancsFeldolgozo
    {
        string[] Parancsok = new string[] 
        {
            MagicValues.CommandTextNew,
            MagicValues.CommandTextModify,
            MagicValues.CommandTextDelete
        };

        public string Vegrehajtas(string[] args)
        {
            //Megtehetem, mert az alkalmazásban kizártam, hogy nincs egy paraméter sem
            var parancsszoveg = args[0]; 

            //ellenőrzöm, hogy a parancs értelmes-e, és ha ?
            //igen, végrehajtom
            //todo: ellenőrizni, hogy kapott-e második paramétert a módosítás és a törlés
            switch (parancsszoveg)
            {
                case MagicValues.CommandTextNew:
                    return New();
                case MagicValues.CommandTextModify:
                    return Modify(args[1]);
                case MagicValues.CommandTextDelete:
                    return Delete(args[1]);
                default:
                    return MagicValues.CommandResponseInvalid;
            }
        }

        private string Delete(string parameter)
        {
            //todo: tevékenység elvégzése (Delete)
            return string.Format(MagicValues.CommandResponseDelete, parameter);
        }

        private string Modify(string parameter)
        {
            //todo: tevékenység elvégzése (Modify)
            return string.Format(MagicValues.CommandResponseModify, parameter);
        }

        private string New()
        {
            //todo: tevékenység elvégzése (New)
            return MagicValues.CommandResponseNew;
        }
    }

}