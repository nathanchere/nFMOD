using System;

namespace FmodSharp.Sound
{
	/// <summary>
	/// These definitions describe the native format of the hardware or software buffer that will be used.
	/// </summary>
	public enum Format
	{
		/// <summary>
		/// Unitialized / unknown.
		/// </summary>
		None,
		
		/// <summary>
		/// 8bit integer PCM data.
		/// </summary>
		PCM8,
		
		/// <summary>
		/// 16bit integer PCM data.
		/// </summary>
		PCM16,
		
		/// <summary>
		/// 24bit integer PCM data.
		/// </summary>
		PCM24,
		
		/// <summary>
		/// 32bit integer PCM data.
		/// </summary>
		PCM32,
		
		/// <summary>
		/// 32bit floating point PCM data.
		/// </summary>
		PCMFLOAT,
		
		/// <summary>
		/// Compressed GameCube DSP data.
		/// </summary>
		GCADPCM,
		
		/// <summary>
		/// Compressed XBox ADPCM data.
		/// </summary>
		IMAADPCM,
		
		/// <summary>
		/// Compressed PlayStation 2 ADPCM data.
		/// </summary>
		VAG,
		
		/// <summary>
		/// Compressed Xbox360 data.
		/// </summary>
		XMA,
		
		/// <summary>
		/// Compressed MPEG layer 2 or 3 data.
		/// </summary>
		MPEG,
		
		/// <summary>
		/// Maximum number of sound formats supported.
		/// </summary>
		Max,
		
		/// <summary>
		/// Compressed CELT data.
		/// </summary>
		CELT,
	}
	
	//TODO end submary
	
	
	//[REMARKS]
	//This is the format the native hardware or software buffer will be or is created in.
	
	//[PLATFORMS]
	//Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii
	
	//[SEE_ALSO]
	//System::createSound
	//Sound::GetFormat
	//]
	//
}

