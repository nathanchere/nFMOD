using System;
using System.Runtime.InteropServices;
using System.Security;
using nFMOD.Enums;

namespace nFMOD
{
	public partial class SoundSystem
	{
		public Reverb CreateReverb ()
		{
			IntPtr ReverbHandle = IntPtr.Zero;
			
			ErrorCode ReturnCode = CreateReverb (this.DangerousGetHandle (), ref ReverbHandle);
			Errors.ThrowError (ReturnCode);
			
			return new Reverb (ReverbHandle);
		}
		
		public Reverb.Properties ReverbProperties {
			get {
				var Val = Reverb.Properties.Generic;
				ErrorCode ReturnCode = GetReverbProperties(this.DangerousGetHandle(), ref Val);
				Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				ErrorCode ReturnCode = SetReverbProperties(this.DangerousGetHandle(), ref value);
				Errors.ThrowError(ReturnCode);
			}
		}
		
		public Reverb.Properties ReverbAmbientProperties {
			get {
				var Val = Reverb.Properties.Generic;
				
				ErrorCode ReturnCode = GetReverbAmbientProperties(this.DangerousGetHandle(), ref Val);
				Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				ErrorCode ReturnCode = SetReverbAmbientProperties(this.DangerousGetHandle(), ref value);
				Errors.ThrowError(ReturnCode);
			}
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateReverb"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode CreateReverb (IntPtr system, ref IntPtr reverb);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetReverbProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetReverbProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetReverbProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetReverbProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetReverbAmbientProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetReverbAmbientProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetReverbAmbientProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetReverbAmbientProperties (IntPtr system, ref Reverb.Properties prop);
		
	}
}

