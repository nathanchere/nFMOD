using System;

namespace nFMOD.Dsp
{
	
	public delegate Error.Code DspDelegate (ref State dsp_state);
	
	public delegate Error.Code ReadDelegate (ref State dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);
    
	public delegate Error.Code SetPositionDelegate (ref State dsp_state, uint seeklen);
    
	public delegate Error.Code SetParamDelegate (ref State dsp_state, int index, float val);
    
	public delegate Error.Code GetParamDelegate (ref State dsp_state, int index, ref float val, System.Text.StringBuilder valuestr);
    
	public delegate Error.Code DialogDelegate (ref State dsp_state, IntPtr hwnd, bool show);

}
