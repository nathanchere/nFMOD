using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
    public class Channel : Handle, ISpectrumWave
    {
        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_AddDSP"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode AddDSP(IntPtr channel, IntPtr dsp, ref IntPtr connection);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DAttributes(IntPtr channel, ref Vector3 pos, ref Vector3 vel);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DConeOrientation"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DConeOrientation(IntPtr channel, ref Vector3 orientation);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DConeSettings"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DConeSettings(IntPtr channel, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DCustomRolloff(IntPtr channel, ref IntPtr points, ref int numpoints);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DDopplerLevel"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DDopplerLevel(IntPtr channel, ref float level);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DMinMaxDistance(IntPtr channel, ref float mindistance, ref float maxdistance);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DOcclusion"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DOcclusion(IntPtr channel, ref float directocclusion, ref float reverbocclusion);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DPanLevel"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DPanLevel(IntPtr channel, ref float level);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3DSpread"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3DSpread(IntPtr channel, ref float angle);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Get3Docclusion"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Get3Docclusion(IntPtr channel, ref float directocclusion, ref float reverbocclusion);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetAudibility"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetAudibility(IntPtr channel, ref float audibility);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetChannelGroup"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetChannelGroup(IntPtr channel, ref IntPtr channelgroup);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetCurrentSound"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetCurrentSound(IntPtr channel, ref IntPtr sound);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetDSPHead"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetDSPHead(IntPtr channel, ref IntPtr dsp);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetDelay"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetDelay(IntPtr channel, DelayType delaytype, ref uint delayhi, ref uint delaylo);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetFrequency"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetFrequency(IntPtr channel, ref float frequency);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetIndex"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetIndex(IntPtr channel, ref int index);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetInputChannelMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetInputChannelMix(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetLoopCount"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetLoopCount(IntPtr channel, ref int loopcount);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetLoopPoints"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetLoopPoints(IntPtr channel, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetLowPassGain"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetLowPassGain(IntPtr channel, ref float gain);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMemoryInfo(IntPtr channel, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetMode"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMode(IntPtr channel, ref SoundMode mode);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMute(IntPtr channel, ref bool mute);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetPan"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPan(IntPtr channel, ref float pan);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetPaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPaused(IntPtr channel, ref bool paused);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPosition(IntPtr channel, ref uint position, TimeUnit postype);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetPriority"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPriority(IntPtr channel, ref int priority);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetReverbProperties"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetReverbProperties(IntPtr channel, ref ReverbChannelProperties prop);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetSpeakerLevels"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpeakerLevels(IntPtr channel, Speaker speaker, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetSpeakerMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpeakerMix(IntPtr channel, ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetSpectrum"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpectrum(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, FFTWindow windowtype);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetSystemObject"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSystemObject(IntPtr channel, ref IntPtr system);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetUserData(IntPtr channel, ref IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetVolume(IntPtr channel, ref float volume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_GetWaveData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetWaveData(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_IsPlaying"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode IsChannelPlaying(IntPtr channel, ref bool isplaying);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_IsVirtual"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode IsChannelVirtual(IntPtr channel, ref int isvirtual);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DAttributes(IntPtr channel, ref Vector3 pos, ref Vector3 vel);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DConeOrientation"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DConeOrientation(IntPtr channel, ref Vector3 orientation);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DConeSettings"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DConeSettings(IntPtr channel, float insideconeangle, float outsideconeangle, float outsidevolume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DCustomRolloff(IntPtr channel, ref Vector3 points, int numpoints);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DDopplerLevel"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DDopplerLevel(IntPtr channel, float level);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DMinMaxDistance(IntPtr channel, float mindistance, float maxdistance);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DOcclusion"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DOcclusion(IntPtr channel, float directocclusion, float reverbocclusion);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DPanLevel"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DPanLevel(IntPtr channel, float level);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3DSpread"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3DSpread(IntPtr channel, float angle);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Set3Docclusion"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Set3Docclusion(IntPtr channel, float directocclusion, float reverbocclusion);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetCallback"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetCallback(IntPtr channel, ChannelCallbackType callback);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetChannelGroup"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetChannelGroup(IntPtr channel, IntPtr channelgroup);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetDelay"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetDelay(IntPtr channel, DelayType delaytype, uint delayhi, uint delaylo);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetFrequency"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetFrequency(IntPtr channel, float frequency);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetInputChannelMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetInputChannelMix(IntPtr channel, float[] levels, int numlevels);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetLoopCount"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetLoopCount(IntPtr channel, int loopcount);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetLoopPoints"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetLoopPoints(IntPtr channel, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetLowPassGain"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetLowPassGain(IntPtr channel, float gain);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetMode"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetMode(IntPtr channel, SoundMode mode);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetMute(IntPtr channel, bool mute);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetPan"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPan(IntPtr channel, float pan);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetPaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPaused(IntPtr channel, bool paused);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPosition(IntPtr channel, uint position, TimeUnit postype);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetPriority"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPriority(IntPtr channel, int priority);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetReverbProperties"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetReverbProperties(IntPtr channel, ref ReverbChannelProperties prop);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetSpeakerLevels"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetSpeakerLevels(IntPtr channel, Speaker speaker, float[] levels, int numlevels);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetSpeakerMix"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetSpeakerMix(IntPtr channel, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetUserData(IntPtr channel, IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_SetVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetVolume(IntPtr channel, float volume);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Channel_Stop"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Stop(IntPtr channel);

        #endregion

        public delegate ErrorCode ChannelDelegate(IntPtr channelraw, ChannelCallbackType type, IntPtr commanddata1, IntPtr commanddata2);

        internal Channel(IntPtr hnd)
        {
            SetHandle(hnd);
        }

        public bool Paused
        {
            get
            {
                bool result = false;
                Errors.ThrowIfError(GetPaused(DangerousGetHandle(), ref result));
                return result;
            }
            set
            {
                Errors.ThrowIfError(SetPaused(DangerousGetHandle(), value));
            }
        }

        public float Volume
        {
            get
            {
                float result = 0.0f;
                Errors.ThrowIfError(GetVolume(DangerousGetHandle(), ref result));
                return result;
            }
            set
            {
                Errors.ThrowIfError(SetVolume(DangerousGetHandle(), value));
            }
        }

        public float Frequency
        {
            get
            {
                float result = 0.0f;
                Errors.ThrowIfError(GetFrequency(DangerousGetHandle(), ref result));
                return result;
            }
            set
            {
                Errors.ThrowIfError(SetFrequency(DangerousGetHandle(), value));
            }
        }

        public float Pan
        {
            get
            {
                float result = 0.0f;
                Errors.ThrowIfError(GetPan(DangerousGetHandle(), ref result));
                return result;
            }
            set
            {
                Errors.ThrowIfError(SetPan(DangerousGetHandle(), value));
            }
        }

        public bool Mute
        {
            get
            {
                bool value = false;
                Errors.ThrowIfError(GetMute(DangerousGetHandle(), ref value));
                return value;
            }

            set
            {
                Errors.ThrowIfError(SetMute(DangerousGetHandle(), value));
            }
        }

        #region new
        /// <remarks>
        /// Throws FmodTooManyChannelsException if FmodSystem handle is invalid
        /// </remarks>>
        public FmodSystem SystemInstance // TODO: internal?
        {
            get
            {
                IntPtr result = IntPtr.Zero;
                Errors.ThrowIfError(GetSystemObject(handle, ref result));
                return new FmodSystem(result);
            }
        }

        public DelaySettings Delay
        {
            get // TODO: Errors.ThrowIfError(GetDelay(DangerousGetHandle(), type, hi, lo));
            {
                throw new NotImplementedException();
            }

            set
            {
                Errors.ThrowIfError(SetDelay(DangerousGetHandle(), value.Type, value.High, value.Low));
            }
        }

        //public TODO SpeakerMix
        //{
        //    get: GetSpeakerMix(channelraw, ref frontleft, ref frontright, ref center, ref lfe, ref backleft, ref backright, ref sideleft, ref sideright);
        //    set: SetSpeakerMix(channelraw, frontleft, frontright, center, lfe, backleft, backright, sideleft, sideright);
        //}

        //public TODO SpeakerLevels
        //{
        //    GetSpeakerLevels(channelraw, speaker, levels, numlevels);
        //    SetSpeakerLevels(channelraw, speaker, levels, numlevels);
        //}

        //public TODO InputChannelMix {
        //    SetInputChannelMix(channelraw, levels, numlevels);
        //    GetInputChannelMix(channelraw, levels, numlevels);
        //}

        //public TODO Priority { 
        //    GetPriority(channelraw, ref priority);
        //    SetPriority(channelraw, priority);
        //}

        //public TODO Position { 
        //    SetPosition(channelraw, position, postype);
        //    GetPosition(channelraw, ref position, postype);
        //}

        public float LowPassGain
        {
            get
            {
                float result = 0.0f;
                Errors.ThrowIfError(GetLowPassGain(DangerousGetHandle(), ref result));
                return result;
            }

            set
            {
                Errors.ThrowIfError(SetLowPassGain(DangerousGetHandle(), value));
            }
        }

        public ChannelGroup ChannelGroup
        {
            get
            {
                IntPtr handle = IntPtr.Zero;
                Errors.ThrowIfError(GetChannelGroup(DangerousGetHandle(), ref handle));
                return new ChannelGroup(handle);
            }
            set
            {
                SetChannelGroup(DangerousGetHandle(), value.DangerousGetHandle());
            }
        }

        public ReverbChannelProperties ReverbProperties
        {
            get
            {
                var result = new ReverbChannelProperties();
                Errors.ThrowIfError(GetReverbProperties(DangerousGetHandle(), ref result));
                return result;
            }
            set
            {
                Errors.ThrowIfError(SetReverbProperties(DangerousGetHandle(), ref value));
            }
        }

        public void SetCallback(ChannelCallbackType callback)
        {
            Errors.ThrowIfError(SetCallback(DangerousGetHandle(), callback));
        }        

        #region 3D stuff
        //public todo SurroundAttributes { 
        //    Set3DAttributes(channelraw, ref pos, ref vel);
        //    Get3DAttributes       (ref VECTOR pos, ref VECTOR vel)
        //}
        //public RESULT set3DMinMaxDistance   (float mindistance, float maxdistance)
        //{
        //    return FMOD_Channel_Set3DMinMaxDistance(channelraw, mindistance, maxdistance);
        //}
        //public RESULT get3DMinMaxDistance   (ref float mindistance, ref float maxdistance)
        //{
        //    return FMOD_Channel_Get3DMinMaxDistance(channelraw, ref mindistance, ref maxdistance);
        //}
        //public RESULT set3DConeSettings     (float insideconeangle, float outsideconeangle, float outsidevolume)
        //{
        //    return FMOD_Channel_Set3DConeSettings(channelraw, insideconeangle, outsideconeangle, outsidevolume);
        //}
        //public RESULT get3DConeSettings     (ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume)
        //{
        //    return FMOD_Channel_Get3DConeSettings(channelraw, ref insideconeangle, ref outsideconeangle, ref outsidevolume);
        //}
        //public RESULT set3DConeOrientation  (ref VECTOR orientation)
        //{
        //    return FMOD_Channel_Set3DConeOrientation(channelraw, ref orientation);
        //}
        //public RESULT get3DConeOrientation  (ref VECTOR orientation)
        //{
        //    return FMOD_Channel_Get3DConeOrientation(channelraw, ref orientation);
        //}
        //public RESULT set3DCustomRolloff    (ref VECTOR points, int numpoints)
        //{
        //    return FMOD_Channel_Set3DCustomRolloff(channelraw, ref points, numpoints);
        //}
        //public RESULT get3DCustomRolloff    (ref IntPtr points, ref int numpoints)
        //{
        //    return FMOD_Channel_Get3DCustomRolloff(channelraw, ref points, ref numpoints);
        //}
        //public RESULT set3DOcclusion        (float directocclusion, float reverbocclusion)
        //{
        //    return FMOD_Channel_Set3DOcclusion(channelraw, directocclusion, reverbocclusion);
        //}
        //public RESULT get3DOcclusion        (ref float directocclusion, ref float reverbocclusion)
        //{
        //    return FMOD_Channel_Get3DOcclusion(channelraw, ref directocclusion, ref reverbocclusion);
        //}
        //public RESULT set3DSpread           (float angle)
        //{
        //    return FMOD_Channel_Set3DSpread(channelraw, angle);
        //}
        //public RESULT get3DSpread           (ref float angle)
        //{
        //    return FMOD_Channel_Get3DSpread(channelraw, ref angle);
        //}
        //public RESULT set3DPanLevel         (float level)
        //{
        //    return FMOD_Channel_Set3DPanLevel(channelraw, level);
        //}
        //public RESULT get3DPanLevel         (ref float level)
        //{
        //    return FMOD_Channel_Get3DPanLevel(channelraw, ref level);
        //}
        //public RESULT set3DDopplerLevel     (float level)
        //{
        //    return FMOD_Channel_Set3DDopplerLevel(channelraw, level);
        //}
        //public RESULT get3DDopplerLevel     (ref float level)
        //{
        //    return FMOD_Channel_Get3DDopplerLevel(channelraw, ref level);
        //}
        #endregion

        public float Audibility
        {
            get
            {
                float value = 0f;
                Errors.ThrowIfError(GetAudibility(DangerousGetHandle(), ref value));
                return value;
            }            
        }

        public Sound CurrentSound 
        {
            get
            {
                IntPtr result = IntPtr.Zero;
                Errors.ThrowIfError(GetCurrentSound(DangerousGetHandle(), ref result));
                return new Sound(result);
            }         
        }
        
        //public RESULT getSpectrum           (float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype)
        //{
        //    return FMOD_Channel_GetSpectrum(channelraw, spectrumarray, numvalues, channeloffset, windowtype);
        //}
        //public RESULT getWaveData           (float[] wavearray, int numvalues, int channeloffset)
        //{
        //    return FMOD_Channel_GetWaveData(channelraw, wavearray, numvalues, channeloffset);
        //}
        //public RESULT getIndex              (ref int index)
        //{
        //    return FMOD_Channel_GetIndex(channelraw, ref index);
        //}

        //public RESULT getDSPHead            (ref DSP dsp)
        //{
        //    RESULT result      = RESULT.OK;
        //    IntPtr dspraw      = new IntPtr();
        //    DSP    dspnew      = null;

        //    try
        //    {
        //        result = FMOD_Channel_GetDSPHead(channelraw, ref dspraw);
        //    }
        //    catch
        //    {
        //        result = RESULT.ERR_INVALID_PARAM;
        //    }
        //    if (result != RESULT.OK)
        //    {
        //        return result;
        //    }

        //    dspnew = new DSP();
        //    dspnew.setRaw(dspraw);
        //    dsp = dspnew;

        //    return result; 
        //}
        //public RESULT addDSP                (DSP dsp, ref DSPConnection connection)
        //{
        //    RESULT result = RESULT.OK;
        //    IntPtr dspconnectionraw = new IntPtr();
        //    DSPConnection dspconnectionnew = null;

        //    try
        //    {
        //        result = FMOD_Channel_AddDSP(channelraw, dsp.getRaw(), ref dspconnectionraw);
        //    }
        //    catch
        //    {
        //        result = RESULT.ERR_INVALID_PARAM;
        //    }
        //    if (result != RESULT.OK)
        //    {
        //        return result;
        //    }

        //    if (connection == null)
        //    {
        //        dspconnectionnew = new DSPConnection();
        //        dspconnectionnew.setRaw(dspconnectionraw);
        //        connection = dspconnectionnew;
        //    }
        //    else
        //    {
        //        connection.setRaw(dspconnectionraw);
        //    }

        //    return result;
        //}


        //public RESULT setMode               (MODE mode)
        //{
        //    return FMOD_Channel_SetMode(channelraw, mode);
        //}
        //public RESULT getMode               (ref MODE mode)
        //{
        //    return FMOD_Channel_GetMode(channelraw, ref mode);
        //}
        //public RESULT setLoopCount          (int loopcount)
        //{
        //    return FMOD_Channel_SetLoopCount(channelraw, loopcount);
        //}
        //public RESULT getLoopCount          (ref int loopcount)
        //{
        //    return FMOD_Channel_GetLoopCount(channelraw, ref loopcount);
        //}
        //public RESULT setLoopPoints         (uint loopstart, TIMEUNIT loopstarttype, uint loopend, TIMEUNIT loopendtype)
        //{
        //    return FMOD_Channel_SetLoopPoints(channelraw, loopstart, loopstarttype, loopend, loopendtype);
        //}
        //public RESULT getLoopPoints         (ref uint loopstart, TIMEUNIT loopstarttype, ref uint loopend, TIMEUNIT loopendtype)
        //{
        //    return FMOD_Channel_GetLoopPoints(channelraw, ref loopstart, loopstarttype, ref loopend, loopendtype);
        //}


        //public RESULT setUserData           (IntPtr userdata)
        //{
        //    return FMOD_Channel_SetUserData(channelraw, userdata);
        //}
        //public RESULT getUserData           (ref IntPtr userdata)
        //{
        //    return FMOD_Channel_GetUserData(channelraw, ref userdata);
        //}

        //public RESULT getMemoryInfo(uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details)
        //{
        //    return FMOD_Channel_GetMemoryInfo(channelraw, memorybits, event_memorybits, ref memoryused, ref memoryused_details);
        //}
        #endregion

        #region ISpectrumWave
        public float[] GetSpectrum(int numvalues, int channeloffset, FFTWindow windowtype)
        {
            var result = new float[numvalues];
            GetSpectrum(result, numvalues, channeloffset, windowtype);
            return result;
        }

        public void GetSpectrum(float[] spectrumarray, int numvalues, int channeloffset, FFTWindow windowtype)
        {
            GetSpectrum(DangerousGetHandle(), spectrumarray, numvalues, channeloffset, windowtype);
        }

        public float[] GetWaveData(int numvalues, int channeloffset)
        {
            var result = new float[numvalues];
            GetWaveData(result, numvalues, channeloffset);
            return result;
        }

        public void GetWaveData(float[] wavearray, int numvalues, int channeloffset)
        {
            GetWaveData(DangerousGetHandle(), wavearray, numvalues, channeloffset);
        }
        #endregion

        public bool IsPlaying
        {
            get
            {
                bool result = false;
                Errors.ThrowIfError(IsChannelPlaying(DangerousGetHandle(), ref result));
                return result;
            }
        }

        public bool IsVirtual
        {
            get
            {
                int result = 0;
                Errors.ThrowIfError(IsChannelVirtual(DangerousGetHandle(), ref result));
                return result > 0;
            }
        }

        protected override bool ReleaseHandle()
        {
            if (IsInvalid)
                return true;

            Stop(handle);
            //Release (this.handle); //TODO find if Channel need to be released before closing.
            SetHandleAsInvalid();
            return true;
        }

        public void Stop()
        {
            Errors.ThrowIfError(Stop(DangerousGetHandle()));
        }
    }
}
