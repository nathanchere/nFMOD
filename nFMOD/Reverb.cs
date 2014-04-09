using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
	public partial class Reverb : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Reverb_SetProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetProperties (IntPtr reverb, ref ReverbProperties properties);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Reverb_GetProperties"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetProperties (IntPtr reverb, ref ReverbProperties properties);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DAttributes (IntPtr reverb, ref Vector3 position, float mindistance, float maxdistance);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DAttributes (IntPtr reverb, ref Vector3 position, ref float mindistance, ref float maxdistance);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetActive (IntPtr reverb, int active);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetActive (IntPtr reverb, ref int active);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetUserData (IntPtr reverb, IntPtr userdata);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetUserData (IntPtr reverb, ref IntPtr userdata);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = ""), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMemoryInfo (IntPtr reverb, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);
        #endregion
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
			
	}
}

