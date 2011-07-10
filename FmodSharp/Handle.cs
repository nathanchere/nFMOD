using System;
using System.Runtime.InteropServices;

namespace FmodSharp
{
	public abstract class Handle : SafeHandle
	{
		public Handle () : this(true)
		{
		}
		public Handle (bool OwnsHandle) : base(IntPtr.Zero, OwnsHandle)
		{
		}
		
		public override bool IsInvalid {
			get {
				return (this.handle == IntPtr.Zero || (int)this.handle == -1);
			}
		}
	}
	
}
