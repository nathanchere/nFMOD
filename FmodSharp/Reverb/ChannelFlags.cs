using System;

namespace FmodSharp
{
	
    /*
    [DEFINE] 
    [
        [NAME] 
        REVERB_CHANNELFLAGS

        [DESCRIPTION]
        Values for the Flags member of the REVERB_CHANNELPROPERTIES structure.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        REVERB_CHANNELPROPERTIES
    ]
    */
	[Flags]
	public enum ChannelFlags : uint
	{
		DirectHFAuto  = 0x00000001,
		/* Automatic setting of 'Direct'  due to distance from listener */
        
		RoomAuto      = 0x00000002,
		/* Automatic setting of 'Room'  due to distance from listener */
        
		RoomHFAuto   = 0x00000004,
		/* Automatic setting of 'RoomHF' due to distance from listener */
        
		Instance0     = 0x00000010,
		/* SFX/Wii. Specify channel to target reverb instance 0.  Default target. */
        
		Instance1     = 0x00000020,
		/* SFX/Wii. Specify channel to target reverb instance 1. */
        
		Instance2     = 0x00000040,
		/* SFX/Wii. Specify channel to target reverb instance 2. */
        
		Instance3     = 0x00000080,
		/* SFX. Specify channel to target reverb instance 3. */
		
		Default = (DirectHFAuto | RoomAuto | RoomHFAuto | Instance0)
	}
}

