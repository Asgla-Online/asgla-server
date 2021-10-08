using Asgla.Explosion.Network.Service;
using System;
using WebSocketSharp.Server;

namespace Asgla.Explosion.Network {
    public class WebSocket {

        public WebSocket(string url) {
            WebSocketServer webSocket = new WebSocketServer(url);

            //webSocket.Log.Level = LogLevel.Info;

            webSocket.AddWebSocketService<Game>("/");

            webSocket.Start();

            if (webSocket.IsListening) {
                Console.WriteLine("[WebSocket] Listening on port {0}", webSocket.Port);

                foreach (string path in webSocket.WebSocketServices.Paths)
                    Console.WriteLine("[WebSocket] Service: {0}", path);
            }

            //webSocket.Stop();
        }

    }
}
