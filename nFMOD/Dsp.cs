using System;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using nFMOD.Dsps;

namespace nFMOD
{
    public abstract class Dsp : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_AddInput"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode AddInput(IntPtr dsp, IntPtr target, ref IntPtr connection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_DisconnectAll"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode DisconnectAll(IntPtr dsp, int inputs, int outputs);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_DisconnectFrom"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode DisconnectFrom(IntPtr dsp, IntPtr target);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetActive(IntPtr dsp, ref int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetBypass"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetBypass(IntPtr dsp, ref int bypass);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetDefaults"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetDefaults(IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetInfo(IntPtr dsp, ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetInput"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetInput(IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMemoryInfo(IntPtr dsp, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetNumInputs"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumInputs(IntPtr dsp, ref int numinputs);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetNumOutputs"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumOutputs(IntPtr dsp, ref int numoutputs);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetNumParameters"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumParameters(IntPtr dsp, ref int numparams);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetOutput"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetOutput(IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetParameter"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetParameter(IntPtr dsp, int index, ref float value, StringBuilder valuestr, int valuestrlen);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetParameterInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetParameterInfo(IntPtr dsp, int index, ref IntPtr name, ref IntPtr label, StringBuilder description, int descriptionlen, ref float min, ref float max);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetSpeakerActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpeakerActive(IntPtr dsp, Speaker speaker, ref int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetSystemObject"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSystemObject(IntPtr dsp, ref IntPtr system);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetType"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetType(IntPtr dsp, ref DspType type);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_GetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetUserData(IntPtr dsp, ref IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_Release"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Release(IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_Remove"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Remove_External(IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_Reset"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Reset_External(IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetActive(IntPtr dsp, int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetBypass"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetBypass(IntPtr dsp, int bypass);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetDefaults"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetDefaults(IntPtr dsp, float frequency, float volume, float pan, int priority);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetParameter"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetParameter(IntPtr dsp, int index, float value);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetSpeakerActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetSpeakerActive(IntPtr dsp, Speaker speaker, int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_SetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetUserData(IntPtr dsp, IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_DSP_ShowConfigDialog"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode ShowConfigDialog(IntPtr dsp, IntPtr hwnd, int show);
        #endregion

        internal Dsp(IntPtr hnd)
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
        /// 
        /// </summary>
        internal static Dsp GetInstance(DspType type, IntPtr handle)
        {
            if(type == DspType.Oscillator) return new Oscillator(handle);

            // TODO: implement other types
            throw new NotSupportedException("DSP type " + type + " not currently supported by nFMOD");
        }
    }
}
