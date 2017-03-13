using System;
using System.Collections.Generic;
using System.Text;
using Nuance.Mix.Codecs;

namespace Nuance
{
    namespace Mix
    {
        namespace Message
        {
            /// <summary>
            /// <para>Type wrapping the Connect message</para>
            /// Reference: https://developer.nuance.com/mix/documentation/websockets/#connect
            /// </summary>
            public class ConnectMsg
            {
                private Codec codecWrapper;

                public ConnectMsg(string device_id, string user_id, Codec codec)
                {
                    this.user_id = user_id;
                    codecWrapper = codec;
                    this.device_id = device_id;
                }

                public const string message = "connect";

                /// <summary>
                /// String that uniquely identifies the device that the query is being sent from, such as a MAC address.
                /// </summary>
                public string device_id { get; set; }

                /// <summary>
                /// String that uniquely identifies the user who is speaking, if available.
                /// </summary>
                public string user_id { get; set; }

                /// <summary>
                /// MIME type of the audio audio-codecs
                /// </summary>
                public string codec => codecWrapper.ToString();

            }
        }
    }
}
