using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Reverb
{
	//TODO end convertion
	
	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Structure defining a reverb environment.<br>
        <br>
        For more indepth descriptions of the reverb properties under win32, please see the EAX2 and EAX3
        documentation at http://developer.creative.com/ under the 'downloads' section.<br>
        If they do not have the EAX3 documentation, then most information can be attained from
        the EAX2 documentation, as EAX3 only adds some more parameters and functionality on top of 
        EAX2.

        [REMARKS]
        Note the default reverb properties are the same as the FMOD_PRESET_GENERIC preset.<br>
        Note that integer values that typically range from -10,000 to 1000 are represented in 
        decibels, and are of a logarithmic scale, not linear, wheras float values are always linear.<br>
        <br>
        The numerical values listed below are the maximum, minimum and default values for each variable respectively.<br>
        <br>
        <b>SUPPORTED</b> next to each parameter means the platform the parameter can be set on.  Some platforms support all parameters and some don't.<br>
        EAX   means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support EAX 1 to 4.<br>
        EAX4  means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support EAX 4.<br>
        I3DL2 means hardware reverb on FMOD_OUTPUTTYPE_DSOUND on windows only (must use FMOD_HARDWARE), on soundcards that support I3DL2 non EAX native reverb.<br>
        GC    means Nintendo Gamecube hardware reverb (must use FMOD_HARDWARE).<br>
        WII   means Nintendo Wii hardware reverb (must use FMOD_HARDWARE).<br>
        PS2   means Playstation 2 hardware reverb (must use FMOD_HARDWARE).<br>
        SFX   means FMOD SFX software reverb.  This works on any platform that uses FMOD_SOFTWARE for loading sounds.<br>
        <br>
        Members marked with [in] mean the user sets the value before passing it to the function.<br>
        Members marked with [out] mean FMOD sets the value to be used after the function exits.<br>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::setReverbProperties
        System::getReverbProperties
        FMOD_REVERB_PRESETS
        FMOD_REVERB_FLAGS
    ]
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct Properties
    {
		/*          MIN     MAX    DEFAULT   DESCRIPTION */
        
		public int   Instance;
		/* [in]     0     , 3     , 0      , EAX4 only. Environment Instance. 3 seperate reverbs simultaneously are possible. This specifies which one to set. (win32 only) */
        
		public int   Environment;
		/* [in/out] -1    , 25    , -1     , sets all listener properties (win32/ps2) */
        
		public float EnvSize;
		/* [in/out] 1.0   , 100.0 , 7.5    , environment size in meters (win32 only) */
        
		public float EnvDiffusion;
		/* [in/out] 0.0   , 1.0   , 1.0    , environment diffusion (win32/xbox) */
        
		public int   Room;
		/* [in/out] -10000, 0     , -1000  , room effect level (at mid frequencies) (win32/xbox) */
        
		public int   RoomHF;
		/* [in/out] -10000, 0     , -100   , relative room effect level at high frequencies (win32/xbox) */
        
		public int   RoomLF;
		/* [in/out] -10000, 0     , 0      , relative room effect level at low frequencies (win32 only) */
        
		public float DecayTime;
		/* [in/out] 0.1   , 20.0  , 1.49   , reverberation decay time at mid frequencies (win32/xbox) */
        
		public float DecayHFRatio;
		/* [in/out] 0.1   , 2.0   , 0.83   , high-frequency to mid-frequency decay time ratio (win32/xbox) */
        
		public float DecayLFRatio;
		/* [in/out] 0.1   , 2.0   , 1.0    , low-frequency to mid-frequency decay time ratio (win32 only) */
        
		public int   Reflections;
		/* [in/out] -10000, 1000  , -2602  , early reflections level relative to room effect (win32/xbox) */
        
		public float ReflectionsDelay;
		/* [in/out] 0.0   , 0.3   , 0.007  , initial reflection delay time (win32/xbox) */
        
		//TODO replace by Vector3
		
		/// <summary>
		/// 
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public float[] ReflectionsPan;
		/* [in/out]       ,       , [0,0,0], early reflections panning vector (win32 only) */
        
		public int   Reverb;
		/* [in/out] -10000, 2000  , 200    , late reverberation level relative to room effect (win32/xbox) */
        
		public float ReverbDelay;
		/* [in/out] 0.0   , 0.1   , 0.011  , late reverberation delay time relative to initial reflection (win32/xbox) */
        
		//TODO replace by Vector3
		
		[MarshalAs(UnmanagedType.ByValArray,SizeConst=3)]
        public float[] ReverbPan;
		/* [in/out]       ,       , [0,0,0], late reverberation panning vector (win32 only) */
        
		public float EchoTime;
		/* [in/out] .075  , 0.25  , 0.25   , echo time (win32 only) */
        
		public float EchoDepth;
		/* [in/out] 0.0   , 1.0   , 0.0    , echo depth (win32 only) */
        
		public float ModulationTime;
		/* [in/out] 0.04  , 4.0   , 0.25   , modulation time (win32 only) */
        
		public float ModulationDepth;
		/* [in/out] 0.0   , 1.0   , 0.0    , modulation depth (win32 only) */
        
		public float AirAbsorptionHF;
		/* [in/out] -100  , 0.0   , -5.0   , change in level per meter at high frequencies (win32 only) */
        
		public float HFReference;
		/* [in/out] 1000.0, 20000 , 5000.0 , reference high frequency (hz) (win32/xbox) */
        
		public float LFReference;
		/* [in/out] 20.0  , 1000.0, 250.0  , reference low frequency (hz) (win32 only) */
        
		public float RoomRolloffFactor;
		/* [in/out] 0.0   , 10.0  , 0.0    , like rolloffscale in System::set3DSettings but for reverb room size effect (win32) */
        
		public float Diffusion;
		/* [in/out] 0.0   , 100.0 , 100.0  , Value that controls the echo density in the late reverberation decay. (xbox only) */
        
		public float Density;
		/* [in/out] 0.0   , 100.0 , 100.0  , Value that controls the modal density in the late reverberation decay (xbox only) */
        
		public Flags Flags;
		/* [in/out] REVERB_FLAGS - modifies the behavior of above properties (win32/ps2) */

		//TODO end subbmary
		

		#region Default Preset
		
		public static readonly Properties Generic = new Properties {
			Instance = 0,
			Environment = -1,
			EnvSize = 7.5,
			EnvDiffusion = 1.0,
			Room = -1000,
			RoomHF = -100,
			RoomLF = 0,
			DecayTime = 1.49,
			DecayHFRatio = 0.83,
			DecayLFRatio = 1.0,
			Reflections = -2602,
			ReflectionsDelay = 0.007,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 200,
			ReverbDelay = 0.011,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.25,
			EchoDepth = 0.0,
			ModulationTime = 0.25,
			ModulationDepth = 0.0,
			AirAbsorptionHF = -5.0,
			HFReference = 5000.0,
			LFReference = 250.0,
			RoomRolloffFactor = 0.0,
			Diffusion = 100.0,
			Density = 100.0,
			Flags Flags.Default
		};
		
		#endregion
		
    }
}

