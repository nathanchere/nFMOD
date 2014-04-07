using System;
namespace nFMOD
{
	public interface ISpectrumWave
	{
		float[] GetSpectrum (int numvalues, int channeloffset, FFTWindow windowtype);
		void GetSpectrum (float[] spectrumarray, int numvalues, int channeloffset, FFTWindow windowtype);

		float[] GetWaveData (int numvalues, int channeloffset);
		void GetWaveData (float[] wavearray, int numvalues, int channeloffset);
		
		bool IsPlaying { get; }
	}
}

