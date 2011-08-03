using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Sound
{
	public class SoundGroup : Handle
	{
		
		#region Create/Release
		
		private SoundGroup ()
		{
		}
		internal SoundGroup (IntPtr hnd) : base()
		{
			this.SetHandle(hnd);
		}
		
		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			Release (this.handle);
			this.SetHandleAsInvalid ();
			
			return true;
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_SoundGroup_Release")]
		private static extern Error.Code Release (IntPtr soundgroup);

		#endregion
		
		//TODO Implement extern funcitons
		/*
	
		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetSystemObject (IntPtr soundgroup, ref IntPtr system);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudible (IntPtr soundgroup, int maxaudible);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudible (IntPtr soundgroup, ref int maxaudible);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetMaxAudibleBehavior (IntPtr soundgroup, SOUNDGROUP_BEHAVIOR behavior);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMaxAudibleBehavior (IntPtr soundgroup, ref SOUNDGROUP_BEHAVIOR behavior);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetMuteFadeSpeed (IntPtr soundgroup, float speed);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMuteFadeSpeed (IntPtr soundgroup, ref float speed);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetVolume (IntPtr soundgroup, float volume);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetVolume (IntPtr soundgroup, ref float volume);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_Stop (IntPtr soundgroup);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetName (IntPtr soundgroup, StringBuilder name, int namelen);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetNumSounds (IntPtr soundgroup, ref int numsounds);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetSound (IntPtr soundgroup, int index, ref IntPtr sound);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetNumPlaying (IntPtr soundgroup, ref int numplaying);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_SetUserData (IntPtr soundgroup, IntPtr userdata);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetUserData (IntPtr soundgroup, ref IntPtr userdata);

		[DllImport(VERSION.dll)]
		private static extern RESULT FMOD_SoundGroup_GetMemoryInfo (IntPtr soundgroup, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		*/
	}
}
