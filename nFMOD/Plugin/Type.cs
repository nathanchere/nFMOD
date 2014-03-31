using System;

namespace nFMOD.Plugin
{
	//TODO write Summary
	
	//These are plugin types defined for use with the System::getNumPlugins,
	//System::getPluginInfo and System::unloadPlugin functions.
	
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="FMOD_System_GetNumPlugins"/>
	/// <seealso cref="FMOD_System_GetPluginInfo"/>
	/// <seealso cref="FMOD_System_UnloadPlugin"/>
	/// <platforms>
	/// Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii
	/// </platforms>
	public enum Type
	{
		
		/// <summary>
		/// The plugin type is an output module.
		/// FMOD mixed audio will play through one of these devices.
		/// </summary>
		Output,
		
		/// <summary>
		/// The plugin type is a file format codec.
		/// FMOD will use these codecs to load file formats for playback.
		/// </summary>
		Codec,
		
		/// <summary>
		/// The plugin type is a DSP unit.
		/// FMOD will use these plugins as part of its DSP network to
		/// apply effects to output or generate sound in realtime.
		/// </summary>
		DSP
	}
}
