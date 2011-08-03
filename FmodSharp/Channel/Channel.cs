using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Channel
{
	public class Channel : Handle
	{
		
		#region Create/Release
		
		private Channel ()
		{
		}
		internal Channel (IntPtr hnd) : base()
		{
			this.SetHandle(hnd);
		}
		
		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			this.Stop();
			
			//TODO find if Channel need to be released before closing.
			//Release (this.handle);
			this.SetHandleAsInvalid ();
			
			return true;
		}
		
		#endregion
		
		#region Properties
		
		public bool Paused {
			get {
				bool pause = false;
				
				Error.Code ReturnCode = GetPaused(this.DangerousGetHandle(), ref pause);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
				
				return pause;
			}
			set {
				Error.Code ReturnCode = SetPaused(this.DangerousGetHandle(), value);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		public float Volume {
			get {
				float Vol = 0.0f;
				
				Error.Code ReturnCode = GetVolume(this.DangerousGetHandle(), ref Vol);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
				
				return Vol;
			}
			set {
				Error.Code ReturnCode = SetVolume(this.DangerousGetHandle(), value);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		public float Frequency {
			get {
				float Freq = 0.0f;
				
				Error.Code ReturnCode = GetFrequency(this.DangerousGetHandle(), ref Freq);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
				
				return Freq;
			}
			set {
				Error.Code ReturnCode = SetFrequency(this.DangerousGetHandle(), value);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		public float Pan {
			get {
				float pan = 0.0f;
				
				Error.Code ReturnCode = GetPan(this.DangerousGetHandle(), ref pan);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
				
				return pan;
			}
			set {
				Error.Code ReturnCode = SetPan(this.DangerousGetHandle(), value);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetPaused")]
		private static extern Error.Code SetPaused (IntPtr channel, bool paused);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetPaused")]
		private static extern Error.Code GetPaused (IntPtr channel, ref bool paused);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetVolume")]
		private static extern Error.Code SetVolume (IntPtr channel, float volume);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetVolume")]
		private static extern Error.Code GetVolume (IntPtr channel, ref float volume);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetFrequency")]
		private static extern Error.Code SetFrequency (IntPtr channel, float frequency);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetFrequency")]
		private static extern Error.Code GetFrequency (IntPtr channel, ref float frequency);
	
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetPan")]
		private static extern Error.Code SetPan (IntPtr channel, float pan);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetPan")]
		private static extern Error.Code GetPan (IntPtr channel, ref float pan);
		
		#endregion
		
		#region PlayPauseStop	
		
		public bool IsPlaying {
			get {
				bool playing = false;
				
				Error.Code ReturnCode = IsPlaying_extern(this.DangerousGetHandle(), ref playing);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
				
				return playing;
			}
		}
		
		public void Stop()
		{
			Error.Code ReturnCode = Stop(this.DangerousGetHandle());
			if(ReturnCode != Error.Code.OK)
				Error.Errors.ThrowError(ReturnCode);
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Stop")]
		private static extern Error.Code Stop (IntPtr channel);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_IsPlaying")]
		private static extern Error.Code IsPlaying_extern (IntPtr channel, ref bool isplaying);

		#endregion
			
		
		//TODO Implement extern funcitons
		
		/*
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetSystemObject")]
		private static extern Error.Code GetSystemObject (IntPtr channel, ref IntPtr system);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetDelay")]
		private static extern Error.Code SetDelay (IntPtr channel, DELAYTYPE delaytype, uint delayhi, uint delaylo);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetDelay")]
		private static extern Error.Code GetDelay (IntPtr channel, DELAYTYPE delaytype, ref uint delayhi, ref uint delaylo);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetSpeakerMix")]
		private static extern Error.Code SetSpeakerMix (IntPtr channel, float frontleft, float frontright, float center, float lfe, float backleft, float backright, float sideleft, float sideright);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetSpeakerMix")]
		private static extern Error.Code GetSpeakerMix (IntPtr channel, ref float frontleft, ref float frontright, ref float center, ref float lfe, ref float backleft, ref float backright, ref float sideleft, ref float sideright);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetSpeakerLevels")]
		private static extern Error.Code SetSpeakerLevels (IntPtr channel, SPEAKER speaker, float[] levels, int numlevels);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetSpeakerLevels")]
		private static extern Error.Code GetSpeakerLevels (IntPtr channel, SPEAKER speaker, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetInputChannelMix")]
		private static extern Error.Code SetInputChannelMix (IntPtr channel, float[] levels, int numlevels);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetInputChannelMix")]
		private static extern Error.Code GetInputChannelMix (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] levels, int numlevels);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetMute")]
		private static extern Error.Code SetMute (IntPtr channel, int mute);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetMute")]
		private static extern Error.Code GetMute (IntPtr channel, ref int mute);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetPriority")]
		private static extern Error.Code SetPriority (IntPtr channel, int priority);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetPriority")]
		private static extern Error.Code GetPriority (IntPtr channel, ref int priority);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DAttributes")]
		private static extern Error.Code Set3DAttributes (IntPtr channel, ref Vector3 pos, ref Vector3 vel);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DAttributes")]
		private static extern Error.Code Get3DAttributes (IntPtr channel, ref Vector3 pos, ref Vector3 vel);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DMinMaxDistance")]
		private static extern Error.Code Set3DMinMaxDistance (IntPtr channel, float mindistance, float maxdistance);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DMinMaxDistance")]
		private static extern Error.Code Get3DMinMaxDistance (IntPtr channel, ref float mindistance, ref float maxdistance);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DConeSettings")]
		private static extern Error.Code Set3DConeSettings (IntPtr channel, float insideconeangle, float outsideconeangle, float outsidevolume);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DConeSettings")]
		private static extern Error.Code Get3DConeSettings (IntPtr channel, ref float insideconeangle, ref float outsideconeangle, ref float outsidevolume);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DConeOrientation")]
		private static extern Error.Code Set3DConeOrientation (IntPtr channel, ref Vector3 orientation);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DConeOrientation")]
		private static extern Error.Code Get3DConeOrientation (IntPtr channel, ref Vector3 orientation);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DCustomRolloff")]
		private static extern Error.Code Set3DCustomRolloff (IntPtr channel, ref Vector3 points, int numpoints);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DCustomRolloff")]
		private static extern Error.Code Get3DCustomRolloff (IntPtr channel, ref IntPtr points, ref int numpoints);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3Docclusion")]
		private static extern Error.Code Set3Docclusion (IntPtr channel, float directocclusion, float reverbocclusion);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3Docclusion")]
		private static extern Error.Code Get3Docclusion (IntPtr channel, ref float directocclusion, ref float reverbocclusion);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DOcclusion")]
		private static extern Error.Code Set3DOcclusion (IntPtr channel, float directocclusion, float reverbocclusion);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DOcclusion")]
		private static extern Error.Code Get3DOcclusion (IntPtr channel, ref float directocclusion, ref float reverbocclusion);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DSpread")]
		private static extern Error.Code Set3DSpread (IntPtr channel, float angle);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DSpread")]
		private static extern Error.Code Get3DSpread (IntPtr channel, ref float angle);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DPanLevel")]
		private static extern Error.Code Set3DPanLevel (IntPtr channel, float level);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DPanLevel")]
		private static extern Error.Code Get3DPanLevel (IntPtr channel, ref float level);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Set3DDopplerLevel")]
		private static extern Error.Code Set3DDopplerLevel (IntPtr channel, float level);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_Get3DDopplerLevel")]
		private static extern Error.Code Get3DDopplerLevel (IntPtr channel, ref float level);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetReverbProperties")]
		private static extern Error.Code SetReverbProperties (IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetReverbProperties")]
		private static extern Error.Code GetReverbProperties (IntPtr channel, ref REVERB_CHANNELPROPERTIES prop);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetLowPassGain")]
		private static extern Error.Code SetLowPassGain (IntPtr channel, float gain);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetLowPassGain")]
		private static extern Error.Code GetLowPassGain (IntPtr channel, ref float gain);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetChannelGroup")]
		private static extern Error.Code SetChannelGroup (IntPtr channel, IntPtr channelgroup);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetChannelGroup")]
		private static extern Error.Code GetChannelGroup (IntPtr channel, ref IntPtr channelgroup);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_IsVirtual")]
		private static extern Error.Code IsVirtual (IntPtr channel, ref int isvirtual);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetAudibility")]
		private static extern Error.Code GetAudibility (IntPtr channel, ref float audibility);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetCurrentSound")]
		private static extern Error.Code GetCurrentSound (IntPtr channel, ref IntPtr sound);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetSpectrum")]
		private static extern Error.Code GetSpectrum (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, DSP_FFT_WINDOW windowtype);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetWaveData")]
		private static extern Error.Code GetWaveData (IntPtr channel, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetIndex")]
		private static extern Error.Code GetIndex (IntPtr channel, ref int index);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetCallback")]
		private static extern Error.Code SetCallback (IntPtr channel, CHANNEL_CALLBACK callback);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetPosition")]
		private static extern Error.Code SetPosition (IntPtr channel, uint position, TimeUnit postype);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetPosition")]
		private static extern Error.Code GetPosition (IntPtr channel, ref uint position, TimeUnit postype);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetDSPHead")]
		private static extern Error.Code GetDSPHead (IntPtr channel, ref IntPtr dsp);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_AddDSP")]
		private static extern Error.Code AddDSP (IntPtr channel, IntPtr dsp, ref IntPtr connection);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetMode")]
		private static extern Error.Code SetMode (IntPtr channel, Mode mode);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetMode")]
		private static extern Error.Code GetMode (IntPtr channel, ref Mode mode);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetLoopCount")]
		private static extern Error.Code SetLoopCount (IntPtr channel, int loopcount);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetLoopCount")]
		private static extern Error.Code GetLoopCount (IntPtr channel, ref int loopcount);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetLoopPoints")]
		private static extern Error.Code SetLoopPoints (IntPtr channel, uint loopstart, TimeUnit loopstarttype, uint loopend, TimeUnit loopendtype);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetLoopPoints")]
		private static extern Error.Code GetLoopPoints (IntPtr channel, ref uint loopstart, TimeUnit loopstarttype, ref uint loopend, TimeUnit loopendtype);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_SetUserData")]
		private static extern Error.Code SetUserData (IntPtr channel, IntPtr userdata);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetUserData")]
		private static extern Error.Code GetUserData (IntPtr channel, ref IntPtr userdata);
		
		[DllImport("fmodex", EntryPoint = "FMOD_Channel_GetMemoryInfo")]
		private static extern Error.Code GetMemoryInfo (IntPtr channel, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		
		*/
	}
}
