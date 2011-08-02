using System;

namespace FmodSharp.Reverb
{
	//TODO end submmary
	
	/*
    [PLATFORMS]
    Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

    [SEE_ALSO]
    System::setReverbProperties
    ]
	 */
	
	//TODO end convertion
	
	/// <summary>
	/// A set of predefined environment PARAMETERS, created by Creative Labs
	/// These are used to initialize an FMOD_REVERB_PROPERTIES structure statically.
	/// ie 
	/// FMOD_REVERB_PROPERTIES prop = FMOD_PRESET_GENERIC;
	/// </summary>
	public static class Presets
	{
		
		public static readonly Properties Off = new Properties {
			Instance = 0,
			Environment = -1,
			EnvironmentSize = 7.5f,
			EnvironmentDiffusion = 1.00f,
			Room = -10000,
			RoomHighFrequencies = -10000,
			RoomLowFrequencies = 0,
			DecayTime = 1.00f,
			DecayHighFrequencyRatio = 1.00f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -2602,
			ReflectionsDelay = 0.007f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 200,
			ReverbDelay = 0.011f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 0.00f,
			ModulationTime = 0.25f,
			ModulationDepth = 0.000f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 0.0f,
			Density = 0.0f,
			//TODO Find documentation about the Flag 0x33F.
			Flags = (Flags)0x33F
		};
		
		public static readonly Properties Generic = new Properties {
			Instance = 0,
			Environment = 0,
			EnvironmentSize = 7.5f,
			EnvironmentDiffusion = 1.00f,
			Room = -1000,
			RoomHighFrequencies = -100,
			RoomLowFrequencies = 0,
			DecayTime = 1.49f,
			DecayHighFrequencyRatio = 0.83f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -2602,
			ReflectionsDelay = 0.007f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 200,
			ReverbDelay = 0.011f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 0.00f,
			ModulationTime = 0.25f,
			ModulationDepth = 0.000f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 100.0f,
			Density = 100.0f,
			Flags = Flags.Default
		};
		
		public static readonly Properties PaddedCell = new Properties {
			Instance = 0,
			Environment = 1,
			EnvironmentSize = 1.4f,
			EnvironmentDiffusion = 1.00f,
			Room = -1000,
			RoomHighFrequencies = -6000,
			RoomLowFrequencies = 0,
			DecayTime = 0.17f,
			DecayHighFrequencyRatio = 0.10f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -1204,
			ReflectionsDelay = 0.001f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 207,
			ReverbDelay = 0.002f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 0.00f,
			ModulationTime = 0.25f,
			ModulationDepth = 0.000f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 100.0f,
			Density = 100.0f,
			Flags = Flags.Default
		};
		
		public static readonly Properties Room = new Properties {
			Instance = 0,
			Environment = 2,
			EnvironmentSize = 1.9f,
			EnvironmentDiffusion = 1.00f,
			Room = -1000,
			RoomHighFrequencies = -454,
			RoomLowFrequencies = 0,
			DecayTime = 0.40f,
			DecayHighFrequencyRatio = 0.83f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -1646,
			ReflectionsDelay = 0.002f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 53,
			ReverbDelay = 0.003f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 0.00f,
			ModulationTime = 0.25f,
			ModulationDepth = 0.000f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 100.0f,
			Density = 100.0f,
			Flags = Flags.Default
		};
		
