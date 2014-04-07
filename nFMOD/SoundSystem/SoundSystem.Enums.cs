using System;

namespace nFMOD
{
    public partial class SoundSystem
    {
        /// <summary>
        /// These callback types are used with System::setCallback.
        /// </summary>
        /// <remarks>
        /// Currently the user must call System::update for these callbacks to trigger.
        /// </remarks>
        public enum CallbackType : int
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
        /// Use them with <see cref="SoundSystem.Init"/> in the flags parameter to change various behaviour.
        /// </summary>
        [Flags]
        public enum InitFlags : int
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
            WASAPI_EXCLUSIVE = 0x100,

            /// <summary>
            /// For DirectSound output - FMOD_HARDWARE|FMOD_3D buffers use simple stereo
            /// panning/doppler/attenuation when 3D hardware acceleration is not present.
            /// </summary>
            DSOUND_HRTFNONE = 0x200,

            /// <summary>
            /// For DirectSound output - FMOD_HARDWARE|FMOD_3D buffers use a slightly higher
            /// quality algorithm when 3D hardware acceleration is not present.
            /// </summary>
            DSOUND_HRTFLIGHT = 0x400,

            /// <summary>
            /// For DirectSound output - FMOD_HARDWARE|FMOD_3D buffers use full quality 3D
            /// playback when 3d hardware acceleration is not present.
            /// </summary>
            DSOUND_HRTFFULL = 0x800,

            /// <summary>
            /// FMOD Mixer thread is woken up to do a mix when System::update is called
            /// rather than waking periodically on its own timer.
            /// </summary>
            SYNCMIXERWITHUPDATE = 0x400000,

            /// <summary>
            /// Use DTS Neural surround downmixing from 7.1 if speakermode set to FMOD_SPEAKERMODE_STEREO
            /// or FMOD_SPEAKERMODE_5POINT1. Internal DSP structure will be set to 7.1.
            /// </summary>
            DTS_NEURALSURROUND = 0x02000000,

            /// <summary>
            /// With the geometry engine, only process the closest polygon rather than accumulating
            /// all polygons the sound to listener line intersects.
            /// </summary>
            GEOMETRY_USECLOSEST = 0x04000000,

            /// <summary>
            /// Disables MyEars HRTF 7.1 downmixing. MyEars will otherwise be disbaled if speakermode is not
            /// set to FMOD_SPEAKERMODE_STEREO or the data file is missing.
            /// </summary>
            DISABLE_MYEARS = 0x08000000,

            [Obsolete("PS2 only")]
            PS2_DISABLECORE0REVERB = 0x10000,
            [Obsolete("PS2 only")]
            PS2_DISABLECORE1REVERB = 0x20000,
            [Obsolete("PS2 only")]
            PS2_DONTUSESCRATCHPAD = 0x40000,
            [Obsolete("PS2 only")]
            PS2_SWAPDMACHANNELS = 0x80000,
            [Obsolete("Xbox only")]
            XBOX_REMOVEHEADROOM = 0x100000,
            [Obsolete("Xbox360 only")]
            Xbox360_MUSICMUTENOTPAUSE = 0x200000,
        }

        /// <summary>
        /// These output types are used with System::setOutput/System::getOutput,
        /// to choose which output method to use.
        /// </summary>
        /// <remarks>
        /// To drive the output synchronously, and to disable FMOD's timing thread, use the FMOD_INIT_NONREALTIME flag.
        /// To pass information to the driver when initializing fmod use the extradriverdata parameter for the following reasons.
        /// <li>FMOD_OUTPUTTYPE_WAVWRITER - extradriverdata is a pointer to a char * filename that the wav writer will output to.
        /// <li>FMOD_OUTPUTTYPE_WAVWRITER_NRT - extradriverdata is a pointer to a char * filename that the wav writer will output to.
        /// <li>FMOD_OUTPUTTYPE_DSOUND - extradriverdata is a pointer to a HWND so that FMOD can set the focus on the audio for a particular window.
        /// <li>FMOD_OUTPUTTYPE_GC - extradriverdata is a pointer to a FMOD_ARAMBLOCK_INFO struct. This can be found in fmodgc.h.
        /// Currently these are the only FMOD drivers that take extra information.  Other unknown plugins may have different requirements.
        /// </remarks>
        public enum OutputType : int
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

            //TODO Replace System::setSoftwareFormat by real name.

            /// <summary>
            /// Writes output to fmodout.wav by default.
            /// Use System::setSoftwareFormat to set the filename.
            /// </summary>
            WavWriter,

            /// <summary>
            /// Non-realtime version of FMOD_OUTPUTTYPE_NOSOUND.
            /// User can drive mixer with System::update at whatever rate they want.
            /// </summary>
            NoSound_NRT,

            /// <summary>
            /// Non-realtime version of FMOD_OUTPUTTYPE_WAVWRITER.
            /// User can drive mixer with System::update at whatever rate they want.
            /// </summary>
            WavWriter_NRT,

            /// <summary>
            /// Win32/Win64 - DirectSound output.
            /// Use this to get hardware accelerated 3d audio and EAX Reverb support.
            /// (Default on Windows)
            /// </summary>
            DirectSound,

            /// <summary>
            /// Win32/Win64 - Windows Multimedia output.
            /// </summary>
            WindowsMultimedia,

            /// <summary>
            /// Win32 - Windows Audio Session API. (Default on Windows Vista)
            /// </summary>
            WASAPI,

            /// <summary>
            /// Win32 - Low latency ASIO driver.
            /// </summary>
            ASIO,

            /// <summary>
            /// Linux - Open Sound System output.
            /// </summary>
            OSS,

            /// <summary>
            /// Linux - Advanced Linux Sound Architecture output.
            /// </summary>
            ALSA,

            /// <summary>
            /// Linux - Enlightment Sound Daemon output.
            /// </summary>
            ESD,

            /// <summary>
            /// Linux/Linux64 - PulseAudio output.
            /// </summary>
            PulseAudio,

            /// <summary>
            /// Mac - Macintosh SoundManager output.
            /// </summary>
            SoundManager,

            /// <summary>
            /// Mac - Macintosh CoreAudio output.
            /// </summary>
            CoreAudio,

            /// <summary>
            /// Xbox - Native hardware output.
            /// </summary>
            Xbox,

            /// <summary>
            /// PS2 - Native hardware output.
            /// </summary>
            PS2,

            /// <summary>
            /// PS3 - Native hardware output. (Default on PS3)
            /// </summary>
            PS3,

            /// <summary>
            /// GameCube - Native hardware output.
            /// </summary>
            GameCube,

            /// <summary>
            /// Xbox 360 - Native hardware output.
            /// </summary>
            Xbox360,

            /// <summary>
            /// PSP - Native hardware output.
            /// </summary>
            PSP,

            /// <summary>
            /// Native hardware output. (Default on Wii)
            /// </summary>
            Wii,

            /// <summary>
            /// Native android output.
            /// </summary>
            Android,

            /// <summary>
            /// Maximum number of output types supported.
            /// </summary>
            Max
        }

        //TODO complete submmary

        /*
 
        [REMARKS]


        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii, Android

        [SEE_ALSO]      
        System::setOutput
        System::getOutput
        System::setSoftwareFormat
        System::getSoftwareFormat
        System::init
    ]
    */
    }
}

