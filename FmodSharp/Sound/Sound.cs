//Author:
//      Marc-Andre Ferland <madrang@gmail.com>
//
//Copyright (c) 2011 TheWarrentTeam
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System;
using System.Runtime.InteropServices;

namespace Xpod.FmodSharp.Sound
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

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_Sound_Release")]
		private static extern Error.Code Release (IntPtr sound);
		
		#endregion
		
		
		
		//TODO Implement extern funcitons
		
		/*
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSystemObject (IntPtr sound, ref IntPtr system);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Lock (IntPtr sound, uint offset, uint length, ref IntPtr ptr1, ref IntPtr ptr2, ref uint len1, ref uint len2);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Unlock (IntPtr sound, IntPtr ptr1, IntPtr ptr2, uint len1, uint len2);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetDefaults (IntPtr sound, float frequency, float volume, float pan, int priority);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetDefaults (IntPtr sound, ref float frequency, ref float volume, ref float pan, ref int priority);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetVariations (IntPtr sound, float frequencyvar, float volumevar, float panvar);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetVariations (IntPtr sound, ref float frequencyvar, ref float volumevar, ref float panvar);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Set3DMinMaxDistance (IntPtr sound, float min, float max);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Get3DMinMaxDistance (IntPtr sound, ref float min, ref float max);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Set3DConeSettings (IntPtr sound, float insideconeangle, float outsideconeangle, float outsidevolume);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Get3DConeSettings (IntPtr sound, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Set3DCustomRolloff (IntPtr sound, ref Vector3 points, int numpoints);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_Get3DCustomRolloff (IntPtr sound, ref IntPtr points, ref int numpoints);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetSubSound (IntPtr sound, int index, IntPtr subsound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSubSound (IntPtr sound, int index, ref IntPtr subsound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetSubSoundSentence (IntPtr sound, int[] subsoundlist, int numsubsounds);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetName (IntPtr sound, StringBuilder name, int namelen);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetLength (IntPtr sound, ref uint length, TimeUnit lengthtype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetFormat (IntPtr sound, ref FmodSharp.Sound.Type type, ref FmodSharp.Sound.Format format, ref int channels, ref int bits);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetNumSubSounds (IntPtr sound, ref int numsubsounds);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetNumTags (IntPtr sound, ref int numtags, ref int numtagsupdated);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetTag (IntPtr sound, string name, int index, ref TAG tag);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetOpenState (IntPtr sound, ref OPENSTATE openstate, ref uint percentbuffered, ref int starving);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_ReadData (IntPtr sound, IntPtr buffer, uint lenbytes, ref uint read);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SeekData (IntPtr sound, uint pcm);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetSoundGroup (IntPtr sound, IntPtr soundgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSoundGroup (IntPtr sound, ref IntPtr soundgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetNumSyncPoints (IntPtr sound, ref int numsyncpoints);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSyncPoint (IntPtr sound, int index, ref IntPtr point);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetSyncPointInfo (IntPtr sound, IntPtr point, StringBuilder name, int namelen, ref uint offset, TIMEUNIT offsettype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_AddSyncPoint (IntPtr sound, uint offset, TimeUnit offsettype, string name, ref IntPtr point);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_DeleteSyncPoint (IntPtr sound, IntPtr point);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetMode (IntPtr sound, Mode mode);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMode (IntPtr sound, ref Mode mode);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetLoopCount (IntPtr sound, int loopcount);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetLoopCount (IntPtr sound, ref int loopcount);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetLoopPoints (IntPtr sound, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetLoopPoints (IntPtr sound, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMusicNumChannels (IntPtr sound, ref int numchannels);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetMusicChannelVolume (IntPtr sound, int channel, float volume);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMusicChannelVolume (IntPtr sound, int channel, ref float volume);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetMusicSpeed (IntPtr sound, float speed);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMusicSpeed (IntPtr sound, ref float speed);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_SetUserData (IntPtr sound, IntPtr userdata);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetUserData (IntPtr sound, ref IntPtr userdata);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex")]
		private static extern Error.Code FMOD_Sound_GetMemoryInfo (IntPtr sound, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		
		*/

	
	}
}

