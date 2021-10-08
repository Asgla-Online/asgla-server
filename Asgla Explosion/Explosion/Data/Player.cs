using Asgla.Explosion.Interface;
using Newtonsoft.Json.Linq;

namespace Asgla.Explosion.Enum {
    public class Player : IDispatch {

        public static Player NONE = new Player();

        private int _id;

        private string _username;

        private Map _map;

        //TODO: Database

        private readonly PlayerInventory inventory = PlayerInventory.NONE;

        private readonly PlayerEquipment equipment = PlayerEquipment.NONE;

        private readonly PlayerStatus status = PlayerStatus.NONE;

        public Player() {
            this.inventory = new PlayerInventory(this);
            this.equipment = new PlayerEquipment(this);
            this.status = new PlayerStatus(this);
        }

        public int Id() => _id;

        public string Username() => _username;

        public Map Map() => _map;

        public PlayerInventory Inventory() {
            return inventory;
        }

        public PlayerEquipment Equipment() {
            return equipment;
        }

        public PlayerStatus Status() {
            return status;
        }

        public bool doesNotExist() {
            return Equals(NONE);
        }

        public bool doesExist() {
            return !doesNotExist();
        }

        public void MoveToArea() {

        }

        public void Logout() {
        
        }

        public JObject Save(JObject jsonObject) {
            jsonObject.Add("id", 1);
            jsonObject.Add("test", "");
            return jsonObject;
        }

        public void Dispatch(string[] json) {
            throw new System.NotImplementedException();
        }

        public void Dispatch(JObject json) {
            throw new System.NotImplementedException();
        }

    }
}
