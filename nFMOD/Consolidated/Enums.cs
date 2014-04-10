using System;
using System.Runtime.InteropServices;

namespace nFMOD
{
    #region Channel
    /// <summary>
    /// Types of delay that can be used with Channel::setDelay / Channel::getDelay
    /// </summary>
    /// <remarks>
    /// If you haven't called Channel::setDelay yet, if you call Channel::getDelay with FMOD_DELAYTYPE_DSPCLOCK_START it will return the 
    /// equivalent global DSP clock value to determine when a channel started, so that you can use it for other channels to sync against.
    /// Use System::getDSPClock to also get the current dspclock time, a base for future calls to Channel::setDelay.
    /// Use FMOD_64BIT_ADD or FMOD_64BIT_SUB to add a hi/lo combination together and cope with wraparound.
    /// If FMOD_DELAYTYPE_END_MS is specified, the value is not treated as a 64 bit number, just the delay hi value is used and it is
    /// treated as milliseconds.
    /// </remarks>
    public enum DelayType
    {
        /// <summary>
        /// Delay at the end of the sound in milliseconds. Use delayhi only.
        /// Channel::isPlaying will remain true until this delay has passed even though the sound itself has stopped playing
        /// </summary>
        EndInMilliseconds,

        /// <summary>
        /// Time the sound started if Channel::getDelay is used, or if Channel::setDelay is used, the sound will delay
        /// playing until this exact tick.
        /// </summary>
        DspClockStart,

        /// <summary>
        /// Time the sound should end. If this is non-zero, the channel will go silent at this exact tick.
        /// </summary>
        DspClockEnd,

        /// <summary>
        /// Time the sound should pause. If this is non-zero, the channel will pause at this exact tick.
        /// </summary>
        DspClockPause,

        Max
    }

    public enum ChannelIndex
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

    /// <summary>
    /// These callback types are used with Channel::setCallback.
    /// </summary>
    /// <remarks>
    /// Each callback has commanddata parameters passed int unique to the type of callback.
    /// See reference to FMOD_CHANNEL_CALLBACK to determine what they might mean for each type of callback.
    /// </remarks>
    public enum ChannelCallbackType
    {
        /// <summary>
        /// Called when a sound ends.
        /// </summary>
        End,

        /// <summary>
        /// Called when a voice is swapped out or swapped in.
        /// </summary>
        VirtualVoice,

        /// <summary>
        /// Called when a syncpoint is encountered.  Can be from wav file markers.
        /// </summary>
        SyncPoint,

        /// <summary>
        /// Called when the channel has its geometry occlusion value calculated.
        /// Can be used to clamp or change the value.
        /// </summary>
        Occlusion,

        Max
    }

    #endregion

    #region Debug
    /// <summary>
	/// Bit fields to use with <see cref="Debug.Level"/> to
	/// control the level of tty debug output with logging versions of FMOD (fmodL).
	/// </summary>
	[Flags]
	public enum DebugLevel : byte
	{
		None = 0x00,		
		Log = 0x01,
		Error = 0x02,
		Warning = 0x04,
		Hint = 0x08,
		
		All = 0xFF,
	}
	
	[Flags]
	public enum DebugType : byte
	{
		None = 0x00,
		
		Memory = 0x01,
        Thread = 0x02,
        File = 0x04,
        Net = 0x08,
        Event = 0x10,
		
        All = 0xFF,
	}
	
	[Flags]
	public enum DebugDisplay : byte
	{
		None = 0x00,
		
		Timestamps = 0x01,
        LineNumbers = 0x02,
        Compress = 0x04,
        Thread = 0x08,
		
        All = 0x0F,
	}
    #endregion

    #region FmodSystem
    /// <summary>
    /// These callback types are used with System::setCallback.
    /// </summary>
    /// <remarks>
    /// Currently the user must call System::update for these callbacks to trigger.
    /// </remarks>
    public enum CallbackType
    {
        /// <summary>
        /// Called when the enumerated list of devices has changed.
        /// </summary>
        DeviceListChanged,

        /// <summary>
        /// Called from System::update when an output device has been lost
        /// due to control panel parameter changes and FMOD cannot automatically recover.
        /// </summary>
        DeviceLost,

        /// <summary>
        /// Called directly when a memory allocation fails somewhere in FMOD.
        /// </summary>
        MemoryAllocationFailed,

        /// <summary>
        /// Called directly when a thread is created.
        /// </summary>
        ThreadCreated,

        /// <summary>
        /// Called when a bad connection was made with DSP::addInput.
        /// Usually called from mixer thread because that is where the connections are made.
        /// </summary>
        BadDspConnection,

        /// <summary>
        /// Called when too many effects were added exceeding the maximum tree depth of 128.
        /// This is most likely caused by accidentally adding too many DSP effects.
        /// Usually called from mixer thread because that is where the connections are made.
        /// </summary>
        BadDspLevel,

        /// <summary>
        /// Maximum number of callback types supported.
        /// </summary>
        Max

    }

