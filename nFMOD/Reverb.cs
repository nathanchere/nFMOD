using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
	public partial class Reverb : Handle
	{
		
		#region Create/Release
		
		private Reverb()
		{
		}
		internal Reverb (IntPtr hnd)
		{
			SetHandle (hnd);
		}

		protected override bool ReleaseHandle()
		{
			if (IsInvalid)
				return true;
			
			Release (handle);
			SetHandleAsInvalid();
			
			return true;
		}

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Reverb_Release"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Release (IntPtr reverb);
		
		#endregion
		
		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Reverb_SetProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetProperties (IntPtr reverb, ref ReverbProperties properties);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Reverb_GetProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetProperties (IntPtr reverb, ref ReverbProperties properties);
		
		
		//TODO Implement extern funcitons
		
		/*

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_Set3DAttributes (IntPtr reverb, ref VECTOR position, float mindistance, float maxdistance);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_Get3DAttributes (IntPtr reverb, ref VECTOR position, ref float mindistance, ref float maxdistance);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_SetActive (IntPtr reverb, int active);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_GetActive (IntPtr reverb, ref int active);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_SetUserData (IntPtr reverb, IntPtr userdata);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_GetUserData (IntPtr reverb, ref IntPtr userdata);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_Reverb_GetMemoryInfo (IntPtr reverb, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		*/
	}
}

