
using Asgla.Explosion.Enum;
using Asgla.Explosion.Request;
using Asgla.Explosion.Serializable;
using Newtonsoft.Json;
using System;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Asgla.Explosion.Network.Service {
    internal class Game : WebSocketBehavior {

        protected override void OnOpen() {
            Console.WriteLine("[Game] New connection {0}, {1}", ID, StartTime);
        }

        protected override void OnMessage(MessageEventArgs e) {
            Console.WriteLine("[Game] Message received");

            CmdSerialize cmd = JsonConvert.DeserializeObject<CmdSerialize>(e.Data);

            Console.WriteLine("[Game] Explosion type {0}", cmd.Cmd);

            Thread thread1 = new Thread(() => Manager.Singleton.Init(Player.NONE, e.Data, cmd.Cmd));
            thread1.Start();
        }

        protected override void OnClose(CloseEventArgs e) {
            Console.WriteLine("[Game] Close");
        }

        protected override void OnError(ErrorEventArgs e) {
            Console.WriteLine("[Game] Error");
        }

    }
}