    /// <summary>
    /// //Initialization flags.
    /// Use them with <see cref="FmodSystem.Init"/> in the flags parameter to change various behaviour.
    /// </summary>
    [Flags]
    public enum InitFlags
    {
        /// <summary>
        /// Initialize normally.
        /// </summary>
        Normal = 0x0,

        /// <summary>
        /// No stream thread is created internally.
        /// Mainly used with non-realtime outputs.
        /// </summary>
        StreamFromUpdate = 0x1,

        /// <summary>
        /// FMOD will treat +X as left, +Y as up and +Z as forwards.
        /// </summary>
        RightHanded3D = 0x2,

        /// <summary>
        /// Disable software mixer to save memory.
        /// Anything created with SoftwareDisable will fail and DSP will not work.
        /// </summary>
        SoftwareDisable = 0x4, //TODO verify if it fails with or without SoftwareDisable.

        /// <summary>
        /// All FMOD_SOFTWARE with FMOD_3D based voices will add a
        /// software lowpass filter effect into the DSP chain which is automatically
        /// used when Channel::set3DOcclusion is used or the geometry API.
        /// </summary>
        SoftwareOcclusion = 0x8, //TODO replace Channel::set3DOcclusion by real setting.

        /// <summary>
        /// All Software with 3D based voices will add a
        /// software lowpass filter effect into the DSP chain which causes
        /// sounds to sound duller when the sound goes behind the listener.
        /// </summary>
        SoftwareHRTF = 0x10,

        /// <summary>
        /// Enable TCP/IP based host which allows "DSPNet Listener.exe" to connect to it,
        /// and view the DSP dataflow network graph in real-time.
        /// </summary>
        EnableProfile = 0x20,

        /// <summary>
        /// SFX reverb is run using 22/24khz delay buffers, halving the memory required.
        /// </summary>
        SoftwareReverbLowMem = 0x40,

        /// <summary>
        /// Any sounds that are 0 volume will go virtual and not be processed except
        /// for having their positions updated virtually.
        /// Use System::setAdvancedSettings to adjust what volume besides zero to switch
        /// to virtual at.
        /// </summary>
        Vol0BecomesVirtual = 0x80,

        /// <summary>
        /// For WASAPI output - enable exclusive access to hardware for lower latency at the
        /// expense of excluding other applications from accessing the audio hardware.
        /// </summary>
        /// <remarks>
        /// Win32 Vista only
        /// </remarks>
        WasapiExclusive = 0x100,

        /// <summary>
        /// For DirectSound output - FMOD_HARDWARE|FMOD_3D buffers use simple stereo
        /// panning/doppler/attenuation when 3D hardware acceleration is not present.
        /// </summary>
        DirectsoundHrtfNone = 0x200,

        /// <summary>
        /// For DirectSound output - FMOD_HARDWARE|FMOD_3D buffers use a slightly higher
        /// quality algorithm when 3D hardware acceleration is not present.
        /// </summary>
        DirectsoundHrtfLight = 0x400,

        /// <summary>
        /// For DirectSound output - FMOD_HARDWARE|FMOD_3D buffers use full quality 3D
        /// playback when 3d hardware acceleration is not present.
        /// </summary>
        DirectsoundHrtfFull = 0x800,

        /// <summary>
        /// FMOD Mixer thread is woken up to do a mix when System::update is called
        /// rather than waking periodically on its own timer.
        /// </summary>
        SyncMixerWithUpdate = 0x400000,

        /// <summary>
        /// Use DTS Neural surround downmixing from 7.1 if speakermode set to FMOD_SPEAKERMODE_STEREO
        /// or FMOD_SPEAKERMODE_5POINT1. Internal DSP structure will be set to 7.1.
        /// </summary>
        DtsNeuralSurround = 0x02000000,

        /// <summary>
        /// With the geometry engine, only process the closest polygon rather than accumulating
        /// all polygons the sound to listener line intersects.
        /// </summary>
        GeometryUseClosest = 0x04000000,

        /// <summary>
        /// Disables MyEars HRTF 7.1 downmixing. MyEars will otherwise be disbaled if speakermode is not
        /// set to FMOD_SPEAKERMODE_STEREO or the data file is missing.
        /// </summary>
        DisableMyEarsHrtf = 0x08000000,

        [Obsolete("PS2 only")]
        DisableCore0Reverb = 0x10000,
        [Obsolete("PS2 only")]
        DisableCore1Reverb = 0x20000,
        [Obsolete("PS2 only")]
        DontUseScratchPad = 0x40000,
        [Obsolete("PS2 only")]
        SwapDmacChannels = 0x80000,
        [Obsolete("Xbox only")]
        RemoveHeadRoom = 0x100000,
        [Obsolete("Xbox360 only")]
        MusicMuteNotPause = 0x200000,
    }

