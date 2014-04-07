using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
    public class DspConnection : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_SetMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetMix(IntPtr dspconnection, float volume);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_GetMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMix(IntPtr dspconnection, ref float volume);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_GetInput"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetInput (IntPtr dspconnection, ref IntPtr input);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_GetOutput"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetOutput (IntPtr dspconnection, ref IntPtr output);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_SetLevels"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetLevels (IntPtr dspconnection, Speaker speaker, float[] levels, int numlevels);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_GetLevels"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLevels (IntPtr dspconnection, Speaker speaker, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_SetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetUserData (IntPtr dspconnection, IntPtr userdata);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_GetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetUserData (IntPtr dspconnection, ref IntPtr userdata);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_DSPConnection_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMemoryInfo (IntPtr dspconnection, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
        #endregion


        internal DspConnection(IntPtr ConnPtr)
        {
            SetHandle(ConnPtr);
        }

        protected override bool ReleaseHandle()
        {
            if (IsInvalid) return true;

            //Release (this.handle); //TODO: needed?
            SetHandleAsInvalid();
            return true;
        }

        public float Mix
        {
            get
            {
                float result = 0;
                Errors.ThrowIfError(GetMix(DangerousGetHandle(), ref result));
                return result;
            }

            set
            {
                Errors.ThrowIfError(SetMix(DangerousGetHandle(), value));
            }
        }
    }
}
