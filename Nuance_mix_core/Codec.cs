using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance
{
    namespace Mix
    {
        namespace Codecs
        {
            public abstract class Codec
            {
                public abstract override string ToString();
            }

            /// <summary>
            /// Note that Opus is the preferred format.
            /// </summary>
            public class Opus : Codec
            {
                private uint rate;
                /// <summary>
                /// Note that Opus is the preferred format.
                /// </summary>
                /// <param name="rate">Default 16000 for 16 kHz Opus. </param>
                public Opus(uint rate = 16000)
                {
                    this.rate = rate;
                }
                public override string ToString()
                {
                    return $"audio/opus;rate= {rate}";
                }
            }

            /// <summary>
            /// PCM is supported as a legacy format.
            /// </summary>
            public class PCM : Codec
            {
                private uint rate;

                /// <summary>
                /// PCM is supported as a legacy format.
                /// </summary>
                /// <param name="rate">Default 16000 for 16kHz, 16-bit PCM.</param>
                public PCM(uint rate = 16000)
                {
                    this.rate = rate;
                }
                public override string ToString()
                {
                    return $"audio / L16; rate = {rate}";
                }
            }

            /// <summary>
            /// SPEEX is supported as a legacy format.
            /// </summary>
            public class SPEEX : Codec
            {
                /// <summary>
                /// SPEEX is supported as a legacy format.
                /// </summary>
                public SPEEX() { }
                public override string ToString()
                {
                    return "audio/x-speex;mode=wb";
                }
            }
        }
    }
}