		/*
		public REVERB_PROPERTIES BATHROOM()            { return new REVERB_PROPERTIES(0,       3,    1.4f,   1.00f, -1000,  -1200,  0,   1.49f,  0.54f, 1.0f,   -370, 0.007f, 0.0f,0.0f,0.0f,  1030, 0.011f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f,  60.0f, 0x3f );}
        public REVERB_PROPERTIES LIVINGROOM()          { return new REVERB_PROPERTIES(0,       4,    2.5f,   1.00f, -1000,  -6000,  0,   0.50f,  0.10f, 1.0f,  -1376, 0.003f, 0.0f,0.0f,0.0f, -1104, 0.004f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES STONEROOM()           { return new REVERB_PROPERTIES(0,       5,    11.6f,  1.00f, -1000,  -300,   0,   2.31f,  0.64f, 1.0f,   -711, 0.012f, 0.0f,0.0f,0.0f,    83, 0.017f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES AUDITORIUM()          { return new REVERB_PROPERTIES(0,       6,    21.6f,  1.00f, -1000,  -476,   0,   4.32f,  0.59f, 1.0f,   -789, 0.020f, 0.0f,0.0f,0.0f,  -289, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES CONCERTHALL()         { return new REVERB_PROPERTIES(0,       7,    19.6f,  1.00f, -1000,  -500,   0,   3.92f,  0.70f, 1.0f,  -1230, 0.020f, 0.0f,0.0f,0.0f,    -2, 0.029f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES CAVE()                { return new REVERB_PROPERTIES(0,       8,    14.6f,  1.00f, -1000,  0,      0,   2.91f,  1.30f, 1.0f,   -602, 0.015f, 0.0f,0.0f,0.0f,  -302, 0.022f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x1f );}
        public REVERB_PROPERTIES ARENA()               { return new REVERB_PROPERTIES(0,       9,    36.2f,  1.00f, -1000,  -698,   0,   7.24f,  0.33f, 1.0f,  -1166, 0.020f, 0.0f,0.0f,0.0f,    16, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES HANGAR()              { return new REVERB_PROPERTIES(0,       10,   50.3f,  1.00f, -1000,  -1000,  0,   10.05f, 0.23f, 1.0f,   -602, 0.020f, 0.0f,0.0f,0.0f,   198, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES CARPETTEDHALLWAY()    { return new REVERB_PROPERTIES(0,       11,   1.9f,   1.00f, -1000,  -4000,  0,   0.30f,  0.10f, 1.0f,  -1831, 0.002f, 0.0f,0.0f,0.0f, -1630, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES HALLWAY()             { return new REVERB_PROPERTIES(0,       12,   1.8f,   1.00f, -1000,  -300,   0,   1.49f,  0.59f, 1.0f,  -1219, 0.007f, 0.0f,0.0f,0.0f,   441, 0.011f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES STONECORRIDOR()       { return new REVERB_PROPERTIES(0,       13,   13.5f,  1.00f, -1000,  -237,   0,   2.70f,  0.79f, 1.0f,  -1214, 0.013f, 0.0f,0.0f,0.0f,   395, 0.020f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES ALLEY()               { return new REVERB_PROPERTIES(0,       14,   7.5f,   0.30f, -1000,  -270,   0,   1.49f,  0.86f, 1.0f,  -1204, 0.007f, 0.0f,0.0f,0.0f,    -4, 0.011f, 0.0f,0.0f,0.0f, 0.125f, 0.95f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES FOREST()              { return new REVERB_PROPERTIES(0,       15,   38.0f,  0.30f, -1000,  -3300,  0,   1.49f,  0.54f, 1.0f,  -2560, 0.162f, 0.0f,0.0f,0.0f,  -229, 0.088f, 0.0f,0.0f,0.0f, 0.125f, 1.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f,  79.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES CITY()                { return new REVERB_PROPERTIES(0,       16,   7.5f,   0.50f, -1000,  -800,   0,   1.49f,  0.67f, 1.0f,  -2273, 0.007f, 0.0f,0.0f,0.0f, -1691, 0.011f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f,  50.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES MOUNTAINS()           { return new REVERB_PROPERTIES(0,       17,   100.0f, 0.27f, -1000,  -2500,  0,   1.49f,  0.21f, 1.0f,  -2780, 0.300f, 0.0f,0.0f,0.0f, -1434, 0.100f, 0.0f,0.0f,0.0f, 0.250f, 1.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f,  27.0f, 100.0f, 0x1f );}
        public REVERB_PROPERTIES QUARRY()              { return new REVERB_PROPERTIES(0,       18,   17.5f,  1.00f, -1000,  -1000,  0,   1.49f,  0.83f, 1.0f, -10000, 0.061f, 0.0f,0.0f,0.0f,   500, 0.025f, 0.0f,0.0f,0.0f, 0.125f, 0.70f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES PLAIN()               { return new REVERB_PROPERTIES(0,       19,   42.5f,  0.21f, -1000,  -2000,  0,   1.49f,  0.50f, 1.0f,  -2466, 0.179f, 0.0f,0.0f,0.0f, -1926, 0.100f, 0.0f,0.0f,0.0f, 0.250f, 1.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f,  21.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES PARKINGLOT()          { return new REVERB_PROPERTIES(0,       20,   8.3f,   1.00f, -1000,  0,      0,   1.65f,  1.50f, 1.0f,  -1363, 0.008f, 0.0f,0.0f,0.0f, -1153, 0.012f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x1f );}
        public REVERB_PROPERTIES SEWERPIPE()           { return new REVERB_PROPERTIES(0,       21,   1.7f,   0.80f, -1000,  -1000,  0,   2.81f,  0.14f, 1.0f,    429, 0.014f, 0.0f,0.0f,0.0f,  1023, 0.021f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f,  80.0f,  60.0f, 0x3f );}
        public REVERB_PROPERTIES UNDERWATER()          { return new REVERB_PROPERTIES(0,       22,   1.8f,   1.00f, -1000,  -4000,  0,   1.49f,  0.10f, 1.0f,   -449, 0.007f, 0.0f,0.0f,0.0f,  1700, 0.011f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 1.18f, 0.348f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
		 */
		
		
		#region Non I3DL2 presets
		
