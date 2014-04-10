using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace nFMOD
{
    public class ChannelGroup : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_AddDSP"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode AddDSP(IntPtr channelgroup, IntPtr dsp, ref IntPtr connection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_AddGroup"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode AddGroup(IntPtr channelgroup, IntPtr @group);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_Get3DOcclusion"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3dOcclusion(IntPtr channelgroup, ref float directocclusion, ref float reverbocclusion);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetChannel"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetChannel(IntPtr channelgroup, int index, ref IntPtr channel);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetDSPHead"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetDSPHead(IntPtr channelgroup, ref IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetGroup"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetGroup(IntPtr channelgroup, int index, ref IntPtr @group);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMemoryInfo(IntPtr channelgroup, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMute(IntPtr channelgroup, ref int mute);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetName"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetName(IntPtr channelgroup, StringBuilder name, int namelen);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetNumChannels"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumChannels(IntPtr channelgroup, ref int numchannels);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetNumGroups"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumGroups(IntPtr channelgroup, ref int numgroups);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetParentGroup"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetParentGroup(IntPtr channelgroup, ref IntPtr @group);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetPaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPaused(IntPtr channelgroup, ref int paused);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetPitch"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPitch(IntPtr channelgroup, ref float pitch);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetSpectrum"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpectrum(IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, FFTWindow windowtype);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetSystemObject"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSystemObject(IntPtr channelgroup, ref IntPtr system);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetUserData(IntPtr channelgroup, ref IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetVolume(IntPtr channelgroup, ref float volume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_GetWaveData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetWaveData(IntPtr channelgroup, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_Override3DAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Override3dAttributes(IntPtr channelgroup, ref Vector3 pos, ref Vector3 vel);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverrideFrequency"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverrideFrequency(IntPtr channelgroup, float frequency);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverrideMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverrideMute(IntPtr channelgroup, int mute);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverridePan"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverridePan(IntPtr channelgroup, float pan);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverridePaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverridePaused(IntPtr channelgroup, int paused);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverrideReverbProperties"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverrideReverbProperties(IntPtr channelgroup, ref ReverbChannelProperties prop);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverrideSpeakerMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverrideSpeakerMix(IntPtr channelgroup, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_OverrideVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode OverrideVolume(IntPtr channelgroup, float volume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_Release"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Release(IntPtr channelgroup);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_Set3DOcclusion"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3dOcclusion(IntPtr channelgroup, float directocclusion, float reverbocclusion);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_SetMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetMute(IntPtr channelgroup, int mute);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_SetPaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPaused(IntPtr channelgroup, int paused);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_SetPitch"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPitch(IntPtr channelgroup, float pitch);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_SetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetUserData(IntPtr channelgroup, IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_SetVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetVolume(IntPtr channelgroup, float volume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_ChannelGroup_Stop"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Stop(IntPtr channelgroup);
        #endregion

        private ChannelGroup() { }

        internal ChannelGroup(IntPtr hnd)
        {
            SetHandle(hnd);
        }

        protected override bool ReleaseHandle()
        {
            if (IsInvalid) return true;

            Release(handle);
            SetHandleAsInvalid();
            return true;
        }
    }
}
