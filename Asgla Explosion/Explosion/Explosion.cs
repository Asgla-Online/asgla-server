using Asgla.Explosion.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Asgla.Explosion {
    public class Explosion {

        public static readonly Explosion Singleton = new Explosion();

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            Console.WriteLine("[Main] ConfigureServices");
        }

        public static void Main(string[] args) {
            Console.WriteLine("[Main] Asgla Explosion - Anthony S.");

            using (MariaDB mariaDB = new MariaDB()) {
                User user = mariaDB.DBUser.Find(1);
                Console.WriteLine(user.Username);
            }

            Core.Init();

            Console.WriteLine("[Main] Waiting players ------------");
            Thread.Sleep(Timeout.Infinite);
        }

    }
}
