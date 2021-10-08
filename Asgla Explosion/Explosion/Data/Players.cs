using Asgla.Explosion.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asgla.Explosion.Enum {
    public class Players : IDispatch {

        public static readonly Players Singleton = new Players();

        private int totalOnline = 0;
        private int highestOnline = 0;

        private List<Player> players;

        public void Create() {
            Player player = new Player();
            players.Add(player);
        }

        public void Add(Player player) => players.Add(player);

        public void Remove(Player player) => players.Remove(player);

        public Player Find(int id) => players.Where(p => p.Id() == id).FirstOrDefault() ?? Player.NONE;

        public Player Find(string username) => players.Where(p => p.Username() == username).FirstOrDefault() ?? Player.NONE;

        public void Dispatch(string[] json) {
            throw new NotImplementedException();
        }

        public void Dispatch(JObject json) {
            throw new NotImplementedException();
        }
    }
}
