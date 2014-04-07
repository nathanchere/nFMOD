using System;

namespace nFMOD
{
    /// <summary>
    /// Bit fields for memory allocation type being passed into FMOD memory callbacks.
    /// </summary>
    public enum MemoryType
    {
        /// <summary>
        /// Standard memory.
        /// </summary>
        Normal = 0x00000000,

        /// <summary>
        /// Stream file buffer, size controllable with System::setStreamBufferSize.
        /// </summary>
        StreamFile = 0x00000001,

        /// <summary>
        /// Stream decode buffer, size controllable with FMOD_CREATESOUNDEXINFO::decodebuffersize.
        /// </summary>
        StreamDecode = 0x00000002,

        /// <summary>
        /// Requires XPhysicalAlloc / XPhysicalFree.
        /// </summary>
        Xbox360_Physical = 0x00100000,

        /// <summary>
        /// Persistent memory. Memory will be freed when System::release is called.
        /// </summary>
        Persistent = 0x00200000,

        /// <summary>
        /// Secondary memory. Allocation should be in secondary memory. For example RSX on the PS3.
        /// </summary>
        Secondary = 0x00400000
    }

    /// <summary>
    /// List of time types that can be returned by Sound::getLength and used with Channel::setPosition or Channel::getPosition.
    /// </summary>
    public enum TimeUnit
    {
        Milliseconds = 0x1,

        /// <summary>
        /// PCM Samples, related to milliseconds * samplerate / 1000.
        /// </summary>
        PCM = 0x2,

        /// <summary>
        /// Bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes).
        /// </summary>
        PCMBytes = 0x4,

        /// <summary>
        /// Raw file bytes of (compressed) sound data (does not include headers).  Only used by Sound::getLength and Channel::getPosition.
        /// </summary>
        RawBytes = 0x8,

        /// <summary>
        /// MOD/S3M/XM/IT.  Order in a sequenced module format.  Use Sound::getFormat to determine the format.
        /// </summary>
        ModOrder = 0x100,

        /// <summary>
        /// MOD/S3M/XM/IT.  Current row in a sequenced module format.  Sound::getLength will return the number if rows in the currently playing or seeked to pattern. 
        /// </summary>
        ModRow = 0x200,

        /// <summary>
        /// MOD/S3M/XM/IT.  Current pattern in a sequenced module format.  Sound::getLength will return the number of patterns in the song and Channel::getPosition will return the currently playing pattern.
        /// </summary>
        ModPattern = 0x400,

        /// <summary>
        /// Currently playing subsound in a sentence time in milliseconds.
        /// </summary>
        Sentence_Milliseconds = 0x10000,

        /// <summary>
        /// Currently playing subsound in a sentence time in PCM Samples, related to milliseconds * samplerate / 1000.
        /// </summary>
        Sentence_PCM = 0x20000,

        /// <summary>
        /// Currently playing subsound in a sentence time in bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes).
        /// </summary>
        Sentence_PCMBytes = 0x40000,

        /// <summary>
        /// Currently playing sentence index according to the channel.
        /// </summary>
        Sentence = 0x80000,

        /// <summary>
        /// Currently playing subsound index in a sentence.
        /// </summary>
        Sentence_SubSound = 0x100000,

        /// <summary>
        /// Time value as seen by buffered stream.  This is always ahead of audible time, and is only used for processing.
        /// </summary>
        Buffered = 0x10000000
    }

    /// <summary>
    /// These are speaker types defined for use with the System::setSpeakerMode or System::getSpeakerMode command.
    /// </summary>
    public enum SpeakerMode : int
    {
        /// <summary>		
        /// Output devices that are not specifically mono/stereo/quad/surround/5.1 or 7.1, but are multichannel.
        /// Sound channels map to speakers sequentially, so a mono sound maps to output speaker 0, stereo sound maps to output speaker 0 & 1.
        /// The user assumes knowledge of the speaker order.  FMOD_SPEAKER enumerations may not apply, so raw channel indicies should be used.
        /// Multichannel sounds map input channels to output channels 1:1.
        /// Channel::setPan and Channel::setSpeakerMix do not work.
        /// Speaker levels must be manually set with Channel::setSpeakerLevels.
        /// </summary>
        Raw,

        /// <summary>
        /// Single-speaker arrangement.
        /// Panning does not work in this speaker mode.
        /// Mono, stereo and multichannel sounds have each sound channel played on the one speaker unity.
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix does not work.
        /// </summary>
        Mono,

        /// <summary>
        /// Arrangements that have a left and right speaker [DEFAULT]
        /// Mono sounds default to an even distribution between left and right. They can be panned with Channel::setPan.
        /// Stereo sounds default to the middle, or full left in the left speaker and full right in the right speaker.
        /// They can be cross faded with Channel::setPan.
        /// Multichannel sounds have each sound channel played on each speaker at unity.
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix works but only front left and right parameters are used, the rest are ignored.
        /// </summary>
        Stereo,

