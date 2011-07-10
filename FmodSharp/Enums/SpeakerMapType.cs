using System;

namespace FmodSharp
{
	/// <summary>
	/// When creating a multichannel sound,
	/// FMOD will pan them to their default speaker locations,
	/// for example a 6 channel sound will default to one channel per 5.1 output speaker.
	/// <br>
	/// Another example is a stereo sound.
	/// It will default to left = front left, right = front right.
	/// <br>
	/// <br>
	/// This is for sounds that are not 'default'.
	/// For example you might have a sound that is 6 channels but actually made up of 3 stereo pairs,
	/// that should all be located in front left, front right only.
	/// </summary>
	/// <remarks>
	/// For full flexibility of speaker assignments, use Channel::setSpeakerLevels.  This functionality is cheaper, uses less memory and easier to use.
	/// </remarks>
	public enum SpeakerMapType
	{
		/// <summary>
		/// This is the default, and just means FMOD decides which speakers it puts the source channels.
		/// </summary>
		Default,
		
		/// <summary>
		/// This means the sound is made up of all mono sounds.
		/// All voices will be panned to the front center by default in this case.
		/// </summary>
		AllMono,
		
		/// <summary>
		/// This means the sound is made up of all stereo sounds.
		/// All voices will be panned to front left and front right alternating every second channel.
		/// </summary>
		AllStereo,
		
		/// <summary>
		/// Map a 5.1 sound to use protools L C R Ls Rs LFE mapping.
		/// Will return an error if not a 6 channel sound.
		/// </summary>
		ProTools51,
	}
	
	//TODO add platform
	//[PLATFORMS]
	//Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii

}

