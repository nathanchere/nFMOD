using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace nFMOD
{
    public abstract class Handle : SafeHandle
    {
        public Handle() : this(IntPtr.Zero) { }
        public Handle(IntPtr Handle) : this(Handle, true) { }
        public Handle(IntPtr Handle, bool OwnsHandle) : base(IntPtr.Zero, OwnsHandle)
        {
            SetHandle(Handle);
        }

        public override bool IsInvalid
        {
            get
            {
                if(handle == IntPtr.Zero || (int)handle == -1) Debugger.Break();
                return (handle == IntPtr.Zero || (int)handle == -1);
            }
        }

    }
}