        /// <summary>
        /// Arrangements that have a front left, front right, rear left and a rear right speaker.
        /// Mono sounds default to an even distribution between front left and front right.  They can be panned with Channel::setPan.
        /// Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.
        /// They can be cross faded with Channel::setPan.
        /// Multichannel sounds default to all of their sound channels being played on each speaker in order of input.
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix works but side left, side right, center and lfe are ignored.
        /// </summary>
        Quad,

        /// <summary>
        /// Arrangements that have a front left, front right, front center and a rear center.
        /// Mono sounds default to the center speaker.  They can be panned with Channel::setPan.
        /// Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
        /// They can be cross faded with Channel::setPan.
        /// Multichannel sounds default to all of their sound channels being played on each speaker in order of input.
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix works but side left, side right and lfe are ignored, and rear left / rear right are averaged into the rear speaker.
        /// </summary>
        Surround,

        /// Arrangements that have a left/right/center/rear left/rear right and a subwoofer speaker.
        /// Mono sounds default to the center speaker.  They can be panned with Channel::setPan.
        /// Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.  
        /// They can be cross faded with Channel::setPan.
        /// Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix works but side left / side right are ignored.
        _5Point1,

        /// <summary>
        /// Arrangements that have a left/right/center/rear left/rear right/side left/side right and a subwoofer speaker.
        /// Mono sounds default to the center speaker.  They can be panned with Channel::setPan.
        /// Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.
        /// They can be cross faded with Channel::setPan.
        /// Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix works and every parameter is used to set the balance of a sound in any speaker.
        /// </summary>
        _7Point1,

        /// <summary>
        /// This mode is for mono, stereo, 5.1 and 7.1 speaker arrangements, as it is backwards and forwards compatible with stereo,
        /// but to get a surround effect a Dolby Prologic or Prologic 2 hardware decoder / amplifier is needed.
        /// Pan behaviour is the same as FMOD_SPEAKERMODE_5POINT1.
        /// If this function is called the numoutputchannels setting in System::setSoftwareFormat is overwritten.
        /// For 3D sounds, panning is determined at runtime by the 3D subsystem based on the speaker mode to determine
        /// which speaker the sound should be placed in.
        /// </summary>
        Prologic,

        /// <summary>
        /// Maximum number of speaker modes supported.
        /// </summary>
        Max,
    }

    /// <summary>
    /// When creating a multichannel sound, FMOD will pan them to their default speaker locations.
    /// For example a 6 channel sound will default to one channel per 5.1 output speaker.
    /// Another example is a stereo sound.  It will default to left = front left, right = front right.	
    /// This is for sounds that are not 'default'.
    /// For example you might have a sound that is 6 channels but actually made up of 3 stereo pairs,
    /// that should all be located in front left, front right only.
    /// </summary>
    /// <remarks>
    /// For full flexibility of speaker assignments, use Channel::setSpeakerLevels.  This functionality is cheaper, uses less memory and easier to use.
    /// </remarks>
    public enum SpeakerMapType
    {
        /// <summary>
        /// This is the default, and just means FMOD decides which speakers it puts the source channels.
        /// </summary>
        Default,

        /// <summary>
        /// This means the sound is made up of all mono sounds.
        /// All voices will be panned to the front center by default in this case.
        /// </summary>
        AllMono,

        /// <summary>
        /// This means the sound is made up of all stereo sounds.
        /// All voices will be panned to front left and front right alternating every second channel.
        /// </summary>
        AllStereo,

        /// <summary>
        /// Map a 5.1 sound to use protools L C R Ls Rs LFE mapping.
        /// Will return an error if not a 6 channel sound.
        /// </summary>
        ProTools51,
    }

    /// <summary>
    /// These are speaker types defined for use with the Channel::setSpeakerLevels command.
    /// It can also be used for speaker placement in the System::setSpeakerPosition command.
    /// </summary>
    /// <remarks>
    /// If you are using FMOD_SPEAKERMODE_RAW and speaker assignments are meaningless, just cast a raw integer value to this type.
    /// For example (FMOD_SPEAKER)7 would use the 7th speaker (also the same as FMOD_SPEAKER_SIDE_RIGHT).
    /// Values higher than this can be used if an output system has more than 8 speaker types / output channels.  15 is the current maximum.
    /// </remarks>
    public enum Speaker : int
    {
        FrontLeft,
        FrontRight,
        FrontCenter,
        LowFrequency,
        BackLeft,
        BackRight,
        SideLeft,
        SideRight,

        /// <summary>
        /// Maximum number of speaker types supported.
        /// </summary>
        Max,

        /// <summary>
        /// For use with FMOD_SPEAKERMODE_MONO and Channel::SetSpeakerLevels.
        /// Mapped to same value as FMOD_SPEAKER_FRONT_LEFT.
        /// </summary>
        Mono = FrontLeft,

        /// <summary>
        /// A non speaker.  Use this to send.
        /// </summary>
        Null = Max,

        /// <summary>
        /// For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers.
        /// </summary>
        SBL = SideLeft,

        /// <summary>
        /// For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers.
        /// </summary>
        SBR = SideRight,
    }

