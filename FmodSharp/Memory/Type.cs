using System;

namespace FmodSharp.Memory
{
	//TODO complete submmary
	
	    /*
    [DEFINE] 
    [
        [NAME]
        FMOD_MEMORY_TYPE

        [DESCRIPTION]   
        Bit fields for memory allocation type being passed into FMOD memory callbacks.

        [REMARKS]

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        FMOD_MEMORY_ALLOCCALLBACK
        FMOD_MEMORY_REALLOCCALLBACK
        FMOD_MEMORY_FREECALLBACK
        Memory_Initialize
    
    ]
    */
    public enum Type
    {
        /// <summary>
		/// Standard memory.
		/// </summary>
		Normal = 0x00000000,
		
		/// <summary>
		/// Stream file buffer, size controllable with System::setStreamBufferSize.
		/// </summary>
		StreamFile = 0x00000001,
		
		/// <summary>
		/// Stream decode buffer, size controllable with FMOD_CREATESOUNDEXINFO::decodebuffersize.
		/// </summary>
		StreamDecode = 0x00000002,
		
		/// <summary>
		/// Requires XPhysicalAlloc / XPhysicalFree.
		/// </summary>
		Xbox360_Physical = 0x00100000,
		
		/// <summary>
		/// Persistent memory. Memory will be freed when System::release is called.
		/// </summary>
		Persistent = 0x00200000,
		
		/// <summary>
		/// Secondary memory. Allocation should be in secondary memory. For example RSX on the PS3.
		/// </summary>
		Secondary = 0x00400000
	}
}

