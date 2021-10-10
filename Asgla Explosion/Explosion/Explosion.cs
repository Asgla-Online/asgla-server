using System;
using System.Threading;

namespace Asgla.Explosion {
    public class Explosion {

        public static readonly Explosion Singleton = new Explosion();

        public static void Main(string[] args) {
            Console.WriteLine("[Main] Asgla Explosion - Anthony S.");

            Core.Init();

            Console.WriteLine("[Main] Waiting players ------------");
            Thread.Sleep(Timeout.Infinite);
        }

    }
}
