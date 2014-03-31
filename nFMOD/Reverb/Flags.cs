using System;

namespace nFMOD.Reverb
{
	
	/*
    [DEFINE] 
    [
        [NAME] 
        REVERB_FLAGS

        [DESCRIPTION]
        

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        REVERB_PROPERTIES
    ]
    */
	
	/// <summary>
	/// Values for the Flags member of the REVERB_PROPERTIES structure.
	/// </summary>
    [Flags]
    public enum Flags : uint
	{
		/// <summary>
		/// 'EnvSize' affects reverberation decay time
		/// </summary>
		DecayTimeScale = 0x00000001,
        
		/// <summary>
		/// 'EnvSize' affects reflection level
		/// </summary>
		ReflectionsScale = 0x00000002,
        
		/// <summary>
		/// 'EnvSize' affects initial reflection delay time
		/// </summary>
		ReflectionsDelayScale = 0x00000004,
        
		/// <summary>
		/// 'EnvSize' affects reflections level
		/// </summary>
		ReverbScale = 0x00000008,
        
		/// <summary>
		/// 'EnvSize' affects late reverberation delay time
		/// </summary>
		ReverbDelayScale = 0x00000010,
        
		/// <summary>
		/// AirAbsorptionHF affects DecayHFRatio
		/// </summary>
		DecayHFLimit = 0x00000020,
        
		/// <summary>
		/// 'EnvSize' affects echo time
		/// </summary>
		EchoTimeScale = 0x00000040,
        
		/// <summary>
		/// 'EnvSize' affects modulation time
		/// </summary>
		ModulationTimeScale = 0x00000080,
        
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// Is equal to 0x3F
		/// </remarks>
		Default = DecayTimeScale | ReflectionsScale | 
		ReflectionsDelayScale | ReverbScale | 
		ReverbDelayScale | DecayHFLimit
	}
}

//TODO complete submmary.
