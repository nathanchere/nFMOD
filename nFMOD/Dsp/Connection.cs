using System;
using System.Runtime.InteropServices;
using System.Security;
using nFMOD.Enums;

namespace nFMOD.Dsp
{
	public class Connection : Handle
	{
		#region Create/Release
		
		private Connection ()
		{
		}
		
		internal Connection (IntPtr ConnPtr)
		{
			this.SetHandle(ConnPtr);
		}
		
		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			//TODO find if Connection need to be released before closing.
			//Release (this.handle);
			this.SetHandleAsInvalid ();
			
			return true;
		}
		
		public float Mix {
			get {
				float Val = 0;
				ErrorCode ReturnCode = GetMix(this.DangerousGetHandle(), ref Val);
				Errors.ThrowIfError(ReturnCode);
				
				return Val;
			}
			
			set {
				ErrorCode ReturnCode = SetMix(this.DangerousGetHandle(), value);
				Errors.ThrowIfError(ReturnCode);
			}
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_DSPConnection_SetMix"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMix (IntPtr dspconnection, float volume);
		
		[DllImport("fmodex", EntryPoint = "FMOD_DSPConnection_GetMix"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMix (IntPtr dspconnection, ref float volume);

		#endregion
		
		//TODO Implement extern funcitons
		
		/*
		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_GetInput (IntPtr dspconnection, ref IntPtr input);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_GetOutput (IntPtr dspconnection, ref IntPtr output);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_SetLevels (IntPtr dspconnection, SPEAKER speaker, float[] levels, int numlevels);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_GetLevels (IntPtr dspconnection, SPEAKER speaker, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_SetUserData (IntPtr dspconnection, IntPtr userdata);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_GetUserData (IntPtr dspconnection, ref IntPtr userdata);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_DSPConnection_GetMemoryInfo (IntPtr dspconnection, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		*/
	}
}
