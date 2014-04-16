using System;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using nFMOD.Dsps;

namespace nFMOD
{
    /// <TODO>
    /// * implement Pause / stop
    /// </TODO>
    public abstract class Dsp : Handle
    {
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_System_PlayDSP"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode PlayDSP(IntPtr system, ChannelIndex channelid, int Dsp, int paused, ref int channel);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_System_PlayDSP"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode PlayDsp(IntPtr system, ChannelIndex channelid, IntPtr dsp, bool paused, ref IntPtr channel);

        [Obsolete("Use overload with IntPtr instead")]
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_System_CreateDSPByType"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode CreateDSPByType(IntPtr system, DspType dsptype, ref int Dsp);
        
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_System_CreateDSPByType"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode CreateDspByType(IntPtr system, DspType type, ref IntPtr dsp);

        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_AddInput"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode AddInput(IntPtr dsp, IntPtr target, ref IntPtr connection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_DisconnectAll"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode DisconnectAll(IntPtr dsp, int inputs, int outputs);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_DisconnectFrom"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode DisconnectFrom(IntPtr dsp, IntPtr target);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetActive"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetActive(IntPtr dsp, ref int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetBypass"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetBypass(IntPtr dsp, ref int bypass);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetDefaults"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetDefaults(IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetInfo"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetInfo(IntPtr dsp, ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetInput"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetInput(IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetMemoryInfo(IntPtr dsp, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetNumInputs"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetNumInputs(IntPtr dsp, ref int numinputs);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetNumOutputs"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetNumOutputs(IntPtr dsp, ref int numoutputs);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetNumParameters"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetNumParameters(IntPtr dsp, ref int numparams);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetOutput"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetOutput(IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetParameter"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetParameter(IntPtr dsp, int index, ref float value, StringBuilder valuestr, int valuestrlen);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetParameterInfo"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetParameterInfo(IntPtr dsp, int index, ref IntPtr name, ref IntPtr label, StringBuilder description, int descriptionlen, ref float min, ref float max);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetSpeakerActive"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetSpeakerActive(IntPtr dsp, Speaker speaker, ref int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetSystemObject"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetSystemObject(IntPtr dsp, ref IntPtr system);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetType"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetType(IntPtr dsp, ref DspType type);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetUserData"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode GetUserData(IntPtr dsp, ref IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_Release"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode Release(IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_Remove"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode Remove_External(IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_Reset"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode Reset_External(IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetActive"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode SetActive(IntPtr dsp, int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetBypass"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode SetBypass(IntPtr dsp, int bypass);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetDefaults"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode SetDefaults(IntPtr dsp, float frequency, float volume, float pan, int priority);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetParameter"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode SetParameter(IntPtr dsp, int index, float value);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetSpeakerActive"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode SetSpeakerActive(IntPtr dsp, Speaker speaker, int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetUserData"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode SetUserData(IntPtr dsp, IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_ShowConfigDialog"), SuppressUnmanagedCodeSecurity]
        protected static extern ErrorCode ShowConfigDialog(IntPtr dsp, IntPtr hwnd, int show);
        #endregion

        protected readonly FmodSystem Parent;
        public Channel Channel
        {
            get;
            private set;
        }

        internal Dsp(IntPtr hnd, FmodSystem parent)
        {
            Parent = parent;
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

        public Channel Play(Channel channel = null)
        {
            IntPtr result = channel == null
                ? IntPtr.Zero
                : Channel.DangerousGetHandle()
                ;

            Errors.ThrowIfError(PlayDsp(Parent.DangerousGetHandle(), ChannelIndex.Free, DangerousGetHandle(), false, ref result));

            Channel = channel == null
                ? new Channel(result)
                : channel;

            return Channel;
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
        /// Kind of like a DSP factory. But not.
        /// </summary>
        internal static Dsp GetInstance(FmodSystem system, DspType type)
        {
            IntPtr handle = IntPtr.Zero;
            Errors.ThrowIfError(CreateDspByType(system.DangerousGetHandle(), type, ref handle));
            
            if (type == DspType.Oscillator) return new Oscillator(handle, system);;

            // TODO: implement other types
            throw new NotSupportedException("DSP type " + type + " not currently supported by nFMOD");
        }
    }
}
