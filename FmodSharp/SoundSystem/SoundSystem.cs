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

namespace Xpod.FmodSharp.SoundSystem
{
	public partial class SoundSystem : Handle, iSpectrumWave
	{
		/// <summary>
		/// Used to check against <see cref="FmodSharp.System.Version"/> FMOD::System::getVersion.
		/// </summary>
		public const uint Fmod_Version = 0x43202;

		#region Create/Release

		public SoundSystem () : base()
		{
			IntPtr SoundSystemHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = Create (ref SoundSystemHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			this.SetHandle (SoundSystemHandle);
			
			if (this.Version < Fmod_Version) {
				Release (this.handle);
				this.SetHandleAsInvalid ();
				throw new NotSupportedException ("The current version of Fmod isnt supported.");
			}
		}

		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			CloseSystem (this.handle);
			Release (this.handle);
			this.SetHandleAsInvalid ();
			
			return true;
		}
		
		public void Init ()
		{
			Init (32, InitFlags.Normal | InitFlags.RightHanded3D);
		}

		public void Init (int Maxchannels, InitFlags Flags)
		{
			Init (Maxchannels, Flags, IntPtr.Zero);
		}

		public void Init (int Maxchannels, InitFlags Flags, IntPtr Extradriverdata)
		{
			Error.Code ReturnCode = Init (this.handle, Maxchannels, Flags, Extradriverdata);
			Error.Errors.ThrowError (ReturnCode);
		}

