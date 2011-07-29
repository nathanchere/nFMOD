using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Sound
{
	public class Sound : Handle
	{
		
		#region Create/Release
		
		private Sound()
		{
		}
		internal Sound (IntPtr hnd) : base()
		{
			this.SetHandle (hnd);
		}

		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			Release (this.handle);
			this.SetHandleAsInvalid ();
			
			return true;
		}

		[DllImport("fmodex", EntryPoint = "FMOD_Sound_Release")]
		private static extern Error.Code Release (IntPtr sound);
		
		#endregion
		
		
		
		//TODO Implement extern funcitons
		
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSystemObject (IntPtr sound, ref IntPtr system);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Lock (IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Unlock (IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetDefaults (IntPtr sound, float frequency, float volume, float pan, int priority);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetDefaults (IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetVariations (IntPtr sound, float frequencyvar, float volumevar, float panvar);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetVariations (IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Set3DMinMaxDistance (IntPtr sound, float min, float max);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Get3DMinMaxDistance (IntPtr sound, ref float min, ref float max);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Set3DConeSettings (IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Get3DConeSettings (IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Set3DCustomRolloff (IntPtr sound, ref Vector3 points, int numpoints);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Get3DCustomRolloff (IntPtr sound, ref IntPtr points, ref int numpoints);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetSubSound (IntPtr sound, int index, IntPtr subsound);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSubSound (IntPtr sound, int index, ref IntPtr subsound);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetSubSoundSentence (IntPtr sound, int[] subsoundlist, int numsubsounds);

		//[DllImport("fmodex")]
		//private static extern Error.Code FMOD_Sound_GetName (IntPtr sound, StringBuilder name, int namelen);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetLength (IntPtr sound, ref uint length, TimeUnit lengthtype);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetFormat (IntPtr sound, ref FmodSharp.Sound.Type type, ref FmodSharp.Sound.Format format, ref int channels, ref int bits);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetNumSubSounds (IntPtr sound, ref int numsubsounds);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetNumTags (IntPtr sound, ref int numtags, ref int numtagsupdated);

		//[DllImport("fmodex")]
		//private static extern Error.Code FMOD_Sound_GetTag (IntPtr sound, string name, int index, ref TAG tag);

		//[DllImport("fmodex")]
		//private static extern Error.Code FMOD_Sound_GetOpenState (IntPtr sound, ref OPENSTATE openstate, ref uint percentbuffered, ref int starving);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_ReadData (IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SeekData (IntPtr sound, uint pcm);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetSoundGroup (IntPtr sound, IntPtr soundgroup);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSoundGroup (IntPtr sound, ref IntPtr soundgroup);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetNumSyncPoints (IntPtr sound, ref int numsyncpoints);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSyncPoint (IntPtr sound, int index, ref IntPtr point);

		//[DllImport("fmodex")]
		//private static extern Error.Code FMOD_Sound_GetSyncPointInfo (IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_AddSyncPoint (IntPtr sound, uint offset, TimeUnit offsettype, string name, ref IntPtr point);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_DeleteSyncPoint (IntPtr sound, IntPtr point);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetMode (IntPtr sound, Mode mode);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMode (IntPtr sound, ref Mode mode);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetLoopCount (IntPtr sound, int loopcount);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetLoopCount (IntPtr sound, ref int loopcount);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetLoopPoints (IntPtr sound, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetLoopPoints (IntPtr sound, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMusicNumChannels (IntPtr sound, ref int numchannels);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetMusicChannelVolume (IntPtr sound, int channel, float volume);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMusicChannelVolume (IntPtr sound, int channel, ref float volume);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetMusicSpeed (IntPtr sound, float speed);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMusicSpeed (IntPtr sound, ref float speed);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetUserData (IntPtr sound, IntPtr userdata);

		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetUserData (IntPtr sound, ref IntPtr userdata);

		//[DllImport("fmodex")]
		//private static extern Error.Code FMOD_Sound_GetMemoryInfo (IntPtr sound, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
	}
}

