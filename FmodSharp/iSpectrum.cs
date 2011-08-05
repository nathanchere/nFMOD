using System;

namespace FmodSharp
{
	public interface iSpectrum
	{
		float[] GetSpectrum (int numvalues, int channeloffset, Dsp.FFTWindow windowtype);
		
		void GetSpectrum (float[] spectrumarray, int numvalues, int channeloffset, Dsp.FFTWindow windowtype);
	}
}

