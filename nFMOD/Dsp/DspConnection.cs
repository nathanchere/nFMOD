using System;
using System.Runtime.InteropServices;
using System.Security;
using nFMOD.Enums;

namespace nFMOD
{
	public class DspConnection : Handle
	{
		#region Create/Release
		
		private DspConnection ()
		{
		}
		
		internal DspConnection (IntPtr ConnPtr)
		{
			this.SetHandle(ConnPtr);
		}
		
		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			//TODO find if DspConnection need to be released before closing.
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

    /*
    [ENUM]
    [
        [REMARKS]
        The default resampler type is FMOD_DSP_RESAMPLER_LINEAR.<br>
        Use System::setSoftwareFormat to tell FMOD the resampling quality you require for FMOD_SOFTWARE based sounds.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::setSoftwareFormat
        System::getSoftwareFormat
    ]
    */
	
}
