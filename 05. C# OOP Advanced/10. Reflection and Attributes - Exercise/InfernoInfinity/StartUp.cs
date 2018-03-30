using P09_InfernoInfinity.Contracts;
using P09_InfernoInfinity.Core;
using P09_InfernoInfinity.IO;

namespace P09_InfernoInfinity
{
    internal class StartUp
    {
        private static void Main(string[] args)
        {
            IReader reader = new Reader();

            Engine engine = new Engine(reader);
            engine.Run();
        }
    }
}