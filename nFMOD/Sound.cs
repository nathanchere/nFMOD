using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace nFMOD
{
	public class Sound : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Release"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Release (IntPtr sound);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetSystemObject"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSystemObject (IntPtr sound, ref IntPtr system);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Lock"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Lock (IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Unlock"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Unlock (IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetDefaults"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetDefaults (IntPtr sound, float frequency, float volume, float pan, int priority);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetDefaults"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDefaults (IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetVariations"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetVariations (IntPtr sound, float frequencyvar, float volumevar, float panvar);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetVariations"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetVariations (IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Set3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DMinMaxDistance (IntPtr sound, float min, float max);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Get3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DMinMaxDistance (IntPtr sound, ref float min, ref float max);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Set3DConeSettings"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DConeSettings (IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Get3DConeSettings"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DConeSettings (IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Set3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Set3DCustomRolloff (IntPtr sound, ref Vector3 points, int numpoints);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_Get3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Get3DCustomRolloff (IntPtr sound, ref IntPtr points, ref int numpoints);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetSubSound"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetSubSound (IntPtr sound, int index, IntPtr subsound);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetSubSound"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSubSound (IntPtr sound, int index, ref IntPtr subsound);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetSubSoundSentence"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetSubSoundSentence (IntPtr sound, int[] subsoundlist, int numsubsounds);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetName"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetName (IntPtr sound, StringBuilder name, int namelen);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetLength"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLength (IntPtr sound, ref uint length, TimeUnit lengthtype);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetFormat"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetFormat (IntPtr sound, ref SoundType type, ref SoundFormat format, ref int channels, ref int bits);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetNumSubSounds"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumSubSounds (IntPtr sound, ref int numsubsounds);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetNumTags"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumTags (IntPtr sound, ref int numtags, ref int numtagsupdated);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetTag"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetTag (IntPtr sound, string name, int index, ref Tag tag);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetOpenState"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetOpenState (IntPtr sound, ref OpenState openstate, ref uint percentbuffered, ref int starving);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_ReadData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode ReadData (IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SeekData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SeekData (IntPtr sound, uint pcm);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetSoundGroup"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetSoundGroup (IntPtr sound, IntPtr soundgroup);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetSoundGroup"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSoundGroup (IntPtr sound, ref IntPtr soundgroup);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetNumSyncPoints"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumSyncPoints (IntPtr sound, ref int numsyncpoints);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetSyncPoint"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSyncPoint (IntPtr sound, int index, ref IntPtr point);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetSyncPointInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetSyncPointInfo (IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TimeUnit offsettype);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_AddSyncPoint"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode AddSyncPoint (IntPtr sound, uint offset, TimeUnit offsettype, string name, ref IntPtr point);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_DeleteSyncPoint"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode DeleteSyncPoint (IntPtr sound, IntPtr point);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetMode"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMode (IntPtr sound, Mode mode);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetMode"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMode (IntPtr sound, ref Mode mode);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetLoopCount"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetLoopCount (IntPtr sound, int loopcount);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetLoopCount"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLoopCount (IntPtr sound, ref int loopcount);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetLoopPoints"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetLoopPoints (IntPtr sound, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetLoopPoints"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLoopPoints (IntPtr sound, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetMusicNumChannels"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMusicNumChannels (IntPtr sound, ref int numchannels);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetMusicChannelVolume"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMusicChannelVolume (IntPtr sound, int channel, float volume);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetMusicChannelVolume"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMusicChannelVolume (IntPtr sound, int channel, ref float volume);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetMusicSpeed"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetMusicSpeed (IntPtr sound, float speed);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetMusicSpeed"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMusicSpeed (IntPtr sound, ref float speed);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_SetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetUserData (IntPtr sound, IntPtr userdata);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetUserData"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetUserData (IntPtr sound, ref IntPtr userdata);

		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Sound_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetMemoryInfo (IntPtr sound, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);
        #endregion       

        public delegate ErrorCode NonBlockDelegate (IntPtr soundraw, ErrorCode result);
	    public delegate ErrorCode PCMReadDelegate (IntPtr soundraw, IntPtr data, uint datalen);
	    public delegate ErrorCode PCMSetposDelegate (IntPtr soundraw, int subsound, uint position, TimeUnit postype);

		private Sound() { }

		internal Sound (IntPtr hnd)
		{
			SetHandle (hnd);
		}

		protected override bool ReleaseHandle()
		{
			if (IsInvalid) return true;
			
			Release (handle);
			SetHandleAsInvalid();			
			return true;
		}
	}
}

