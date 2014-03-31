using System;

namespace nFMOD.Channel
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
}