    /// <summary>
    /// Sound description bitfields, bitwise OR them together for loading and describing sounds.
    /// </summary>
    /// <remarks>
    /// By default a sound will open as a static sound that is decompressed fully into memory.
    /// To have a sound stream instead, use FMOD_CREATESTREAM.
    /// Some opening modes (ie FMOD_OPENUSER, FMOD_OPENMEMORY, FMOD_OPENRAW) will need extra information.
    /// This can be provided using the FMOD_CREATESOUNDEXINFO structure.
    /// </remarks>
    [Flags]
    public enum Mode : uint
    {
        /// <summary>
        /// FMOD_DEFAULT is a default sound type.
        /// Equivalent to all the defaults listed below.
        /// FMOD_LOOP_OFF, FMOD_2D, FMOD_HARDWARE.
        /// </summary>
        Default = 0x0,

        /// <summary>
        /// For non looping sounds. (default).  Overrides FMOD_LOOP_NORMAL / FMOD_LOOP_BIDI.
        /// </summary>
        LoopOff = 0x1,

        /// <summary>
        /// For forward looping sounds.
        /// </summary>
        LoopNormal = 0x2,

        /// <summary>
        /// For bidirectional looping sounds. (only works on software mixed static sounds).
        /// </summary>
        LoopBidi = 0x4,

        /// <summary>
        /// Ignores any 3d processing. (default).
        /// </summary>
        _2D = 0x8,

        /// <summary>
        /// Makes the sound positionable in 3D.
        /// Overrides FMOD_2D.
        /// </summary>
        _3D = 0x10,

        /// <summary>
        /// Attempts to make sounds use hardware acceleration. (default).
        /// </summary>
        Hardware = 0x20,

        /// <summary>
        /// Makes sound reside in software.
        /// Overrides FMOD_HARDWARE.
        /// Use this for FFT,
        /// DSP, 2D multi speaker support and other software related features.
        /// </summary>
        Software = 0x40,

        /// <summary>
        /// Decompress at runtime, streaming from the source provided (standard stream).
        /// Overrides FMOD_CREATESAMPLE.
        /// </summary>
        CreateStream = 0x80,

        /// <summary>
        /// Decompress at loadtime,
        /// decompressing or decoding whole file into memory as the target sample format.
        /// (standard sample).
        /// </summary>
        CreateSample = 0x100,

        /// <summary>
        /// Load MP2, MP3, IMAADPCM or XMA into memory and leave it compressed.
        /// During playback the FMOD software mixer will decode it in realtime as a 'compressed sample'.
        /// Can only be used in combination with FMOD_SOFTWARE.
        /// </summary>
        CreateCompressedSample = 0x200,

        /// <summary>
        /// Opens a user created static sample or stream.
        /// Use FMOD_CREATESOUNDEXINFO to specify format and/or read callbacks.
        /// If a user created 'sample' is created with no read callback, the sample will be empty.
        /// Use FMOD_Sound_Lock and FMOD_Sound_Unlock to place sound data into the sound if this is the case.
        /// </summary>
        OpenUser = 0x400,

        /// <summary>
        /// "name_or_data" will be interpreted as a pointer to memory instead of filename for creating sounds.
        /// </summary>
        OpenMemory = 0x800,

        /// <summary>
        /// "name_or_data" will be interpreted as a pointer to memory instead of filename for creating sounds.
        /// Use FMOD_CREATESOUNDEXINFO to specify length.
        /// This differs to FMOD_OPENMEMORY in that it uses the memory as is, without duplicating the memory into its own buffers.
        /// FMOD_SOFTWARE only. Doesn't work with FMOD_HARDWARE, as sound hardware cannot access main ram on a lot of platforms.
        /// Cannot be freed after open, only after Sound::release.
        /// Will not work if the data is compressed and FMOD_CREATECOMPRESSEDSAMPLE is not used.
        /// </summary>
        OpenMemoryPoint = 0x10000000,

        /// <summary>
        /// Will ignore file format and treat as raw pcm.
        /// User may need to declare if data is FMOD_SIGNED or FMOD_UNSIGNED
        /// </summary>
        OpenRaw = 0x1000,

        /// <summary>
        /// Just open the file, dont prebuffer or read.
        /// Good for fast opens for info, or when FMOD_Sound_ReadData is to be used.
        /// </summary>
        OpenOnly = 0x2000,

        /// <summary>
        /// For FMOD_System_CreateSound - for accurate FMOD_Sound_GetLength / FMOD_Channel_SetPosition on VBR MP3, AAC and MOD/S3M/XM/IT/MIDI files.
        /// Scans file first, so takes longer to open.
        /// FMOD_OPENONLY does not affect this.
        /// </summary>
        AccurateTime = 0x4000,

        /// <summary>
        /// For corrupted / bad MP3 files.
        /// This will search all the way through the file until it hits a valid MPEG header.
        /// Normally only searches for 4k.
        /// </summary>
        MpegSearch = 0x8000,

        /// <summary>
        /// For opening sounds and getting streamed subsounds (seeking) asyncronously.
        /// Use Sound::getOpenState to poll the state of the sound as it opens or retrieves the subsound in the background.
        /// </summary>
        NonBlocking = 0x10000,

        /// <summary>
        /// Unique sound, can only be played one at a time.
        /// </summary>
        Unique = 0x20000,

