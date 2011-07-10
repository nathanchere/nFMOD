using System;

using SoundsSharpNameSpace.fmodex.fmodexvb;
using SoundsSharpNameSpace.fmodex.DSP;

namespace FmodSharp
{

	public class SoundsSharp
	{
		//public static  GlobalVelocity;
		public static Vector lastpos = new Vector ();


		#region "SoundManager"
		public static long SoundSystem;
		public class SoundManager
		{
			#region "SoundManager::Init Stuffs"
			#region "SoundManager::Init Stuffs::New"
			public SoundManager ()
			{
				Init ();
				Config (FMOD_OUTPUTTYPE.FMOD_OUTPUTTYPE_OPENAL, FMOD_SPEAKERMODE.FMOD_SPEAKERMODE_STEREO);
			}
			public SoundManager (FMOD_OUTPUTTYPE optype)
			{
				Init ();
				Config (optype, FMOD_SPEAKERMODE.FMOD_SPEAKERMODE_STEREO);
			}
			public SoundManager (FMOD_OUTPUTTYPE optype, FMOD_SPEAKERMODE spkmde)
			{
				Init ();
				Config (optype, spkmde);
			}
			#endregion

			public bool Init ()
			{
				bool FirstResult = false;
				bool SecondResult = false;
				if (SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Create (ref SoundsSharp.SoundSystem) == 0) {
					FirstResult = true;
				} else {
					FirstResult = false;
				}
				
				
				if (SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Init (SoundsSharp.SoundSystem, 32, FMOD_INITFLAGS.FMOD_INIT_3D_RIGHTHANDED, 0) == FMOD_RESULT.FMOD_OK) {
					SecondResult = true;
				} else {
					SecondResult = false;
				}
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Set3DSettings (SoundsSharp.SoundSystem, 1, 1.0, 1);
				
				return (FirstResult & SecondResult);
			}

			public void Config (fmodex.FMOD_OUTPUTTYPE Outputmode, fmodex.FMOD_SPEAKERMODE SpeakerMode)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_SetOutput (SoundsSharp.SoundSystem, Outputmode);
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_SetSpeakerMode (SoundsSharp.SoundSystem, SpeakerMode);
			}
			#endregion
			//  Function CreateSound(ByVal filepath$, ByVal Position As vector) As SoundEntity
			//Dim tempSound&
			//Dim SndEnt As New SoundEntity
			//
			//           SndEnt.hWnd = tempSound
			//          Return SndEnt
			//     End Function

