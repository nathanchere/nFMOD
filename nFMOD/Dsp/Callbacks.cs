using System;
using nFMOD.Enums;

namespace nFMOD.Dsp
{
	
	public delegate ErrorCode DspDelegate (ref State dsp_state);
	
	public delegate ErrorCode ReadDelegate (ref State dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);
    
	public delegate ErrorCode SetPositionDelegate (ref State dsp_state, uint seeklen);
    
	public delegate ErrorCode SetParamDelegate (ref State dsp_state, int index, float val);
    
	public delegate ErrorCode GetParamDelegate (ref State dsp_state, int index, ref float val, System.Text.StringBuilder valuestr);
    
	public delegate ErrorCode DialogDelegate (ref State dsp_state, IntPtr hwnd, bool show);

}