		public void CloseSystem ()
		{
			CloseSystem (this.DangerousGetHandle ());
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Create")]
		private static extern Error.Code Create (ref IntPtr system);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Release")]
		private static extern Error.Code Release (IntPtr system);
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Init")]
		private static extern Error.Code Init (IntPtr system, int Maxchannels, InitFlags Flags, IntPtr Extradriverdata);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Close")]
		private static extern Error.Code CloseSystem (IntPtr system);

		#endregion
		
		#region Events
		
		//TODO Implement SoundSystem Events.
		
		public delegate void SystemDelegate (SoundSystem Sys);
		
		/// <summary>
		/// Called when the enumerated list of devices has changed.
		/// </summary>
		public event SystemDelegate DeviceListChanged;

		/// <summary>
		/// Called from System::update when an output device has been lost
		/// due to control panel parameter changes and FMOD cannot automatically recover.
		/// </summary>
		public event SystemDelegate DeviceLost;

		/// <summary>
		/// Called directly when a memory allocation fails somewhere in FMOD.
		/// </summary>
		public event SystemDelegate MemoryAllocationFailed;

		/// <summary>
		/// Called directly when a thread is created.
		/// </summary>
		public event SystemDelegate ThreadCreated;

		/// <summary>
		/// Called when a bad connection was made with DSP::addInput.
		/// Usually called from mixer thread because that is where the connections are made.
		/// </summary>
		public event SystemDelegate BadDspConnection;

		/// <summary>
		/// Called when too many effects were added exceeding the maximum tree depth of 128.
		/// This is most likely caused by accidentally adding too many DSP effects.
		/// Usually called from mixer thread because that is where the connections are made.
		/// </summary>
		public event SystemDelegate BadDspLevel;
		
		private Error.Code HandleCallback (IntPtr systemraw, CallbackType type, IntPtr commanddata1, IntPtr commanddata2)
		{
			return Error.Code.OK;
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetCallback")]
		private static extern Error.Code FMOD_System_SetCallback (IntPtr system, SystemDelegate callback);
		
		#endregion
		
		#region Network
		
		public string NetworkProxy
		{
			get {
				System.Text.StringBuilder str = new System.Text.StringBuilder(255);
				
				Error.Code ReturnCode = GetNetworkProxy (this.DangerousGetHandle (), str, str.Capacity);
				Error.Errors.ThrowError (ReturnCode);
				
				return str.ToString();
			}
			set {
				Error.Code ReturnCode = SetNetworkProxy (this.DangerousGetHandle (), value);
				Error.Errors.ThrowError (ReturnCode);
			}
		}
		
		public int NetworkTimeout
		{
			get {
				int time = 0;
				
				Error.Code ReturnCode = GetNetworkTimeout (this.DangerousGetHandle (), ref time);
				Error.Errors.ThrowError (ReturnCode);
				
				return time;
			}
			set {
				Error.Code ReturnCode = SetNetworkTimeout (this.DangerousGetHandle (), value);
				Error.Errors.ThrowError (ReturnCode);
			}
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetNetworkProxy")]
		private static extern Error.Code SetNetworkProxy (IntPtr system, string proxy);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNetworkProxy")]
		private static extern Error.Code GetNetworkProxy (IntPtr system, System.Text.StringBuilder proxy, int proxylen);
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetNetworkTimeout")]
		private static extern Error.Code SetNetworkTimeout (IntPtr system, int timeout);
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNetworkTimeout")]
		private static extern Error.Code GetNetworkTimeout (IntPtr system, ref int timeout);
		
		#endregion
		
		#region Others

		public uint Version {
			get {
				uint Ver = 0;
				
				Error.Code ReturnCode = GetVersion (this.DangerousGetHandle (), ref Ver);
				Error.Errors.ThrowError (ReturnCode);
				
				return Ver;
			}
		}

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetVersion")]
		private static extern Error.Code GetVersion (IntPtr system, ref uint version);
		
		#endregion
		
		#region Output

		public OutputType Output {
			get {
				OutputType output = OutputType.Unknown;
				
				Error.Code ReturnCode = GetOutput (this.DangerousGetHandle (), ref output);
				Error.Errors.ThrowError (ReturnCode);
				
				return output;
			}
			set {
				Error.Code ReturnCode = SetOutput (this.DangerousGetHandle (), value);
				Error.Errors.ThrowError (ReturnCode);
			}
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetOutput")]
		private static extern Error.Code SetOutput (IntPtr system, OutputType output);
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetOutput")]
		private static extern Error.Code GetOutput (IntPtr system, ref OutputType output);
		
		#region Channels
		
		public bool IsPlaying {
			get {
				return this.ChannelsPlaying <= 0;
			}
		}
		
		public int ChannelsPlaying {
			get {
				int playing = 0;
				
				Error.Code ReturnCode = GetChannelsPlaying(this.DangerousGetHandle(), ref playing);
				Error.Errors.ThrowError(ReturnCode);
				
				return playing;
			}
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetChannelsPlaying")]
		private static extern Error.Code GetChannelsPlaying (IntPtr system, ref int channels);
		
		#endregion
		
		#region Group
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateChannelGroup")]
		private static extern Error.Code CreateChannelGroup (IntPtr system, string name, ref IntPtr channelgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateSoundGroup")]
		private static extern Error.Code CreateSoundGroup (IntPtr system, string name, ref IntPtr soundgroup);

		#endregion
		
		#region Sound

		public Sound.Sound CreateSound (string path, Mode mode)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateSound (this.DangerousGetHandle (), path, mode, 0, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		public Sound.Sound CreateSound (string path, Mode mode, Sound.Info exinfo)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateSound (this.DangerousGetHandle (), path, mode, ref exinfo, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		public Sound.Sound CreateSound (byte[] data, Mode mode)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateSound (this.DangerousGetHandle (), data, mode, 0, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		public Sound.Sound CreateSound (byte[] data, Mode mode, Sound.Info exinfo)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateSound (this.DangerousGetHandle (), data, mode, ref exinfo, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}
		
		public Channel.Channel PlaySound (Sound.Sound snd)
		{
			return PlaySound (snd, false);
		}

		public Channel.Channel PlaySound (Sound.Sound snd, bool paused)
		{
			IntPtr ChannelHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = PlaySound (this.DangerousGetHandle (), Channel.Index.Free, snd.DangerousGetHandle (), paused, ref ChannelHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Channel.Channel (ChannelHandle);
		}

		private void PlaySound (Sound.Sound snd, bool paused, Channel.Channel chn)
		{
			//FIXME The handle is changed most of the time on some system.
			//Only use the other metods to be safe.
			
			IntPtr channel = chn.DangerousGetHandle ();
			
			Error.Code ReturnCode = PlaySound (this.DangerousGetHandle (), Channel.Index.Reuse, snd.DangerousGetHandle (), paused, ref channel);
			Error.Errors.ThrowError (ReturnCode);
			
			//This can't really happend.
			//Check just in case...
			if(chn.DangerousGetHandle () == channel)
				throw new Exception("Channel handle got changed by Fmod.");
		}

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, string name, Mode mode, ref Sound.Info exinfo, ref IntPtr Sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, string name, Mode mode, int exinfo, ref IntPtr sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, byte[] data, Mode mode, ref Sound.Info exinfo, ref IntPtr sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, byte[] data, Mode mode, int exinfo, ref IntPtr sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_PlaySound")]
		private static extern Error.Code PlaySound (IntPtr system, Channel.Index channelid, IntPtr Sound, bool paused, ref IntPtr channel);
		
		#endregion

		#region Stream
		
		public Sound.Sound CreateStream (string path, Mode mode)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateStream (this.DangerousGetHandle (), path, mode, 0, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		public Sound.Sound CreateStream (string path, Mode mode, Sound.Info exinfo)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateStream (this.DangerousGetHandle (), path, mode, ref exinfo, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		public Sound.Sound CreateStream (byte[] data, Mode mode)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateStream (this.DangerousGetHandle (), data, mode, 0, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		public Sound.Sound CreateStream (byte[] data, Mode mode, Sound.Info exinfo)
		{
			IntPtr SoundHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateStream (this.DangerousGetHandle (), data, mode, ref exinfo, ref SoundHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Sound.Sound (SoundHandle);
		}

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, string name, Mode mode, ref Sound.Info exinfo, ref IntPtr Sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, string name, Mode mode, int exinfo, ref IntPtr sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, byte[] data, Mode mode, ref Sound.Info exinfo, ref IntPtr sound);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, byte[] data, Mode mode, int exinfo, ref IntPtr sound);

		#endregion
		
		#endregion
		
		#region Recording
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordPosition")]
		private static extern Error.Code GetRecordPosition (IntPtr system, int id, ref uint position);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_RecordStart")]
		private static extern Error.Code RecordStart (IntPtr system, int id, IntPtr sound, int loop);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_RecordStop")]
		private static extern Error.Code RecordStop (IntPtr system, int id);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_IsRecording")]
		private static extern Error.Code IsRecording (IntPtr system, int id, ref int recording);

		#endregion
		
		#region Spectrum/Wave
		
		public float[] GetSpectrum (int numvalues, int channeloffset, Dsp.FFTWindow windowtype)
		{
			float[] SpectrumArray = new float[numvalues];
			this.GetSpectrum (SpectrumArray, numvalues, channeloffset, windowtype);
			return SpectrumArray;
		}
		
		public void GetSpectrum (float[] spectrumarray, int numvalues, int channeloffset, Dsp.FFTWindow windowtype)
		{
			GetSpectrum(this.DangerousGetHandle(), spectrumarray, numvalues, channeloffset, windowtype);
		}
		
		public float[] GetWaveData (int numvalues, int channeloffset)
		{
			float[] WaveArray = new float[numvalues];
			this.GetWaveData (WaveArray, numvalues, channeloffset);
			return WaveArray;
		}
		
		public void GetWaveData (float[] wavearray, int numvalues, int channeloffset)
		{
			GetWaveData(this.DangerousGetHandle(), wavearray, numvalues, channeloffset);
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSpectrum")]
		private static extern Error.Code GetSpectrum (IntPtr system, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, Dsp.FFTWindow windowtype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetWaveData")]
		private static extern Error.Code GetWaveData (IntPtr system, [MarshalAs(UnmanagedType.LPArray)] float[] wavearray, int numvalues, int channeloffset);
		
		#endregion
		
		#region Update

		public void Update ()
		{
			Update (this.DangerousGetHandle ());
		}

		public void UpdateFinished ()
		{
			UpdateFinished (this.DangerousGetHandle ());
		}

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Update")]
		private static extern Error.Code Update (IntPtr system);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_UpdateFinished")]
		private static extern Error.Code UpdateFinished (IntPtr system);

		#endregion
		
		//TODO Implement extern funcitons
		
		/*
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDSPHead")]
		private static extern Error.Code GetDSPHead (IntPtr system, ref IntPtr dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetHardwareChannels")]
		private static extern Error.Code SetHardwareChannels (IntPtr system, int min2d, int max2d, int min3d, int max3d);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetHardwareChannels")]
		private static extern Error.Code GetHardwareChannels (IntPtr system, ref int num2d, ref int num3d, ref int total);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSoftwareChannels")]
		private static extern Error.Code SetSoftwareChannels (IntPtr system, int numsoftwarechannels);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoftwareChannels")]
		private static extern Error.Code GetSoftwareChannels (IntPtr system, ref int numsoftwarechannels);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSoftwareFormat")]
		private static extern Error.Code SetSoftwareFormat (IntPtr system, int samplerate, Sound.Format format, int numoutputchannels, int maxinputchannels, Dsp.Resampler resamplemethod);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoftwareFormat")]
		private static extern Error.Code GetSoftwareFormat (IntPtr system, ref int samplerate, ref Sound.Format format, ref int numoutputchannels, ref int maxinputchannels, ref Dsp.Resampler resamplemethod, ref int bits);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetDSPBufferSize")]
		private static extern Error.Code SetDSPBufferSize (IntPtr system, uint bufferlength, int numbuffers);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDSPBufferSize")]
		private static extern Error.Code GetDSPBufferSize (IntPtr system, ref uint bufferlength, ref int numbuffers);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetFileSystem")]
		private static extern Error.Code SetFileSystem (IntPtr system, File_OpenDelegate useropen, File_CloseDelegate userclose, File_ReadDelegate userread, File_SeekDelegate userseek, File_AsyncReadDelegate userasyncread, File_AsyncCancelDelegate userasynccancel, int blockalign);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_AttachFileSystem")]
		private static extern Error.Code AttachFileSystem (IntPtr system, File_OpenDelegate useropen, File_CloseDelegate userclose, File_ReadDelegate userread, File_SeekDelegate userseek);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetPluginPath")]
		private static extern Error.Code SetPluginPath (IntPtr system, string path);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_LoadPlugin")]
		private static extern Error.Code LoadPlugin (IntPtr system, string filename, ref uint handle, uint priority);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_UnloadPlugin")]
		private static extern Error.Code UnloadPlugin (IntPtr system, uint handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumPlugins")]
		private static extern Error.Code GetNumPlugins (IntPtr system, Plugin.Type plugintype, ref int numplugins);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetPluginHandle")]
		private static extern Error.Code GetPluginHandle (IntPtr system, Plugin.Type plugintype, int index, ref uint handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetPluginInfo")]
		private static extern Error.Code GetPluginInfo (IntPtr system, uint handle, ref PLUGINTYPE plugintype, StringBuilder name, int namelen, ref uint version);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateDSPByPlugin")]
		private static extern Error.Code CreateDSPByPlugin (IntPtr system, uint handle, ref IntPtr dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateCodec")]
		private static extern Error.Code CreateCodec (IntPtr system, IntPtr description, uint priority);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetOutputByPlugin")]
		private static extern Error.Code SetOutputByPlugin (IntPtr system, uint handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetOutputByPlugin")]
		private static extern Error.Code GetOutputByPlugin (IntPtr system, ref uint handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetAdvancedSettings")]
		private static extern Error.Code SetAdvancedSettings (IntPtr system, ref ADVANCEDSETTINGS settings);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetAdvancedSettings")]
		private static extern Error.Code GetAdvancedSettings (IntPtr system, ref ADVANCEDSETTINGS settings);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSpeakerMode")]
		private static extern Error.Code SetSpeakerMode (IntPtr system, SpeakerMode speakermode);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSpeakerMode")]
		private static extern Error.Code GetSpeakerMode (IntPtr system, ref SpeakerMode speakermode);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DRolloffCallback")]
		private static extern Error.Code Set3DRolloffCallback (IntPtr system, CB_3D_RollOffDelegate callback);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DSpeakerPosition")]
		private static extern Error.Code Set3DSpeakerPosition (IntPtr system, Speaker speaker, float x, float y, int active);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DSpeakerPosition")]
		private static extern Error.Code Get3DSpeakerPosition (IntPtr system, Speaker speaker, ref float x, ref float y, ref int active);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DSettings")]
		private static extern Error.Code Set3DSettings (IntPtr system, float dopplerscale, float distancefactor, float rolloffscale);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DSettings")]
		private static extern Error.Code Get3DSettings (IntPtr system, ref float dopplerscale, ref float distancefactor, ref float rolloffscale);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DNumListeners")]
		private static extern Error.Code Set3DNumListeners (IntPtr system, int numlisteners);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DNumListeners")]
		private static extern Error.Code Get3DNumListeners (IntPtr system, ref int numlisteners);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DListenerAttributes")]
		private static extern Error.Code Set3DListenerAttributes (IntPtr system, int listener, ref Vector3 pos, ref Vector3 vel, ref Vector3 forward, ref Vector3 up);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DListenerAttributes")]
		private static extern Error.Code Get3DListenerAttributes (IntPtr system, int listener, ref Vector3 pos, ref Vector3 vel, ref Vector3 forward, ref Vector3 up);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetFileBufferSize")]
		private static extern Error.Code SetFileBufferSize (IntPtr system, int sizebytes);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetFileBufferSize")]
		private static extern Error.Code GetFileBufferSize (IntPtr system, ref int sizebytes);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetStreamBufferSize")]
		private static extern Error.Code SetStreamBufferSize (IntPtr system, uint filebuffersize, TimeUnit filebuffersizetype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetStreamBufferSize")]
		private static extern Error.Code GetStreamBufferSize (IntPtr system, ref uint filebuffersize, ref TimeUnit filebuffersizetype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetOutputHandle")]
		private static extern Error.Code GetOutputHandle (IntPtr system, ref IntPtr handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetCPUUsage")]
		private static extern Error.Code GetCPUUsage (IntPtr system, ref float dsp, ref float stream, ref float geometry, ref float update, ref float total);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoundRAM")]
		private static extern Error.Code GetSoundRAM (IntPtr system, ref int currentalloced, ref int maxalloced, ref int total);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumCDROMDrives")]
		private static extern Error.Code GetNumCDROMDrives (IntPtr system, ref int numdrives);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetCDROMDriveName")]
		private static extern Error.Code GetCDROMDriveName (IntPtr system, int drive, StringBuilder drivename, int drivenamelen, StringBuilder scsiname, int scsinamelen, StringBuilder devicename, int devicenamelen);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetChannel")]
		private static extern Error.Code GetChannel (IntPtr system, int channelid, ref IntPtr channel);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetMasterChannelGroup")]
		private static extern Error.Code GetMasterChannelGroup (IntPtr system, ref IntPtr channelgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetMasterSoundGroup")]
		private static extern Error.Code GetMasterSoundGroup (IntPtr system, ref IntPtr soundgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateGeometry")]
		private static extern Error.Code CreateGeometry (IntPtr system, int maxpolygons, int maxvertices, ref IntPtr geometry);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetGeometrySettings")]
		private static extern Error.Code SetGeometrySettings (IntPtr system, float maxworldsize);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetGeometrySettings")]
		private static extern Error.Code GetGeometrySettings (IntPtr system, ref float maxworldsize);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_LoadGeometry")]
		private static extern Error.Code LoadGeometry (IntPtr system, IntPtr data, int datasize, ref IntPtr geometry);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetGeometryOcclusion")]
		private static extern Error.Code GetGeometryOcclusion (IntPtr system, ref Vector3 listener, ref Vector3 source, ref float direct, ref float reverb);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetUserData")]
		private static extern Error.Code SetUserData (IntPtr system, IntPtr userdata);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetUserData")]
		private static extern Error.Code GetUserData (IntPtr system, ref IntPtr userdata);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetMemoryInfo")]
		private static extern Error.Code GetMemoryInfo (IntPtr system, uint memorybits, uint event_memorybits, ref uint memoryused, ref Memory.UsageDetails memoryused_details);

		
		 //Old Methods
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetHardwareChannels")]
		public static extern Error.Code SetHardwareChannels (IntPtr system, int Min2d, int Max2d, int Min3d, int Max3d);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetSoftwareChannels")]
		public static extern Error.Code SetSoftwareChannels (IntPtr system, int Numsoftwarechannels);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSoftwareChannels")]
		public static extern Error.Code GetSoftwareChannels (IntPtr system, ref int Numsoftwarechannels);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetSoftwareFormat")]
		public static extern Error.Code SetSoftwareFormat (IntPtr system, int Samplerate, Sound.Format format, int Numoutputchannels, int Maxinputchannels, Dsp.Resampler Resamplemethod);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSoftwareFormat")]
		public static extern Error.Code GetSoftwareFormat (IntPtr system, ref int Samplerate, ref Sound.Format format, ref int Numoutputchannels, ref int Maxinputchannels, ref Dsp.Resampler Resamplemethod, ref int Bits);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetDSPBufferSize")]
		public static extern Error.Code SetDSPBufferSize (IntPtr system, int Bufferlength, int Numbuffers);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetDSPBufferSize")]
		public static extern Error.Code GetDSPBufferSize (IntPtr system, ref int Bufferlength, ref int Numbuffers);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetFileSystem")]
		public static extern Error.Code SetFileSystem (IntPtr system, int useropen, int userclose, int userread, int userseek, int Buffersize);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_AttachFileSystem")]
		public static extern Error.Code AttachFileSystem (IntPtr system, int useropen, int userclose, int userread, int userseek);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetAdvancedSettings")]
		public static extern Error.Code SetAdvancedSettings (IntPtr system, ref FMOD_ADVANCEDSETTINGS settings);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetAdvancedSettings")]
		public static extern Error.Code GetAdvancedSettings (IntPtr system, ref FMOD_ADVANCEDSETTINGS settings);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetSpeakerMode")]
		public static extern Error.Code SetSpeakerMode (IntPtr system, SpeakerMode Speakermode);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSpeakerMode")]
		public static extern Error.Code GetSpeakerMode (IntPtr system, ref SpeakerMode Speakermode);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetPluginPath")]
		public static extern Error.Code SetPluginPath (IntPtr system, string Path);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_LoadPlugin")]
		public static extern Error.Code LoadPlugin (IntPtr system, string Filename, ref int Handle, int Priority);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_UnloadPlugin")]
		public static extern Error.Code UnloadPlugin (IntPtr system, int Handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetNumPlugins")]
		public static extern Error.Code GetNumPlugins (IntPtr system, Plugin.Type Plugintype, ref int Numplugins);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetPluginHandle")]
		public static extern Error.Code GetPluginHandle (IntPtr system, Plugin.Type Plugintype, int Index, ref int Handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetPluginInfo")]
		public static extern Error.Code GetPluginInfo (IntPtr system, int Handle, ref Plugin.Type Plugintype, ref byte name, int namelen, ref int version);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetOutputByPlugin")]
		public static extern Error.Code SetOutputByPlugin (IntPtr system, int Handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetOutputByPlugin")]
		public static extern Error.Code GetOutputByPlugin (IntPtr system, ref int Handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSPByPlugin")]
		public static extern Error.Code CreateDSPByPlugin (IntPtr system, int Handle, ref int Dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateCodec")]
		public static extern Error.Code CreateCodec (IntPtr system, int CodecDescription);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DSettings")]
		public static extern Error.Code Set3DSettings (IntPtr system, float Dopplerscale, float Distancefactor, float Rolloffscale);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DSettings")]
		public static extern Error.Code Get3DSettings (IntPtr system, ref float Dopplerscale, ref float Distancefactor, ref float Rolloffscale);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DNumListeners")]
		public static extern Error.Code Set3DNumListeners (IntPtr system, int Numlisteners);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DNumListeners")]
		public static extern Error.Code Get3DNumListeners (IntPtr system, ref int Numlisteners);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DListenerAttributes")]
		public static extern Error.Code Set3DListenerAttributes (IntPtr system, int Listener, ref Vector3 Pos, ref Vector3 Vel, ref Vector3 Forward, ref Vector3 Up);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DListenerAttributes")]
		public static extern Error.Code Get3DListenerAttributes (IntPtr system, int Listener, ref Vector3 Pos, ref Vector3 Vel, ref Vector3 Forward, ref Vector3 Up);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DRolloffCallback")]
		public static extern Error.Code Set3DRolloffCallback (IntPtr system, int Callback);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DSpeakerPosition")]
		public static extern Error.Code Set3DSpeakerPosition (IntPtr system, Speaker speaker, float X, float Y, int active);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DSpeakerPosition")]
		public static extern Error.Code Get3DSpeakerPosition (IntPtr system, ref Speaker speaker, ref float X, ref float Y, ref int active);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetStreamBufferSize")]
		public static extern Error.Code SetStreamBufferSize (IntPtr system, int Filebuffersize, TimeUnit Filebuffersizetype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetStreamBufferSize")]
		public static extern Error.Code GetStreamBufferSize (IntPtr system, ref int Filebuffersize, ref TimeUnit Filebuffersizetype);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetOutputHandle")]
		public static extern Error.Code GetOutputHandle (IntPtr system, ref int Handle);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetChannelsPlaying")]
		public static extern Error.Code GetChannelsPlaying (IntPtr system, ref int Channels);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetHardwareChannels")]
		public static extern Error.Code GetHardwareChannels (IntPtr system, ref int Num2d, ref int Num3d, ref int total);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetCPUUsage")]
		public static extern Error.Code GetCPUUsage (IntPtr system, ref float Dsp, ref float Stream, ref float Geometry, ref float Update, ref float total);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSoundRAM")]
		public static extern Error.Code GetSoundRAM (IntPtr system, ref int currentalloced, ref int maxalloced, ref int total);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetNumCDROMDrives")]
		public static extern Error.Code GetNumCDROMDrives (IntPtr system, ref int Numdrives);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetCDROMDriveName")]
		public static extern Error.Code GetCDROMDriveName (IntPtr system, int Drive, ref byte Drivename, int Drivenamelen, ref byte Scsiname, int Scsinamelen, ref byte Devicename, int Devicenamelen);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSP")]
		public static extern Error.Code CreateDSP (IntPtr system, ref FMOD_DSP_DESCRIPTION description, ref int Dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSPByType")]
		public static extern Error.Code CreateDSPByType (IntPtr system, Dsp.Type dsptype, ref int Dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSPByIndex")]
		public static extern Error.Code CreateDSPByIndex (IntPtr system, int Index, ref int Dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_PlayDSP")]
		public static extern Error.Code PlayDSP (IntPtr system, Channel.Index channelid, int Dsp, int paused, ref int channel);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetChannel")]
		public static extern Error.Code GetChannel (IntPtr system, int channelid, ref int channel);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetMasterChannelGroup")]
		public static extern Error.Code GetMasterChannelGroup (IntPtr system, ref int Channelgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetMasterSoundGroup")]
		public static extern Error.Code GetMasterSoundGroup (IntPtr system, ref int soundgroup);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetReverbProperties")]
		public static extern Error.Code SetReverbProperties (IntPtr system, ref Reverb.Properties Prop);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetReverbProperties")]
		public static extern Error.Code GetReverbProperties (IntPtr system, ref Reverb.Properties Prop);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetReverbAmbientProperties")]
		public static extern Error.Code SetReverbAmbientProperties (IntPtr system, ref Reverb.Properties Prop);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetReverbAmbientProperties")]
		public static extern Error.Code GetReverbAmbientProperties (IntPtr system, ref Reverb.Properties Prop);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateGeometry")]
		public static extern Error.Code CreateGeometry (IntPtr system, int MaxPolygons, int MaxVertices, ref int Geometryf);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetGeometrySettings")]
		public static extern Error.Code SetGeometrySettings (IntPtr system, float Maxworldsize);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetGeometrySettings")]
		public static extern Error.Code GetGeometrySettings (IntPtr system, ref float Maxworldsize);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_LoadGeometry")]
		public static extern Error.Code LoadGeometry (IntPtr system, int Data, int DataSize, ref int Geometry);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetUserData")]
		public static extern Error.Code SetUserData (IntPtr system, int userdata);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetUserData")]
		public static extern Error.Code GetUserData (IntPtr system, ref int userdata);
		
		*/
	}
}
