using System;
using System.Runtime.InteropServices;

// Members marked with [in] mean the user sets the value before passing it to the function.
// Members marked with [out] mean FMOD sets the value to be used after the function exits.
namespace nFMOD
{
    /// <summary>
    ///  Settings for advanced features like configuring memory and cpu usage for the
    /// FMOD_CREATECOMPRESSEDSAMPLE feature.     
    /// </summary>
    /// <remarks>
    /// maxMPEGcodecs / maxADPCMcodecs / maxXMAcodecs will determine the maximum cpu usage of playing
    /// realtime samples.  Use this to lower potential excess cpu usage and also control memory usage.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct AdvancedSettings
    {
        /// <summary>
        /// Size of structure. Use sizeof(AdvancedSettings).
        /// </summary>
        public int cbsize;

        /// <summary>
        /// For use with FMOD_CREATECOMPRESSEDSAMPLE only.
        /// MPEG codecs consume 48,696 bytes per instance and this number will determine how many MPEG
        /// channels can be played simultaneously.
        /// </summary>
        /// <remarks>
        /// Default: 16
        /// </remarks>
        public int maxMPEGcodecs;

        /// <summary>
        /// For use with FMOD_CREATECOMPRESSEDSAMPLE only. ADPCM codecs consume 1k per instance and
        /// this number will determine how many ADPCM channels can be played simultaneously.
        /// </summary>
        /// <remarks>
        /// Default: 32
        /// </remarks>
        public int maxADPCMcodecs;

        /// <summary>
        /// For use with FMOD_CREATECOMPRESSEDSAMPLE only.
        /// XMA codecs consume 8k per instance and this number will determine how many XMA channels
        /// can be played simultaneously.
        /// </summary>
        /// <remarks>
        /// Default: 32
        /// </remarks>
        public int maxXMAcodecs;

        [Obsolete("PS3 only")]
        public int maxPCMcodecs;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. For use with FMOD_CREATECOMPRESSEDSAMPLE only. CELT codecs consume
        /// 11,500 bytes per instance and this number will determine how many CELT channels can be played simultaneously.
        /// </summary>
        /// <remarks>
        /// Default: 16
        /// </remarks>
        public int maxCELTcodecs;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. For use with FMOD_CREATECOMPRESSEDSAMPLE only. Vorbis codecs consume
        /// 12,000 bytes per instance and this number will determine how many Vorbis channels can be played simultaneously.
        /// </summary>
        /// <remarks>
        /// Default: 32
        /// </remarks>
        public int maxVORBIScodecs;

        /// <summary>
        /// [in/out]
        /// </summary>        
        public int ASIONumChannels;

        /// <summary>
        /// [in/out]
        /// </summary>
        public IntPtr ASIOChannelList;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. Pointer to a list of speakers that the ASIO channels map to.
        /// This can be called after System::init to remap ASIO output.
        /// </summary>
        public IntPtr ASIOSpeakerList;

        /// <summary>
        /// [in/out] The max number of 3d reverb DSP's in the system.
        /// </summary>
        public int max3DReverbDSPs;

        /// <summary>
        /// [in/out] For use with FMOD_INIT_HRTF_LOWPASS. The angle (0-360) of a 3D sound from the listener's
        /// forward vector at which the HRTF function begins to have an effect.
        /// </summary>
        /// <remarks>
        /// Default: 180.0f
        /// </remarks>
        public float HRTFMinAngle;

        /// <summary>
        /// [in/out] For use with FMOD_INIT_HRTF_LOWPASS.  The angle (0-360) of a 3D sound from the listener's
        /// forward vector at which the HRTF function begins to have maximum effect.  Default = 360.0
        /// </summary>
        /// <remarks>
        /// Default: 360.0f
        /// </remarks>
        public float HRTFMaxAngle;

        /// <summary>
        /// [in/out] For use with FMOD_INIT_HRTF_LOWPASS. The cutoff frequency of the HRTF's lowpass filter function
        /// when at maximum effect (i.e. at HRTFMaxAngle).
        /// </summary>
        /// <remarks>
        /// Default: 4000.0f
        /// </remarks>
        public float HRTFFreq;

        /// <summary>
        ///  [in/out] For use with FMOD_INIT_VOL0_BECOMES_VIRTUAL. If this flag is used, and the volume is 0.0, then the sound
        /// will become virtual. Use this value to raise the threshold to a different point where a sound goes virtual.
        /// </summary>
        public float vol0virtualvol;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. For use with FMOD Event system only.  Specifies the number of slots
        /// available for simultaneous non blocking loads.
        /// </summary>
        /// <remarks>
        /// Default: 32
        /// </remarks>
        public int eventqueuesize;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. For streams. This determines the default size of the double buffer (in
        /// milliseconds) that a stream uses.
        /// </summary>
        /// <remarks>
        /// Default: 400
        /// </remarks>
        public uint defaultDecodeBufferSize;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. Gives fmod's logging system a path/filename. Normally the log is placed
        /// in the same directory as the executable and called fmod.log. When using System::getAdvancedSettings, provide at
        /// least 256 bytes of memory to copy into.
        /// </summary>
        public string debugLogFilename;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. For use with FMOD_INIT_ENABLE_PROFILE. Specify the port to listen on
        /// for connections by the profiler application.
        /// </summary>
        public ushort profileport;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. The maximum time in miliseconds it takes for a channel to fade to the
        /// new level when its occlusion changes.
        /// </summary>
        public uint geometryMaxFadeTime;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. The maximum number of buffers for use with getWaveData/getSpectrum.
        /// </summary>
        public uint maxSpectrumWaveDataBuffers;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. The delay the music system should allow for loading a sample from
        /// disk (in milliseconds).
        /// </summary>
        /// <remarks>
        /// Default: 400
        /// </remarks>
        public uint musicSystemCacheDelay;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. For use with FMOD_INIT_DISTANCE_FILTERING. The default center
        /// frequency in Hz for the distance filtering effect.
        /// </summary>
        /// <remarks>
        /// Default: 1500.0f
        /// </remarks>
        public float distanceFilterCenterFreq;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. Specify the stack size for the FMOD Stream thread in bytes.
        /// Useful for custom codecs that use excess stack.
        /// </summary>
        /// <remarks>
        /// Default: 49152 (48kb)
        /// </remarks>
        public uint stackSizeStream;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. Specify the stack size for the FMOD_NONBLOCKING loading thread.
        /// Useful for custom codecs that use excess stack.
        /// </summary>
        /// <remarks>
        /// Default: 65,536 (64kb)
        /// </remarks>
        public uint stackSizeNonBlocking;

        /// <summary>
        /// [in/out] Optional. Specify 0 to ignore. Specify the stack size for the FMOD mixer thread. Useful for
        /// custom dsps that use excess stack. 
        /// </summary>
        /// <remarks>
        /// Default: 49152 (48kb)
        /// </remarks>
        public uint stackSizeMixer;
    }

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
        public SoundFormat Format;

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
        public SoundType SuggestedSoundType;

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

    public struct OutputDriver
    {
        internal int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            internal set;
        }
        public Guid Guid
        {
            get;
            internal set;
        }
        public DeviceCapabilities Capabilities
        {
            get;
            internal set;
        }
        public int MinimumFrequency
        {
            get;
            internal set;
        }
        public int MaximumFrequency
        {
            get;
            internal set;
        }
        public SpeakerMode SpeakerMode
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public struct RecordDriver
    {
        internal int Id
        {
            get;
            set;
        }
        public string Name
        {
            get;
            internal set;
        }
        public Guid Guid
        {
            get;
            internal set;
        }
        public DeviceCapabilities Capabilities
        {
            get;
            internal set;
        }
        public int MinimumFrequency
        {
            get;
            internal set;
        }
        public int MaximumFrequency
        {
            get;
            internal set;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    
    public struct DspParameterDescription
    {
        /// <summary>
        /// Minimum value of the parameter (i.e. 100.0).
        /// </summary>
        public float Min;

        /// <summary>
        /// Maximum value of the parameter (i.e. 22050.0).
        /// </summary>
        public float Max;

        /// <summary>
        /// Default value of parameter.
        /// </summary>
        public float Defaultval;

        /// <summary>
        /// Name of the parameter to be displayed (i.e. "Cutoff frequency").
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] Name;

        /// <summary>
        /// Short string to be put next to value to denote the unit type. (i.e. "hz").
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] Label;

        /// <summary>
        /// Description of the parameter to be displayed as a help item / tooltip for this parameter.
        /// </summary>
        public string Description;
    }

    /// <summary>
    /// DSP plugin structure that is passed into each callback.
    /// </summary>
    public struct DspState
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

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;
    }

