using Nuance.Mix.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nuance
{
    namespace Mix
    {
        namespace Message
        {
            /// <summary>
            /// <para>Type wrapping the Query Begin message</para>
            /// Reference: https://developer.nuance.com/mix/documentation/websockets/#query-begin
            /// </summary>
            public class QueryBeginMsg
            {
                private Command commandWrapper;

                public QueryBeginMsg(int transaction_id, Command command, string context_tag)
                {
                    this.transaction_id = transaction_id;
                    this.commandWrapper = command;
                    this.context_tag = context_tag;
                }

                public const string message = "query_begin";

                /// <summary>
                /// Integer selected by the client to differentiate responses to the current transaction from “stale” messages from a previous transaction. Must be different from the previous transaction.
                /// </summary>
                public int transaction_id { get; set; }

                /// <summary>
                /// Operation for the server to execute; i.e. NMDP_ASR_CMD
                /// </summary>
                public string command => commandWrapper.ToString();

                /// <summary>
                /// <para>Default: MIME type of the audio codec.</para>
                /// 
                /// <para>For NDSP_ASR_APP_CMD and NDSP_APP_CMD: Context tag describing the version of Mix.nlu model to use.</para>
                /// 
                /// </summary>
                public string context_tag { get; set; }

                /// <summary>
                /// <para>6-Char Code, i.e. “eng-USA” (optional)</para>
                /// List: https://developer.nuance.com/public/index.php?task=supportedLanguages
                /// </summary>
                public string language { get; set; }

                /// <summary>
                /// <para>Optional.</para>
                ///  String that correlates multiple users or devices that belong to a common yet unique entity (e.g. household). Nuance recommends a UUID.
                /// </summary>
                public string subscriber_id { get; set; }

                /// <summary>
                /// <para>Optional.</para>
                ///  String that correlates multiple users or devices that belong to a common yet unique entity (e.g. household). Nuance recommends a UUID.
                /// </summary>
                public string phone_model { get; set; }

                /// <summary>
                /// <para>Optional.</para> 
                /// String that correlates transactions that span multiple connections to NCS for analytics. For example, in a dialog based or task-oriented solution, this parameter can be provided to assist Nuance with analytics (e.g. for a tuning analysis engagement).
                /// </summary>
                public string application_session_id { get; set; }

                /// <summary>
                /// <para>Additional Parameters For NMDP_TTS_CMD</para>
                /// <para>Use to select a specific voice.</para> 
                /// <para>For a list of available voices, see "Languages and Voices" on the Nuance Developers portal.</para>
                /// List: https://developer.nuance.com/public/index.php?task=supportedLanguages
                /// </summary>
                public string tts_voice { get; set; }


            }
        }
    }
}