        /// <summary>
        /// Make the sound's position, velocity and orientation relative to the listener.
        /// </summary>
        _3D_HeadRelative = 0x40000,

        /// <summary>
        /// Make the sound's position, velocity and orientation absolute (relative to the world). (DEFAULT)
        /// </summary>
        _3D_WorldRelative = 0x80000,

        /// <summary>
        /// This sound will follow the standard logarithmic rolloff model where mindistance = full volume,
        /// maxdistance = where sound stops attenuating,
        /// and rolloff is fixed according to the global rolloff factor.  (default)
        /// </summary>
        _3D_LogRolloff = 0x100000,

        /// <summary>
        /// This sound will follow a linear rolloff model where mindistance = full volume, maxdistance = silence.
        /// </summary>
        _3D_LinearRolloff = 0x200000,

        /// <summary>
        /// This sound will follow a rolloff model defined by FMOD_Sound_Set3DCustomRolloff / FMOD_Channel_Set3DCustomRolloff.
        /// </summary>
        _3D_CustomRolloff = 0x4000000,

        /// <summary>
        /// For CDDA sounds only - use ASPI instead of NTSCSI to access the specified CD/DVD device.
        /// </summary>
        CDDA_ForceASPI = 0x400000,

        /// <summary>
        /// For CDDA sounds only - perform jitter correction.
        /// Jitter correction helps produce a more accurate CDDA stream at the cost of more CPU time.
        /// </summary>
        CDDA_JitterCorrect = 0x800000,

        /// <summary>
        /// Filename is double-byte unicode.
        /// </summary>
        Unicode = 0x1000000,

        /// <summary>
        /// Skips id3v2/asf/etc tag checks when opening a sound,
        /// to reduce seek/read overhead when opening files (helps with CD performance).
        /// </summary>
        IgnoreTags = 0x2000000,

        /// <summary>
        /// Removes some features from samples to give a lower memory overhead, like FMOD_Sound_GetName.
        /// </summary>
        LowMemory = 0x8000000,

        /// <summary>
        /// Load sound into the secondary RAM of supported platform.  On PS3, sounds will be loaded into RSX/VRAM.
        /// </summary>
        LoadSecondaryRam = 0x20000000,

        /// <summary>
        /// For sounds that start virtual (due to being quiet or low importance),
        /// instead of swapping back to audible,
        /// and playing at the correct offset according to time,
        /// this flag makes the sound play from the start.
        /// </summary>
        Virtual_PlayFromStart = 0x80000000
    }

    public enum ErrorCode
    {
        /// <summary>
        /// No errors.
        /// </summary>
        OK = 0,

        /// <summary>
        /// Tried to call lock a second time before unlock was called.
        /// </summary>
        AlreadyLocked,

        /// <summary>
        /// Tried to call a function on a data type that does not allow
        /// this type of functionality (ie calling Sound::lock on a streaming sound).
        /// </summary>
        BadCommand,

        /// <summary>
        /// Neither NTSCSI nor ASPI could be initialised.
        /// </summary>
        CDDA_Drivers,

        /// <summary>
        /// An error occurred while initialising the CDDA subsystem.
        /// </summary>
        CDDA_Init,

        /// <summary>
        /// Couldn't find the specified device.
        /// </summary>
        CDDA_InvalidDevice,

        /// <summary>
        /// No audio tracks on the specified disc.
        /// </summary>
        CDDA_NoAudio,

        /// <summary>
        /// No CD/DVD devices were found.
        /// </summary>
        CDDA_NoDevices,

        /// <summary>
        /// No disc present in the specified drive.
        /// </summary>
        CDDA_NoDisc,

        /// <summary>
        /// A CDDA read error occurred.
        /// </summary>
        CDDA_Read,

        /// <summary>
        /// Error trying to allocate a channel.
        /// </summary>
        Channel_Alloc,

        /// <summary>
        /// The specified channel has been reused to play another sound.
        /// </summary>
        Channel_Stolen,

        /// <summary>
        /// A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly.
        /// </summary>
        COM,

        /// <summary>
        /// DMA Failure.  See debug output for more information.
        /// </summary>
        DMA,

        /// <summary>
        /// DSP connection error.  DspConnection possibly caused a cyclic dependancy.
        /// </summary>
        DSP_Connection,

        /// <summary>
        /// DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format.
        /// </summary>
        DSP_Format,

        /// <summary>
        /// DSP connection error.  Couldn't find the DSP unit specified.
        /// </summary>
        DSP_NotFound,

        /// <summary>
        /// DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback.
        /// </summary>
        DSP_Running,

        /// <summary>
        /// DSP connection error.  The unit being connected to or disconnected should only have 1 input or output.
        /// </summary>
        DSP_TooManyConnections,

        /// <summary>
        /// Error loading file.
        /// </summary>
        File_Bad,

        /// <summary>
        /// Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format.
        /// </summary>
        File_CouldNotSeek,

        /// <summary>
        /// Media was ejected while reading.
        /// </summary>
        File_DiskEjected,

        /// <summary>
        /// End of file unexpectedly reached while trying to read essential data (truncated data?).
        /// </summary>
        File_EOF,

