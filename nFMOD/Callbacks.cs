

using System;
using System.Runtime.InteropServices;

namespace nFMOD
{
	public delegate Error.Code File_OpenDelegate ([MarshalAs(UnmanagedType.LPWStr)]string name, int unicode, ref uint filesize, ref IntPtr handle, ref IntPtr userdata);
    public delegate Error.Code File_CloseDelegate (IntPtr handle, IntPtr userdata);
    public delegate Error.Code File_ReadDelegate (IntPtr handle, IntPtr buffer, uint sizebytes, ref uint bytesread, IntPtr userdata);
    public delegate Error.Code File_SeekDelegate (IntPtr handle, int pos, IntPtr userdata);
    public delegate Error.Code File_AsyncReadDelegate (IntPtr handle, IntPtr info, IntPtr userdata);
    public delegate Error.Code File_AsyncCancelDelegate (IntPtr handle, IntPtr userdata);

    public delegate float  CB_3D_RollOffDelegate (IntPtr channelraw, float distance);
	
	
}

