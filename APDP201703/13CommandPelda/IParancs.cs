namespace _13CommandPelda
{
    public interface IParancs
    {
        string ParancsSzoveg { get; }
        void ParameterBeallitas(string[] args);
        string Vegrehajtas();
    }
}