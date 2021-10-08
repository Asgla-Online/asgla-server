namespace Asgla.Explosion.Enum {
    public class PlayerEquipment {

        public static PlayerEquipment NONE = new PlayerEquipment(Player.NONE);

        private Player player;

        public PlayerEquipment(Player player) {
            this.player = player;
        }

        public void Equip() {

        }

        public void Unequip() {

        }

    }
}