			private long[] DSP = new long[21];
			private long[] Active = new long[21];
			public long getID ()
			{
				return SoundsSharp.SoundSystem;
			}
			public void ActivateSFX (FMOD_DSP_TYPE type)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateDSPByType (SoundsSharp.SoundSystem, FMOD_DSP_TYPE.FMOD_DSP_TYPE_COMPRESSOR, ref DSP (type));
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_DSP_GetActive (DSP (type), ref Active (type));
			}
			public void DesactivateSFX (FMOD_DSP_TYPE type)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_DSP_Remove (DSP (type));
			}

			public void Update ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Update (SoundsSharp.SoundSystem);
			}

			public void Update_3D (Vector pos, Vector Forward, Vector up, float FPS)
			{
				Vector vel = default(Vector);
				vel.X = (pos.X - SoundsSharp.lastpos.X) * (1000 / FPS);
				vel.Y = (pos.Y - SoundsSharp.lastpos.Y) * (1000 / FPS);
				vel.Z = (pos.Z - SoundsSharp.lastpos.Z) * (1000 / FPS);
				
				SoundsSharp.lastpos = pos;
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Update (SoundsSharp.SoundSystem);
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Set3DListenerAttributes (SoundsSharp.SoundSystem, 0, ref pos, ref SoundsSharp.GlobalVelocity, ref Forward, ref up);
				
			}
			
			
			
			
		}
		#endregion


		#region "Sound::Ambient"
		public class SoundAmbient
		{
			public long ID;
			public long Channel;
			private float Volume_;
			private float Frequency;
			public bool _loop {
				set {
					if (value == true) {
						SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_NORMAL);
					} else {
						SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_OFF);
					}
				}
			}
			public SoundAmbient (System.Object filepath, bool loopy)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateSound (SoundsSharp.SoundSystem, filepath, FMOD_MODE.FMOD_LOOP_NORMAL, ref ID);
				
				if (loopy == true) {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_NORMAL);
				} else {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_OFF);
				}
			}
			public SoundAmbient (System.Object filepath)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateSound (SoundsSharp.SoundSystem, filepath, FMOD_MODE.FMOD_LOOP_NORMAL, ref ID);
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_NORMAL);
			}
			public void Play ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_PlaySound (SoundsSharp.SoundSystem, FMOD_CHANNELINDEX.FMOD_CHANNEL_FREE, this.ID, 0, ref Channel);
			}
			public void stop_ ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_Stop (this.Channel);
			}
			public void pause ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetPaused (Channel, 1);
			}

			public void Pitch (float value)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetFrequency (this.Channel, 22050 * value);
			}
			public void InitChannel ()
			{
				Play ();
				stop_ ();
			}
			public float Volume {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetVolume (this.Channel, ref this.Volume_);
					return Volume;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.Channel, this.Volume_); }
			}
			private float delayst;
			private float delay_end;
			public float delayStart {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetDelay (this.Channel, ref delayst, ref delay_end);
					return delayst;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetDelay (this.Channel, value, delay_end); }
			}
			public float delayEnd {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetDelay (this.Channel, ref delayst, ref delay_end);
					return delay_end;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetDelay (this.Channel, delayst, value); }
			}
			
			
		}
		#endregion

		#region "Sound::3D"
		public class Sound3D
		{
			public long ID;
			public long Channel;
			private float Volume_;
			private Vector _3Dposition;
			public Vector _3Dpos {
				get { return this._3Dposition; }
				set {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_Set3DAttributes (this.Channel, ref value, ref SoundsSharp.GlobalVelocity);
					_3Dposition = value;
				}
			}
			private float MinDistance;
			private float MaxDistance;
			private float frequency;
			public bool _loop {
				set {
					if (value == true) {
						SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_NORMAL);
					} else {
						SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (ID, FMOD_MODE.FMOD_LOOP_OFF);
					}
				}
			}




			public Sound3D (System.Object Path, Vector positionvector, float minDist, float maxDis, bool loop_)
			{
				
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateSound (SoundsSharp.SoundSystem, Path, FMOD_MODE.FMOD_HARDWARE | FMOD_MODE.FMOD_3D, ref ID);
				
				
				_3Dpos = positionvector;
				
				
				if (loop_ == true) {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_NORMAL);
					this._loop = true;
				} else {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (ID, FMOD_MODE.FMOD_LOOP_OFF);
					this._loop = false;
				}
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_Set3DMinMaxDistance (this.ID, minDist, MaxDistance);
				this.MinDistance = minDist;
				this.MaxDistance = maxDis;
				
				
			}
			public Sound3D (System.Object Path, Vector positionvector, float minDist, float maxDis)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateSound (SoundsSharp.SoundSystem, Path, FMOD_MODE.FMOD_HARDWARE | FMOD_MODE.FMOD_3D, ref ID);
				
				_3Dpos = positionvector;
				
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_SetMode (this.ID, FMOD_MODE.FMOD_LOOP_NORMAL);
				this._loop = true;
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Sound_Set3DMinMaxDistance (this.ID, minDist, MaxDistance);
				this.MinDistance = minDist;
				this.MaxDistance = maxDis;
				
			}
			public void Play ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_PlaySound (SoundsSharp.SoundSystem, FMOD_CHANNELINDEX.FMOD_CHANNEL_FREE, this.ID, 0, ref Channel);
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_Set3DAttributes (this.Channel, ref this._3Dpos, ref SoundsSharp.GlobalVelocity);
			}
			public void stop_ ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_Stop (this.Channel);
			}
			public void pause ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetPaused (Channel, 1);
			}

			public void Pitch (float value)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetFrequency (this.Channel, 22050 * value);
			}
			public void InitChannel ()
			{
				Play ();
				stop_ ();
			}
			public float Volume {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetVolume (this.Channel, ref this.Volume_);
					return Volume;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.Channel, this.Volume_); }
			}
			private float delayst;
			private float delay_end;
			public float delayStart {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetDelay (this.Channel, ref delayst, ref delay_end);
					return delayst;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetDelay (this.Channel, value, delay_end); }
			}
			public float delayEnd {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetDelay (this.Channel, ref delayst, ref delay_end);
					return delay_end;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetDelay (this.Channel, delayst, value); }
			}
			
		}
		#endregion

		#region "Sound::Music"
		public class Music
		{
			private long channel;
			private long ID;
			private float volume_;
			private float frequency;
			public struct FMOD_CREATESOUNDEXINFO
			{
				// [in] Size of this structure.  This is used so the structure can be expanded in the future and still work on older versions of FMOD Ex.
				public int cbsize;
				// [in] Optional. Specify 0 to ignore. Size in bytes of file to load, or sound to create (in this case only if FMOD_OPENUSER is used).  Required if loading from memory.  If 0 is specified, then it will use the size of the file (unless loading from memory then an error will be returned).
				public int Length;
				// [in] Optional. Specify 0 to ignore. Offset from start of the file to start loading from.  This is useful for loading files from inside big data files.
				public int fileoffset;
				// [in] Optional. Specify 0 to ignore. Number of channels in a sound specified only if FMOD_OPENUSER is used.
				public int Numchannels;
				// [in] Optional. Specify 0 to ignore. Default frequency of sound in a sound specified only if FMOD_OPENUSER is used.  Other formats use the frequency determined by the file format.
				public int defaultfrequency;
				//UPGRADE_NOTE: Format was upgraded to Format_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
				// [in] Optional. Specify 0 or FMOD_SOUND_FORMAT_NONE to ignore. Format of the sound specified only if FMOD_OPENUSER is used.  Other formats use the format determined by the file format.
				public FMOD_SOUND_FORMAT Format_Renamed;
				// [in] Optional. Specify 0 to ignore. For streams.  This determines the size of the double buffer (in PCM samples) that a stream uses.  Use this for user created streams if you want to determine the size of the callback buffer passed to you.  Specify 0 to use FMOD's default size which is currently equivalent to 400ms of the sound format created/loaded.
				public int decodebuffersize;
				// [in] Optional. Specify 0 to ignore. In a multi-sample file format such as .FSB/.DLS/.SF2, specify the initial subsound to seek to, only if FMOD_CREATESTREAM is used.
				public int initialsubsound;
				// [in] Optional. Specify 0 to ignore or have no subsounds.  In a user created multi-sample sound, specify the number of subsounds within the sound that are accessable with Sound::getSubSound.
				public int Numsubsounds;
				// [in] Optional. Specify 0 to ignore. In a multi-sample format such as .FSB/.DLS/.SF2 it may be desirable to specify only a subset of sounds to be loaded out of the whole file.  This is an array of subsound indicies to load into memory when created.
				public int inclusionlist;
				// [in] Optional. Specify 0 to ignore. This is the number of integers contained within the inclusionlist array.
				public int inclusionlistnum;
				// [in] Optional. Specify 0 to ignore. Callback to 'piggyback' on FMOD's read functions and accept or even write PCM data while FMOD is opening the sound.  Used for user sounds created with FMOD_OPENUSER or for capturing decoded data as FMOD reads it.
				public int pcmreadcallback;
				// [in] Optional. Specify 0 to ignore. Callback for when the user calls a seeking function such as Channel::setTime or Channel::setPosition within a multi-sample sound, and for when it is opened.
				public int pcmsetposcallback;
				// [in] Optional. Specify 0 to ignore. Callback for successful completion, or error while loading a sound that used the FMOD_NONBLOCKING flag.
				public int nonblockcallback;
				// [in] Optional. Specify 0 to ignore. Filename for a DLS or SF2 sample set when loading a MIDI file.   If not specified, on windows it will attempt to open /windows/system32/drivers/gm.dls, otherwise the MIDI will fail to open.
				public string dlsname;
				// [in] Optional. Specify 0 to ignore. Key for encrypted FSB file.  Without this key an encrypted FSB file will not load.
				public string encryptionkey;
				// [in] Optional. Specify 0 to ingore. For sequenced formats with dynamic channel allocation such as .MID and .IT, this specifies the maximum voice count allowed while playing.  .IT defaults to 64.  .MID defaults to 32.
				public int maxpolyphony;
				// [in] Optional. Specify 0 to ignore. This is user data to be attached to the sound during creation.  Access via Sound::getUserData.
				public int userdata;
				// [in] Optional. Specify 0 or FMOD_SOUND_TYPE_UNKNOWN to ignore.  Instead of scanning all codec types, use this to speed up loading by making it jump straight to this codec.
				public FMOD_SOUND_TYPE suggestedsoundtype;
				// [in] Optional. Specify 0 to ignore. Callback for opening this file.
				public int useropen;
				// [in] Optional. Specify 0 to ignore. Callback for closing this file.
				public int userclose;
				// [in] Optional. Specify 0 to ignore. Callback for reading from this file.
				public int userread;
				// [in] Optional. Specify 0 to ignore. Callback for seeking within this file.
				public int userseek;
				// [in] Optional. Specify 0 to ignore. Use this to differ the way fmod maps multichannel sounds to speakers.  See FMOD_SPEAKERMAPTYPE for more. */
				public FMOD_SPEAKERMAPTYPE speakermap;
				// [in] Optional. Specify 0 to ignore. Specify a sound group if required, to put sound in as it is created.
				public int initialsoundgroup;
				// [in] Optional. Specify 0 to ignore. For streams. Specify an initial position to seek the stream to.
				public int initialseekposition;
				// [in] Optional. Specify 0 to ignore. For streams. Specify the time unit for the position set in initialseekposition.
				public FMOD_TIMEUNIT initialseekpostype;
				// [w] Optional. Specify 0 to ignore. Set to 1 to use fmod's built in file system. Ignores setFileSystem callbacks and also FMOD_CREATESOUNEXINFO file callbacks.  Useful for specific cases where you don't want to use your own file system but want to use fmod's file system (ie net streaming). */
				public int ignoresetfilesystem;
			}
			public void FadeInAndPlay ()
			{
				float timer = 0.5;
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.channel, 0);
				this.Play ();
				while (timer <= 100) {
					timer += 6E-05;
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.channel, timer / 100);
				}
				
				
			}
			public void FadeOutAndStop ()
			{
				float timer = 0.5;
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.channel, 1);
				
				while (timer <= 100) {
					timer += 6E-05;
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.channel, 1 - timer / 100);
				}
				this.stop_ ();
				
			}
			public Music (System.Object Path)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateStream (SoundsSharp.SoundSystem, Path, FMOD_MODE.FMOD_LOOP_NORMAL, ref ID);
			}
			public void Play ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_PlaySound (SoundsSharp.SoundSystem, FMOD_CHANNELINDEX.FMOD_CHANNEL_FREE, this.ID, 0, ref channel);
			}
			public void stop_ ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_Stop (this.channel);
			}
			public void pause ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetPaused (channel, 1);
			}
			public void InitChannel ()
			{
				Play ();
				stop_ ();
			}
			public void Pitch (float value)
			{
				//  FMOD_Channel_GetFrequency(Me.channel, Me.frequency)
				// FMOD_Channel_SetFrequency(Me.channel, Me.frequency * value)
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetFrequency (this.channel, 22050 * value);
			}
			public float Volume {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetVolume (this.channel, ref this.volume_);
					return Volume;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetVolume (this.channel, this.volume_); }
			}
			private float delayst;
			private float delay_end;
			public float delayStart {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetDelay (this.channel, ref delayst, ref delay_end);
					return delayst;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetDelay (this.channel, value, delay_end); }
			}
			public float delayEnd {
				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_GetDelay (this.channel, ref delayst, ref delay_end);
					return delay_end;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Channel_SetDelay (this.channel, delayst, value); }
			}
			
		}
		#endregion

		#region "Reverb"
		public class Reverb
		{
			private long ID;
			private FMOD_REVERB_PROPERTIES properties_;
			private Vector pos;
			float minD;
			float maxD;
			private int actif;
			public void Activate ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_SetActive (ID, actif);
			}
			public void Desactivate ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_Release (ID);
			}
			public Vector Position {
				get { return pos; }
				set {
					pos = value;
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_Set3DAttributes (ID, ref value, minD, maxD);
				}
			}
			public float MaxDistance {
				get { return maxD; }
				set {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_Set3DAttributes (ID, ref pos, minD, value);
					maxD = value;
				}
			}
			public float MinDistance {
				get { return minD; }
				set {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_Set3DAttributes (ID, ref pos, value, maxD);
					minD = value;
				}
			}
			public FMOD_REVERB_PROPERTIES properties {

				get {
					SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_GetProperties (ID, ref properties_);
					return properties_;
				}
				set { SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_Reverb_SetProperties (ID, ref properties_); }
			}
			public Reverb (Vector Position)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateReverb (SoundsSharp.SoundSystem, ref ID);
				this.Position = Position;
			}
			public Reverb ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateReverb (SoundsSharp.SoundSystem, ref ID);
			}
		}
		#endregion
		#region "Reverb Presets"

		public static FMOD_REVERB_PROPERTIES getPreset (System.Object instance, System.Object environement, float envsize, float envDiff, System.Object Room, System.Object RoomHF, System.Object RoomLF, float decaytime, System.Object DecayHF, System.Object DecayLf,
		long refs, float refdelay, Vector reflectionPan, System.Object reverb, float reverbdelay, Vector reverbPan, float echoTime, float echoDepth, float modulationtime, float modulatiodepth,
		
		float airabsorp, float HFref, float LFref, float RoomRollOff, float Diff, float Density, int Flags)
		{
			float[] reverbpan_ = { reverbPan.X, reverbPan.Y, reverbPan.Z };
			float[] refpan_ = { reflectionPan.X, reflectionPan.Y, reflectionPan.Z };
			
			FMOD_REVERB_PROPERTIES X = default(FMOD_REVERB_PROPERTIES);
			X.Instance = instance;
			X.Environment = environement;
			X.EnvSize = envsize;
			X.EnvDiffusion = envDiff;
			X.Room = Room;
			X.RoomHF = RoomHF;
			X.RoomLF = RoomLF;
			X.DecayTime = decaytime;
			X.DecayHFRatio = DecayHF;
			X.DecayLFRatio = DecayLf;
			X.Reflections = refs;
			X.ReflectionsDelay = refdelay;
			X.ReflectionsPan = refpan_;
			X.reverb = reverb;
			X.ReverbDelay = reverbdelay;
			X.ReverbPan = reverbpan_;
			X.EchoTime = echoTime;
			X.EchoDepth = echoDepth;
			X.ModulationTime = modulationtime;
			X.ModulationDepth = modulatiodepth;
			X.AirAbsorptionHF = airabsorp;
			X.HFReference = HFref;
			X.LFReference = LFref;
			X.RoomRolloffFactor = RoomRollOff;
			X.Diffusion = Diff;
			X.Density = Density;
			X.Flags = Flags;
			
			return X;
			
			
		}

		static VECTOR NullVector;


		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_GENERIC = getPreset (0, 0, 7.5f, 1f, -1000, -100, 0, 1.49f, 0.83f, 1f,
		-2602, 0.007f, NullVector, 200, 0.011f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x33f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PADDEDCELL = getPreset (0, 1, 1.4f, 1f, -1000, -6000, 0, 0.17f, 0.1f, 1f,
		-1204, 0.001f, NullVector, 207, 0.002f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_ROOM = getPreset (0, 2, 1.9f, 1f, -1000, -454, 0, 0.4f, 0.83f, 1f,
		-1646, 0.002f, NullVector, 53, 0.003f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_BATHROOM = getPreset (0, 3, 1.4f, 1f, -1000, -1200, 0, 1.49f, 0.54f, 1f,
		-370, 0.007f, NullVector, 1030, 0.011f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 60f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_LIVINGROOM = getPreset (0, 4, 2.5f, 1f, -1000, -6000, 0, 0.5f, 0.1f, 1f,
		-1376, 0.003f, NullVector, -1104, 0.004f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_STONEROOM = getPreset (0, 5, 11.6f, 1f, -1000, -300, 0, 2.31f, 0.64f, 1f,
		-711, 0.012f, NullVector, 83, 0.017f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_AUDITORIUM = getPreset (0, 6, 21.6f, 1f, -1000, -476, 0, 4.32f, 0.59f, 1f,
		-789, 0.02f, NullVector, -289, 0.03f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_CONCERTHALL = getPreset (0, 7, 19.6f, 1f, -1000, -500, 0, 3.92f, 0.7f, 1f,
		-1230, 0.02f, NullVector, -2, 0.029f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_CAVE = getPreset (0, 8, 14.6f, 1f, -1000, 0, 0, 2.91f, 1.3f, 1f,
		-602, 0.015f, NullVector, -302, 0.022f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x1f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_ARENA = getPreset (0, 9, 36.2f, 1f, -1000, -698, 0, 7.24f, 0.33f, 1f,
		-1166, 0.02f, NullVector, 16, 0.03f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_HANGAR = getPreset (0, 10, 50.3f, 1f, -1000, -1000, 0, 10.05f, 0.23f, 1f,
		-602, 0.02f, NullVector, 198, 0.03f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_CARPETTEDHALLWAY = getPreset (0, 11, 1.9f, 1f, -1000, -4000, 0, 0.3f, 0.1f, 1f,
		-1831, 0.002f, NullVector, -1630, 0.03f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_HALLWAY = getPreset (0, 12, 1.8f, 1f, -1000, -300, 0, 1.49f, 0.59f, 1f,
		-1219, 0.007f, NullVector, 441, 0.011f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_STONECORRIDOR = getPreset (0, 13, 13.5f, 1f, -1000, -237, 0, 2.7f, 0.79f, 1f,
		-1214, 0.013f, NullVector, 395, 0.02f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_ALLEY = getPreset (0, 14, 7.5f, 0.3f, -1000, -270, 0, 1.49f, 0.86f, 1f,
		-1204, 0.007f, NullVector, -4, 0.011f, NullVector, 0.125f, 0.95f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_FOREST = getPreset (0, 15, 38f, 0.3f, -1000, -3300, 0, 1.49f, 0.54f, 1f,
		-2560, 0.162f, NullVector, -229, 0.088f, NullVector, 0.125f, 1f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 79f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_CITY = getPreset (0, 16, 7.5f, 0.5f, -1000, -800, 0, 1.49f, 0.67f, 1f,
		-2273, 0.007f, NullVector, -1691, 0.011f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 50f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_MOUNTAINS = getPreset (0, 17, 100f, 0.27f, -1000, -2500, 0, 1.49f, 0.21f, 1f,
		-2780, 0.3f, NullVector, -1434, 0.1f, NullVector, 0.25f, 1f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 27f, 100f, 0x1f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_QUARRY = getPreset (0, 18, 17.5f, 1f, -1000, -1000, 0, 1.49f, 0.83f, 1f,
		-10000, 0.061f, NullVector, 500, 0.025f, NullVector, 0.125f, 0.7f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PLAIN = getPreset (0, 19, 42.5f, 0.21f, -1000, -2000, 0, 1.49f, 0.5f, 1f,
		-2466, 0.179f, NullVector, -1926, 0.1f, NullVector, 0.25f, 1f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 21f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PARKINGLOT = getPreset (0, 20, 8.3f, 1f, -1000, 0, 0, 1.65f, 1.5f, 1f,
		-1363, 0.008f, NullVector, -1153, 0.012f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x1f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_SEWERPIPE = getPreset (0, 21, 1.7f, 0.8f, -1000, -1000, 0, 2.81f, 0.14f, 1f,
		429, 0.014f, NullVector, 1023, 0.021f, NullVector, 0.25f, 0f, 0.25f, 0f,
		-5f, 5000f, 250f, 0f, 80f, 60f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_UNDERWATER = getPreset (0, 22, 1.8f, 1f, -1000, -4000, 0, 1.49f, 0.1f, 1f,
		-449, 0.007f, NullVector, 1700, 0.011f, NullVector, 0.25f, 0f, 1.18f, 0.348f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x3f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_DRUGGED = getPreset (0, 23, 1.9f, 0.5f, -1000, 0, 0, 8.39f, 1.39f, 1f,
		-115, 0.002f, NullVector, 985, 0.03f, NullVector, 0.25f, 0f, 0.25f, 1f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x1f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_DIZZY = getPreset (0, 24, 1.8f, 0.6f, -1000, -400, 0, 17.23f, 0.56f, 1f,
		-1713, 0.02f, NullVector, -613, 0.03f, NullVector, 0.25f, 1f, 0.81f, 0.31f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x1f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PSYCHOTIC = getPreset (0, 25, 1f, 0.5f, -1000, -151, 0, 7.56f, 0.91f, 1f,
		-626, 0.02f, NullVector, 774, 0.03f, NullVector, 0.25f, 0f, 4f, 1f,
		-5f, 5000f, 250f, 0f, 100f, 100f, 0x1f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_ROOM = getPreset (0, 1, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_STUDIO_A = getPreset (0, 2, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_STUDIO_B = getPreset (0, 3, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_STUDIO_C = getPreset (0, 4, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_HALL = getPreset (0, 5, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_SPACE = getPreset (0, 6, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_ECHO = getPreset (0, 7, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0.75f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_DELAY = getPreset (0, 8, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);
		public static FMOD_REVERB_PROPERTIES REVERB_PRESET_PS2_PIPE = getPreset (0, 9, 0, 0, 0, 0, 0, 0f, 0f, 0f,
		0, 0f, NullVector, 0, 0f, NullVector, 0.25f, 0f, 0f, 0f,
		0f, 0f, 0f, 0f, 0f, 0f, 0x31f);

		#endregion
		#region "Useful/Useless"
		public class tools
		{
			public static float DegToRad (float degree)
			{
				return degree / 180;
			}
			public static float RadToDeg (float rad)
			{
				return rad * 180;
			}
			public static float twoDtoRad (Vector vecXY)
			{
				return Math.Atan (vecXY.Y / vecXY.X);
			}
			public static Vector RadtoTwoD (float rad)
			{
				Vector functionReturnValue = default(Vector);
				functionReturnValue.X = 1;
				functionReturnValue.Z = 0;
				functionReturnValue.Y = Math.Tan (rad);
				return functionReturnValue;
				return functionReturnValue;
			}
		}
		#endregion
		
		
	}
}

