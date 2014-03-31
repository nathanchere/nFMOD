using System;

namespace nFMOD
{
	//TODO end convertion
	
	/*
    [ENUM]
    [
        [DESCRIPTION]   


        [REMARKS]
        If you are using FMOD_SPEAKERMODE_RAW and speaker assignments are meaningless, just cast a raw integer value to this type.<br>
        For example (FMOD_SPEAKER)7 would use the 7th speaker (also the same as FMOD_SPEAKER_SIDE_RIGHT).<br>
        Values higher than this can be used if an output system has more than 8 speaker types / output channels.  15 is the current maximum.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        FMOD_SPEAKERMODE
        Channel::setSpeakerLevels
        Channel::getSpeakerLevels
        System::setSpeakerPosition
        System::getSpeakerPosition
    ]
    */
	
	/// <summary>
	/// These are speaker types defined for use with the Channel::setSpeakerLevels command.
	/// It can also be used for speaker placement in the System::setSpeakerPosition command.
	/// </summary>
    public enum Speaker : int
    {
		FrontLeft,
		FrontRight,
		FrontCenter,
		LowFrequency,
		BackLeft,
		BackRight,
		SideLeft,
		SideRight,
		
		/// <summary>
		/// Maximum number of speaker types supported.
		/// </summary>
		Max,
		
		/// <summary>
		/// For use with FMOD_SPEAKERMODE_MONO and Channel::SetSpeakerLevels.
		/// Mapped to same value as FMOD_SPEAKER_FRONT_LEFT.
		/// </summary>
		Mono = FrontLeft,
		
		/// <summary>
		/// A non speaker.  Use this to send.
		/// </summary>
		Null = Max,
		
		/// <summary>
		/// For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers.
		/// </summary>
		SBL = SideLeft,
		
		/// <summary>
		/// For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers.
		/// </summary>
		SBR = SideRight,
		
	}
}

