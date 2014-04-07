using System;

namespace nFMOD
{
    public partial class Reverb
    {        
        /// <summary>        
        /// Values for the Flags member of the REVERB_CHANNELPROPERTIES structure.
        /// </summary>
        [Flags]
        public enum ChannelFlags : uint
        {
            DirectHFAuto = 0x00000001,
            /* Automatic setting of 'Direct'  due to distance from listener */

            RoomAuto = 0x00000002,
            /* Automatic setting of 'Room'  due to distance from listener */

            RoomHFAuto = 0x00000004,
            /* Automatic setting of 'RoomHF' due to distance from listener */

            Instance0 = 0x00000010,
            /* SFX/Wii. Specify channel to target reverb instance 0.  Default target. */

            Instance1 = 0x00000020,
            /* SFX/Wii. Specify channel to target reverb instance 1. */

            Instance2 = 0x00000040,
            /* SFX/Wii. Specify channel to target reverb instance 2. */

            Instance3 = 0x00000080,
            /* SFX. Specify channel to target reverb instance 3. */

            Default = (DirectHFAuto | RoomAuto | RoomHFAuto | Instance0)
        }

        /*
    [DEFINE] 
    [
        [NAME] 
        REVERB_FLAGS

        [DESCRIPTION]
        

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        REVERB_PROPERTIES
    ]
    */

        /// <summary>
        /// Values for the Flags member of the REVERB_PROPERTIES structure.
        /// </summary>
        [Flags]
        public enum Flags : uint
        {
            /// <summary>
            /// 'EnvSize' affects reverberation decay time
            /// </summary>
            DecayTimeScale = 0x00000001,

            /// <summary>
            /// 'EnvSize' affects reflection level
            /// </summary>
            ReflectionsScale = 0x00000002,

            /// <summary>
            /// 'EnvSize' affects initial reflection delay time
            /// </summary>
            ReflectionsDelayScale = 0x00000004,

            /// <summary>
            /// 'EnvSize' affects reflections level
            /// </summary>
            ReverbScale = 0x00000008,

            /// <summary>
            /// 'EnvSize' affects late reverberation delay time
            /// </summary>
            ReverbDelayScale = 0x00000010,

            /// <summary>
            /// AirAbsorptionHF affects DecayHFRatio
            /// </summary>
            DecayHFLimit = 0x00000020,

            /// <summary>
            /// 'EnvSize' affects echo time
            /// </summary>
            EchoTimeScale = 0x00000040,

            /// <summary>
            /// 'EnvSize' affects modulation time
            /// </summary>
            ModulationTimeScale = 0x00000080,

            /// <summary>
            /// 
            /// </summary>
            /// <remarks>
            /// Is equal to 0x3F
            /// </remarks>
            Default = DecayTimeScale | ReflectionsScale |
                      ReflectionsDelayScale | ReverbScale |
                      ReverbDelayScale | DecayHFLimit
        }
    }

    //TODO complete submmary.
}