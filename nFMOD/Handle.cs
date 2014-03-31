using System;
using System.Runtime.InteropServices;

namespace nFMOD
{
	public abstract class Handle : SafeHandle
	{
		public Handle () : this(IntPtr.Zero)
		{
		}
		public Handle (IntPtr Handle) : this(Handle, true)
		{
		}
		public Handle (IntPtr Handle, bool OwnsHandle) : base(IntPtr.Zero, OwnsHandle)
		{
			this.SetHandle(Handle);
		}
		
		public override bool IsInvalid {
			get {
				return (this.handle == IntPtr.Zero || (int)this.handle == -1);
			}
		}
		
	}
}
