using Asgla.Explosion.Enum;
using Asgla.Explosion.Exceptions;
using Asgla.Explosion.Interface;

namespace Asgla.Explosion.Request.Asgla {
    class Default : IExplosion {

        public void Explosion(Player player) => throw new UnknownExplosionException();

    }
}