    /// <summary>
    /// Structure to be filled with detailed memory usage information of an FMOD object
    /// </summary>
    /// <remarks>
    /// Every public readonly FMOD class has a getMemoryInfo function which can be used to get detailed
    /// information on what memory resources are associated with the object in question.  On return from
    /// getMemoryInfo, each member of this structure will hold the amount of memory used for its type in bytes.
    /// </remarks>	
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryUsageDetails
    {
        /// <summary>
        /// Memory not accounted for by other types.
        /// </summary>
        public readonly uint Other;

        /// <summary>
        /// String data
        /// </summary>
        public readonly uint StringData;

        /// <summary>
        /// System object and various internals.
        /// </summary>
        public readonly uint System;

        /// <summary>
        /// Plugin objects and internals
        /// </summary>
        public readonly uint Plugin;

        /// <summary>
        /// Output module object and internals
        /// </summary>
        public readonly uint Output;

        /// <summary>
        /// Channel related memory
        /// </summary>
        public readonly uint Channel;

        /// <summary>
        /// ChannelGroup objects and internals
        /// </summary>
        public readonly uint ChannelGroup;

        /// <summary>
        /// Codecs allocated for streaming
        /// </summary>
        public readonly uint Codec;

        /// <summary>
        /// File buffers and structures
        /// </summary>
        public readonly uint File;

        /// <summary>
        /// Sound objects and internals
        /// </summary>
        public readonly uint Sound;

        /// <summary>
        /// Sound data stored in secondary RAM
        /// </summary>
        public readonly uint SecondaryRam;

        /// <summary>
        /// SoundGroup objects and internals
        /// </summary>
        public readonly uint SoundGroup;

        /// <summary>
        /// Stream buffer memory
        /// </summary>
        public readonly uint StreamBuffer;

        /// <summary>
        /// DSPConnection objects and internals
        /// </summary>
        public readonly uint DspConnection;

        /// <summary>
        /// DSP implementation objects
        /// </summary>
        public readonly uint Dsp;

        /// <summary>
        /// Realtime file format decoding DSP objects
        /// </summary>
        public readonly uint DspCodec;

        /// <summary>
        /// Profiler memory footprint.
        /// </summary>
        public readonly uint Profile;

        /// <summary>
        /// Buffer used to store recorded data from microphone
        /// </summary>
        public readonly uint RecordBuffer;

        /// <summary>
        /// Reverb implementation objects
        /// </summary>
        public readonly uint Reverb;

        /// <summary>
        /// Reverb channel properties structs
        /// </summary>
        public readonly uint ReverbChannelProperties;

        /// <summary>
        /// Geometry objects and internals
        /// </summary>
        public readonly uint Geometry;

        /// <summary>
        /// Sync point memory.
        /// </summary>
        public readonly uint SyncPoint;

        /// <summary>
        /// EventSystem and various internals
        /// </summary>
        public readonly uint EventSystem;

        /// <summary>
        /// MusicSystem and various internals
        /// </summary>
        public readonly uint MusicSystem;

        /// <summary>
        /// Definition of objects contained in all loaded projects.
        /// e.g. events, groups, categories
        /// </summary>
        public readonly uint FEV;

        /// <summary>
        /// Data loaded with registerMemoryFSB
        /// </summary>
        public readonly uint MemoryFSB;

        /// <summary>
        /// EventProject objects and internals
        /// </summary>
        public readonly uint EventProject;

        /// <summary>
        /// EventGroup objects and internals
        /// </summary>
        public readonly uint EventGroup;

        /// <summary>
        /// Objects used to manage wave banks
        /// </summary>
        public readonly uint SoundBankClass;

        /// <summary>
        /// Data used to manage lists of wave bank usage
        /// </summary>
        public readonly uint SoundBankList;

        /// <summary>
        /// Stream objects and internals
        /// </summary>
        public readonly uint StreamInstance;

        /// <summary>
        /// Sound definition objects
        /// </summary>
        public readonly uint SoundDefinitionClass;

        /// <summary>
        /// Sound definition static data objects
        /// </summary>
        public readonly uint SoundDefinitionStaticClass;

        /// <summary>
        /// Sound definition pool data
        /// </summary>
        public readonly uint SoundDefinitionPool;

        /// <summary>
        /// Reverb definition objects
        /// </summary>
        public readonly uint ReverbDefinition;

        /// <summary>
        /// Reverb objects
        /// </summary>
        public readonly uint EventReverb;

        /// <summary>
        /// User property objects
        /// </summary>
        public readonly uint UserProperty;

        /// <summary>
        /// Event instance base objects
        /// </summary>
        public readonly uint EventInstance;

        /// <summary>
        /// Complex event instance objects
        /// </summary>
        public readonly uint EventInstanceComplex;

        /// <summary>
        /// Simple event instance objects
        /// </summary>
        public readonly uint EventInstanceSimple;

        /// <summary>
        /// Event layer instance objects
        /// </summary>
        public readonly uint EventInstanceLayer;

        /// <summary>
        /// Event sound instance objects
        /// </summary>
        public readonly uint EventInstanceSound;

        /// <summary>
        /// Event envelope objects
        /// </summary>
        public readonly uint EventEnvelope;

        /// <summary>
        /// Event envelope definition objects
        /// </summary>
        public readonly uint EventEnvelopeDefinition;

        /// <summary>
        /// Event parameter objects
        /// </summary>
        public readonly uint EventParameter;

        /// <summary>
        /// Event category objects
        /// </summary>
        public readonly uint EventCategory;

        /// <summary>
        /// Event envelope point objects
        /// </summary>
        public readonly uint EventEnvelopePoint;

        /// <summary>
        /// Event instance pool memory
        /// </summary>
        public readonly uint EventInstancePool;
    }