        /// <summary>
        /// File not found.
        /// </summary>
        File_NotFound,

        /// <summary>
        /// Unwanted file access occured.
        /// </summary>
        File_Unwanted,

        /// <summary>
        /// Unsupported file or audio format.
        /// </summary>
        Format,

        /// <summary>
        /// A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere.
        /// </summary>
        HTTP,

        /// <summary>
        /// The specified resource requires authentication or is forbidden.
        /// </summary>
        HTTP_Access,

        /// <summary>
        /// Proxy authentication is required to access the specified resource.
        /// </summary>
        HTTP_ProxyAuth,

        /// <summary>
        /// A HTTP server error occurred.
        /// </summary>
        HTTP_ServerError,

        /// <summary>
        /// The HTTP request timed out.
        /// </summary>
        HTTP_Timeout,

        /// <summary>
        /// FMOD was not initialized correctly to support this function.
        /// </summary>
        Initialization,

        /// <summary>
        /// Cannot call this command after System::init.
        /// </summary>
        Initialized,

        /// <summary>
        /// An error occured that wasn't supposed to.  Contact support.
        /// </summary>
        Internal,

        /// <summary>
        /// On Xbox 360 this memory address passed to FMOD must be physical (ie allocated with XPhysicalAlloc.)
        /// </summary>
        InvalidAddress,

        /// <summary>
        /// Value passed in was a NaN, Inf or denormalized float.
        /// </summary>
        InvalidFloat,

        /// <summary>
        /// An invalid object handle was used.
        /// </summary>
        InvalidHandle,

        /// <summary>
        /// An invalid parameter was passed to this function.
        /// </summary>
        InvalidParam,

        /// <summary>
        /// An invalid seek position was passed to this function.
        /// </summary>
        InvalidPosition,

        /// <summary>
        /// An invalid speaker was passed to this function based on the current speaker mode.
        /// </summary>
        InvalidSpeaker,

        /// <summary>
        /// The syncpoint did not come from this sound handle.
        /// </summary>
        InvalidSyncpoint,

        /// <summary>
        /// The vectors passed in are not unit length, or perpendicular.
        /// </summary>
        InvalidVector,

        /// <summary>
        /// PS2 only.  fmodex.irx failed to initialize.  This is most likely because you forgot to load it.
        /// </summary>
        IRX,

        /// <summary>
        /// Reached maximum audible playback count for this sound's soundgroup.
        /// </summary>
        MaxAudible,

        /// <summary>
        /// Not enough memory or resources.
        /// </summary>
        Memory,

        /// <summary>
        /// Can't use FMOD_OPENMEMORY_POINT on non PCM source data or non mp3/xma/adpcm data if FMOD_CREATECOMPRESSEDSAMPLE was used.
        /// </summary>
        Memory_CantPoint,

        /// <summary>
        /// PS2 only.  Not enough memory or resources on PlayStation 2 IOP ram.
        /// </summary>
        Memory_IOP,

        /// <summary>
        /// Not enough memory or resources on console sound ram.
        /// </summary>
        Memory_SRAM,

        /// <summary>
        /// Tried to call a command on a 3d sound when the command was meant for 2d sound.
        /// </summary>
        Needs2D,

        /// <summary>
        /// Tried to call a command on a 2d sound when the command was meant for 3d sound.
        /// </summary>
        Needs3D,

        /// <summary>
        /// Tried to use a feature that requires hardware support.  (ie trying to play a VAG compressed sound in software on PS2).
        /// </summary>
        NeedsHardware,

        /// <summary>
        /// Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature.
        /// </summary>
        NeedsSoftware,

        /// <summary>
        /// Couldn't connect to the specified host.
        /// </summary>
        Net_Connect,

        /// <summary>
        /// A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere.
        /// </summary>
        Net_SocketError,

        /// <summary>
        /// The specified URL couldn't be resolved.
        /// </summary>
        Net_Url,

        /// <summary>
        /// Operation on a non-blocking socket could not complete immediately.
        /// </summary>
        Net_WouldBlock,

        /// <summary>
        /// Operation could not be performed because specified sound is not ready.
        /// </summary>
        NotReady,

        /// <summary>
        /// Error initializing output device, but more specifically, the output device is already in use and cannot be reused.
        /// </summary>
        Output_Allocated,

        /// <summary>
        /// Error creating hardware sound buffer.
        /// </summary>
        Output_CreateBuffer,

        /// <summary>
        /// A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted.
        /// </summary>
        Output_DriverCall,

        /// <summary>
        /// Error enumerating the available driver list. List may be inconsistent due to a recent device addition or removal.
        /// </summary>
        Output_Enumeration,

        /// <summary>
        /// Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output).
        /// </summary>
        Output_Format,

        /// <summary>
        /// Error initializing output device.
        /// </summary>
        Output_Init,

        /// <summary>
        /// FMOD_HARDWARE was specified but the sound card does not have the resources nescessary to play it.
        /// </summary>
        Output_NoHardware,

        /// <summary>
        /// Attempted to create a software sound but no software channels were specified in System::init.
        /// </summary>
        Output_NoSoftware,

