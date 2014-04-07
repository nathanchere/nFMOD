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
}
