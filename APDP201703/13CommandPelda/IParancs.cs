namespace _13CommandPelda
{
    public interface IParancs
    {
        string HasznalatiUtasitas { get; }
        string ParancsSzoveg { get; }
        void ParameterBeallitas(string[] args);
        string Vegrehajtas();
    }
}