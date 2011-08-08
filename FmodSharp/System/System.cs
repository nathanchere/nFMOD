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

namespace FmodSharp.SoundSystem
{
	public class SoundSystem : Handle, iSpectrum, iWaveData
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
			
			this.CloseSystem();
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
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_Create")]
		private static extern Error.Code Create (ref IntPtr system);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Release")]
		private static extern Error.Code Release (IntPtr system);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_Init")]
		private static extern Error.Code Init (IntPtr system, int Maxchannels, InitFlags Flags, IntPtr Extradriverdata);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Close")]
		private static extern Error.Code CloseSystem (IntPtr system);

		#endregion
		
		#region Driver
		
		public int NumberOutputDrivers {
			get {
				int numdrivers = 0;
				
				Error.Code ReturnCode = GetNumDrivers (this.DangerousGetHandle (), ref numdrivers);
				Error.Errors.ThrowError (ReturnCode);
				
				return numdrivers;
			}
		}
		
		public void GetOutputDriverInfo(int Id, out string Name, ref Guid DriverGuid)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder(255);
			
			Error.Code ReturnCode = GetDriverInfo (this.DangerousGetHandle (), Id, str, str.Capacity, ref DriverGuid);
			Error.Errors.ThrowError (ReturnCode);
			
			Name = str.ToString();
		}
		
		public void GetOutputDriverCapabilities (int id, ref Capabilities caps, ref int minfrequency, ref int maxfrequency, ref SpeakerMode controlpanelspeakermode)
		{
			Error.Code ReturnCode = GetDriverCaps (this.DangerousGetHandle (), id, ref caps, ref minfrequency, ref maxfrequency, ref controlpanelspeakermode);
			Error.Errors.ThrowError (ReturnCode);
		}
		
		public int OutputDriver {
			get {
				int driver = 0;
				
				Error.Code ReturnCode = GetDriver (this.DangerousGetHandle (), ref driver);
				Error.Errors.ThrowError (ReturnCode);
				
				return driver;
			}
			set {
				Error.Code ReturnCode = SetDriver (this.DangerousGetHandle (), value);
				Error.Errors.ThrowError (ReturnCode);
			}
		}
		
		public int NumberRecordDrivers {
			get {
				int numdrivers = 0;
				
				Error.Code ReturnCode = GetRecordNumDrivers (this.DangerousGetHandle (), ref numdrivers);
				Error.Errors.ThrowError (ReturnCode);
				
				return numdrivers;
			}
		}
		
		public void GetRecordDriverInfo(int Id, out string Name, ref Guid DriverGuid)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder(255);
			
			Error.Code ReturnCode = GetRecordDriverInfo (this.DangerousGetHandle (), Id, str, str.Capacity, ref DriverGuid);
			Error.Errors.ThrowError (ReturnCode);
			
			Name = str.ToString();
		}
		
		public void GetRecordDriverCapabilities (int id, ref Capabilities caps, ref int minfrequency, ref int maxfrequency)
		{
			Error.Code ReturnCode = GetRecordDriverCaps (this.DangerousGetHandle (), id, ref caps, ref minfrequency, ref maxfrequency);
			Error.Errors.ThrowError (ReturnCode);
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumDrivers")]
		private static extern Error.Code GetNumDrivers (IntPtr system, ref int Numdrivers);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverInfo")]
		private static extern Error.Code GetDriverInfo (IntPtr system, int id, System.Text.StringBuilder name, int namelen, ref Guid guid);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverInfoW")]
		private static extern Error.Code GetDriverInfoW (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder name, int namelen, ref Guid guid);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverCaps")]
		private static extern Error.Code GetDriverCaps (IntPtr system, int id, ref Capabilities caps, ref int minfrequency, ref int maxfrequency, ref SpeakerMode controlpanelspeakermode);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetDriver")]
		private static extern Error.Code SetDriver (IntPtr system, int driver);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriver")]
		private static extern Error.Code GetDriver (IntPtr system, ref int driver);
		
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordNumDrivers")]
		private static extern Error.Code GetRecordNumDrivers (IntPtr system, ref int numdrivers);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordDriverInfo")]
		private static extern Error.Code GetRecordDriverInfo (IntPtr system, int id, System.Text.StringBuilder name, int namelen, ref Guid guid);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordDriverInfoW")]
		private static extern Error.Code FMOD_System_GetRecordDriverInfoW (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder name, int namelen, ref Guid guid);
	
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordDriverCaps")]
		private static extern Error.Code GetRecordDriverCaps (IntPtr system, int id, ref Capabilities caps, ref int minfrequency, ref int maxfrequency);

		#endregion
		
		#region Effects
		
		#region DSP
		
		public Dsp.Dsp CreateDSP(ref Dsp.Description description)
		{
			IntPtr DspHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateDSP (this.DangerousGetHandle (), ref description, ref DspHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Dsp.Dsp (DspHandle);
		}
		
		public Dsp.Dsp CreateDspByType(Dsp.Type type)
		{
			IntPtr DspHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateDspByType (this.DangerousGetHandle (), type, ref DspHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Dsp.Dsp (DspHandle);
		}
		
		public Channel.Channel PlayDsp (Dsp.Dsp dsp)
		{
			return PlayDsp (dsp, false);
		}

		public Channel.Channel PlayDsp (Dsp.Dsp dsp, bool paused)
		{
			IntPtr ChannelHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = PlayDsp (this.DangerousGetHandle (), Channel.Index.Free, dsp.DangerousGetHandle (), paused, ref ChannelHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Channel.Channel (ChannelHandle);
		}

		public void PlayDsp (Dsp.Dsp dsp, bool paused, Channel.Channel chn)
		{
			IntPtr channel = chn.DangerousGetHandle ();
			
			Error.Code ReturnCode = PlayDsp (this.DangerousGetHandle (), Channel.Index.Reuse, dsp.DangerousGetHandle (), paused, ref channel);
			Error.Errors.ThrowError (ReturnCode);
			
			//This can't really happend.
			//Check just in case...
			if(chn.DangerousGetHandle () != channel)
				throw new Exception("Channel handle got changed by Fmod.");
		}

		[DllImport ("fmodex", EntryPoint = "FMOD_System_CreateDSP")]
		private static extern Error.Code CreateDSP (IntPtr system, ref Dsp.Description description, ref IntPtr dsp);

		[DllImport ("fmodex", EntryPoint = "FMOD_System_CreateDSPByType")]
		private static extern Error.Code CreateDspByType (IntPtr system, Dsp.Type type, ref IntPtr dsp);

		[DllImport("fmodex", EntryPoint = "FMOD_System_PlayDSP")]
		private static extern Error.Code PlayDsp (IntPtr system, Channel.Index channelid, IntPtr dsp, bool paused, ref IntPtr channel);

		#endregion
		
		#region Reverb
		
		public Reverb.Reverb CreateReverb ()
		{
			IntPtr ReverbHandle = IntPtr.Zero;
			
			Error.Code ReturnCode = CreateReverb (this.DangerousGetHandle (), ref ReverbHandle);
			Error.Errors.ThrowError (ReturnCode);
			
			return new Reverb.Reverb (ReverbHandle);
		}
		
		public Reverb.Properties ReverbProperties {
			get {
				Reverb.Properties Val = Reverb.Properties.Generic;
				Error.Code ReturnCode = GetReverbProperties(this.DangerousGetHandle(), ref Val);
				Error.Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				Error.Code ReturnCode = SetReverbProperties(this.DangerousGetHandle(), ref value);
				Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		public Reverb.Properties ReverbAmbientProperties {
			get {
				Reverb.Properties Val = Reverb.Properties.Generic;
				
				Error.Code ReturnCode = GetReverbAmbientProperties(this.DangerousGetHandle(), ref Val);
				Error.Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				Error.Code ReturnCode = SetReverbAmbientProperties(this.DangerousGetHandle(), ref value);
				Error.Errors.ThrowError(ReturnCode);
			}
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateReverb")]
		private static extern Error.Code CreateReverb (IntPtr system, ref IntPtr reverb);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetReverbProperties")]
		private static extern Error.Code SetReverbProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetReverbProperties")]
		private static extern Error.Code GetReverbProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetReverbAmbientProperties")]
		private static extern Error.Code SetReverbAmbientProperties (IntPtr system, ref Reverb.Properties prop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetReverbAmbientProperties")]
		private static extern Error.Code GetReverbAmbientProperties (IntPtr system, ref Reverb.Properties prop);
		
		#endregion
		
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
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetNetworkProxy")]
		private static extern Error.Code SetNetworkProxy (IntPtr system, string proxy);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNetworkProxy")]
		private static extern Error.Code GetNetworkProxy (IntPtr system, System.Text.StringBuilder proxy, int proxylen);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetNetworkTimeout")]
		private static extern Error.Code SetNetworkTimeout (IntPtr system, int timeout);
		
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
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetOutput")]
		private static extern Error.Code SetOutput (IntPtr system, OutputType output);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetOutput")]
		private static extern Error.Code GetOutput (IntPtr system, ref OutputType output);
		
		#region Group
		
		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateChannelGroup")]
		private static extern Error.Code CreateChannelGroup (IntPtr system, string name, ref IntPtr channelgroup);

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

		public void PlaySound (Sound.Sound snd, bool paused, Channel.Channel chn)
		{
			IntPtr channel = chn.DangerousGetHandle ();
			
			Error.Code ReturnCode = PlaySound (this.DangerousGetHandle (), Channel.Index.Reuse, snd.DangerousGetHandle (), paused, ref channel);
			Error.Errors.ThrowError (ReturnCode);
			
			//This can't really happend.
			//Check just in case...
			if(chn.DangerousGetHandle () == channel)
				throw new Exception("Channel handle got changed by Fmod.");
		}

		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, string name, Mode mode, ref Sound.Info exinfo, ref IntPtr Sound);

		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, string name, Mode mode, int exinfo, ref IntPtr sound);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, byte[] data, Mode mode, ref Sound.Info exinfo, ref IntPtr sound);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateSound")]
		private static extern Error.Code CreateSound (IntPtr system, byte[] data, Mode mode, int exinfo, ref IntPtr sound);

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

		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, string name, Mode mode, ref Sound.Info exinfo, ref IntPtr Sound);

		[DllImport("fmodex", CharSet = CharSet.Ansi, EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, string name, Mode mode, int exinfo, ref IntPtr sound);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, byte[] data, Mode mode, ref Sound.Info exinfo, ref IntPtr sound);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateStream")]
		private static extern Error.Code CreateStream (IntPtr system, byte[] data, Mode mode, int exinfo, ref IntPtr sound);

		#endregion
		
		#endregion
		
		#region Recording
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordPosition")]
		private static extern Error.Code GetRecordPosition (IntPtr system, int id, ref uint position);

		[DllImport("fmodex", EntryPoint = "FMOD_System_RecordStart")]
		private static extern Error.Code RecordStart (IntPtr system, int id, IntPtr sound, int loop);

		[DllImport("fmodex", EntryPoint = "FMOD_System_RecordStop")]
		private static extern Error.Code RecordStop (IntPtr system, int id);

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
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSpectrum")]
		private static extern Error.Code GetSpectrum (IntPtr system, [MarshalAs(UnmanagedType.LPArray)] float[] spectrumarray, int numvalues, int channeloffset, Dsp.FFTWindow windowtype);

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

		[DllImport("fmodex", EntryPoint = "FMOD_System_Update")]
		private static extern Error.Code Update (IntPtr system);

		[DllImport("fmodex", EntryPoint = "FMOD_System_UpdateFinished")]
		private static extern Error.Code UpdateFinished (IntPtr system);

		#endregion
		
		//TODO Implement extern funcitons
		
		/*

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetHardwareChannels")]
		private static extern Error.Code SetHardwareChannels (IntPtr system, int min2d, int max2d, int min3d, int max3d);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetHardwareChannels")]
		private static extern Error.Code GetHardwareChannels (IntPtr system, ref int num2d, ref int num3d, ref int total);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSoftwareChannels")]
		private static extern Error.Code SetSoftwareChannels (IntPtr system, int numsoftwarechannels);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoftwareChannels")]
		private static extern Error.Code GetSoftwareChannels (IntPtr system, ref int numsoftwarechannels);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSoftwareFormat")]
		private static extern Error.Code SetSoftwareFormat (IntPtr system, int samplerate, Sound.Format format, int numoutputchannels, int maxinputchannels, Dsp.Resampler resamplemethod);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoftwareFormat")]
		private static extern Error.Code GetSoftwareFormat (IntPtr system, ref int samplerate, ref Sound.Format format, ref int numoutputchannels, ref int maxinputchannels, ref Dsp.Resampler resamplemethod, ref int bits);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetDSPBufferSize")]
		private static extern Error.Code SetDSPBufferSize (IntPtr system, uint bufferlength, int numbuffers);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDSPBufferSize")]
		private static extern Error.Code GetDSPBufferSize (IntPtr system, ref uint bufferlength, ref int numbuffers);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetFileSystem")]
		private static extern Error.Code SetFileSystem (IntPtr system, File_OpenDelegate useropen, File_CloseDelegate userclose, File_ReadDelegate userread, File_SeekDelegate userseek, File_AsyncReadDelegate userasyncread, File_AsyncCancelDelegate userasynccancel, int blockalign);

		[DllImport("fmodex", EntryPoint = "FMOD_System_AttachFileSystem")]
		private static extern Error.Code AttachFileSystem (IntPtr system, File_OpenDelegate useropen, File_CloseDelegate userclose, File_ReadDelegate userread, File_SeekDelegate userseek);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetPluginPath")]
		private static extern Error.Code SetPluginPath (IntPtr system, string path);

		[DllImport("fmodex", EntryPoint = "FMOD_System_LoadPlugin")]
		private static extern Error.Code LoadPlugin (IntPtr system, string filename, ref uint handle, uint priority);

		[DllImport("fmodex", EntryPoint = "FMOD_System_UnloadPlugin")]
		private static extern Error.Code UnloadPlugin (IntPtr system, uint handle);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumPlugins")]
		private static extern Error.Code GetNumPlugins (IntPtr system, Plugin.Type plugintype, ref int numplugins);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetPluginHandle")]
		private static extern Error.Code GetPluginHandle (IntPtr system, Plugin.Type plugintype, int index, ref uint handle);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetPluginInfo")]
		private static extern Error.Code GetPluginInfo (IntPtr system, uint handle, ref PLUGINTYPE plugintype, StringBuilder name, int namelen, ref uint version);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateDSPByPlugin")]
		private static extern Error.Code CreateDSPByPlugin (IntPtr system, uint handle, ref IntPtr dsp);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateCodec")]
		private static extern Error.Code CreateCodec (IntPtr system, IntPtr description, uint priority);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetOutputByPlugin")]
		private static extern Error.Code SetOutputByPlugin (IntPtr system, uint handle);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetOutputByPlugin")]
		private static extern Error.Code GetOutputByPlugin (IntPtr system, ref uint handle);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetAdvancedSettings")]
		private static extern Error.Code SetAdvancedSettings (IntPtr system, ref ADVANCEDSETTINGS settings);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetAdvancedSettings")]
		private static extern Error.Code GetAdvancedSettings (IntPtr system, ref ADVANCEDSETTINGS settings);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetSpeakerMode")]
		private static extern Error.Code SetSpeakerMode (IntPtr system, SpeakerMode speakermode);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSpeakerMode")]
		private static extern Error.Code GetSpeakerMode (IntPtr system, ref SpeakerMode speakermode);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DRolloffCallback")]
		private static extern Error.Code Set3DRolloffCallback (IntPtr system, CB_3D_RollOffDelegate callback);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DSpeakerPosition")]
		private static extern Error.Code Set3DSpeakerPosition (IntPtr system, Speaker speaker, float x, float y, int active);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DSpeakerPosition")]
		private static extern Error.Code Get3DSpeakerPosition (IntPtr system, Speaker speaker, ref float x, ref float y, ref int active);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DSettings")]
		private static extern Error.Code Set3DSettings (IntPtr system, float dopplerscale, float distancefactor, float rolloffscale);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DSettings")]
		private static extern Error.Code Get3DSettings (IntPtr system, ref float dopplerscale, ref float distancefactor, ref float rolloffscale);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DNumListeners")]
		private static extern Error.Code Set3DNumListeners (IntPtr system, int numlisteners);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DNumListeners")]
		private static extern Error.Code Get3DNumListeners (IntPtr system, ref int numlisteners);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Set3DListenerAttributes")]
		private static extern Error.Code Set3DListenerAttributes (IntPtr system, int listener, ref Vector3 pos, ref Vector3 vel, ref Vector3 forward, ref Vector3 up);

		[DllImport("fmodex", EntryPoint = "FMOD_System_Get3DListenerAttributes")]
		private static extern Error.Code Get3DListenerAttributes (IntPtr system, int listener, ref Vector3 pos, ref Vector3 vel, ref Vector3 forward, ref Vector3 up);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetFileBufferSize")]
		private static extern Error.Code SetFileBufferSize (IntPtr system, int sizebytes);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetFileBufferSize")]
		private static extern Error.Code GetFileBufferSize (IntPtr system, ref int sizebytes);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetStreamBufferSize")]
		private static extern Error.Code SetStreamBufferSize (IntPtr system, uint filebuffersize, TimeUnit filebuffersizetype);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetStreamBufferSize")]
		private static extern Error.Code GetStreamBufferSize (IntPtr system, ref uint filebuffersize, ref TimeUnit filebuffersizetype);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetOutputHandle")]
		private static extern Error.Code GetOutputHandle (IntPtr system, ref IntPtr handle);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetChannelsPlaying")]
		private static extern Error.Code GetChannelsPlaying (IntPtr system, ref int channels);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetCPUUsage")]
		private static extern Error.Code GetCPUUsage (IntPtr system, ref float dsp, ref float stream, ref float geometry, ref float update, ref float total);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetSoundRAM")]
		private static extern Error.Code GetSoundRAM (IntPtr system, ref int currentalloced, ref int maxalloced, ref int total);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumCDROMDrives")]
		private static extern Error.Code GetNumCDROMDrives (IntPtr system, ref int numdrives);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetCDROMDriveName")]
		private static extern Error.Code GetCDROMDriveName (IntPtr system, int drive, StringBuilder drivename, int drivenamelen, StringBuilder scsiname, int scsinamelen, StringBuilder devicename, int devicenamelen);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetChannel")]
		private static extern Error.Code GetChannel (IntPtr system, int channelid, ref IntPtr channel);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetMasterChannelGroup")]
		private static extern Error.Code GetMasterChannelGroup (IntPtr system, ref IntPtr channelgroup);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetMasterSoundGroup")]
		private static extern Error.Code GetMasterSoundGroup (IntPtr system, ref IntPtr soundgroup);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDSPHead")]
		private static extern Error.Code GetDSPHead (IntPtr system, ref IntPtr dsp);

		[DllImport("fmodex", EntryPoint = "FMOD_System_AddDSP")]
		private static extern Error.Code AddDSP (IntPtr system, IntPtr dsp, ref IntPtr connection);

		[DllImport("fmodex", EntryPoint = "FMOD_System_LockDSP")]
		private static extern Error.Code LockDSP (IntPtr system);

		[DllImport("fmodex", EntryPoint = "FMOD_System_UnlockDSP")]
		private static extern Error.Code UnlockDSP (IntPtr system);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDSPClock")]
		private static extern Error.Code GetDSPClock (IntPtr system, ref uint hi, ref uint lo);

		[DllImport("fmodex", EntryPoint = "FMOD_System_CreateGeometry")]
		private static extern Error.Code CreateGeometry (IntPtr system, int maxpolygons, int maxvertices, ref IntPtr geometry);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetGeometrySettings")]
		private static extern Error.Code SetGeometrySettings (IntPtr system, float maxworldsize);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetGeometrySettings")]
		private static extern Error.Code GetGeometrySettings (IntPtr system, ref float maxworldsize);

		[DllImport("fmodex", EntryPoint = "FMOD_System_LoadGeometry")]
		private static extern Error.Code LoadGeometry (IntPtr system, IntPtr data, int datasize, ref IntPtr geometry);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetGeometryOcclusion")]
		private static extern Error.Code GetGeometryOcclusion (IntPtr system, ref Vector3 listener, ref Vector3 source, ref float direct, ref float reverb);

		[DllImport("fmodex", EntryPoint = "FMOD_System_SetUserData")]
		private static extern Error.Code SetUserData (IntPtr system, IntPtr userdata);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetUserData")]
		private static extern Error.Code GetUserData (IntPtr system, ref IntPtr userdata);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetMemoryInfo")]
		private static extern Error.Code GetMemoryInfo (IntPtr system, uint memorybits, uint event_memorybits, ref uint memoryused, ref Memory.UsageDetails memoryused_details);

		











		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetHardwareChannels")]
		public static extern Error.Code SetHardwareChannels (IntPtr system, int Min2d, int Max2d, int Min3d, int Max3d);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetSoftwareChannels")]
		public static extern Error.Code SetSoftwareChannels (IntPtr system, int Numsoftwarechannels);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSoftwareChannels")]
		public static extern Error.Code GetSoftwareChannels (IntPtr system, ref int Numsoftwarechannels);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetSoftwareFormat")]
		public static extern Error.Code SetSoftwareFormat (IntPtr system, int Samplerate, Sound.Format format, int Numoutputchannels, int Maxinputchannels, Dsp.Resampler Resamplemethod);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSoftwareFormat")]
		public static extern Error.Code GetSoftwareFormat (IntPtr system, ref int Samplerate, ref Sound.Format format, ref int Numoutputchannels, ref int Maxinputchannels, ref Dsp.Resampler Resamplemethod, ref int Bits);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetDSPBufferSize")]
		public static extern Error.Code SetDSPBufferSize (IntPtr system, int Bufferlength, int Numbuffers);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetDSPBufferSize")]
		public static extern Error.Code GetDSPBufferSize (IntPtr system, ref int Bufferlength, ref int Numbuffers);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetFileSystem")]
		public static extern Error.Code SetFileSystem (IntPtr system, int useropen, int userclose, int userread, int userseek, int Buffersize);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_AttachFileSystem")]
		public static extern Error.Code AttachFileSystem (IntPtr system, int useropen, int userclose, int userread, int userseek);

		//[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetAdvancedSettings")]
		//public static extern Error.Code SetAdvancedSettings (IntPtr system, ref FMOD_ADVANCEDSETTINGS settings);

		//[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetAdvancedSettings")]
		//public static extern Error.Code GetAdvancedSettings (IntPtr system, ref FMOD_ADVANCEDSETTINGS settings);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetSpeakerMode")]
		public static extern Error.Code SetSpeakerMode (IntPtr system, SpeakerMode Speakermode);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSpeakerMode")]
		public static extern Error.Code GetSpeakerMode (IntPtr system, ref SpeakerMode Speakermode);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetPluginPath")]
		public static extern Error.Code SetPluginPath (IntPtr system, string Path);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_LoadPlugin")]
		public static extern Error.Code LoadPlugin (IntPtr system, string Filename, ref int Handle, int Priority);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_UnloadPlugin")]
		public static extern Error.Code UnloadPlugin (IntPtr system, int Handle);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetNumPlugins")]
		public static extern Error.Code GetNumPlugins (IntPtr system, Plugin.Type Plugintype, ref int Numplugins);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetPluginHandle")]
		public static extern Error.Code GetPluginHandle (IntPtr system, Plugin.Type Plugintype, int Index, ref int Handle);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetPluginInfo")]
		public static extern Error.Code GetPluginInfo (IntPtr system, int Handle, ref Plugin.Type Plugintype, ref byte name, int namelen, ref int version);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetOutputByPlugin")]
		public static extern Error.Code SetOutputByPlugin (IntPtr system, int Handle);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetOutputByPlugin")]
		public static extern Error.Code GetOutputByPlugin (IntPtr system, ref int Handle);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSPByPlugin")]
		public static extern Error.Code CreateDSPByPlugin (IntPtr system, int Handle, ref int Dsp);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateCodec")]
		public static extern Error.Code CreateCodec (IntPtr system, int CodecDescription);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DSettings")]
		public static extern Error.Code Set3DSettings (IntPtr system, float Dopplerscale, float Distancefactor, float Rolloffscale);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DSettings")]
		public static extern Error.Code Get3DSettings (IntPtr system, ref float Dopplerscale, ref float Distancefactor, ref float Rolloffscale);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DNumListeners")]
		public static extern Error.Code Set3DNumListeners (IntPtr system, int Numlisteners);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DNumListeners")]
		public static extern Error.Code Get3DNumListeners (IntPtr system, ref int Numlisteners);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DListenerAttributes")]
		public static extern Error.Code Set3DListenerAttributes (IntPtr system, int Listener, ref Vector3 Pos, ref Vector3 Vel, ref Vector3 Forward, ref Vector3 Up);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DListenerAttributes")]
		public static extern Error.Code Get3DListenerAttributes (IntPtr system, int Listener, ref Vector3 Pos, ref Vector3 Vel, ref Vector3 Forward, ref Vector3 Up);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DRolloffCallback")]
		public static extern Error.Code Set3DRolloffCallback (IntPtr system, int Callback);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Set3DSpeakerPosition")]
		public static extern Error.Code Set3DSpeakerPosition (IntPtr system, Speaker speaker, float X, float Y, int active);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_Get3DSpeakerPosition")]
		public static extern Error.Code Get3DSpeakerPosition (IntPtr system, ref Speaker speaker, ref float X, ref float Y, ref int active);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetStreamBufferSize")]
		public static extern Error.Code SetStreamBufferSize (IntPtr system, int Filebuffersize, TimeUnit Filebuffersizetype);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetStreamBufferSize")]
		public static extern Error.Code GetStreamBufferSize (IntPtr system, ref int Filebuffersize, ref TimeUnit Filebuffersizetype);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetOutputHandle")]
		public static extern Error.Code GetOutputHandle (IntPtr system, ref int Handle);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetChannelsPlaying")]
		public static extern Error.Code GetChannelsPlaying (IntPtr system, ref int Channels);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetHardwareChannels")]
		public static extern Error.Code GetHardwareChannels (IntPtr system, ref int Num2d, ref int Num3d, ref int total);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetCPUUsage")]
		public static extern Error.Code GetCPUUsage (IntPtr system, ref float Dsp, ref float Stream, ref float Geometry, ref float Update, ref float total);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSoundRAM")]
		public static extern Error.Code GetSoundRAM (IntPtr system, ref int currentalloced, ref int maxalloced, ref int total);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetNumCDROMDrives")]
		public static extern Error.Code GetNumCDROMDrives (IntPtr system, ref int Numdrives);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetCDROMDriveName")]
		public static extern Error.Code GetCDROMDriveName (IntPtr system, int Drive, ref byte Drivename, int Drivenamelen, ref byte Scsiname, int Scsinamelen, ref byte Devicename, int Devicenamelen);

		//[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetSpectrum")]
		//public static extern Error.Code GetSpectrum (IntPtr system, ref float Spectrumarray, int Numvalues, int Channeloffset, ref FMOD_DSP_FFT_WINDOW Windowtype);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetWaveData")]
		public static extern Error.Code GetWaveData (IntPtr system, ref float Wavearray, int Numvalues, int Channeloffset);

		//[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSP")]
		//public static extern Error.Code CreateDSP (IntPtr system, ref FMOD_DSP_DESCRIPTION description, ref int Dsp);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSPByType")]
		public static extern Error.Code CreateDSPByType (IntPtr system, Dsp.Type dsptype, ref int Dsp);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateDSPByIndex")]
		public static extern Error.Code CreateDSPByIndex (IntPtr system, int Index, ref int Dsp);



		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_PlayDSP")]
		public static extern Error.Code PlayDSP (IntPtr system, Channel.Index channelid, int Dsp, int paused, ref int channel);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetChannel")]
		public static extern Error.Code GetChannel (IntPtr system, int channelid, ref int channel);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetMasterChannelGroup")]
		public static extern Error.Code GetMasterChannelGroup (IntPtr system, ref int Channelgroup);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetMasterSoundGroup")]
		public static extern Error.Code GetMasterSoundGroup (IntPtr system, ref int soundgroup);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetReverbProperties")]
		public static extern Error.Code SetReverbProperties (IntPtr system, ref Reverb.Properties Prop);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetReverbProperties")]
		public static extern Error.Code GetReverbProperties (IntPtr system, ref Reverb.Properties Prop);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetReverbAmbientProperties")]
		public static extern Error.Code SetReverbAmbientProperties (IntPtr system, ref Reverb.Properties Prop);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetReverbAmbientProperties")]
		public static extern Error.Code GetReverbAmbientProperties (IntPtr system, ref Reverb.Properties Prop);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetDSPHead")]
		public static extern Error.Code GetDSPHead (IntPtr system, ref int Dsp);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_AddDSP")]
		public static extern Error.Code AddDSP (IntPtr system, int Dsp, ref int dspconnection);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_LockDSP")]
		public static extern Error.Code LockDSP (IntPtr system);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_UnlockDSP")]
		public static extern Error.Code UnlockDSP (IntPtr system);


		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetRecordPosition")]
		public static extern Error.Code GetRecordPosition (IntPtr system, int Id, ref int position);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_RecordStart")]
		public static extern Error.Code RecordStart (IntPtr system, int Id, int Sound, int Loop);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_RecordStop")]
		public static extern Error.Code RecordStop (IntPtr system, int Id);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_IsRecording")]
		public static extern Error.Code IsRecording (IntPtr system, int Id, ref int Recording);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_CreateGeometry")]
		public static extern Error.Code CreateGeometry (IntPtr system, int MaxPolygons, int MaxVertices, ref int Geometryf);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetGeometrySettings")]
		public static extern Error.Code SetGeometrySettings (IntPtr system, float Maxworldsize);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetGeometrySettings")]
		public static extern Error.Code GetGeometrySettings (IntPtr system, ref float Maxworldsize);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_LoadGeometry")]
		public static extern Error.Code LoadGeometry (IntPtr system, int Data, int DataSize, ref int Geometry);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetNetworkProxy")]
		public static extern Error.Code SetNetworkProxy (IntPtr system, string Proxy);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetNetworkProxy")]
		public static extern Error.Code GetNetworkProxy (IntPtr system, ref byte Proxy, int Proxylen);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetNetworkTimeout")]
		public static extern Error.Code SetNetworkTimeout (IntPtr system, int timeout);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetNetworkTimeout")]
		public static extern Error.Code GetNetworkTimeout (IntPtr system, ref int timeout);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_SetUserData")]
		public static extern Error.Code SetUserData (IntPtr system, int userdata);

		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_System_GetUserData")]
		public static extern Error.Code GetUserData (IntPtr system, ref int userdata);
		/* */
	}
}
