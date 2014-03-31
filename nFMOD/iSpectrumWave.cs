using System;
namespace nFMOD
{
	public interface iSpectrumWave
	{
		float[] GetSpectrum (int numvalues, int channeloffset, Dsp.FFTWindow windowtype);
		void GetSpectrum (float[] spectrumarray, int numvalues, int channeloffset, Dsp.FFTWindow windowtype);

		float[] GetWaveData (int numvalues, int channeloffset);
		void GetWaveData (float[] wavearray, int numvalues, int channeloffset);
		
		bool IsPlaying { get; }
	}
}

