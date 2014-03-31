using System;

namespace nFMOD.Dsp
{
	//TODO end subbmary
	
	/*
    [ENUM]
    [
        [REMARKS]
        The default resampler type is FMOD_DSP_RESAMPLER_LINEAR.<br>
        Use System::setSoftwareFormat to tell FMOD the resampling quality you require for FMOD_SOFTWARE based sounds.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::setSoftwareFormat
        System::getSoftwareFormat
    ]
    */
	
	/// <summary>
	/// List of interpolation types that the FMOD Ex software mixer supports.
	/// </summary>
    public enum Resampler : int
    {
		/// <summary>
		/// High frequency aliasing hiss will be audible depending on the sample rate of the sound.
		/// </summary>
		NoInterpolation,
        
		/// <summary>
		/// Fast and good quality, causes very slight lowpass effect on low frequency sounds.
		/// (default method)
		/// </summary>
		Linear,
		
		/// <summary>
		/// Slower than linear interpolation but better quality.
		/// </summary>
		Cubic,
		
		/// <summary>
		/// 5 point spline interpolation.
		/// Slowest resampling method but best quality.
		/// </summary>
		Spline,
		
		/// <summary>
		/// Maximum number of resample methods supported.
		/// </summary>
		Max,
	}
}
