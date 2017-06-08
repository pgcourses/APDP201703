namespace _12BuilderPelda
{
    public abstract class AbstractPCBuilder
    {
        protected Computer computer;

        public void CreatePC()
        {
            computer = new Computer();
        }

        public void BuildPC()
        {
            BuildHardware();
            InstallOS();
            InstallApplications();
        }

        public abstract void InstallApplications();
        public abstract void InstallOS();
        public abstract void BuildHardware();

        public Computer GetPC()
        {
            return computer;
        }
    }
}