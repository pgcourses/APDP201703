namespace _12BuilderPelda
{
    public abstract class AbstractPCDirector
    {
        protected AbstractPCBuilder builder;

        public AbstractPCDirector(AbstractPCBuilder builder)
        {
            this.builder = builder;
        }

        public abstract void BuildPC();

        public Computer GetPC()
        {
            return builder.GetPC();
        }

    }
}