    /// <summary>
    /// These output types are used with setOutputgetOutput to choose
    /// which output method to use.
    /// </summary>
    /// <remarks>
    /// To drive the output synchronously and to disable FMOD's timing thread,
    /// use the FMOD_INIT_NONREALTIME flag.
    /// To pass information to the driver when initializing FMOD, use the
    /// extradriverdata parameter for the following reasons:
    /// * FMOD_OUTPUTTYPE_WAVWRITER - extradriverdata is a pointer to a
    ///   char * filename that the wav writer will output to.
    /// * FMOD_OUTPUTTYPE_WAVWRITER_NRT - extradriverdata is a pointer to
    ///   a char * filename that the wav writer will output to.
    /// * FMOD_OUTPUTTYPE_DSOUND - extradriverdata is a pointer to a HWND
    ///   so that FMOD can set the focus on the audio for a particular window.
    /// * FMOD_OUTPUTTYPE_GC - extradriverdata is a pointer to a
    ///   FMOD_ARAMBLOCK_INFO struct.
    /// Currently these are the only FMOD drivers that take extra information.
    /// Other unknown plugins may have different requirements.
    /// </remarks>
    public enum OutputType
    {
        /// <summary>
        /// Picks the best output mode for the platform.
        /// This is the default.
        /// </summary>
        AutoDetect,

        /// <summary>
        /// 3rd party plugin, unknown.  This is for use with System::getOutput only.
        /// </summary>
        Unknown,

        /// <summary>
        /// All calls in this mode succeed but make no sound.
        /// </summary>
        NoSound,

        /// <summary>
        /// Writes output to fmodout.wav by default.
        /// Use System::setSoftwareFormat to set the filename.
        /// </summary>
        WavWriter,

        /// <summary>
        /// Non-realtime version of FMOD_OUTPUTTYPE_NOSOUND.
        /// User can drive mixer with System::update at whatever rate they want.
        /// </summary>
        NoSoundNonRealtime,

        /// <summary>
        /// Non-realtime version of FMOD_OUTPUTTYPE_WAVWRITER.
        /// User can drive mixer with System::update at whatever rate they want.
        /// </summary>
        WavWriterNonRealtime,

        /// <summary>
        /// DirectSound output. Use this to get hardware accelerated 3D
        /// audio and EAX Reverb support (default on Windows)
        /// </summary>
        DirectSound,

        /// <summary>
        /// Windows Multimedia output.
        /// </summary>
        WindowsMultimedia,

        /// <summary>
        /// Windows Audio Session API (default on Windows Vista)
        /// </summary>
        WASAPI,

        /// <summary>
        /// Low latency ASIO driver.
        /// </summary>
        ASIO,

        [Obsolete("Linux only")]
        OSS,
        [Obsolete("Linux only")]
        ALSA,
        [Obsolete("Linux only")]
        ESD,
        [Obsolete("Linux only")]
        PulseAudio,
        [Obsolete("Mac only")]
        SoundManager,
        [Obsolete("Mac only")]
        CoreAudio,
        [Obsolete("Xbox only")]
        Xbox,
        [Obsolete("PS2 only")]
        PS2,
        [Obsolete("PS3 only")]
        PS3,
        [Obsolete("GameCube only")]
        GameCube,
        [Obsolete("Xbox360 only")]
        Xbox360,
        [Obsolete("PSP only")]
        PSP,
        [Obsolete("Wii only")]
        Wii,
        [Obsolete("Android only")]
        Android,

        /// <summary>
        /// Maximum number of output types supported.
        /// </summary>
        Max
    }
    #endregion

    #region DSP
    /// <summary>
    /// List of windowing methods used in spectrum analysis to reduce leakage / transient signals
    /// intefering with the analysis. This is a problem with analysis of continuous signals that
    /// only have a small portion of the signal sample (the FFT window size). Windowing the signal
    /// with a curve or triangle tapers the sides of the FFT window to help alleviate this problem.        
    /// </summary>
    /// <remarks>
    /// Cyclic signals such as a sine wave that repeat their cycle in a multiple of the window size
    /// do not need windowing (i.e. if the sine wave repeats every 1024, 512, 256 etc samples and
    /// the FMOD fft window is 1024, then the signal would not need windowing).
    /// Not windowing is the same as FMOD_DSP_FFT_WINDOW_RECT, which is the default.
    /// If the cycle of the signal (i.e. the sine wave) is not a multiple of the window size, it
    /// will cause frequency abnormalities, so a different windowing method is needed.
    /// </remarks>
    public enum FFTWindow
    {
        /// <summary>
        /// w[n] = 1.0
        /// </summary>
        Rectangle,

        /// <summary>
        /// w[n] = TRI(2n/N)
        /// </summary>
        Triangle,

        /// <summary>
        /// w[n] = 0.54 - (0.46 * COS(n/N) )
        /// </summary>
        Hamming,

        /// <summary>
        /// w[n] = 0.5 *  (1.0  - COS(n/N) )
        /// </summary>
        Hanning,

        /// <summary>
        /// w[n] = 0.42 - (0.5  * COS(n/N) ) + (0.08 * COS(2.0 * n/N) )
        /// </summary>
        Blackman,

        /// <summary>
        /// w[n] = 0.35875 - (0.48829 * COS(1.0 * n/N)) + (0.14128 * COS(2.0 * n/N)) - (0.01168 * COS(3.0 * n/N))
        /// </summary>
        BlackmanHarris,

        Max
    }

