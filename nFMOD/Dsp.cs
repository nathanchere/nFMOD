using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace nFMOD
{
    public class Dsp : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_Release"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Release(IntPtr dsp);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_Remove"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Remove_External(IntPtr dsp);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_Reset"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Reset_External(IntPtr dsp);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetSystemObject"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSystemObject(IntPtr dsp, ref IntPtr system);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_AddInput"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode AddInput(IntPtr dsp, IntPtr target, ref IntPtr connection);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_DisconnectFrom"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode DisconnectFrom(IntPtr dsp, IntPtr target);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_DisconnectAll"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode DisconnectAll(IntPtr dsp, int inputs, int outputs);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetNumInputs"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumInputs(IntPtr dsp, ref int numinputs);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetNumOutputs"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumOutputs(IntPtr dsp, ref int numoutputs);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetInput"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetInput(IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetOutput"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetOutput(IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_SetActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetActive(IntPtr dsp, int active);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetActive(IntPtr dsp, ref int active);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_SetBypass"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetBypass(IntPtr dsp, int bypass);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetBypass"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetBypass(IntPtr dsp, ref int bypass);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_SetSpeakerActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetSpeakerActive(IntPtr dsp, Speaker speaker, int active);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetSpeakerActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpeakerActive(IntPtr dsp, Speaker speaker, ref int active);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_SetParameter"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetParameter(IntPtr dsp, int index, float value);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetParameter"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetParameter(IntPtr dsp, int index, ref float value, StringBuilder valuestr, int valuestrlen);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetNumParameters"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumParameters(IntPtr dsp, ref int numparams);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetParameterInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetParameterInfo(IntPtr dsp, int index, ref IntPtr name, ref IntPtr label, StringBuilder description, int descriptionlen, ref float min, ref float max);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_ShowConfigDialog"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode ShowConfigDialog(IntPtr dsp, IntPtr hwnd, int show);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetInfo(IntPtr dsp, ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetType"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetType(IntPtr dsp, ref DspType type);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_SetDefaults"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetDefaults(IntPtr dsp, float frequency, float volume, float pan, int priority);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetDefaults"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetDefaults(IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_SetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetUserData(IntPtr dsp, IntPtr userdata);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetUserData(IntPtr dsp, ref IntPtr userdata);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSP_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMemoryInfo(IntPtr dsp, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);
        #endregion

        #region Delegates
        public delegate ErrorCode DspDelegate(ref DspState dsp_state);

        public delegate ErrorCode ReadDelegate(ref DspState dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);

        public delegate ErrorCode SetPositionDelegate(ref DspState dsp_state, uint seeklen);

        public delegate ErrorCode SetParamDelegate(ref DspState dsp_state, int index, float val);

        public delegate ErrorCode GetParamDelegate(ref DspState dsp_state, int index, ref float val, StringBuilder valuestr);

        public delegate ErrorCode DialogDelegate(ref DspState dsp_state, IntPtr hwnd, bool show);
        #endregion

        internal Dsp(IntPtr hnd)
            : base()
        {
            SetHandle(hnd);
        }

        protected override bool ReleaseHandle()
        {
            if (IsInvalid)
                return true;

            Remove();
            Release(handle);
            SetHandleAsInvalid();

            return true;
        }

        public void Remove()
        {
            Errors.ThrowIfError(Remove_External(DangerousGetHandle()));
        }

        public void Reset()
        {
            Errors.ThrowIfError(Reset_External(DangerousGetHandle()));
        }

        /// <summary>
        /// Strcture to define the parameters for a DSP unit.
        /// </summary>
        public struct DSPDescription
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
            public DspParameterDescription[] ParameterDesc;

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





    }


}
