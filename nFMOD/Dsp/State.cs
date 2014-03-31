using System;

namespace nFMOD.Dsp
{
	
	//TODO complete submmary
	/*
        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3

        [SEE_ALSO]
        FMOD_DSP_DESCRIPTION
    ]
    */
	
	/// <summary>
	/// DSP plugin structure that is passed into each callback.
	/// </summary>
	public struct State
	{
		/// <summary>
		/// Handle to the DSP the user created.
		/// Not to be modified.
		/// </summary>
		public IntPtr Instance;
		
		/// <summary>
		/// Plugin writer created data the output author wants to attach to this object.
		/// </summary>
		public IntPtr PluginData;
		
		/// <summary>
		/// Specifies which speakers the DSP effect is active on.
		/// </summary>
		public ushort SpeakerMask;
		
	}
}

