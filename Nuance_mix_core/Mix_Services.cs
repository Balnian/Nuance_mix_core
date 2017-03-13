using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Nuance.Mix.Codecs;
using Nuance.Mix.Message;

namespace Nuance
{
    namespace Mix
    {
        /*enum Commands
        {
            NMDP_ASR_CMD,       // Speech Recognition
            NMDP_TTS_CMD,       // Text to Speech
            NDSP_ASR_APP_CMD,   // Speech Recognition with NLU
            NDSP_APP_CMD        // Text NLU
        }*/

        public class Mix_Services
        {
            private ClientWebSocket socket = new ClientWebSocket();
            CancellationTokenSource wsCancel = new CancellationTokenSource();


            public Mix_Services(string app_id, string app_key)
            {
                UriBuilder urlb = new UriBuilder("wss", "ws.dev.nuance.com", 443, "/v1", $"?app_id={app_id}&algorithm=key&app_key={app_key}");

                

                byte[] rcv;
                try
                {
                    socket.ConnectAsync(urlb.Uri, wsCancel.Token);

                    Thread th = new Thread(listenToServer);
                    th.Start();

                    
                    socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new ConnectMsg(user_id: "123", codec: new SPEEX(), device_id: "Window10"))/*@"{""message"":""connect"",""user_id"":""123"",""codec"":""audio / x - speex; mode = wb"",""device_id"":""Windows10""}"*/)), new WebSocketMessageType(), false, wsCancel.Token);


                    socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(@"{""message"":""query_begin"",""transaction_id"":8,""command"":""NDSP_APP_CMD"",""language"":""eng - USA"",""context_tag"":""Test_Version""}")), new WebSocketMessageType(), false, wsCancel.Token);


                    socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(@"{""message"":""query_parameter"",""transaction_id"":8,""parameter_name"":""REQUEST_INFO"",""parameter_type"":""dictionary"",""dictionary"":{""application_data"":{""text_input"":""Fire ball""}}}")), new WebSocketMessageType(), false, wsCancel.Token);


                    socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(@"{""message"":""query_end"",""transaction_id"":8}")), new WebSocketMessageType(), true, wsCancel.Token);
  
                    //socket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(@"{""message"":""disconnect""}")), new WebSocketMessageType(), false, wsCancel.Token);
                    
                    Thread.Sleep(2000);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    wsCancel.Cancel();
                }
            }

            private void listenToServer()
            {
                byte[] rcv;

                while (!wsCancel.IsCancellationRequested)
                {
                    rcv = new byte[1080];
                    socket.ReceiveAsync(new ArraySegment<byte>(rcv), wsCancel.Token).Wait();
                    Console.WriteLine("Received:\t" + Encoding.ASCII.GetString(rcv));
                }
            }
        }
    }
}