        /// <summary>
        /// Panning only works with mono or stereo sound sources.
        /// </summary>
        Pan,

        /// <summary>
        /// An unspecified error has been returned from a 3rd party plugin.
        /// </summary>
        Plugin,

        /// <summary>
        /// The number of allowed instances of a plugin has been exceeded.
        /// </summary>
        Plugin_Instances,

        /// <summary>
        /// A requested output dsp unit type or codec was not available.
        /// </summary>
        Plugin_Missing,

        /// <summary>
        /// A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback)
        /// </summary>
        Plugin_Resource,

        /// <summary>
        /// The specified sound is still in use by the event system,
        /// call EventSystem::unloadFSB before trying to release it.
        /// </summary>
        Preloaded,

        /// <summary>
        /// The specified sound is still in use by the event system,
        /// wait for the event which is using it finish with it.
        /// </summary>
        ProgrammerSound,

        /// <summary>
        /// An error occured trying to initialize the recording device.
        /// </summary>
        Record,

        /// <summary>
        /// Specified Instance in FMOD_REVERB_PROPERTIES couldn't be set. Most likely because another application has locked the EAX4 FX slot.
        /// </summary>
        Reverb_Instance,

        /// <summary>
        /// This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first.
        /// </summary>
        SubSound_Allocated,

        /// <summary>
        /// Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file.
        /// </summary>
        SubSound_CantMove,

        /// <summary>
        /// The subsound's mode bits do not match with the parent sound's mode bits.
        /// See documentation for function that it was called with.
        /// </summary>
        SubSound_Mode,

        /// <summary>
        /// The error occured because the sound referenced contains subsounds.
        /// (ie you cannot play the parent sound as a static sample, only its subsounds.)
        /// </summary>
        SubSounds,

        /// <summary>
        /// The specified tag could not be found or there are no tags.
        /// </summary>
        TagNotFound,

        /// <summary>
        /// The sound created exceeds the allowable input channel count.
        /// This can be increased using the maxinputchannels parameter in System::setSoftwareFormat.
        /// </summary>
        TooManyChannels,

        /// <summary>
        /// Something in FMOD hasn't been implemented when it should be! contact support!
        /// </summary>
        Unimplemented,

        /// <summary>
        /// This command failed because System::init or System::setDriver was not called.
        /// </summary>
        Uninitialized,

        /// <summary>
        /// A command issued was not supported by this object.
        /// Possibly a plugin without certain callbacks specified.
        /// </summary>
        Unsupported,

        /// <summary>
        /// An error caused by System::update occured.
        /// </summary>
        Update,

        /// <summary>
        /// The version number of this file format is not supported.
        /// </summary>
        Version,

        /// <summary>
        /// An Event failed to be retrieved, most likely due to 'just fail' being specified as the max playbacks behavior.
        /// </summary>
        Event_Failed,

        /// <summary>
        /// Can't execute this command on an EVENT_INFOONLY event.
        /// </summary>
        Event_InfoOnly,

        /// <summary>
        /// An error occured that wasn't supposed to.  See debug log for reason.
        /// </summary>
        Event_Internal,

        /// <summary>
        /// Event failed because 'Max streams' was hit when FMOD_INIT_FAIL_ON_MAXSTREAMS was specified.
        /// </summary>
        Event_MaxStreams,

        /// <summary>
        /// FSB mis-matches the FEV it was compiled with.
        /// </summary>
        Event_Mismatch,

        /// <summary>
        /// A category with the same name already exists.
        /// </summary>
        Event_NameConflict,

        /// <summary>
        /// The requested event, event group, event category or event property could not be found.
        /// </summary>
        Event_NotFound,

        /// <summary>
        /// Tried to call a function on a complex event that's only supported by simple events.
        /// </summary>
        Event_NeedsSimple,

        /// <summary>
        /// An event with the same GUID already exists.
        /// </summary>
        Event_GuidConflict,

        /// <summary>
        /// The specified project has already been loaded.
        /// Having multiple copies of the same project loaded simultaneously is forbidden.
        /// </summary>
        Event_AlreadyLoaded,

        /// <summary>
        /// Music system is not initialized probably because no music data is loaded.
        /// </summary>
        Music_Uninitialized,

        /// <summary>
        /// The requested music entity could not be found.
        /// </summary>
        Music_NotFound,

        /// <summary>
        /// The music callback is required, but it has not been set.
        /// </summary>
        Music_NoCallback,

    }

    /// <summary>
    /// List of tag types that could be stored within a sound.
    /// These include id3 tags, metadata from netstreams and vorbis/asf data.
    /// </summary>
    public enum TagType : int
    {
        UNKNOWN = 0,
        ID3V1,
        ID3V2,
        VORBISCOMMENT,
        SHOUTCAST,
        ICECAST,
        ASF,
        MIDI,
        PLAYLIST,
        FMOD,
        USER
    }

    /// <summary>
    /// List of data types that can be returned by Sound::getTag
    /// </summary>
    public enum TagDataType : int
    {
        BINARY = 0,
        INT,
        FLOAT,
        STRING,
        STRING_UTF16,
        STRING_UTF16BE,
        STRING_UTF8,
        CDTOC
    }

