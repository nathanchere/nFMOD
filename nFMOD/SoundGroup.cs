using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace nFMOD
{
	public class SoundGroup : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL, EntryPoint = "Release"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Release (IntPtr soundgroup);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetSystemObject"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSystemObject (IntPtr soundgroup, ref IntPtr system);
        		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_SetMaxAudible"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMaxAudible (IntPtr soundgroup, int maxaudible);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetMaxAudible"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMaxAudible (IntPtr soundgroup, ref int maxaudible);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_SetMaxAudibleBehavior"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMaxAudibleBehavior (IntPtr soundgroup, SoundGroupBehavior behavior);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetMaxAudibleBehavior"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMaxAudibleBehavior (IntPtr soundgroup, ref SoundGroupBehavior behavior);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_SetMuteFadeSpeed"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMuteFadeSpeed (IntPtr soundgroup, float speed);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetMuteFadeSpeed"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMuteFadeSpeed (IntPtr soundgroup, ref float speed);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_SetVolume "), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetVolume (IntPtr soundgroup, float volume);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetVolume"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetVolume (IntPtr soundgroup, ref float volume);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_Stop"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Stop (IntPtr soundgroup);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetName"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetName (IntPtr soundgroup, StringBuilder name, int namelen);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetNumSounds"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumSounds (IntPtr soundgroup, ref int numsounds);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetSound"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSound (IntPtr soundgroup, int index, ref IntPtr sound);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetNumPlaying"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumPlaying (IntPtr soundgroup, ref int numplaying);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_SetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetUserData (IntPtr soundgroup, IntPtr userdata);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetUserData (IntPtr soundgroup, ref IntPtr userdata);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_SoundGroup_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMemoryInfo (IntPtr soundgroup, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);		
        #endregion

        private SoundGroup () { }

		internal SoundGroup (IntPtr hnd)
		{
			SetHandle(hnd);
		}
		
		protected override bool ReleaseHandle ()
		{
			if (IsInvalid) return true;
			
			Release (handle);
			SetHandleAsInvalid();			
			return true;
		}				
	}
}
