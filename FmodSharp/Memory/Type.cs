using System;

namespace FmodSharp.Memory
{
	
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
        NORMAL           = 0x00000000,       /* Standard memory. */
        STREAM_FILE      = 0x00000001,       /* Stream file buffer, size controllable with System::setStreamBufferSize. */
        STREAM_DECODE    = 0x00000002,       /* Stream decode buffer, size controllable with FMOD_CREATESOUNDEXINFO::decodebuffersize. */
        XBOX360_PHYSICAL = 0x00100000,       /* Requires XPhysicalAlloc / XPhysicalFree. */
        PERSISTENT       = 0x00200000,       /* Persistent memory. Memory will be freed when System::release is called. */
        SECONDARY        = 0x00400000        /* Secondary memory. Allocation should be in secondary memory. For example RSX on the PS3. */
    }
}

