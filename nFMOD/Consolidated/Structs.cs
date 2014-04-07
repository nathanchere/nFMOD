using System;
using System.Runtime.InteropServices;

// Members marked with [in] mean the user sets the value before passing it to the function.
// Members marked with [out] mean FMOD sets the value to be used after the function exits.
namespace nFMOD
{           
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
    public struct UsageDetails
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

        public string name { get { return Marshal.PtrToStringAnsi(namePtr); } }
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

            //TODO replace by Vector3
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] private float[] reflectionsPan;

            private int reverb;
            private float reverbDelay;

            //TODO replace by Vector3
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] private float[] reverbPan;

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
                get { return this.instance; }
                set
                {
                    this.CheckRange(value, 0, 3, "Instance");
                    this.instance = value;
                }
            }

            /// <summary>
            /// Sets all listener properties
            /// </summary>
            public int Environment
            {
                get { return this.environment; }
                set
                {
                    this.CheckRange(value, -1, 25, "Environment");
                    this.environment = value;
                }
            }

            /// <summary>
            /// Environment size in meters
            /// </summary>
            public float EnvironmentSize
            {
                get { return this.envSize; }
                set
                {
                    this.CheckRange(value, 1.0, 100.0, "EnvironmentSize");
                    this.envSize = value;
                }
            }

            /// <summary>
            /// Environment diffusion
            /// </summary>
            public float EnvironmentDiffusion
            {
                get { return this.envDiffusion; }
                set
                {
                    this.CheckRange(value, 0.0, 1.0, "EnvironmentDiffusion");
                    this.envDiffusion = value;
                }
            }

            /// <summary>
            /// Room effect level at mid frequencies
            /// </summary>
            public int Room
            {
                get { return this.room; }
                set
                {
                    this.CheckRange(value, -10000, 0, "Room");
                    this.room = value;
                }
            }

            /// <summary>
            /// Relative room effect level at high frequencies
            /// </summary>
            public int RoomHighFrequencies
            {
                get { return this.roomHF; }
                set
                {
                    this.CheckRange(value, -10000, 0, "RoomHighFrequencies");
                    this.roomHF = value;
                }
            }

            /// <summary>
            /// Relative room effect level at low frequencies
            /// </summary>
            public int RoomLowFrequencies
            {
                get { return this.roomLF; }
                set
                {
                    this.CheckRange(value, -10000, 0, "RoomLowFrequencies");
                    this.roomLF = value;
                }
            }

            /// <summary>
            /// Reverb decay time at mid frequencies
            /// </summary>
            public float DecayTime
            {
                get { return this.decayTime; }
                set
                {
                    this.CheckRange(value, 0.1, 20.0, "DecayTime");
                    this.decayTime = value;
                }
            }

            /// <summary>
            /// High-frequency to mid-frequency decay time ratio
            /// </summary>
            public float DecayHighFrequencyRatio
            {
                get { return this.decayHFRatio; }
                set
                {
                    this.CheckRange(value, 0.1, 2.0, "DecayHighFrequencyRatio");
                    this.decayHFRatio = value;
                }
            }

            /// <summary>
            /// Low-frequency to mid-frequency decay time ratio
            /// </summary>
            public float DecayLowFrequencyRatio
            {
                get { return this.decayLFRatio; }
                set
                {
                    this.CheckRange(value, 0.1, 2.0, "DecayLowFrequencyRatio");
                    this.decayLFRatio = value;
                }
            }

            /// <summary>
            /// Early reflections level relative to room effect
            /// </summary>
            public int Reflections
            {
                get { return this.reflections; }
                set
                {
                    this.CheckRange(value, -10000, 1000, "Reflections");
                    this.reflections = value;
                }
            }

            /// <summary>
            /// Initial reflection delay time
            /// </summary>
            public float ReflectionsDelay
            {
                get { return this.reflectionsDelay; }
                set
                {
                    this.CheckRange(value, 0.0, 0.3, "ReflectionsDelay");
                    this.reflectionsDelay = value;
                }
            }            

            /// <summary>
            /// Early reflections panning vector
            /// </summary>
            public float[] ReflectionsPan //TODO replace by Vector3
            {
                get { return this.reflectionsPan; }
                set { this.reflectionsPan = value; }
            }

            /// <summary>
            /// Late reverb level relative to room effect
            /// </summary>
            public int Reverb
            {
                get { return this.reverb; }
                set
                {
                    this.CheckRange(value, -10000, 2000, "Reverb");
                    this.reverb = value;
                }
            }

            /// <summary>
            /// Late reverb delay time relative to initial reflection
            /// </summary>
            public float ReverbDelay
            {
                get { return this.reverbDelay; }
                set
                {
                    this.CheckRange(value, 0.0, 0.1, "ReverbDelay");
                    this.reverbDelay = value;
                }
            }
            
            /// <summary>
            /// Late reverb panning vector)
            /// </summary>
            public float[] ReverbPan //TODO replace by Vector3
            {
                get { return this.reverbPan; }
                set { this.reverbPan = value; }
            }

            /// <summary>
            /// Echo time
            /// </summary>
            public float EchoTime
            {
                get { return this.echoTime; }
                set
                {
                    this.CheckRange(value, 0.075, 0.25, "EchoTime");
                    this.echoTime = value;
                }
            }

            /// <summary>
            /// Echo depth
            /// </summary>
            public float EchoDepth
            {
                get { return this.echoDepth; }
                set
                {
                    this.CheckRange(value, 0.0, 1.0, "EchoDepth");
                    this.echoDepth = value;
                }
            }

            /// <summary>
            /// Modulation time
            /// </summary>
            public float ModulationTime
            {
                get { return this.modulationTime; }
                set
                {
                    this.CheckRange(value, 0.04, 4.0, "ModulationTime");
                    this.modulationTime = value;
                }
            }

            /// <summary>
            /// Modulation depth
            /// </summary>
            public float ModulationDepth
            {
                get { return this.modulationDepth; }
                set
                {
                    this.CheckRange(value, 0.0, 1.0, "ModulationDepth");
                    this.modulationDepth = value;
                }
            }

            /// <summary>
            /// Change in level per meter at high frequencies
            /// </summary>
            public float AirAbsorptionHighFrequencies
            {
                get { return this.airAbsorptionHF; }
                set
                {
                    this.CheckRange(value, -100.0, 0.0, "AirAbsorptionHighFrequencies");
                    this.airAbsorptionHF = value;
                }
            }

            /// <summary>
            /// Reference high frequency (hz)
            /// </summary>
            public float HighFrequencyReference
            {
                get { return this.hFReference; }
                set
                {
                    this.CheckRange(value, 1000.0, 20000.0, "HighFrequencyReference");
                    this.hFReference = value;
                }
            }

            /// <summary>
            /// Reference low frequency (hz)
            /// </summary>
            public float LowFrequencyReference
            {
                get { return this.lFReference; }
                set
                {
                    this.CheckRange(value, 20.0, 1000.0, "LowFrequencyReference");
                    this.lFReference = value;
                }
            }

            /// <summary>
            /// Like rolloffscale in System::set3DSettings but for reverb room size effect
            /// </summary>
            public float RoomRolloffFactor
            {
                get { return this.roomRolloffFactor; }
                set
                {
                    this.CheckRange(value, 0.0, 10.0, "RoomRolloffFactor");
                    this.roomRolloffFactor = value;
                }
            }

            #endregion

            /// <summary>
            /// Modifies the behavior of other reverb properties.
            /// </summary>
            public ReverbFlags Flags
            {
                get { return this.flags; }
                set { this.flags = value; }
            }

            private void CheckRange(double Value, double Min, double Max, string Param)
            {
                if (Value < Min || Value > Max)
                    throw new ArgumentOutOfRangeException(Param, Value,
                        string.Format("{0}: Tried to set the value [{1}], but only accept [{2} to {3}].", Param, Value,
                            Min, Max));
            }

            public static readonly ReverbProperties Generic = new ReverbProperties
            {
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
                ReflectionsPan = new float[] {0.0f, 0.0f, 0.0f},
                Reverb = 200,
                ReverbDelay = 0.011f,
                ReverbPan = new float[] {0.0f, 0.0f, 0.0f},
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
