using System;

namespace nFMOD.SoundSystem
{
	/*
    [ENUM]
    [
        [DESCRIPTION]   
        

        [REMARKS]
        Each callback has commanddata parameters passed as int unique to the type of callback.<br>
        See reference to FMOD_SYSTEM_CALLBACK to determine what they might mean for each type of callback.<br>
        <br>
        <b>Note!</b>  Currently the user must call System::update for these callbacks to trigger!

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::setCallback
        FMOD_SYSTEM_CALLBACK
        System::update
    ]
    */

	/// <summary>
	/// These callback types are used with System::setCallback.
	/// </summary>
	public enum CallbackType : int
	{
		/// <summary>
		/// Called when the enumerated list of devices has changed.
		/// </summary>
		DeviceListChanged,

		/// <summary>
		/// Called from System::update when an output device has been lost
		/// due to control panel parameter changes and FMOD cannot automatically recover.
		/// </summary>
		DeviceLost,

		/// <summary>
		/// Called directly when a memory allocation fails somewhere in FMOD.
		/// </summary>
		MemoryAllocationFailed,

		/// <summary>
		/// Called directly when a thread is created.
		/// </summary>
		ThreadCreated,

		/// <summary>
		/// Called when a bad connection was made with DSP::addInput.
		/// Usually called from mixer thread because that is where the connections are made.
		/// </summary>
		BadDspConnection,

		/// <summary>
		/// Called when too many effects were added exceeding the maximum tree depth of 128.
		/// This is most likely caused by accidentally adding too many DSP effects.
		/// Usually called from mixer thread because that is where the connections are made.
		/// </summary>
		BadDspLevel,

		/// <summary>
		/// Maximum number of callback types supported.
		/// </summary>
		Max
		
	}

	public delegate Error.Code SystemDelegate (IntPtr systemraw, CallbackType type, IntPtr commanddata1, IntPtr commanddata2);
	
	//TODO complete submary
}
