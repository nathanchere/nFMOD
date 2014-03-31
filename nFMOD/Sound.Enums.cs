using System;

namespace nFMOD
{
    public partial class Sound
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
}