    /// <summary>
    /// List of interpolation types that the FMOD software mixer supports.
    /// </summary>
    public enum DspResampler
    {
        /// <summary>
        /// High frequency aliasing hiss will be audible depending on the sample rate of the sound.
        /// </summary>
        NoInterpolation,

        /// <summary>
        /// Fast and good quality, causes very slight lowpass effect on low frequency sounds.
        /// (default method)
        /// </summary>
        Linear,

        /// <summary>
        /// Slower than linear interpolation but better quality.
        /// </summary>
        Cubic,

        /// <summary>
        /// 5 point spline interpolation.
        /// Slowest resampling method but best quality.
        /// </summary>
        Spline,

        /// <summary>
        /// Maximum number of resample methods supported.
        /// </summary>
        Max,
    }

    /// <summary>
    /// These definitions can be used for creating FMOD defined special effects or DSP units.
    /// </summary>
    /// <remarks>
    /// To get them to be active first create the unit then add it somewhere into the DSP
    /// network, either at the front of the network near the soundcard unit to affect
    /// the global output (by using System::getDSPHead) or on a single channel (using
    /// Channel::getDSPHead).
    /// </remarks>
    public enum DspType
    {
        /// <summary>
        /// This unit was created via a non FMOD plugin so has an unknown purpose.
        /// </summary>
        Unknown,

        /// <summary>
        /// This unit does nothing but take inputs and mix them together
        /// then feed the result to the soundcard unit.
        /// </summary>
        Mixer,

        /// <summary>
        /// This unit generates sine/square/saw/triangle or noise tones.
        /// </summary>
        Oscillator,

        /// <summary>
        /// This unit filters sound using a high quality, resonant lowpass filter
        /// algorithm but consumes more CPU time.
        /// </summary>
        LowPass,

        /// <summary>
        /// This unit filters sound using a resonant lowpass filter algorithm that is
        /// used in Impulse Tracker, but with limited cutoff range (0 to 8060hz).
        /// </summary>
        ImpulseTrackerLowPass,

        /// <summary>
        /// This unit filters sound using a resonant highpass filter algorithm.
        /// </summary>
        HighPass,

        /// <summary>
        /// This unit produces an echo on the sound and fades out at the desired rate.
        /// </summary>
        Echo,

        /// <summary>
        /// This unit produces a flange effect on the sound.
        /// </summary>
        Flange,

        /// <summary>
        /// This unit distorts the sound.
        /// </summary>
        Distortion,

        /// <summary>
        /// This unit normalizes or amplifies the sound to a certain level.
        /// </summary>
        Normalize,

        /// <summary>
        /// This unit attenuates or amplifies a selected frequency range.
        /// </summary>
        ParameQ,

        /// <summary>
        /// This unit bends the pitch of a sound without changing the speed of playback.
        /// </summary>
        PitchShift,

        /// <summary>
        /// This unit produces a chorus effect on the sound.
        /// </summary>
        Chorus,

        /// <summary>
        /// This unit produces a reverb effect on the sound.
        /// </summary>
        Reverb,

        /// <summary>
        /// This unit allows the use of Steinberg VST plugins
        /// </summary>
        VstPlugin,

        /// <summary>
        /// This unit allows the use of Nullsoft Winamp plugins.
        /// </summary>
        WinampPlugin,

        /// <summary>
        /// This unit produces an echo on the sound and fades out at the desired rate
        /// as is used in Impulse Tracker.
        /// </summary>
        ImpulseTrackerEcho,

        /// <summary>
        /// This unit implements dynamic compression (linked multichannel, wideband).
        /// </summary>
        Compressor,

        /// <summary>
        /// This unit implements SFX reverb.
        /// </summary>
        SfxReverb,

        /// <summary>
        /// This unit filters sound using a simple lowpass with no resonance, but
        /// has flexible cutoff and is fast.
        /// </summary>
        LowPassSimple,

        /// <summary>
        /// This unit produces different delays on individual channels of the sound.
        /// </summary>
        Delay,

        /// <summary>
        /// This unit produces a tremolo / chopper effect on the sound.
        /// </summary>
        Tremolo,

        /// <summary>
        /// This unit allows the use of LADSPA standard plugins.
        /// </summary>
        LadspaPlugin
    }

    #endregion

    #region Sound
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
    public enum SoundMode : uint
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
        LoopBidirectional = 0x4,

        /// <summary>
        /// "2D" positioning. Ignores any 3d processing. (default).
        /// </summary>
        NoSurround = 0x8,

        /// <summary>
        /// "3D" positioning. Overrides SoundMode.NoSurround
        /// </summary>
        Surround = 0x10,

        /// <summary>
        /// Attempts to make sounds use hardware acceleration. (default).
        /// </summary>
        HardwareProcessing = 0x20,

        /// <summary>
        /// Makes sound reside in software. Overrides SoundMode.Hardware  Overrides SoundMode.HardwareProcessing.
        /// Use this for FFT, DSP, 2D multi speaker support and other software related features.
        /// </summary>
        SoftwareProcessing = 0x40,

        /// <summary>
        /// Decompress at runtime, streaming from the standard stream source provided.
        /// Overrides SoundMode.CreateSample.
        /// </summary>
        CreateStream = 0x80,

