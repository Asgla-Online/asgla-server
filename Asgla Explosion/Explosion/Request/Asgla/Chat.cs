using Asgla.Explosion.Enum;
using Asgla.Explosion.Interface;
using Asgla.Explosion.Serializable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Asgla.Explosion.Request.Asgla {
    public class Chat : IExplosion {

        private readonly ChatSerialize chat;

        public Chat(string data) => chat = JsonConvert.DeserializeObject<ChatSerialize>(data);

        public void Explosion(Player player) {
            Console.WriteLine("[Chat] request [{0}]: {1}", chat.Channel, chat.Message);

            JObject JChat = new JObject {
                { "cmd", 1 },
                { "Channel", true },
                { "PlayerName", player.Username() },
                { "Message", chat.Message }
            };

            switch (chat.Channel) {
                case ChatChannel.ZONE:
                    Map map = player.Map();
                    map.Dispatch(JChat);
                    break;
                case ChatChannel.WORLD:
                    Players.Singleton.Dispatch(JChat);
                    break;
                case ChatChannel.GUILD:
                    throw new NotImplementedException();
                case ChatChannel.PARTY:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }

            player.Dispatch(JChat);
        }

    }
}
