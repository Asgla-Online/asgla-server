using Asgla.Explosion.Interface;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Asgla.Explosion.Enum {
    public class Map : IDispatch {

        public static Map NONE = new Map();
        
        public int Id { get; private set; }

        public string Name { get; private set; }

        //TODO: Database

        private Dictionary<int, Player> players;

        private Dictionary<int, Monster> monsters;

        public Player FindPlayer(int id) => players[id] ?? Player.NONE;

        public Monster FindMonster(int id) => monsters[id] ?? Monster.NONE;

        public void Dispatch(string[] json) {
            throw new System.NotImplementedException();
        }

        public void Dispatch(JObject json) {
            throw new System.NotImplementedException();
        }
    }
}
