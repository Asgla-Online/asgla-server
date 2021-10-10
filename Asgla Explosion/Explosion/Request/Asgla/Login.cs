using Asgla.Explosion.DB;
using Asgla.Explosion.Enum;
using Asgla.Explosion.Interface;
using Asgla.Explosion.Serializable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace Asgla.Explosion.Request.Asgla {
    class Login : IExplosion {

        private readonly LoginSerialize login;

        public Login(string data) => login = JsonConvert.DeserializeObject<LoginSerialize>(data);

        public void Explosion(Player player) {
            Console.WriteLine("[Login] request {0}", login.Token);

            JObject JLogin = new JObject {
                { "cmd", 1 },
                { "Status", true }
            };

            var watch = System.Diagnostics.Stopwatch.StartNew();

            Database.open();

            using (Database db = new Database()) {
                System.Collections.Generic.List<User> users = db.Users.ToList();

                Console.WriteLine(users.Count());

               // users.ForEach(user => Console.WriteLine(user.Username));
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            Console.WriteLine(JLogin);

            //player.Dispatch(JLogin);
        }

    }
}
