using System;
using System.Runtime.InteropServices;

// Members marked with [in] mean the user sets the value before passing it to the function.
// Members marked with [out] mean FMOD sets the value to be used after the function exits.
namespace nFMOD
{           
    [StructLayout(LayoutKind.Sequential)]
	public struct Vector3
	{
		public float X;
		public float Y;
		public float Z;
	}	

    /// <summary>
    /// Structure describing a piece of tag data.
    /// </summary>    
    [StructLayout(LayoutKind.Sequential)]
    public struct Tag
    {
        /// <summary>
        /// [out] The type of this tag
        /// </summary>
        public TagType type;

        /// <summary>
        /// [out] The type of data that this tag contains
        /// </summary>
        public TagDataType datatype;

        /// <summary>
        /// [out] The name of this tag i.e. "TITLE", "ARTIST" etc
        /// </summary>
        public IntPtr namePtr;

        /// <summary>
        /// [out] Pointer to the tag data - its format is determined by the datatype member
        /// </summary>
        public IntPtr data;

        /// <summary>
        /// [out] Length of the data contained in this tag
        /// </summary>
        public uint datalen;

        /// <summary>
        /// [out] True if this tag has been updated since last being accessed with Sound::getTag
        /// </summary>
        public bool updated;

        public string name { get { return Marshal.PtrToStringAnsi(namePtr); } }
    }
}
