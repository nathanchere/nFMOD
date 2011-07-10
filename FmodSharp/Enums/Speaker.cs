using System;

namespace FmodSharp
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
    public enum Speaker :int
    {
        FRONT_LEFT,
        FRONT_RIGHT,
        FRONT_CENTER,
        LOW_FREQUENCY,
        BACK_LEFT,
        BACK_RIGHT,
        SIDE_LEFT,
        SIDE_RIGHT,
    
        MAX,
		/* Maximum number of speaker types supported. */
        MONO        = FRONT_LEFT,
		/* For use with FMOD_SPEAKERMODE_MONO and Channel::SetSpeakerLevels.
		 * Mapped to same value as FMOD_SPEAKER_FRONT_LEFT. */
        
		NULL        = MAX,
		/* A non speaker.  Use this to send. */
        
		SBL         = SIDE_LEFT,
		/* For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers. */
        
		SBR         = SIDE_RIGHT,
		/* For use with FMOD_SPEAKERMODE_7POINT1 on PS3 where the extra speakers are surround back inside of side speakers. */
    }
}

