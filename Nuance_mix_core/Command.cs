using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance
{
    namespace Mix
    {
        namespace Commands
        {
            public abstract class Command
            {
                public abstract override string ToString();
            }

            /// <summary>
            /// Command for Speech Recognition
            /// </summary>
            public class NMDP_ASR_CMD : Command
            {
                public override string ToString()
                {
                    return "NMDP_ASR_CMD";
                }
            }

            /// <summary>
            /// Command for Text to Speech
            /// </summary>
            public class NMDP_TTS_CMD : Command
            {
                public override string ToString()
                {
                    return "NMDP_TTS_CMD";
                }
            }

            /// <summary>
            /// Command for Speech Recognition with NLU
            /// </summary>
            public class NDSP_ASR_APP_CMD : Command
            {
                public override string ToString()
                {
                    return "NDSP_ASR_APP_CMD";
                }
            }

            /// <summary>
            /// Command for Text NLU
            /// </summary>
            public class NDSP_APP_CMD : Command
            {
                public override string ToString()
                {
                    return "NDSP_APP_CMD";
                }
            }


        }
    }
}
