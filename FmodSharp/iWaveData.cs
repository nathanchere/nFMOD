using System;

namespace FmodSharp
{
	public interface iWaveData
	{
		float[] GetWaveData (int numvalues, int channeloffset);
		
		void GetWaveData (float[] wavearray, int numvalues, int channeloffset);
	}
}

