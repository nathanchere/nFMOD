using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
	public partial class SoundSystem
    {
        #region Externs
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_CreateReverb"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode CreateReverb (IntPtr system, ref IntPtr reverb);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_SetReverbProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetReverbProperties (IntPtr system, ref ReverbProperties prop);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetReverbProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetReverbProperties (IntPtr system, ref ReverbProperties prop);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_SetReverbAmbientProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetReverbAmbientProperties (IntPtr system, ref ReverbProperties prop);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetReverbAmbientProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetReverbAmbientProperties (IntPtr system, ref ReverbProperties prop);
        #endregion

        public Reverb CreateReverb ()
		{
			IntPtr ReverbHandle = IntPtr.Zero;
			
			ErrorCode ReturnCode = CreateReverb (this.DangerousGetHandle (), ref ReverbHandle);
			Errors.ThrowIfError (ReturnCode);
			
			return new Reverb (ReverbHandle);
		}
		
		public ReverbProperties ReverbProperties {
			get {
				var Val = ReverbProperties.Generic;
				ErrorCode ReturnCode = GetReverbProperties(this.DangerousGetHandle(), ref Val);
				Errors.ThrowIfError(ReturnCode);
				
				return Val;
			}
			
			set {
				ErrorCode ReturnCode = SetReverbProperties(this.DangerousGetHandle(), ref value);
				Errors.ThrowIfError(ReturnCode);
			}
		}
		
		public ReverbProperties ReverbAmbientProperties {
			get {
				var Val = ReverbProperties.Generic;
				
				ErrorCode ReturnCode = GetReverbAmbientProperties(this.DangerousGetHandle(), ref Val);
				Errors.ThrowIfError(ReturnCode);
				
				return Val;
			}
			
			set {
				ErrorCode ReturnCode = SetReverbAmbientProperties(this.DangerousGetHandle(), ref value);
				Errors.ThrowIfError(ReturnCode);
			}
		}
	}
}