		public static readonly Properties Drugged = new Properties {
			Instance = 0,
			Environment = 23,
			EnvironmentSize = 1.9f,
			EnvironmentDiffusion = 0.50f,
			Room = -1000,
			RoomHighFrequencies = 0,
			RoomLowFrequencies = 0,
			DecayTime = 8.39f,
			DecayHighFrequencyRatio = 1.39f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -115,
			ReflectionsDelay = 0.002f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 985,
			ReverbDelay = 0.030f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 0.00f,
			ModulationTime = 0.25f,
			ModulationDepth = 1.000f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 100.0f,
			Density = 100.0f,
			Flags = Flags.DecayTimeScale | Flags.ReflectionsScale | 
			Flags.ReflectionsDelayScale | Flags.ReverbScale | Flags.ReverbDelayScale
		};
		
		public static readonly Properties Dizzy = new Properties {
			Instance = 0,
			Environment = 24,
			EnvironmentSize = 1.8f,
			EnvironmentDiffusion = 0.60f,
			Room = -1000,
			RoomHighFrequencies = -400,
			RoomLowFrequencies = 0,
			DecayTime = 17.23f,
			DecayHighFrequencyRatio = 0.56f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -1713,
			ReflectionsDelay = 0.020f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = -613,
			ReverbDelay = 0.030f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 1.00f,
			ModulationTime = 0.81f,
			ModulationDepth = 0.310f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 100.0f,
			Density = 100.0f,
			Flags = Flags.DecayTimeScale | Flags.ReflectionsScale | 
			Flags.ReflectionsDelayScale | Flags.ReverbScale | Flags.ReverbDelayScale
		};
		
		public static readonly Properties Psychotic = new Properties {
			Instance = 0,
			Environment = 25,
			EnvironmentSize = 1.0f,
			EnvironmentDiffusion = 0.50f,
			Room = -1000,
			RoomHighFrequencies = -151,
			RoomLowFrequencies = 0,
			DecayTime = 7.56f,
			DecayHighFrequencyRatio = 0.91f,
			DecayLowFrequencyRatio = 1.0f,
			Reflections = -626,
			ReflectionsDelay = 0.020f,
			ReflectionsPan = new float[] { 0.0f, 0.0f, 0.0f },
			Reverb = 774,
			ReverbDelay = 0.030f,
			ReverbPan = new float[] { 0.0f, 0.0f, 0.0f },
			EchoTime = 0.250f,
			EchoDepth = 0.00f,
			ModulationTime = 4.00f,
			ModulationDepth = 1.000f,
			AirAbsorptionHighFrequencies = -5.0f,
			HighFrequencyReference = 5000.0f,
			LowFrequencyReference = 250.0f,
			RoomRolloffFactor = 0.0f,
			Diffusion = 100.0f,
			Density = 100.0f,
			Flags = Flags.DecayTimeScale | Flags.ReflectionsScale | 
			Flags.ReflectionsDelayScale | Flags.ReverbScale | Flags.ReverbDelayScale
		};
		
		#endregion
		
		#region PlayStation 2 Only presets
		
		public static readonly Properties PS2_Room = new Properties {
			Environment = 1,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Studio_A = new Properties {
			Environment = 2,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Studio_B = new Properties {
			Environment = 3,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Studio_C = new Properties {
			Environment = 4,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Hall = new Properties {
			Environment = 5,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Space = new Properties {
			Environment = 6,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Echo = new Properties {
			Environment = 7,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Delay = new Properties {
			Environment = 8,
			Flags = (Flags)0x31f
		};
		
		public static readonly Properties PS2_Pipe = new Properties {
			Environment = 9,
			Flags = (Flags)0x31f
		};
		
		#endregion
		
	}
}

