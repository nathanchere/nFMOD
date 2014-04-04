using System.Runtime.InteropServices;

namespace nFMOD
{	
	/// <summary>
	/// Structure describing a point in 3D space.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector3
	{
		public float X;
		public float Y;
		public float Z;
	}
	
}