    /// <summary>
    /// These values describe what state a sound is in after NONBLOCKING has been used to open it.
    /// </summary>
    public enum OpenState : int
    {
        /// <summary>
        /// Opened and ready to play
        /// </summary>
        READY = 0,

        /// <summary>
        /// Initial load in progress
        /// </summary>
        LOADING,

        /// <summary>
        /// Failed to open - file not found, out of memory etc.  See return value of Sound::getOpenState for what happened
        /// </summary>        
        ERROR,

        /// <summary>
        /// Connecting to remote host (internet sounds only)
        /// </summary>
        CONNECTING,

        /// <summary>
        /// Buffering data
        /// </summary>
        BUFFERING,

        /// <summary>
        /// Seeking to subsound and re-flushing stream buffer
        /// </summary>
        SEEKING,

        /// <summary>
        /// Ready and playing, but not possible to release at this time without stalling the main thread
        /// </summary>
        PLAYING,

        /// <summary>
        /// Seeking within a stream to a different position
        /// </summary>
        SETPOSITION,
    }

    public enum SoundGroupBehavior : int
    {
        /// <summary>
        /// Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will simply fail during System::playSound.
        /// </summary>
        BEHAVIOR_FAIL,

        /// <summary>
        /// Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will be silent, then if another sound in the group stops the sound that was silent before becomes audible again.
        /// </summary>
        BEHAVIOR_MUTE,

        /// <summary>
        /// Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will steal the quietest / least important sound playing in the group.
        /// </summary>
        BEHAVIOR_STEALLOWEST
    }

    [Flags]
    public enum Capabilities : uint
    {
        /// <summary>
        /// Device has no special capabilities.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Device supports hardware mixing.
        /// </summary>
        Hardware = 0x00000001,

        /// <summary>
        /// User has device set to 'Hardware acceleration = off' in control panel,
        /// and now extra 200ms latency is incurred.
        /// </summary>
        HardwareEmulated = 0x00000002,

        /// <summary>
        /// Device can do multichannel output, ie greater than 2 channels.
        /// </summary>
        OutputMultichannel = 0x00000004,

        /// <summary>
        /// Device can output to 8bit integer PCM.
        /// </summary>
        OutputFormatPCM8 = 0x00000008,

        /// <summary>
        /// Device can output to 16bit integer PCM.
        /// </summary>
        OutputFormatPCM16 = 0x00000010,

        /// <summary>
        /// Device can output to 24bit integer PCM.
        /// </summary>
        OutputFormatPCM24 = 0x00000020,

        /// <summary>
        /// Device can output to 32bit integer PCM.
        /// </summary>
        OutputFormatPCM32 = 0x00000040,

        /// <summary>
        /// Device can output to 32bit floating point PCM.
        /// </summary>
        OutputFormatPCMFloat = 0x00000080,

        /// <summary>
        /// Device supports EAX2 reverb.
        /// </summary>
        ReverbEAX2 = 0x00000100,

        /// <summary>
        /// Device supports EAX3 reverb.
        /// </summary>
        ReverbEAX3 = 0x00000200,

        /// <summary>
        /// Device supports EAX4 reverb.
        /// </summary>
        ReverbEAX4 = 0x00000400,

        /// <summary>
        /// Device supports EAX5 reverb.
        /// </summary>
        ReverbEAX5 = 0x00000800,

        /// <summary>
        /// Device supports I3DL2 reverb.
        /// </summary>
        ReverbI3DL2 = 0x00001000,

        /// <summary>
        /// Device supports some form of limited hardware reverb, maybe parameterless and only selectable by environment.
        /// </summary>
        ReverbLimited = 0x00002000
    }

