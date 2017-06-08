using System;

namespace _13CommandPelda
{
    public class Alkalmazas
    {

        public string Bevitel(string[] args)
        {
            if (args.Length == 0)
            { //
                return HasznalatiUtasitas();
            }

            var feldolgozo = new ParancsFeldolgozo();
            return feldolgozo.Vegrehajtas(args);
        }

        public string HasznalatiUtasitas()
        {
            var hUtasitas = string.Format("Használat: CommandPelda[.Exe] parancs paraméterek{0}", Environment.NewLine);
            hUtasitas = string.Format("{0}{1}{2}", hUtasitas, MagicValues.CommandTextNew, Environment.NewLine);
            hUtasitas = string.Format("{0}{1} paraméter{2}", hUtasitas, MagicValues.CommandTextModify, Environment.NewLine);
            hUtasitas = string.Format("{0}{1} paraméter{2}", hUtasitas, MagicValues.CommandTextDelete, Environment.NewLine);
            return hUtasitas;
        }
    }
}