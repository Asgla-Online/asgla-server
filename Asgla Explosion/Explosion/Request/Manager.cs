using Asgla.Explosion.Enum;
using Asgla.Explosion.Interface;
using System;
using System.Linq;
using System.Reflection;

using static Asgla.Explosion.Request.ClassBuilder;

namespace Asgla.Explosion.Request {
    public class Manager {

        public static readonly Manager Singleton = new Manager();

        public void Init(Player player, string json, string cmd) {
            Type explosion = Type.GetType(Requests.Default[cmd].ToString());

            if (explosion == null)
                explosion = Type.GetType(Requests.Default.None);

            ConstructorInfo ctor = explosion.GetConstructors().First();
            ObjectActivator<IExplosion> createdActivator = GetActivator<IExplosion>(ctor);

            IExplosion instance = createdActivator(json);

            instance.Explosion(player);
        }

    }
}