    /// <summary>
    /// Structure defining the properties for a reverb source, related to a FMOD channel.
    /// </summary>
    /// <remarks>
    /// Note the default reverb properties are the same as the PRESET_GENERIC preset.
    /// Note that integer values that typically range from -10,000 to 1000 are represented in 
    /// decibels, and are of a logarithmic scale, not linear, wheras FLOAT values are typically linear.                
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct ReverbChannelProperties
    {

        /// <summary>
        /// [in/out] Direct path level (at low and mid frequencies)
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 1000
        /// Default: 0
        /// </remarks>
        public int Direct;

        /// <summary>
        /// [in/out] Delative direct path level at high frequencies 
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 0
        /// Default: 0
        /// </remarks>
        public int DirectHF;

        /// <summary>
        /// [in/out] Room effect level (at low and mid frequencies)
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 1000
        /// Default: 0
        /// </remarks>
        public int Room;

        /// <summary>
        /// [in/out] Relative room effect level at high frequencies
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 0
        /// Default: 0
        /// </remarks>
        public int RoomHF;

        /// <summary>
        /// [in/out] Main obstruction control (attenuation at high frequencies)
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 0
        /// Default: 0
        /// </remarks>
        public int Obstruction;

        /// <summary>
        /// [in/out] Obstruction low-frequency level re. main control
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 1.0
        /// Default: 0.0
        /// </remarks>
        public float ObstructionLFRatio;

        /// <summary>
        /// [in/out] Main occlusion control (attenuation at high frequencies)
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 0
        /// Default: 0
        /// </remarks>
        public int Occlusion;

        /// <summary>
        /// [in/out] Occlusion low-frequency level re. main control
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 1.0
        /// Default: 0.25
        /// </remarks>
        public float OcclusionLFRatio;

        /// <summary>
        /// [in/out] Relative occlusion control for room effect
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 10.0
        /// Default: 1.5
        /// </remarks>
        public float OcclusionRoomRatio;

        /// <summary>
        /// [in/out] Relative occlusion control for direct path
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 10.0
        /// Default: 1.0
        /// </remarks>
        public float OcclusionDirectRatio;

        /// <summary>
        /// [in/out] Main exlusion control (attenuation at high frequencies)
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 0
        /// Default: 0
        /// </remarks>
        public int Exclusion;

        /// <summary>
        /// [in/out] Exclusion low-frequency level re. main control
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 1.0
        /// Default: 1.0
        /// </remarks>
        public float ExclusionLFRatio;

        /// <summary>
        /// [in/out] Outside sound cone level at high frequencies
        /// </summary>            
        /// <remarks>
        /// Min: -10000
        /// Max: 0
        /// Default: 0
        /// </remarks>
        public int OutsideVolumeHF;

        /// <summary>
        /// [in/out] Like DS3D flDopplerFactor but per source
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 10.0
        /// Default: 0.0
        /// </remarks>
        public float DopplerFactor;

        /// <summary>
        /// [in/out] Like DS3D flRolloffFactor but per source
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 10.0
        /// Default: 0.0
        /// </remarks>
        public float RolloffFactor;

        /// <summary>
        /// [in/out] Like DS3D flRolloffFactor but for room effect
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 10.0
        /// Default: 0.0
        /// </remarks>
        public float RoomRolloffFactor;

        /// <summary>
        /// [in/out] Multiplies AirAbsorptionHF member of REVERB_PROPERTIES
        /// </summary>            
        /// <remarks>
        /// Min: 0.0
        /// Max: 10.0
        /// Default: 1.0
        /// </remarks>
        public float AirAbsorptionFactor;

        /// <summary>
        /// [in/out] Modifies the behavior of properties
        /// </summary>                        
        public ReverbChannelFlags Flags;

        /// <summary>
        /// [in/out] DSP network location to connect reverb for this channel
        /// </summary>            
        public IntPtr ConnectionPoint;
    }

    /// <summary>        
    /// Values for the Flags member of the REVERB_CHANNELPROPERTIES structure.
    /// </summary>
    [Flags]
    public enum ReverbChannelFlags : uint
    {
        /// <summary>
        /// Automatic setting of 'Direct' due to distance from listener.
        /// </summary>
        DirectHFAuto = 0x00000001,

        /// <summary>
        /// Automatic setting of 'Room' due to distance from listener.
        /// </summary>
        RoomAuto = 0x00000002,

        /// <summary>
        /// Automatic setting of 'RoomHF' due to distance from listener.
        /// </summary>
        RoomHFAuto = 0x00000004,

        /// <summary>
        /// Specify channel to target reverb instance 0.  Default target.
        /// </summary>
        Instance0 = 0x00000010,

        /// <summary>
        /// Specify channel to target reverb instance 1.
        /// </summary>
        Instance1 = 0x00000020,

        /// <summary>
        /// Specify channel to target reverb instance 2.
        /// </summary>
        Instance2 = 0x00000040,

        /// <summary>
        /// Specify channel to target reverb instance 3.
        /// </summary>
        Instance3 = 0x00000080,

        Default = (DirectHFAuto | RoomAuto | RoomHFAuto | Instance0)
    }

    /// <summary>
    /// Values for the Flags member of the REVERB_PROPERTIES structure.
    /// </summary>
    [Flags]
    public enum ReverbFlags : uint
    {
        /// <summary>
        /// 'EnvSize' affects reverberation decay time
        /// </summary>
        DecayTimeScale = 0x00000001,

        /// <summary>
        /// 'EnvSize' affects reflection level
        /// </summary>
        ReflectionsScale = 0x00000002,

        /// <summary>
        /// 'EnvSize' affects initial reflection delay time
        /// </summary>
        ReflectionsDelayScale = 0x00000004,

        /// <summary>
        /// 'EnvSize' affects reflections level
        /// </summary>
        ReverbScale = 0x00000008,

        /// <summary>
        /// 'EnvSize' affects late reverberation delay time
        /// </summary>
        ReverbDelayScale = 0x00000010,

        /// <summary>
        /// AirAbsorptionHF affects DecayHFRatio
        /// </summary>
        DecayHFLimit = 0x00000020,

        /// <summary>
        /// 'EnvSize' affects echo time
        /// </summary>
        EchoTimeScale = 0x00000040,

        /// <summary>
        /// 'EnvSize' affects modulation time
        /// </summary>
        ModulationTimeScale = 0x00000080,

        Default = DecayTimeScale | ReflectionsScale |
                  ReflectionsDelayScale | ReverbScale |
                  ReverbDelayScale | DecayHFLimit
    }

}
