using Asgla.Explosion.Interface;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Asgla.Explosion.Enum {
    public class Maps : IDispatch {

        public static readonly Maps Singleton = new Maps();

        private List<Map> maps;

        public void Add(Map map) => maps.Add(map);

        public void Remove(Map map) => maps.Remove(map);

        public Map Find(int id) => maps.Where(m => m.Id == id).FirstOrDefault() ?? Map.NONE;

        public Map Find(string name) => maps.Where(m => m.Name == name).FirstOrDefault() ?? Map.NONE;

        public void Dispatch(string[] json) {
            throw new System.NotImplementedException();
        }

        public void Dispatch(JObject json) {
            throw new System.NotImplementedException();
        }
    }
}
