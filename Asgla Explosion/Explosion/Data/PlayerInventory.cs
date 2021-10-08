namespace Asgla.Explosion.Enum {
    public class PlayerInventory {

        public static PlayerInventory NONE = new PlayerInventory(Player.NONE);

        private Player player;

        public PlayerInventory(Player player) {
            this.player = player;
        }
    }
}
