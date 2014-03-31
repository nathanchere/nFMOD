using System;

namespace nFMOD.Sound
{
	/// <summary>
	/// These definitions describe the type of song being played.
	/// </summary>
	public enum Type
	{
		/// <summary>
		/// 3rd party / unknown plugin format.
		/// </summary>
		Unknown,
		
		/// <summary>
		/// AAC.  Currently unsupported.
		/// </summary>
		AAC,
		
		AIFF,
	
		/// <summary>
		/// Microsoft Advanced Systems Format (ie WMA/ASF/WMV).
		/// </summary>
		ASF,
		
		/// <summary>
		/// Sony ATRAC 3 format
		/// </summary>
		AT3,
		
		/// <summary>
		/// Digital CD audio.
		/// </summary>
		CDDA,
		
		/// <summary>
		/// Sound font / downloadable sound bank.
		/// </summary>
		DLS,
		
		/// <summary>
		/// FLAC lossless codec.
		/// </summary>
		FLAC,
		
		/// <summary>
		/// FMOD Sample Bank.
		/// </summary>
		FSB,
		
		GCADPCM,
		// GameCube ADPCM
		
		IT,
		// Impulse Tracker.
		
		MIDI,
		// MIDI.
		
		MOD,
		// Protracker / Fasttracker MOD.
		
		MPEG,
		// MP2/MP3 MPEG.
		
		OGGVORBIS,
		// Ogg vorbis.
		
		PLAYLIST,
		// Information only from ASX/PLS/M3U/WAX playlists
		
		RAW,
		// Raw PCM data.
		
		S3M,
		// ScreamTracker 3.
		
		SF2,
		// Sound font 2 format.
		
		User,
		// User created sound.
		
		WAV,
		// Microsoft WAV.
		
		XM,
		// FastTracker 2 XM.
		
		XMA,
		// Xbox360 XMA
		
		VAG,
		// PlayStation 2 / PlayStation Portable adpcm VAG format.
		
		AudioQueue,
		/* iPhone hardware decoder, supports AAC, ALAC and MP3. */
		
		XWMA,
		/* Xbox360 XWMA */
	}
	
	//TODO end submary
	
	//[PLATFORMS]
	//Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii
	
	//[SEE_ALSO]
	//Sound:: GetFormat
	//]
	//
	
	
}

