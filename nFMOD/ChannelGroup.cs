using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
	public class ChannelGroup : Handle
	{
		
		#region Create/Release
		
		private ChannelGroup()
		{
		}
		internal ChannelGroup (IntPtr hnd)
		{
			SetHandle(hnd);
		}
		
		protected override bool ReleaseHandle()
		{
			if (IsInvalid)
				return true;
			
			Release (handle);
			SetHandleAsInvalid();
			
			return true;
		}
		
		[DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_Release"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode Release (IntPtr channelgroup);
		
		#endregion
		
		
		//TODO Implement extern funcitons
		/*
	
		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetSystemObject (IntPtr channelgroup, ref IntPtr system);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_SetVolume (IntPtr channelgroup, float volume);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetVolume (IntPtr channelgroup, ref float volume);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_SetPitch (IntPtr channelgroup, float pitch);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetPitch (IntPtr channelgroup, ref float pitch);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_Set3DOcclusion (IntPtr channelgroup, float directocclusion, float reverbocclusion);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_Get3DOcclusion (IntPtr channelgroup, ref float directocclusion, ref float reverbocclusion);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_SetPaused (IntPtr channelgroup, int paused);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetPaused (IntPtr channelgroup, ref int paused);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_SetMute (IntPtr channelgroup, int mute);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetMute (IntPtr channelgroup, ref int mute);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_Stop (IntPtr channelgroup);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverridePaused (IntPtr channelgroup, int paused);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverrideVolume (IntPtr channelgroup, float volume);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverrideFrequency (IntPtr channelgroup, float frequency);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverridePan (IntPtr channelgroup, float pan);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverrideMute (IntPtr channelgroup, int mute);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverrideReverbProperties (IntPtr channelgroup, ref REVERB_CHANNELPROPERTIES prop);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_Override3DAttributes (IntPtr channelgroup, ref VECTOR pos, ref VECTOR vel);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_OverrideSpeakerMix (IntPtr channelgroup, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_AddGroup (IntPtr channelgroup, IntPtr @group);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetNumGroups (IntPtr channelgroup, ref int numgroups);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetGroup (IntPtr channelgroup, int index, ref IntPtr @group);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetParentGroup (IntPtr channelgroup, ref IntPtr @group);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetDSPHead (IntPtr channelgroup, ref IntPtr dsp);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_AddDSP (IntPtr channelgroup, IntPtr dsp, ref IntPtr connection);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetName (IntPtr channelgroup, StringBuilder name, int namelen);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetNumChannels (IntPtr channelgroup, ref int numchannels);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetChannel (IntPtr channelgroup, int index, ref IntPtr channel);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetSpectrum (IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetWaveData (IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_SetUserData (IntPtr channelgroup, IntPtr userdata);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetUserData (IntPtr channelgroup, ref IntPtr userdata);

		[DllImport(VERSION.dll), SuppressUnmanagedCodeSecurity]
		private static extern RESULT FMOD_ChannelGroup_GetMemoryInfo (IntPtr channelgroup, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		*/
	}
}
