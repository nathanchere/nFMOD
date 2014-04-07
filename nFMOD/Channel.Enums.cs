using System;

namespace nFMOD
{
    public partial class Channel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <platforms>
        /// Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii
        /// </platforms>
        /// <seealso cref="nFMOD.System.PlaySound"/>
        /// <seealso cref="nFMOD.System.PlayDSP"/>
        /// <seealso cref="nFMOD.System.GetChannel"/>
        public enum Index
        {
            /// <summary>
            /// For a channel index, FMOD chooses a free voice using the priority system.
            /// </summary>
            Free = -1,

            /// <summary>
            /// For a channel index, re-use the channel handle that was passed in.
            /// </summary>
            Reuse = -2
        }

        /// <summary>
        /// These callback types are used with Channel::setCallback.
        /// </summary>
        /// <remarks>
        /// Each callback has commanddata parameters passed int unique to the type of callback.
        /// See reference to FMOD_CHANNEL_CALLBACK to determine what they might mean for each type of callback.
        /// </remarks>
        public enum CallbackType : int
        {
            /// <summary>
            /// Called when a sound ends.
            /// </summary>
            End,

            /// <summary>
            /// Called when a voice is swapped out or swapped in.
            /// </summary>
            VirtualVoice,

            /// <summary>
            /// Called when a syncpoint is encountered.  Can be from wav file markers.
            /// </summary>
            SyncPoint,

            /// <summary>
            /// Called when the channel has its geometry occlusion value calculated.
            /// Can be used to clamp or change the value.
            /// </summary>
            Occlusion,

            Max
        }

        public delegate ErrorCode ChannelDelegate(IntPtr channelraw, CallbackType type, IntPtr commanddata1, IntPtr commanddata2);

        //TODO end submmary

        /*
        [ENUM]
        [
            [DESCRIPTION]   
        

            [REMARKS]


            [PLATFORMS]
            Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

            [SEE_ALSO]      
            Channel::setCallback
            FMOD_CHANNEL_CALLBACK
        ]
        */
    }

}

