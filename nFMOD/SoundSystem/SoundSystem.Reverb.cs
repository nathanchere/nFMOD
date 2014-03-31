using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD.SoundSystem
{
	public partial class SoundSystem
	{
		public Reverb.Reverb CreateReverb ()
		{
			IntPtr ReverbHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateReverb (this.DangerousGetHandle (), ref ReverbHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Reverb.Reverb (ReverbHandle);
		}
		
		public Reverb.Properties ReverbProperties {
			get {
				Reverb.Properties Val = Reverb.Properties.Generic;
				Error.Code ReturnCode = GetReverbProperties(this.DangerousGetHandle(), ref Val);
				Error.Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				Error.Code ReturnCode = SetReverbProperties(this.DangerousGetHandle(), ref value);
				Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		public Reverb.Properties ReverbAmbientProperties {
			get {
				Reverb.Properties Val = Reverb.Properties.Generic;
				
				Error.Code ReturnCode = GetReverbAmbientProperties(this.DangerousGetHandle(), ref Val);
				Error.Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				Error.Code ReturnCode = SetReverbAmbientProperties(this.DangerousGetHandle(), ref value);
				Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateReverb"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code CreateReverb (IntPtr system, ref IntPtr reverb);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetReverbProperties"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code SetReverbProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetReverbProperties"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetReverbProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetReverbAmbientProperties"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code SetReverbAmbientProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetReverbAmbientProperties"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetReverbAmbientProperties (IntPtr system, ref Reverb.Properties prop);
		
	}
}

