using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace nFMOD
{
    public class Dsp : Handle
    {
        internal Dsp(IntPtr hnd) : base()
        {
            SetHandle(hnd);
        }

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
        public enum FFTWindow : int
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

        public struct ParameterDescription
        {
            /// <summary>
            /// Minimum value of the parameter.
            /// (ie 100.0)
            /// </summary>
            public float Min;

            /// <summary>
            /// Maximum value of the parameter.
            /// (ie 22050.0)
            /// </summary>
            public float Max;

            /// <summary>
            /// Default value of parameter.
            /// </summary>
            public float Defaultval;

            /// <summary>
            /// Name of the parameter to be displayed
            /// (ie "Cutoff frequency").
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] Name;

            /// <summary>
            /// Short string to be put next to value to denote the unit type.
            /// (ie "hz")
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public char[] Label;

            /// <summary>
            /// Description of the parameter to be displayed as a help item / tooltip for this parameter.
            /// </summary>
            public string Description;
        }

        //TODO complete submmary
        /*
            [PLATFORMS]
            Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3

            [SEE_ALSO]
            FMOD_DSP_DESCRIPTION
        ]
        */

        /// <summary>
        /// DSP plugin structure that is passed into each callback.
        /// </summary>
        public struct State
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

        public delegate ErrorCode DspDelegate(ref State dsp_state);

        public delegate ErrorCode ReadDelegate(ref State dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);

        public delegate ErrorCode SetPositionDelegate(ref State dsp_state, uint seeklen);

        public delegate ErrorCode SetParamDelegate(ref State dsp_state, int index, float val);

        public delegate ErrorCode GetParamDelegate(ref State dsp_state, int index, ref float val, StringBuilder valuestr);

        public delegate ErrorCode DialogDelegate(ref State dsp_state, IntPtr hwnd, bool show);

        protected override bool ReleaseHandle()
        {
            if (IsInvalid)
                return true;

            Remove();
            Release(handle);
            SetHandleAsInvalid();

            return true;
        }

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_Release")]
        private static extern ErrorCode Release(IntPtr dsp);

        public void Remove()
        {
            ErrorCode ReturnCode = Remove_External(DangerousGetHandle());
            Errors.ThrowIfError(ReturnCode);
        }

        public void Reset()
        {
            ErrorCode ReturnCode = Reset_External(DangerousGetHandle());
            Errors.ThrowIfError(ReturnCode);
        }

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_Remove")]
        private static extern ErrorCode Remove_External(IntPtr dsp);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_Reset")]
        private static extern ErrorCode Reset_External(IntPtr dsp);

        //TODO Implement extern funcitons
        /*

        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetSystemObject           (IntPtr dsp, ref IntPtr system);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]                   
        private static extern RESULT FMOD_DSP_AddInput                  (IntPtr dsp, IntPtr target, ref IntPtr connection);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_DisconnectFrom            (IntPtr dsp, IntPtr target);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_DisconnectAll             (IntPtr dsp, int inputs, int outputs);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetNumInputs              (IntPtr dsp, ref int numinputs);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetNumOutputs             (IntPtr dsp, ref int numoutputs);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetInput                  (IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetOutput                 (IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetActive                 (IntPtr dsp, int active);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetActive                 (IntPtr dsp, ref int active);    
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetBypass                 (IntPtr dsp, int bypass);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetBypass                 (IntPtr dsp, ref int bypass);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetSpeakerActive          (IntPtr dsp, SPEAKER speaker, int active);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetSpeakerActive          (IntPtr dsp, SPEAKER speaker, ref int active);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetParameter              (IntPtr dsp, int index, float value);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetParameter              (IntPtr dsp, int index, ref float value, StringBuilder valuestr, int valuestrlen);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetNumParameters          (IntPtr dsp, ref int numparams);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetParameterInfo          (IntPtr dsp, int index, ref IntPtr name, ref IntPtr label, StringBuilder description, int descriptionlen, ref float min, ref float max);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_ShowConfigDialog          (IntPtr dsp, IntPtr hwnd, int show);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetInfo                   (IntPtr dsp, ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetType                   (IntPtr dsp, ref DSP_TYPE type);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetDefaults               (IntPtr dsp, float frequency, float volume, float pan, int priority);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetDefaults               (IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]                   
        private static extern RESULT FMOD_DSP_SetUserData               (IntPtr dsp, IntPtr userdata);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetUserData               (IntPtr dsp, ref IntPtr userdata);
        
        [DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
        private static extern RESULT FMOD_DSP_GetMemoryInfo             (IntPtr dsp, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
        */

        /// <summary>
        /// Strcture to define the parameters for a DSP unit.
        /// </summary>
        public struct Description
        {
            /// <summary>
            /// Name of the unit to be displayed in the network.
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] Name;

            /// <summary>
            /// Plugin writer's version number.
            /// </summary>
            public uint Version;

            /// <summary>
            /// Number of channels.
            /// Use 0 to process whatever number of channels is currently in the network.
            /// Value other than 0 would be mostly used if the unit is a unit that only generates sound.
            /// </summary>
            public int Channels;

            /// <summary>
            /// Create callback.
            /// This is called when DSP unit is created.
            /// Can be null.
            /// </summary>
            public DspDelegate Create;

            /// <summary>
            /// Release callback.
            /// This is called just before the unit is freed so the user can do any cleanup needed for the unit.
            /// Can be null.
            /// </summary>
            public DspDelegate Release;

            /// <summary>
            /// Reset callback.
            /// This is called by the user to reset any history buffers that may need resetting for a filter,
            /// when it is to be used or re-used for the first time to its initial clean state.
            /// Use to avoid clicks or artifacts.
            /// </summary>
            public DspDelegate Reset;

            /// <summary>
            /// Read callback.
            /// Processing is done here.
            /// Can be null.
            /// </summary>
            public ReadDelegate Read;

            /// <summary>
            /// Setposition callback.
            /// This is called if the unit wants to update its position info but not process data.
            /// Can be null.
            /// </summary>
            public SetPositionDelegate SetPosition;

            /// <summary>
            /// Number of parameters used in this filter.
            /// The user finds this with DSP::getNumParameters
            /// </summary>
            public int NumberParameters;

            /// <summary>
            /// Variable number of parameter structures.
            /// </summary>
            public ParameterDescription[] ParameterDesc;

            /// <summary>
            /// This is called when the user calls DSP::setParameter.
            /// Can be null.
            /// </summary>
            public SetParamDelegate SetParameter;

            /// <summary>
            /// This is called when the user calls DSP::getParameter.
            /// Can be null.
            /// </summary>
            public GetParamDelegate GetParameter;

            /// <summary>
            /// This is called when the user calls DSP::showConfigDialog.
            /// Can be used to display a dialog to configure the filter.
            /// Can be null.
            /// </summary>
            public DialogDelegate Config;

            /// <summary>
            /// Width of config dialog graphic if there is one.
            /// 0 otherwise.
            /// </summary>
            public int ConfigWidth;

            /// <summary>
            /// Height of config dialog graphic if there is one.
            /// 0 otherwise.
            /// </summary>
            public int ConfigHeight;

            /// <summary>
            /// Optional.
            /// Specify 0 to ignore.
            /// This is user data to be attached to the DSP unit during creation.
            /// Access via DSP::getUserData.
            /// </summary>
            public IntPtr UserData;
        }

        /// <summary>
        /// List of interpolation types that the FMOD Ex software mixer supports.
        /// </summary>
        public enum Resampler : int
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
        /// To get them to be active, first create the unit,
        /// then add it somewhere into the DSP network,
        /// either at the front of the network near the soundcard unit to affect
        /// the global output (by using System::getDSPHead),
        /// or on a single channel (using Channel::getDSPHead).
        /// </remarks>
        /// <platforms>
        /// Win32, Win64, Linux, Linux64, Macintosh,
        /// Xbox, Xbox360, PlayStation 2, GameCube,
        /// PlayStation Portable, PlayStation 3, Wii
        /// </platforms>
        /// <seealso cref="nFMOD.System.System.CreateDspByType"/>
        public enum Type : int
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
            /// This unit filters sound using a high quality,
            /// resonant lowpass filter algorithm but consumes more CPU time.
            /// </summary>
            LowPass,

            /// <summary>
            /// This unit filters sound using a resonant lowpass filter
            /// algorithm that is used in Impulse Tracker,
            /// but with limited cutoff range (0 to 8060hz).
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
            VSTPlugin,

            /// <summary>
            /// This unit allows the use of Nullsoft Winamp plugins.
            /// </summary>
            WinampPlugin,

            /// <summary>
            /// This unit produces an echo on the sound and fades out
            /// at the desired rate as is used in Impulse Tracker.
            /// </summary>
            ImpulseTrackerEcho,

            /// <summary>
            /// This unit implements dynamic compression.
            /// (linked multichannel, wideband)
            /// </summary>
            Compressor,

            /// <summary>
            /// This unit implements SFX reverb.
            /// </summary>
            SFXReverb,

            /// <summary>
            /// This unit filters sound using a simple lowpass with no resonance, but has flexible cutoff and is fast.
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
            LADSPAPlugin
        }

    }


}
