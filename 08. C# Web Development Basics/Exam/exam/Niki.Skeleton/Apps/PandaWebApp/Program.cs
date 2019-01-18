namespace PandaWebApp
{
    using SIS.MvcFramework;

    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
