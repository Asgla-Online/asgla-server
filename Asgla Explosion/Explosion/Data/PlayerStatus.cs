namespace Asgla.Explosion.Enum {
    public partial class PlayerStatus {

        public static PlayerStatus NONE = new PlayerStatus(Player.NONE);

        private int Health = 1;
        private int HealthMax = 1;
        private int Mana = 1;
        private int ManaMax = 100;

        private PlayerState State = PlayerState.NORMAL;

        private Player player;

        public PlayerStatus(Player player) {
            this.player = player;
        }

        public void Restore() {

        }

        public void Die() {

        }

    }
}
