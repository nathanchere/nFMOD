using System;

namespace nFMOD.Channel
{
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

	public delegate Error.Code ChannelDelegate (IntPtr channelraw, CallbackType type, IntPtr commanddata1, IntPtr commanddata2);
	
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

