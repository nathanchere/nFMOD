using System;

namespace FmodSharp.Dsp
{
	
	    /*
    [ENUM]
    [
        [DESCRIPTION]   
        List of windowing methods used in spectrum analysis to reduce leakage / transient signals intefering with the analysis.
        This is a problem with analysis of continuous signals that only have a small portion of the signal sample (the fft window size).
        Windowing the signal with a curve or triangle tapers the sides of the fft window to help alleviate this problem.

        [REMARKS]
        Cyclic signals such as a sine wave that repeat their cycle in a multiple of the window size do not need windowing.
        I.e. If the sine wave repeats every 1024, 512, 256 etc samples and the FMOD fft window is 1024, then the signal would not need windowing.
        Not windowing is the same as FMOD_DSP_FFT_WINDOW_RECT, which is the default.
        If the cycle of the signal (ie the sine wave) is not a multiple of the window size, it will cause frequency abnormalities, so a different windowing method is needed.
        <exclude>
        
        FMOD_DSP_FFT_WINDOW_RECT.
        <img src = "rectangle.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_TRIANGLE.
        <img src = "triangle.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_HAMMING.
        <img src = "hamming.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_HANNING.
        <img src = "hanning.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_BLACKMAN.
        <img src = "blackman.gif"></img>
        
        FMOD_DSP_FFT_WINDOW_BLACKMANHARRIS.
        <img src = "blackmanharris.gif"></img>
        </exclude>

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]      
        System::getSpectrum
        Channel::getSpectrum
    ]
    */
    public enum FFTWindow :int
    {
        Rectangle,
		// w[n] = 1.0
        
		Triangle,
		// w[n] = TRI(2n/N)
        
		Hamming,
		// w[n] = 0.54 - (0.46 * COS(n/N) )
        
		Hanning,
		// w[n] = 0.5 *  (1.0  - COS(n/N) )
        
		Blackman,
		// w[n] = 0.42 - (0.5  * COS(n/N) ) + (0.08 * COS(2.0 * n/N) )
        
		BlackmanHarris,
		// w[n] = 0.35875 - (0.48829 * COS(1.0 * n/N)) + (0.14128 * COS(2.0 * n/N)) - (0.01168 * COS(3.0 * n/N))

        Max
    }
}