        /// <summary>
        /// Decompress at loadtime, decompressing or decoding whole file into memory as the target sample format.
        /// </summary>
        CreateSample = 0x100,

        /// <summary>
        /// Load MP2, MP3, IMAADPCM or XMA into memory and leave it compressed.
        /// During playback the FMOD software mixer will decode it in realtime as a 'compressed sample'.
        /// Can only be used in combination with SoundMode.SoftwareProcessing.
        /// </summary>
        CreateCompressedSample = 0x200,

        /// <summary>
        /// Opens a user created static sample or stream. Use SoundInfo to specify format and/or read callbacks.
        /// If a user created 'sample' is created with no read callback, the sample will be empty.
        /// Use Sound_Lock and Sound_Unlock to place sound data into the sound if this is the case.
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
        SurroundHeadRelative = 0x40000,

        /// <summary>
        /// [default] Make the sound's position, velocity and orientation absolute (relative to the world).
        /// </summary>
        SurroundWorldRelative = 0x80000,

        /// <summary>
        /// [default] This sound will follow the standard logarithmic rolloff model where mindistance = full volume,
        /// maxdistance = where sound stops attenuating, and rolloff is fixed according to the global rolloff factor.
        /// </summary>
        SurroundLogRolloff = 0x100000,

        /// <summary>
        /// This sound will follow a linear rolloff model where mindistance = full volume, maxdistance = silence.
        /// </summary>
        SurroundLinearRolloff = 0x200000,

        /// <summary>
        /// This sound will follow a rolloff model defined by Set3DCustomRolloff / Set3DCustomRolloff.
        /// </summary>
        SurroundCustomRolloff = 0x4000000,

        /// <summary>
        /// For CDDA sounds only - use ASPI instead of NTSCSI to access the specified CD/DVD device.
        /// </summary>
        CddaForceAspi = 0x400000,

