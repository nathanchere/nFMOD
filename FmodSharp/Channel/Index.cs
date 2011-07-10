using System;

namespace FmodSharp.Channel
{
	/// <summary>
	/// 
	/// </summary>
	/// <platforms>
	/// Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii
	/// </platforms>
	/// <seealso cref="FmodSharp.System.PlaySound"/>
	/// <seealso cref="FmodSharp.System.PlayDSP"/>
	/// <seealso cref="FmodSharp.System.GetChannel"/>
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