    /// <summary>
    /// Structure describing a piece of tag data.
    /// </summary>    
    [StructLayout(LayoutKind.Sequential)]
    public struct Tag
    {
        /// <summary>
        /// [out] The type of this tag
        /// </summary>
        public TagType type;

        /// <summary>
        /// [out] The type of data that this tag contains
        /// </summary>
        public TagDataType datatype;

        /// <summary>
        /// [out] The name of this tag i.e. "TITLE", "ARTIST" etc
        /// </summary>
        public IntPtr namePtr;

        /// <summary>
        /// [out] Pointer to the tag data - its format is determined by the datatype member
        /// </summary>
        public IntPtr data;

        /// <summary>
        /// [out] Length of the data contained in this tag
        /// </summary>
        public uint datalen;

        /// <summary>
        /// [out] True if this tag has been updated since last being accessed with Sound::getTag
        /// </summary>
        public bool updated;

        public string name
        {
            get
            {
                return Marshal.PtrToStringAnsi(namePtr);
            }
        }
    }

    /// <summary>
    /// Structure defining a reverb environment.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ReverbProperties
    {

        #region Variables
        private int instance;
        private int environment;
        private float envSize;
        private float envDiffusion;
        private int room;
        private int roomHF;
        private int roomLF;
        private float decayTime;
        private float decayHFRatio;
        private float decayLFRatio;
        private int reflections;
        private float reflectionsDelay;       
        private int reverb;
        private float reverbDelay;
        private float echoTime;
        private float echoDepth;
        private float modulationTime;
        private float modulationDepth;
        private float airAbsorptionHF;
        private float hFReference;
        private float lFReference;
        private float roomRolloffFactor;

        [Obsolete("Xbox-only")]
        private readonly float diffusion;
        [Obsolete("Xbox-only")]
        private readonly float density;

        private ReverbFlags flags;
        #endregion

        #region Properties/// <summary>
        /// EAX4 only. Environment Instance.
        /// 3 seperate reverbs simultaneously are possible.
        /// This specifies which one to set.
        /// </summary>
        public int Instance
        {
            get
            {
                return instance;
            }
            set
            {
                CheckRange(value, 0, 3, "Instance");
                instance = value;
            }
        }

        /// <summary>
        /// Sets all listener properties
        /// </summary>
        public int Environment
        {
            get
            {
                return environment;
            }
            set
            {
                CheckRange(value, -1, 25, "Environment");
                environment = value;
            }
        }

        /// <summary>
        /// Environment size in meters
        /// </summary>
        public float EnvironmentSize
        {
            get
            {
                return envSize;
            }
            set
            {
                CheckRange(value, 1.0, 100.0, "EnvironmentSize");
                envSize = value;
            }
        }

        /// <summary>
        /// Environment diffusion
        /// </summary>
        public float EnvironmentDiffusion
        {
            get
            {
                return envDiffusion;
            }
            set
            {
                CheckRange(value, 0.0, 1.0, "EnvironmentDiffusion");
                envDiffusion = value;
            }
        }

        /// <summary>
        /// Room effect level at mid frequencies
        /// </summary>
        public int Room
        {
            get
            {
                return room;
            }
            set
            {
                CheckRange(value, -10000, 0, "Room");
                room = value;
            }
        }

        /// <summary>
        /// Relative room effect level at high frequencies
        /// </summary>
        public int RoomHighFrequencies
        {
            get
            {
                return roomHF;
            }
            set
            {
                CheckRange(value, -10000, 0, "RoomHighFrequencies");
                roomHF = value;
            }
        }

        /// <summary>
        /// Relative room effect level at low frequencies
        /// </summary>
        public int RoomLowFrequencies
        {
            get
            {
                return roomLF;
            }
            set
            {
                CheckRange(value, -10000, 0, "RoomLowFrequencies");
                roomLF = value;
            }
        }

        /// <summary>
        /// Reverb decay time at mid frequencies
        /// </summary>
        public float DecayTime
        {
            get
            {
                return decayTime;
            }
            set
            {
                CheckRange(value, 0.1, 20.0, "DecayTime");
                decayTime = value;
            }
        }

        /// <summary>
        /// High-frequency to mid-frequency decay time ratio
        /// </summary>
        public float DecayHighFrequencyRatio
        {
            get
            {
                return decayHFRatio;
            }
            set
            {
                CheckRange(value, 0.1, 2.0, "DecayHighFrequencyRatio");
                decayHFRatio = value;
            }
        }

        /// <summary>
        /// Low-frequency to mid-frequency decay time ratio
        /// </summary>
        public float DecayLowFrequencyRatio
        {
            get
            {
                return decayLFRatio;
            }
            set
            {
                CheckRange(value, 0.1, 2.0, "DecayLowFrequencyRatio");
                decayLFRatio = value;
            }
        }

        /// <summary>
        /// Early reflections level relative to room effect
        /// </summary>
        public int Reflections
        {
            get
            {
                return reflections;
            }
            set
            {
                CheckRange(value, -10000, 1000, "Reflections");
                reflections = value;
            }
        }

        /// <summary>
        /// Initial reflection delay time
        /// </summary>
        public float ReflectionsDelay
        {
            get
            {
                return reflectionsDelay;
            }
            set
            {
                CheckRange(value, 0.0, 0.3, "ReflectionsDelay");
                reflectionsDelay = value;
            }
        }

        /// <summary>
        /// Late reverb level relative to room effect
        /// </summary>
        public int Reverb
        {
            get
            {
                return reverb;
            }
            set
            {
                CheckRange(value, -10000, 2000, "Reverb");
                reverb = value;
            }
        }

        /// <summary>
        /// Late reverb delay time relative to initial reflection
        /// </summary>
        public float ReverbDelay
        {
            get { return reverbDelay; }
            set
            {
                CheckRange(value, 0.0, 0.1, "ReverbDelay");
                reverbDelay = value;
            }
        }

        /// <summary>
        /// Echo time
        /// </summary>
        public float EchoTime
        {
            get
            {
                return echoTime;
            }
            set
            {
                CheckRange(value, 0.075, 0.25, "EchoTime");
                echoTime = value;
            }
        }

        /// <summary>
        /// Echo depth
        /// </summary>
        public float EchoDepth
        {
            get
            {
                return echoDepth;
            }
            set
            {
                CheckRange(value, 0.0, 1.0, "EchoDepth");
                echoDepth = value;
            }
        }

        /// <summary>
        /// Modulation time
        /// </summary>
        public float ModulationTime
        {
            get
            {
                return modulationTime;
            }
            set
            {
                CheckRange(value, 0.04, 4.0, "ModulationTime");
                modulationTime = value;
            }
        }

        /// <summary>
        /// Modulation depth
        /// </summary>
        public float ModulationDepth
        {
            get
            {
                return modulationDepth;
            }
            set
            {
                CheckRange(value, 0.0, 1.0, "ModulationDepth");
                modulationDepth = value;
            }
        }

        /// <summary>
        /// Change in level per meter at high frequencies
        /// </summary>
        public float AirAbsorptionHighFrequencies
        {
            get
            {
                return airAbsorptionHF;
            }
            set
            {
                CheckRange(value, -100.0, 0.0, "AirAbsorptionHighFrequencies");
                airAbsorptionHF = value;
            }
        }

        /// <summary>
        /// Reference high frequency (hz)
        /// </summary>
        public float HighFrequencyReference
        {
            get
            {
                return hFReference;
            }
            set
            {
                CheckRange(value, 1000.0, 20000.0, "HighFrequencyReference");
                hFReference = value;
            }
        }

        /// <summary>
        /// Reference low frequency (hz)
        /// </summary>
        public float LowFrequencyReference
        {
            get
            {
                return lFReference;
            }
            set
            {
                CheckRange(value, 20.0, 1000.0, "LowFrequencyReference");
                lFReference = value;
            }
        }

        /// <summary>
        /// Like rolloffscale in System::set3DSettings but for reverb room size effect
        /// </summary>
        public float RoomRolloffFactor
        {
            get
            {
                return roomRolloffFactor;
            }
            set
            {
                CheckRange(value, 0.0, 10.0, "RoomRolloffFactor");
                roomRolloffFactor = value;
            }
        }

        #endregion

        /// <summary>
        /// Modifies the behavior of other reverb properties.
        /// </summary>
        public ReverbFlags Flags
        {
            get
            {
                return flags;
            }
            set
            {
                flags = value;
            }
        }

        private void CheckRange(double Value, double Min, double Max, string Param)
        {
            if (Value < Min || Value > Max)
                throw new ArgumentOutOfRangeException(Param, Value,
                    string.Format("{0}: Tried to set the value [{1}], but only accept [{2} to {3}].", Param, Value,
                        Min, Max));
        }

        public static readonly ReverbProperties Generic = new ReverbProperties {
            Instance = 0,
            Environment = -1,
            EnvironmentSize = 7.5f,
            EnvironmentDiffusion = 1.0f,
            Room = -1000,
            RoomHighFrequencies = -100,
            RoomLowFrequencies = 0,
            DecayTime = 1.49f,
            DecayHighFrequencyRatio = 0.83f,
            DecayLowFrequencyRatio = 1.0f,
            Reflections = -2602,
            ReflectionsDelay = 0.007f,
            Reverb = 200,
            ReverbDelay = 0.011f,
            EchoTime = 0.25f,
            EchoDepth = 0.0f,
            ModulationTime = 0.25f,
            ModulationDepth = 0.0f,
            AirAbsorptionHighFrequencies = -5.0f,
            HighFrequencyReference = 5000.0f,
            LowFrequencyReference = 250.0f,
            RoomRolloffFactor = 0.0f,
            Flags = ReverbFlags.Default
        };
    }
}
