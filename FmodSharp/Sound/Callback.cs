using System;

namespace FmodSharp.Sound
{
	public delegate Error.Code NonBlockDelegate (IntPtr soundraw, Error.Code result);
	public delegate Error.Code PCMReadDelegate (IntPtr soundraw, IntPtr data, uint datalen);
	public delegate Error.Code PCMSetposDelegate (IntPtr soundraw, int subsound, uint position, TimeUnit postype);
	
}

