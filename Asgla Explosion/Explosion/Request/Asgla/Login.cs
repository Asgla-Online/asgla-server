using Asgla.Explosion.Database;
using Asgla.Explosion.Enum;
using Asgla.Explosion.Interface;
using Asgla.Explosion.Serializable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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

            using (MariaDB mariaDB = new MariaDB()) {
                User user = mariaDB.DBUser.Find(1);
                Console.WriteLine(user.Username);
            }

            Console.WriteLine(JLogin);

            //player.Dispatch(JLogin);
        }

    }
}
