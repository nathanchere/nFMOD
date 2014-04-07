using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace nFMOD
{
	public partial class Sound : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Release"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Release (IntPtr sound);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetSystemObject"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSystemObject (IntPtr sound, ref IntPtr system);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Lock"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Lock (IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Unlock"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Unlock (IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetDefaults"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetDefaults (IntPtr sound, float frequency, float volume, float pan, int priority);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetDefaults"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDefaults (IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetVariations"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetVariations (IntPtr sound, float frequencyvar, float volumevar, float panvar);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetVariations"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetVariations (IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Set3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DMinMaxDistance (IntPtr sound, float min, float max);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Get3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DMinMaxDistance (IntPtr sound, ref float min, ref float max);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Set3DConeSettings"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DConeSettings (IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Get3DConeSettings"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DConeSettings (IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Set3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DCustomRolloff (IntPtr sound, ref Vector3 points, int numpoints);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_Get3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DCustomRolloff (IntPtr sound, ref IntPtr points, ref int numpoints);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetSubSound"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetSubSound (IntPtr sound, int index, IntPtr subsound);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetSubSound"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSubSound (IntPtr sound, int index, ref IntPtr subsound);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetSubSoundSentence"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetSubSoundSentence (IntPtr sound, int[] subsoundlist, int numsubsounds);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetName"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetName (IntPtr sound, StringBuilder name, int namelen);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetLength"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLength (IntPtr sound, ref uint length, TimeUnit lengthtype);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetFormat"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetFormat (IntPtr sound, ref Sound.Type type, ref Sound.Format format, ref int channels, ref int bits);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetNumSubSounds"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumSubSounds (IntPtr sound, ref int numsubsounds);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetNumTags"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumTags (IntPtr sound, ref int numtags, ref int numtagsupdated);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetTag"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetTag (IntPtr sound, string name, int index, ref Tag tag);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetOpenState"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetOpenState (IntPtr sound, ref OpenState openstate, ref uint percentbuffered, ref int starving);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_ReadData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode ReadData (IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SeekData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SeekData (IntPtr sound, uint pcm);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetSoundGroup"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetSoundGroup (IntPtr sound, IntPtr soundgroup);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetSoundGroup"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSoundGroup (IntPtr sound, ref IntPtr soundgroup);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetNumSyncPoints"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumSyncPoints (IntPtr sound, ref int numsyncpoints);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetSyncPoint"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSyncPoint (IntPtr sound, int index, ref IntPtr point);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetSyncPointInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSyncPointInfo (IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TimeUnit offsettype);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_AddSyncPoint"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode AddSyncPoint (IntPtr sound, uint offset, TimeUnit offsettype, string name, ref IntPtr point);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_DeleteSyncPoint"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode DeleteSyncPoint (IntPtr sound, IntPtr point);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetMode"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMode (IntPtr sound, Mode mode);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetMode"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMode (IntPtr sound, ref Mode mode);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetLoopCount"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetLoopCount (IntPtr sound, int loopcount);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetLoopCount"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLoopCount (IntPtr sound, ref int loopcount);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetLoopPoints"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetLoopPoints (IntPtr sound, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetLoopPoints"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLoopPoints (IntPtr sound, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetMusicNumChannels"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMusicNumChannels (IntPtr sound, ref int numchannels);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetMusicChannelVolume"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMusicChannelVolume (IntPtr sound, int channel, float volume);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetMusicChannelVolume"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMusicChannelVolume (IntPtr sound, int channel, ref float volume);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetMusicSpeed"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMusicSpeed (IntPtr sound, float speed);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetMusicSpeed"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMusicSpeed (IntPtr sound, ref float speed);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_SetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetUserData (IntPtr sound, IntPtr userdata);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetUserData (IntPtr sound, ref IntPtr userdata);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Sound_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMemoryInfo (IntPtr sound, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);
        #endregion

        #region Enums
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

            /// <summary>
            /// GameCube ADPCM
            /// </summary>
            GCADPCM,

            /// <summary>
            /// Impulse Tracker
            /// </summary>
            IT,

            /// <summary>
            /// MIDI
            /// </summary>
            MIDI,

            /// <summary>
            /// Protracker / Fasttracker MOD
            /// </summary>
            MOD,

            /// <summary>
            /// MP2/MP3 MPEG
            /// </summary>
            MPEG,            

            /// <summary>
            /// Ogg vorbis
            /// </summary>
            OGGVORBIS,           

            /// <summary>
            /// Metadata only from ASX/PLS/M3U/WAX playlists
            /// </summary>
            PLAYLIST,

            /// <summary>
            /// Raw PCM data
            /// </summary>
            RAW,

            /// <summary>
            /// ScreamTracker 3
            /// </summary>
            S3M,

            /// <summary>
            /// Sound font 2
            /// </summary>
            SF2,

            /// <summary>
            /// User created sound
            /// </summary>
            User,

            /// <summary>
            /// Microsoft WAV
            /// </summary>
            WAV,

            /// <summary>
            /// FastTracker 2
            /// </summary>
            XM,

            /// <summary>
            /// Xbox360 XMA
            /// </summary>
            XMA,            

            /// <summary>
            /// PlayStation 2 / PlayStation Portable adpcm VAG format
            /// </summary>
            VAG,            

            /// <summary>
            /// iPhone hardware decoder, supports AAC, ALAC and MP3
            /// </summary>
            AudioQueue,

            /// <summary>
            /// Xbox360 XWMA
            /// </summary>
            XWMA,
        }
        #endregion

        #region Structs
        /// <summary>
        /// Use this structure with System::createSound when more control is needed over loading.
        /// The possible reasons to use this with System::createSound are:
        /// * Loading a file from memory.
        /// * Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.
        /// * To create a user created / non file based sound.
        /// * To specify a starting subsound to seek to within a multi-sample sounds (ie FSB/DLS/SF2) when created as a stream.
        /// * To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.
        /// * To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.
        /// * To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.
        /// See below on what members to fill for each of the above types of sound you want to create.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SoundInfo
        {

            /// <summary>
            /// [in] Size of this structure.
            /// This is used so the structure can be expanded in the future and still work on older versions of FMOD Ex.
            /// </summary>
            public int cbsize;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Size in bytes of file to load, or sound to create (in this case only if FMOD_OPENUSER is used).
            /// Required if loading from memory.
            /// If 0 is specified, then it will use the size of the file (unless loading from memory then an error will be returned).
            /// </summary>
            public uint Length;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Offset from start of the file to start loading from.
            /// This is useful for loading files from inside big data files.
            /// </summary>
            public uint FileOffset;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Number of channels in a sound specified only if OPENUSER is used.
            /// </summary>
            public int NumberChannels;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Default frequency of sound in a sound specified only if OPENUSER is used.
            /// Other formats use the frequency determined by the file format.
            /// </summary>
            public int DefaultFrequency;

            /// <summary>
            /// [in] Optional. Specify 0 or SOUND_FORMAT_NONE to ignore.
            /// Format of the sound specified only if OPENUSER is used.
            /// Other formats use the format determined by the file format.
            /// </summary>
            public Format Format;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore. For streams.
            /// This determines the size of the double buffer (in PCM samples) that a stream uses.
            /// Use this for user created streams if you want to determine the size of the callback buffer passed to you.
            /// Specify 0 to use FMOD's default size which is currently equivalent to 400ms of the sound format created/loaded.
            /// </summary>
            public uint DecodeBufferSize;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// In a multi-sample file format such as .FSB/.DLS/.SF2, specify the initial subsound to seek to, only if CREATESTREAM is used.
            /// </summary>
            public int InitialSubsound;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore or have no subsounds.
            /// In a user created multi-sample sound, specify the number of subsounds within the sound that are accessable with Sound::getSubSound / SoundGetSubSound.
            /// </summary>
            public int NumberSubsounds;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// In a multi-sample format such as .FSB/.DLS/.SF2 it may be desirable to specify only a subset of sounds to be loaded out of the whole file.
            /// This is an array of subsound indicies to load into memory when created.
            /// </summary>
            public IntPtr InclusionList;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// This is the number of integers contained within the
            /// </summary>
            public int InclusionListNumber;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback to 'piggyback' on FMOD's read functions and accept or even write PCM data while FMOD is opening the sound.
            /// Used for user sounds created with OPENUSER or for capturing decoded data as FMOD reads it.
            /// </summary>
            public PCMReadDelegate PCMReadCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for when the user calls a seeking function such as Channel::setPosition within a multi-sample sound, and for when it is opened.
            /// </summary>
            public PCMSetposDelegate PCMSetPositionCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore. Callback for successful completion, or error while loading a sound that used the FMOD_NONBLOCKING flag.
            /// </summary>
            public NonBlockDelegate NonBlockCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore. Filename for a DLS or SF2 sample set when loading a MIDI file.
            /// If not specified, on windows it will attempt to open /windows/system32/drivers/gm.dls, otherwise the MIDI will fail to open.
            /// </summary>
            public string DLSName;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore. Key for encrypted FSB file.  Without this key an encrypted FSB file will not load.
            /// </summary>
            public string EncryptionKey;

            /// <summary>
            /// [in] Optional. Specify 0 to ingore.
            /// For sequenced formats with dynamic channel allocation such as .MID and .IT, this specifies the maximum voice count allowed while playing.
            /// .IT defaults to 64.  .MID defaults to 32.
            /// </summary>
            public int MaximumPolyphony;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// This is user data to be attached to the sound during creation.
            /// Access via Sound::getUserData. 
            /// </summary>
            public IntPtr UserData;

            /// <summary>
            /// [in] Optional. Specify 0 or FMOD_SOUND_TYPE_UNKNOWN to ignore.
            /// Instead of scanning all codec types, use this to speed up loading by making it jump straight to this codec.
            /// </summary>
            public Type SuggestedSoundType;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for opening this file.
            /// </summary>
            public File_OpenDelegate UserOpenCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for closing this file.
            /// </summary>
            public File_CloseDelegate UserCloseCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for reading from this file.
            /// </summary>
            public File_ReadDelegate UserReadCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for seeking within this file.
            /// </summary>
            public File_SeekDelegate UserSeekCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for asyncronously reading from this file.
            /// </summary>
            public File_AsyncReadDelegate UserAsyncReadCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Callback for cancelling an asyncronous read.
            /// </summary>
            public File_AsyncCancelDelegate UserAsyncCancelCallback;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Use this to differ the way fmod maps multichannel sounds to speakers.
            /// See FMOD_SPEAKERMAPTYPE for more.
            /// </summary>
            public SpeakerMapType SpeakerMap;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Specify a sound group if required, to put sound in as it is created.
            /// </summary>
            public IntPtr InitialSoundGroup;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore. For streams.
            /// Specify an initial position to seek the stream to.
            /// </summary>
            public uint InitialSeekPosition;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore. For streams.
            /// Specify the time unit for the position set in initialseekposition.
            /// </summary>
            public TimeUnit InitialSeekPositionType;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Set to 1 to use fmod's built in file system.
            /// Ignores setFileSystem callbacks and also FMOD_CREATESOUNEXINFO file callbacks.
            /// Useful for specific cases where you don't want to use your own file system but want to use fmod's file system (ie net streaming).
            /// </summary>
            public int IgnoreSetFileSystem;

            /// <summary>
            /// [in] Optional. Specify 0 to ignore.
            /// Codec specific data.
            /// See FMOD_SOUND_TYPE for what each codec might take here.
            /// </summary>
            public IntPtr ExtraCodecData;

        }
        #endregion

        public delegate ErrorCode NonBlockDelegate (IntPtr soundraw, ErrorCode result);
	    public delegate ErrorCode PCMReadDelegate (IntPtr soundraw, IntPtr data, uint datalen);
	    public delegate ErrorCode PCMSetposDelegate (IntPtr soundraw, int subsound, uint position, TimeUnit postype);

		private Sound() { }

		internal Sound (IntPtr hnd) : base()
		{
			SetHandle (hnd);
		}

		protected override bool ReleaseHandle ()
		{
			if (IsInvalid) return true;
			
			Release (handle);
			SetHandleAsInvalid ();			
			return true;
		}
	}
}

