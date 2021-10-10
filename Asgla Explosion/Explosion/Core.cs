using Asgla.Explosion.Network;

namespace Asgla.Explosion {
    internal class Core {

        internal static void Init() {
            _ = new WebSocket("ws://localhost:4649");
        }

    }
}
