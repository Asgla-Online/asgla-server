using Asgla.Explosion.Enum;
using Asgla.Explosion.Interface;
using Asgla.Explosion.Serializable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;

namespace Asgla.Explosion.Request.Asgla {
    class Login2 : IExplosion {

        private readonly LoginSerialize login;

        public Login2(string data) => login = JsonConvert.DeserializeObject<LoginSerialize>(data);

        public void Explosion(Player player) {
            Console.WriteLine("[Login2] request {0}", login.Token);

            JObject JLogin = new JObject {
                { "cmd", 1 },
                { "Status", true }
            };

            Thread thread = Thread.CurrentThread;

            for (int i = 1; i < 1001; i++)
                Console.WriteLine($"Thread 2 {thread.Name} -> Iteração {i}");

            Console.WriteLine(JLogin);

            //player.Dispatch(JLogin);
        }

    }
}
