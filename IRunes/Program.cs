namespace IRunes
{
    using System;
    using System.Threading.Tasks;
    using SIS.MvcFramework;

    class Program
    {
        static async Task Main(string[] args)
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