        /// <summary>
        /// For CDDA sounds only - perform jitter correction.
        /// Jitter correction helps produce a more accurate CDDA stream at the cost of more CPU time.
        /// </summary>
        CddaJitterCorrect = 0x800000,

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
        /// For sounds that start virtual (due to being quiet or low importance), instead of swapping back to
        /// audible, and playing at the correct offset according to time, this flag makes the sound play from
        /// the start.
        /// </summary>
        VirtualPlayFromStart = 0x80000000
    }

    /// <summary>
    /// These values describe what state a sound is in after NONBLOCKING has been used to open it.
    /// </summary>
    public enum SoundOpenState
    {
        /// <summary>
        /// Opened and ready to play
        /// </summary>
        Ready = 0,

        /// <summary>
        /// Initial load in progress
        /// </summary>
        Loading,

        /// <summary>
        /// Failed to open - file not found, out of memory etc.  See return value of Sound::getOpenState for what happened
        /// </summary>        
        Error,

        /// <summary>
        /// Connecting to remote host (internet sounds only)
        /// </summary>
        Connecting,

        /// <summary>
        /// Buffering data
        /// </summary>
        Buffering,

        /// <summary>
        /// Seeking to subsound and re-flushing stream buffer
        /// </summary>
        Seeking,

        /// <summary>
        /// Ready and playing, but not possible to release at this time without stalling the main thread
        /// </summary>
        Playing,

        /// <summary>
        /// Seeking within a stream to a different position
        /// </summary>
        SetPosition,
    }

    /// <summary>
    /// These definitions describe the native format of the hardware or software buffer that will be used.
    /// </summary>
    public enum SoundFormat
    {

        /// <summary>
        /// Unitialized / unknown.
        /// </summary>
        None,

        /// <summary>
        /// 8bit integer PCM data.
        /// </summary>
        Pcm8Bit,

        /// <summary>
        /// 16bit integer PCM data.
        /// </summary>
        Pcm16Bit,

        /// <summary>
        /// 24bit integer PCM data.
        /// </summary>
        Pcm24Bit,

        /// <summary>
        /// 32bit integer PCM data.
        /// </summary>
        Pcm32Bit,

        /// <summary>
        /// 32bit floating point PCM data.
        /// </summary>
        PcmFloat,

        /// <summary>
        /// Compressed GameCube DSP data.
        /// </summary>
        [Obsolete("GameCube only")]
        GcAdPcm,

        /// <summary>
        /// Compressed XBox ADPCM data.
        /// </summary>
        [Obsolete("Xbox only")]
        ImaAdPcm,

        /// <summary>
        /// Compressed PlayStation 2 ADPCM data.
        /// </summary>
        [Obsolete("PS2 only")]
        Vag,

        /// <summary>
        /// Compressed Xbox360 data.
        /// </summary>
        [Obsolete("Xbox360 only")]
        Xma,

        /// <summary>
        /// Compressed MPEG layer 2 or 3 data.
        /// </summary>
        Mpeg,

        /// <summary>
        /// Maximum number of sound formats supported.
        /// </summary>
        Max,

        /// <summary>
        /// Compressed CELT data.
        /// </summary>
        Celt,
    }

    /// <summary>
    /// These definitions describe the type of song being played.
    /// </summary>
    public enum SoundType
    {
        /// <summary>
        /// 3rd party / unknown plugin format.
        /// </summary>
        Unknown,

        /// <summary>
        /// AAC.  Currently unsupported.
        /// </summary>
        Aac,

        Aiff,

        /// <summary>
        /// Microsoft Advanced Systems Format (ie WMA/ASF/WMV).
        /// </summary>
        Asf,

        /// <summary>
        /// Sony ATRAC 3 format
        /// </summary>
        At3,

        /// <summary>
        /// Digital CD audio.
        /// </summary>
        Cdda,

        /// <summary>
        /// Sound font / downloadable sound bank.
        /// </summary>
        Dls,

        /// <summary>
        /// FLAC lossless codec.
        /// </summary>
        Flac,

        /// <summary>
        /// FMOD Sample Bank.
        /// </summary>
        Fsb,

        /// <summary>
        /// GameCube ADPCM
        /// </summary>
        [Obsolete("GameCube only")]
        GcAdPcm,

        /// <summary>
        /// Impulse Tracker
        /// </summary>
        It,

        /// <summary>
        /// MIDI
        /// </summary>
        Midi,

        /// <summary>
        /// Protracker / Fasttracker MOD
        /// </summary>
        Mod,

        /// <summary>
        /// MP2/MP3 MPEG
        /// </summary>
        Mpeg,

        /// <summary>
        /// Ogg vorbis
        /// </summary>
        OggVorbis,

        /// <summary>
        /// Metadata only from ASX/PLS/M3U/WAX playlists
        /// </summary>
        Playlist,

        /// <summary>
        /// Raw PCM data
        /// </summary>
        Raw,

        /// <summary>
        /// ScreamTracker 3
        /// </summary>
        S3M,

        /// <summary>
        /// Sound font 2
        /// </summary>
        Sf2,

        /// <summary>
        /// User created sound
        /// </summary>
        User,

        /// <summary>
        /// Microsoft WAV
        /// </summary>
        Wav,

        /// <summary>
        /// FastTracker 2
        /// </summary>
        Xm,

        /// <summary>
        /// Xbox360 XMA
        /// </summary>
        [Obsolete("Xbox360 only")]
        Xma,

        /// <summary>
        /// PlayStation 2 / PlayStation Portable adpcm VAG format
        /// </summary>
        [Obsolete("PS2/PSP only")]
        Vag,

        /// <summary>
        /// iPhone hardware decoder, supports AAC, ALAC and MP3
        /// </summary>
        [Obsolete("iPhone only")]
        AudioQueue,

        /// <summary>
        /// Xbox360 XWMA
        /// </summary>
        [Obsolete(" only")]
        Xwma,
    }
    #endregion

    #region Speaker
    /// <summary>
    /// These are speaker types defined for use with the System::setSpeakerMode or System::getSpeakerMode command.
    /// </summary>
    public enum SpeakerMode
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
        Surround51,

        /// <summary>
        /// Arrangements that have a left/right/center/rear left/rear right/side left/side right and a subwoofer speaker.
        /// Mono sounds default to the center speaker.  They can be panned with Channel::setPan.
        /// Stereo sounds default to the left sound channel played on the front left, and the right sound channel played on the front right.
        /// They can be cross faded with Channel::setPan.
        /// Multichannel sounds default to all of their sound channels being played on each speaker in order of input.  
        /// Mix behaviour for multichannel sounds can be set with Channel::setSpeakerLevels.
        /// Channel::setSpeakerMix works and every parameter is used to set the balance of a sound in any speaker.
        /// </summary>
        Surround71,

        /// <summary>
        /// This mode is for mono, stereo, 5.1 and 7.1 speaker arrangements, as it is backwards and forwards compatible with stereo,
        /// but to get a surround effect a Dolby Prologic or Prologic 2 hardware decoder / amplifier is needed.
        /// Pan behaviour is the same as Surrround51.
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
    public enum Speaker
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

        [Obsolete("PS3-only")]
        SBL = SideLeft,
        [Obsolete("PS3-only")]
        SBR = SideRight,
    }
    #endregion

    #region Reverb
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
    #endregion

    #region Misc
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
        CddaDrivers,

        /// <summary>
        /// An error occurred while initialising the CDDA subsystem.
        /// </summary>
        CddaInit,

        /// <summary>
        /// Couldn't find the specified device.
        /// </summary>
        CddaInvalidDevice,

        /// <summary>
        /// No audio tracks on the specified disc.
        /// </summary>
        CddaNoAudio,

        /// <summary>
        /// No CD/DVD devices were found.
        /// </summary>
        CddaNoDevices,

        /// <summary>
        /// No disc present in the specified drive.
        /// </summary>
        CddaNoDisc,

        /// <summary>
        /// A CDDA read error occurred.
        /// </summary>
        CddaRead,

        /// <summary>
        /// Error trying to allocate a channel.
        /// </summary>
        ChannelAllocate,

        /// <summary>
        /// The specified channel has been reused to play another sound.
        /// </summary>
        ChannelStolen,

        /// <summary>
        /// A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly.
        /// </summary>
        Win32Com,

        /// <summary>
        /// DMA Failure.  See debug output for more information.
        /// </summary>
        Dma,

        /// <summary>
        /// DSP connection error.  DspConnection possibly caused a cyclic dependancy.
        /// </summary>
        DspConnection,

        /// <summary>
        /// DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format.
        /// </summary>
        DspFormat,

        /// <summary>
        /// DSP connection error.  Couldn't find the DSP unit specified.
        /// </summary>
        DspNotFound,

        /// <summary>
        /// DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback.
        /// </summary>
        DspRunning,

        /// <summary>
        /// DSP connection error.  The unit being connected to or disconnected should only have 1 input or output.
        /// </summary>
        DspTooManyConnections,

        /// <summary>
        /// Error loading file.
        /// </summary>
        FileBad,

        /// <summary>
        /// Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format.
        /// </summary>
        FileCouldNotSeek,

        /// <summary>
        /// Media was ejected while reading.
        /// </summary>
        FileMediaEjected,

        /// <summary>
        /// End of file unexpectedly reached while trying to read essential data (truncated data?).
        /// </summary>
        FileEnd,

        /// <summary>
        /// File not found.
        /// </summary>
        FileNotFound,

        /// <summary>
        /// Unwanted file access occured.
        /// </summary>
        FileUnwantedAccess,

        /// <summary>
        /// Unsupported file or audio format.
        /// </summary>
        Format,

        /// <summary>
        /// A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere.
        /// </summary>
        HttpError,

        /// <summary>
        /// The specified resource requires authentication or is forbidden.
        /// </summary>
        HttpAccess,

        /// <summary>
        /// Proxy authentication is required to access the specified resource.
        /// </summary>
        HttpProxyAuth,

        /// <summary>
        /// A HTTP server error occurred.
        /// </summary>
        HttpServerError,

        /// <summary>
        /// The HTTP request timed out.
        /// </summary>
        HttpTimeout,

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
        [Obsolete("Xbox360 only")]
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
        /// fmodex.irx failed to initialize.  This is most likely because you forgot to load it.
        /// </summary>
        [Obsolete("PS2 only")]
        Irx,

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
        MemoryCantPoint,

        /// <summary>
        ///Not enough memory or resources on PlayStation 2 IOP ram.
        /// </summary>
        [Obsolete("PS2 only")]
        Memory_IOP,

        /// <summary>
        /// Not enough memory or resources on console sound ram.
        /// </summary>
        MemorySram,

        /// <summary>
        /// Tried to call a command on a 3d sound when the command was meant for 2d sound.
        /// </summary>
        Needs2d,

        /// <summary>
        /// Tried to call a command on a 2d sound when the command was meant for 3d sound.
        /// </summary>
        Needs3d,

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
        NetConnect,

        /// <summary>
        /// A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere.
        /// </summary>
        NetSocketError,

        /// <summary>
        /// The specified URL couldn't be resolved.
        /// </summary>
        NetUrl,

        /// <summary>
        /// Operation on a non-blocking socket could not complete immediately.
        /// </summary>
        NetWouldBlock,

        /// <summary>
        /// Operation could not be performed because specified sound is not ready.
        /// </summary>
        NotReady,

        /// <summary>
        /// Error initializing output device, but more specifically, the output device is already in use and cannot be reused.
        /// </summary>
        OutputAllocated,

        /// <summary>
        /// Error creating hardware sound buffer.
        /// </summary>
        OutputCreateBuffer,

        /// <summary>
        /// A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted.
        /// </summary>
        OutputDriverCall,

        /// <summary>
        /// Error enumerating the available driver list. List may be inconsistent due to a recent device addition or removal.
        /// </summary>
        OutputEnumeration,

        /// <summary>
        /// Soundcard does not support the minimum features needed for this FmodSystem (16bit stereo output).
        /// </summary>
        OutputFormat,

        /// <summary>
        /// Error initializing output device.
        /// </summary>
        OutputInit,

        /// <summary>
        /// FMOD_HARDWARE was specified but the sound card does not have the resources nescessary to play it.
        /// </summary>
        OutputNoHardware,

        /// <summary>
        /// Attempted to create a software sound but no software channels were specified in System::init.
        /// </summary>
        OutputNoSoftware,

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
        PluginInstances,

        /// <summary>
        /// A requested output dsp unit type or codec was not available.
        /// </summary>
        PluginMissing,

        /// <summary>
        /// A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback)
        /// </summary>
        PluginResource,

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
        ReverbInstance,

        /// <summary>
        /// This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first.
        /// </summary>
        SubSoundAllocated,

        /// <summary>
        /// Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file.
        /// </summary>
        SubSoundCantMove,

        /// <summary>
        /// The subsound's mode bits do not match with the parent sound's mode bits.
        /// See documentation for function that it was called with.
        /// </summary>
        SubSoundMode,

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
        EventFailed,

        /// <summary>
        /// Can't execute this command on an EVENT_INFOONLY event.
        /// </summary>
        EventInfoOnly,

        /// <summary>
        /// An error occured that wasn't supposed to.  See debug log for reason.
        /// </summary>
        EventInternal,

        /// <summary>
        /// Event failed because 'Max streams' was hit when FMOD_INIT_FAIL_ON_MAXSTREAMS was specified.
        /// </summary>
        EventMaxStreams,

        /// <summary>
        /// FSB mis-matches the FEV it was compiled with.
        /// </summary>
        EventMismatch,

        /// <summary>
        /// A category with the same name already exists.
        /// </summary>
        EventNameConflict,

        /// <summary>
        /// The requested event, event group, event category or event property could not be found.
        /// </summary>
        EventNotFound,

        /// <summary>
        /// Tried to call a function on a complex event that's only supported by simple events.
        /// </summary>
        EventNeedsSimple,

        /// <summary>
        /// An event with the same GUID already exists.
        /// </summary>
        EventGuidConflict,

        /// <summary>
        /// The specified project has already been loaded.
        /// Having multiple copies of the same project loaded simultaneously is forbidden.
        /// </summary>
        EventAlreadyLoaded,

        /// <summary>
        /// Music system is not initialized probably because no music data is loaded.
        /// </summary>
        MusicUninitialized,

        /// <summary>
        /// The requested music entity could not be found.
        /// </summary>
        MusicNotFound,

        /// <summary>
        /// The music callback is required, but it has not been set.
        /// </summary>
        MusicNoCallback,

    }

    /// <summary>
    /// List of tag types that could be stored within a sound.
    /// These include id3 tags, metadata from netstreams and vorbis/asf data.
    /// </summary>
    public enum TagType
    {
        Unknown = 0,
        Id3V1,
        Id3V2,
        VorbisComment,
        Shoutcase,
        Icecast,
        Asf,
        Midi,
        Playlist,
        Fmod,
        User
    }

    /// <summary>
    /// List of data types that can be returned by Sound::getTag
    /// </summary>
    public enum TagDataType
    {
        Binary = 0,
        Int,
        Float,
        String,
        StringUtf16,
        StringUtf16Be,
        StringUtf8,
        Cdtoc
    }

    public enum SoundGroupBehavior
    {
        /// <summary>
        /// Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will
        /// simply fail during System::playSound.
        /// </summary>
        Fail,

        /// <summary>
        /// Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will be silent,
        /// then if another sound in the group stops the sound that was silent before becomes audible again.
        /// </summary>
        Mute,

        /// <summary>
        /// Any sound played that puts the sound count over the SoundGroup::setMaxAudible setting, will steal the
        /// quietest / least important sound playing in the group.
        /// </summary>
        StealLowest
    }

    [Flags]
    public enum DeviceCapabilities : uint
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
    /// These are plugin types defined for use with the System::getNumPlugins / System_GetNumPlugins, 
    /// System::getPluginInfo / System_GetPluginInfo and System::unloadPlugin / System_UnloadPlugin functions.
    /// </summary>
    public enum PluginType
    {
        /// <summary>
        /// Output module.  FMOD mixed audio will play through one of these devices.
        /// </summary>
        Output,

        /// <summary>
        /// File format CODEC.  FMOD will use these codecs to load file formats for playback.
        /// </summary>
        Codec,

        /// <summary>
        /// DSP unit.  FMOD will use these plugins as part of its DSP network to apply effects to output or generate sound in realtime.
        /// </summary>
        Dsp,
    }

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
        /// Raw file bytes of (compressed) sound data (does not include headers).  Only used by
        /// Sound::getLength and Channel::getPosition.
        /// </summary>
        RawBytes = 0x8,

        /// <summary>
        /// MOD/S3M/XM/IT.  Order in a sequenced module format.  Use Sound::getFormat to determine the format.
        /// </summary>
        ModOrder = 0x100,

        /// <summary>
        /// MOD/S3M/XM/IT.  Current row in a sequenced module format.  Sound::getLength will return the number
        /// if rows in the currently playing or seeked to pattern. 
        /// </summary>
        ModRow = 0x200,

        /// <summary>
        /// MOD/S3M/XM/IT.  Current pattern in a sequenced module format.  Sound::getLength will return the
        /// number of patterns in the song and Channel::getPosition will return the currently playing pattern.
        /// </summary>
        ModPattern = 0x400,

        /// <summary>
        /// Currently playing subsound in a sentence time in milliseconds.
        /// </summary>
        SentenceMilliseconds = 0x10000,

        /// <summary>
        /// Currently playing subsound in a sentence time in PCM Samples, related to milliseconds * samplerate / 1000.
        /// </summary>
        SentencePcm = 0x20000,

        /// <summary>
        /// Currently playing subsound in a sentence time in bytes, related to PCM samples * channels * datawidth (ie 16bit = 2 bytes).
        /// </summary>
        SentencePcmBytes = 0x40000,

        /// <summary>
        /// Currently playing sentence index according to the channel.
        /// </summary>
        Sentence = 0x80000,

        /// <summary>
        /// Currently playing subsound index in a sentence.
        /// </summary>
        SentenceSubSound = 0x100000,

        /// <summary>
        /// Time value as seen by buffered stream.  This is always ahead of audible time, and is only used for processing.
        /// </summary>
        Buffered = 0x10000000
    }
    #endregion
}