using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace nFMOD
{
    #region Sound
    public delegate ErrorCode NonBlockDelegate(IntPtr soundraw, ErrorCode result);
    public delegate ErrorCode PCMReadDelegate(IntPtr soundraw, IntPtr data, uint datalen);
    public delegate ErrorCode PCMSetposDelegate(IntPtr soundraw, int subsound, uint position, TimeUnit postype);
    #endregion

    #region SoundSystem
    public delegate void SystemDelegate(SoundSystem system);

    public delegate ErrorCode File_OpenDelegate([MarshalAs(UnmanagedType.LPWStr)]string name, int unicode, ref uint filesize, ref IntPtr handle, ref IntPtr userdata);
    public delegate ErrorCode File_CloseDelegate(IntPtr handle, IntPtr userdata);
    public delegate ErrorCode File_ReadDelegate(IntPtr handle, IntPtr buffer, uint sizebytes, ref uint bytesread, IntPtr userdata);
    public delegate ErrorCode File_SeekDelegate(IntPtr handle, int pos, IntPtr userdata);
    public delegate ErrorCode File_AsyncReadDelegate(IntPtr handle, IntPtr info, IntPtr userdata);
    public delegate ErrorCode File_AsyncCancelDelegate(IntPtr handle, IntPtr userdata);

    public delegate float System_3D_RollOffDelegate(IntPtr channelraw, float distance);
    #endregion

    #region DSP
    //TODO: name these better / more consistently
    public delegate ErrorCode DspDelegate(ref DspState dsp_state);
    public delegate ErrorCode ReadDelegate(ref DspState dsp_state, IntPtr inbuffer, IntPtr outbuffer, uint length, int inchannels, int outchannels);
    public delegate ErrorCode SetPositionDelegate(ref DspState dsp_state, uint seeklen);
    public delegate ErrorCode SetParamDelegate(ref DspState dsp_state, int index, float val);
    public delegate ErrorCode GetParamDelegate(ref DspState dsp_state, int index, ref float val, StringBuilder valuestr);
    public delegate ErrorCode DialogDelegate(ref DspState dsp_state, IntPtr hwnd, bool show);
    #endregion
}
