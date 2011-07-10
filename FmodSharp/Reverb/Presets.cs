using System;

namespace FmodSharp.Reverb
{
	//TODO end submmary
	//TODO end convertion
	
	/// <summary>
	/// 
	/// </summary>
	public static class Presets
	{
		
		    /*
    [DEFINE] 
    [
    [NAME] 
    FMOD_REVERB_PRESETS

    [DESCRIPTION]   
    A set of predefined environment PARAMETERS, created by Creative Labs
    These are used to initialize an FMOD_REVERB_PROPERTIES structure statically.
    ie 
    FMOD_REVERB_PROPERTIES prop = FMOD_PRESET_GENERIC;

    [PLATFORMS]
    Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

    [SEE_ALSO]
    System::setReverbProperties
    ]
    */
  
		public static Properties Off {
			get {
				return new Properties {
					Instance = 0,
					Environment = -1,
					EnvSize = 7.5f,
					EnvDiffusion = 1.00f,
					Room = -10000,
					RoomHF = -10000,
					RoomLF = 0,
					DecayTime = 1.00f,
					DecayHFRatio = 1.00f,
					DecayLFRatio = 1.0f,
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
					AirAbsorptionHF = -5.0f,
					HFReference = 5000.0f,
					LFReference = 250.0f,
					RoomRolloffFactor = 0.0f,
					Diffusion = 0.0f,
					Density = 0.0f,
					Flags = (Flags)0x33f
				};
			}
		}
		
		/*
		public REVERB_PROPERTIES GENERIC()             { return new REVERB_PROPERTIES(0,       0,    7.5f,   1.00f, -1000,  -100,   0,   1.49f,  0.83f, 1.0f,  -2602, 0.007f, 0.0f,0.0f,0.0f,   200, 0.011f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES PADDEDCELL()          { return new REVERB_PROPERTIES(0,       1,    1.4f,   1.00f, -1000,  -6000,  0,   0.17f,  0.10f, 1.0f,  -1204, 0.001f, 0.0f,0.0f,0.0f,   207, 0.002f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
        public REVERB_PROPERTIES ROOM()                { return new REVERB_PROPERTIES(0,       2,    1.9f,   1.00f, -1000,  -454,   0,   0.40f,  0.83f, 1.0f,  -1646, 0.002f, 0.0f,0.0f,0.0f,    53, 0.003f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 0.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x3f );}
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

        // Non I3DL2 presets

        public REVERB_PROPERTIES DRUGGED()             { return new REVERB_PROPERTIES(0,       23,   1.9f,   0.50f, -1000,  0,      0,   8.39f,  1.39f, 1.0f,  -115,  0.002f, 0.0f,0.0f,0.0f,   985, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 0.25f, 1.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x1f );}
        public REVERB_PROPERTIES DIZZY()               { return new REVERB_PROPERTIES(0,       24,   1.8f,   0.60f, -1000,  -400,   0,   17.23f, 0.56f, 1.0f,  -1713, 0.020f, 0.0f,0.0f,0.0f,  -613, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 1.00f, 0.81f, 0.310f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x1f );}
        public REVERB_PROPERTIES PSYCHOTIC()           { return new REVERB_PROPERTIES(0,       25,   1.0f,   0.50f, -1000,  -151,   0,   7.56f,  0.91f, 1.0f,  -626,  0.020f, 0.0f,0.0f,0.0f,   774, 0.030f, 0.0f,0.0f,0.0f, 0.250f, 0.00f, 4.00f, 1.000f, -5.0f, 5000.0f, 250.0f, 0.0f, 100.0f, 100.0f, 0x1f );}

        // PlayStation 2 Only presets

        public REVERB_PROPERTIES PS2_ROOM()            { return new REVERB_PROPERTIES(0,       1,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_STUDIO_A()        { return new REVERB_PROPERTIES(0,       2,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_STUDIO_B()        { return new REVERB_PROPERTIES(0,       3,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_STUDIO_C()        { return new REVERB_PROPERTIES(0,       4,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_HALL()            { return new REVERB_PROPERTIES(0,       5,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_SPACE()           { return new REVERB_PROPERTIES(0,       6,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_ECHO()            { return new REVERB_PROPERTIES(0,       7,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_DELAY()           { return new REVERB_PROPERTIES(0,       8,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
        public REVERB_PROPERTIES PS2_PIPE()            { return new REVERB_PROPERTIES(0,       9,    0,     0,         0,  0,      0,   0.0f,   0.0f,  0.0f,     0,  0.000f,  0.0f,0.0f,0.0f ,     0, 0.000f,  0.0f,0.0f,0.0f , 0.000f, 0.00f, 0.00f, 0.000f,  0.0f, 0000.0f,   0.0f, 0.0f,   0.0f,   0.0f, 0x31f );}
		*/
	}
}

