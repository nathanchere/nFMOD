using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
    public class Channel : Handle, ISpectrumWave
    {
        private Channel()
        {
        }

        public delegate ErrorCode ChannelDelegate(IntPtr channelraw, ChannelCallbackType type, IntPtr commanddata1, IntPtr commanddata2);

        internal Channel(IntPtr hnd)
        {
            SetHandle(hnd);
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

        #region Properties

        public bool Paused
        {
            get
            {
                bool pause = false;
                Errors.ThrowIfError(GetPaused(DangerousGetHandle(), ref pause));
                return pause;
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
                float Vol = 0.0f;
                Errors.ThrowIfError(GetVolume(DangerousGetHandle(), ref Vol));
                return Vol;
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
                float Freq = 0.0f;
                Errors.ThrowIfError(GetFrequency(DangerousGetHandle(), ref Freq));
                return Freq;
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
                float pan = 0.0f;
                Errors.ThrowIfError(GetPan(DangerousGetHandle(), ref pan));
                return pan;
            }
            set {
				Errors.ThrowIfError(SetPan(DangerousGetHandle(), value));
			}
        }

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetPaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPaused(IntPtr channel, bool paused);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetPaused"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPaused(IntPtr channel, ref bool paused);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetVolume(IntPtr channel, float volume);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetVolume"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetVolume(IntPtr channel, ref float volume);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetFrequency"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetFrequency(IntPtr channel, float frequency);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetFrequency"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetFrequency(IntPtr channel, ref float frequency);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetPan"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPan(IntPtr channel, float pan);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetPan"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPan(IntPtr channel, ref float pan);

        #endregion

        #region PlayPauseStop

        public bool IsPlaying
        {
            get {
				bool playing = false;
				
				Errors.ThrowIfError(IsPlaying_External(DangerousGetHandle(), ref playing));
				
				return playing;
			}
        }

        public void Stop()
		{
			Errors.ThrowIfError(Stop(DangerousGetHandle()));
		}

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Stop"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Stop(IntPtr channel);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_IsPlaying"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode IsPlaying_External(IntPtr channel, ref bool isplaying);

        #endregion

        public bool Mute
        {
            get {
				bool Val = false;
				Errors.ThrowIfError(GetMute(DangerousGetHandle(), ref Val));				
				return Val;
			}

            set {
				Errors.ThrowIfError(SetMute(DangerousGetHandle(), value));
			}
        }

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetMute(IntPtr channel, bool mute);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetMute"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMute(IntPtr channel, ref bool mute);

        #region Spectrum/Wave

        public float[] GetSpectrum(int numvalues, int channeloffset, FFTWindow windowtype)
        {
            float[] SpectrumArray = new float[numvalues];
            GetSpectrum(SpectrumArray, numvalues, channeloffset, windowtype);
            return SpectrumArray;
        }

        public void GetSpectrum(float[] spectrumarray, int numvalues, int channeloffset, FFTWindow windowtype)
        {
            GetSpectrum(DangerousGetHandle(), spectrumarray, numvalues, channeloffset, windowtype);
        }

        public float[] GetWaveData(int numvalues, int channeloffset)
        {
            float[] WaveArray = new float[numvalues];
            GetWaveData(WaveArray, numvalues, channeloffset);
            return WaveArray;
        }

        public void GetWaveData(float[] wavearray, int numvalues, int channeloffset)
        {
            GetWaveData(DangerousGetHandle(), wavearray, numvalues, channeloffset);
        }

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetSpectrum"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetSpectrum(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, FFTWindow windowtype);

        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetWaveData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetWaveData(IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);

        #endregion

        //TODO Implement extern funcitons

        /*
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetSystemObject"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetSystemObject (IntPtr channel, ref IntPtr system);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetDelay"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetDelay (IntPtr channel, DELAYTYPE delaytype, uint delayhi, uint delaylo);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetDelay"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetDelay (IntPtr channel, DELAYTYPE delaytype, ref uint delayhi, ref uint delaylo);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetSpeakerMix"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetSpeakerMix (IntPtr channel, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetSpeakerMix"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetSpeakerMix (IntPtr channel, ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetSpeakerLevels"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetSpeakerLevels (IntPtr channel, SPEAKER speaker, float[] levels, int numlevels);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetSpeakerLevels"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetSpeakerLevels (IntPtr channel, SPEAKER speaker, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetInputChannelMix"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetInputChannelMix (IntPtr channel, float[] levels, int numlevels);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetInputChannelMix"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetInputChannelMix (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetPriority"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetPriority (IntPtr channel, int priority);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetPriority"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetPriority (IntPtr channel, ref int priority);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DAttributes (IntPtr channel, ref Vector3 pos, ref Vector3 vel);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DAttributes (IntPtr channel, ref Vector3 pos, ref Vector3 vel);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DMinMaxDistance (IntPtr channel, float mindistance, float maxdistance);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DMinMaxDistance"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DMinMaxDistance (IntPtr channel, ref float mindistance, ref float maxdistance);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DConeSettings"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DConeSettings (IntPtr channel, float insideconeangle, float outsideconeangle, float outsidevolume);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DConeSettings"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DConeSettings (IntPtr channel, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DConeOrientation"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DConeOrientation (IntPtr channel, ref Vector3 orientation);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DConeOrientation"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DConeOrientation (IntPtr channel, ref Vector3 orientation);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DCustomRolloff (IntPtr channel, ref Vector3 points, int numpoints);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DCustomRolloff"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DCustomRolloff (IntPtr channel, ref IntPtr points, ref int numpoints);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3Docclusion"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3Docclusion (IntPtr channel, float directocclusion, float reverbocclusion);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3Docclusion"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3Docclusion (IntPtr channel, ref float directocclusion, ref float reverbocclusion);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DOcclusion"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DOcclusion (IntPtr channel, float directocclusion, float reverbocclusion);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DOcclusion"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DOcclusion (IntPtr channel, ref float directocclusion, ref float reverbocclusion);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DSpread"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DSpread (IntPtr channel, float angle);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DSpread"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DSpread (IntPtr channel, ref float angle);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DPanLevel"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DPanLevel (IntPtr channel, float level);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DPanLevel"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DPanLevel (IntPtr channel, ref float level);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Set3DDopplerLevel"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Set3DDopplerLevel (IntPtr channel, float level);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_Get3DDopplerLevel"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code Get3DDopplerLevel (IntPtr channel, ref float level);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetReverbProperties"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetReverbProperties (IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetReverbProperties"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetReverbProperties (IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetLowPassGain"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetLowPassGain (IntPtr channel, float gain);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetLowPassGain"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetLowPassGain (IntPtr channel, ref float gain);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetChannelGroup"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetChannelGroup (IntPtr channel, IntPtr channelgroup);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetChannelGroup"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetChannelGroup (IntPtr channel, ref IntPtr channelgroup);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_IsVirtual"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code IsVirtual (IntPtr channel, ref int isvirtual);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetAudibility"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetAudibility (IntPtr channel, ref float audibility);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetCurrentSound"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetCurrentSound (IntPtr channel, ref IntPtr sound);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetIndex"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetIndex (IntPtr channel, ref int index);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetCallback"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetCallback (IntPtr channel, CHANNEL_CALLBACK callback);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetPosition (IntPtr channel, uint position, TimeUnit postype);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetPosition (IntPtr channel, ref uint position, TimeUnit postype);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetDSPHead"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetDSPHead (IntPtr channel, ref IntPtr dsp);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_AddDSP"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code AddDSP (IntPtr channel, IntPtr dsp, ref IntPtr connection);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetMode"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetMode (IntPtr channel, Mode mode);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetMode"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetMode (IntPtr channel, ref Mode mode);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetLoopCount"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetLoopCount (IntPtr channel, int loopcount);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetLoopCount"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetLoopCount (IntPtr channel, ref int loopcount);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetLoopPoints"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetLoopPoints (IntPtr channel, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetLoopPoints"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetLoopPoints (IntPtr channel, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_SetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code SetUserData (IntPtr channel, IntPtr userdata);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetUserData (IntPtr channel, ref IntPtr userdata);
		
        [DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Channel_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        private static extern Error.Code GetMemoryInfo (IntPtr channel, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		
        */
    }
}
