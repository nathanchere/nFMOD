using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Sound
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Info
	{
		/// <summary>
		/// [in] Size of this structure.
		/// This is used so the structure can be expanded in the future and still work on older versions of FMOD Ex.
		/// </summary>
		public int cbsize;
		
		/// <summary>
		/// [in] Optional. Specify 0 to ignore.
		/// Size in bytes of file to load, or sound to create (in this case only if FMOD_OPENUSER is used).
		/// Required if loading from memory.
		/// If 0 is specified, then it will use the size of the file (unless loading from memory then an error will be returned).
		/// </summary>
		public uint length;
		
		/// <summary>
		/// [in] Optional. Specify 0 to ignore.
		/// Offset from start of the file to start loading from.
		/// This is useful for loading files from inside big data files.
		/// </summary>
		public uint fileoffset;
		
		/// <summary>
		/// 
		/// </summary>
		public int numchannels;
		/* [in] Optional. Specify 0 to ignore. Number of channels in a sound specified only if OPENUSER is used. */

		/// <summary>
		/// 
		/// </summary>
		public int defaultfrequency;
		/* [in] Optional. Specify 0 to ignore. Default frequency of sound in a sound specified only if OPENUSER is used.  Other formats use the frequency determined by the file format. */

		/// <summary>
		/// 
		/// </summary>
		public Format format;
		/* [in] Optional. Specify 0 or SOUND_FORMAT_NONE to ignore. Format of the sound specified only if OPENUSER is used.  Other formats use the format determined by the file format.   */

		/// <summary>
		/// 
		/// </summary>
		public uint decodebuffersize;
		/* [in] Optional. Specify 0 to ignore. For streams.  This determines the size of the double buffer (in PCM samples) that a stream uses.  Use this for user created streams if you want to determine the size of the callback buffer passed to you.  Specify 0 to use FMOD's default size which is currently equivalent to 400ms of the sound format created/loaded. */

		/// <summary>
		/// 
		/// </summary>
		public int initialsubsound;
		/* [in] Optional. Specify 0 to ignore. In a multi-sample file format such as .FSB/.DLS/.SF2, specify the initial subsound to seek to, only if CREATESTREAM is used. */

		/// <summary>
		/// 
		/// </summary>
		public int numsubsounds;
		/* [in] Optional. Specify 0 to ignore or have no subsounds.  In a user created multi-sample sound, specify the number of subsounds within the sound that are accessable with Sound::getSubSound / SoundGetSubSound. */

		/// <summary>
		/// 
		/// </summary>
		public IntPtr inclusionlist;
		/* [in] Optional. Specify 0 to ignore. In a multi-sample format such as .FSB/.DLS/.SF2 it may be desirable to specify only a subset of sounds to be loaded out of the whole file.  This is an array of subsound indicies to load into memory when created. */

		/// <summary>
		/// 
		/// </summary>
		public int inclusionlistnum;
		/* [in] Optional. Specify 0 to ignore. This is the number of integers contained within the */

		/// <summary>
		/// 
		/// </summary>
		public PCMReadDelegate pcmreadcallback;
		/* [in] Optional. Specify 0 to ignore. Callback to 'piggyback' on FMOD's read functions and accept or even write PCM data while FMOD is opening the sound.  Used for user sounds created with OPENUSER or for capturing decoded data as FMOD reads it. */

		/// <summary>
		/// 
		/// </summary>
		public PCMSetposDelegate pcmsetposcallback;
		/* [in] Optional. Specify 0 to ignore. Callback for when the user calls a seeking function such as Channel::setPosition within a multi-sample sound, and for when it is opened.*/

		/// <summary>
		/// 
		/// </summary>
		public NonBlockDelegate nonblockcallback;
		/* [in] Optional. Specify 0 to ignore. Callback for successful completion, or error while loading a sound that used the FMOD_NONBLOCKING flag.*/

		/// <summary>
		/// 
		/// </summary>
		public string dlsname;
		/* [in] Optional. Specify 0 to ignore. Filename for a DLS or SF2 sample set when loading a MIDI file.   If not specified, on windows it will attempt to open /windows/system32/drivers/gm.dls, otherwise the MIDI will fail to open.  */

		/// <summary>
		/// 
		/// </summary>
		public string encryptionkey;
		/* [in] Optional. Specify 0 to ignore. Key for encrypted FSB file.  Without this key an encrypted FSB file will not load. */

		/// <summary>
		/// 
		/// </summary>
		public int maxpolyphony;
		/* [in] Optional. Specify 0 to ingore. For sequenced formats with dynamic channel allocation such as .MID and .IT, this specifies the maximum voice count allowed while playing.  .IT defaults to 64.  .MID defaults to 32. */

		/// <summary>
		/// 
		/// </summary>
		public IntPtr userdata;
		/* [in] Optional. Specify 0 to ignore. This is user data to be attached to the sound during creation.  Access via Sound::getUserData. */

		/// <summary>
		/// 
		/// </summary>
		public Type suggestedsoundtype;
		/* [in] Optional. Specify 0 or FMOD_SOUND_TYPE_UNKNOWN to ignore.  Instead of scanning all codec types, use this to speed up loading by making it jump straight to this codec. */

		/// <summary>
		/// 
		/// </summary>
		public File_OpenDelegate useropen;
		/* [in] Optional. Specify 0 to ignore. Callback for opening this file. */

		/// <summary>
		/// 
		/// </summary>
		public File_CloseDelegate userclose;
		/* [in] Optional. Specify 0 to ignore. Callback for closing this file. */

		/// <summary>
		/// 
		/// </summary>
		public File_ReadDelegate userread;
		/* [in] Optional. Specify 0 to ignore. Callback for reading from this file. */

		/// <summary>
		/// 
		/// </summary>
		public File_SeekDelegate userseek;
		/* [in] Optional. Specify 0 to ignore. Callback for seeking within this file. */

		/// <summary>
		/// 
		/// </summary>
		public File_AsyncReadDelegate userasyncread;
		/* [in] Optional. Specify 0 to ignore. Callback for asyncronously reading from this file. */

		/// <summary>
		/// 
		/// </summary>
		public File_AsyncCancelDelegate userasynccancel;
		/* [in] Optional. Specify 0 to ignore. Callback for cancelling an asyncronous read. */

		/// <summary>
		/// 
		/// </summary>
		public SpeakerMapType speakermap;
		/* [in] Optional. Specify 0 to ignore. Use this to differ the way fmod maps multichannel sounds to speakers.  See FMOD_SPEAKERMAPTYPE for more. */

		/// <summary>
		/// 
		/// </summary>
		public IntPtr initialsoundgroup;
		/* [in] Optional. Specify 0 to ignore. Specify a sound group if required, to put sound in as it is created. */

		/// <summary>
		/// 
		/// </summary>
		public uint initialseekposition;
		/* [in] Optional. Specify 0 to ignore. For streams. Specify an initial position to seek the stream to. */

		/// <summary>
		/// 
		/// </summary>
		public TimeUnit initialseekpostype;
		/* [in] Optional. Specify 0 to ignore. For streams. Specify the time unit for the position set in initialseekposition. */

		/// <summary>
		/// 
		/// </summary>
		public int ignoresetfilesystem;
		/* [in] Optional. Specify 0 to ignore. Set to 1 to use fmod's built in file system. Ignores setFileSystem callbacks and also FMOD_CREATESOUNEXINFO file callbacks.  Useful for specific cases where you don't want to use your own file system but want to use fmod's file system (ie net streaming). */

		/// <summary>
		/// 
		/// </summary>
		public IntPtr extracodecdata;
		/* [in] Optional. Specify 0 to ignore. Codec specific data. See FMOD_SOUND_TYPE for what each codec might take here. */
	}
		
	
	//TODO complete submmary
	
	/*
    [STRUCTURE] 
    [
        [DESCRIPTION]
        Use this structure with System::createSound when more control is needed over loading.
        The possible reasons to use this with System::createSound are:
        <li>Loading a file from memory.
        <li>Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.
        <li>To create a user created / non file based sound.
        <li>To specify a starting subsound to seek to within a multi-sample sounds (ie FSB/DLS/SF2) when created as a stream.
        <li>To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.
        <li>To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.
        <li>To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.
        See below on what members to fill for each of the above types of sound you want to create.

        [REMARKS]
        This structure is optional!  Specify 0 or NULL in System::createSound if you don't need it!
        
        Members marked with [in] mean the user sets the value before passing it to the function.
        Members marked with [out] mean FMOD sets the value to be used after the function exits.
        
        <u>Loading a file from memory.</u>
        <li>Create the sound using the FMOD_OPENMEMORY flag.
        <li>Mandantory.  Specify 'length' for the size of the memory block in bytes.
        <li>Other flags are optional.
        
        
        <u>Loading a file from within another larger (possibly wad/pak) file, by giving the loader an offset and length.</u>
        <li>Mandantory.  Specify 'fileoffset' and 'length'.
        <li>Other flags are optional.
        
        
        <u>To create a user created / non file based sound.</u>
        <li>Create the sound using the FMOD_OPENUSER flag.
        <li>Mandantory.  Specify 'defaultfrequency, 'numchannels' and 'format'.
        <li>Other flags are optional.
        
        
        <u>To specify a starting subsound to seek to and flush with, within a multi-sample stream (ie FSB/DLS/SF2).</u>
        
        <li>Mandantory.  Specify 'initialsubsound'.
        
        
        <u>To specify which subsounds to load for multi-sample sounds (ie FSB/DLS/SF2) so that memory is saved and only a subset is actually loaded/read from disk.</u>
        
        <li>Mandantory.  Specify 'inclusionlist' and 'inclusionlistnum'.
        
        
        <u>To specify 'piggyback' read and seek callbacks for capture of sound data as fmod reads and decodes it.  Useful for ripping decoded PCM data from sounds as they are loaded / played.</u>
        
        <li>Mandantory.  Specify 'pcmreadcallback' and 'pcmseekcallback'.
        
        
        <u>To specify a MIDI DLS/SF2 sample set file to load when opening a MIDI file.</u>
        
        <li>Mandantory.  Specify 'dlsname'.
        
        
        Setting the 'decodebuffersize' is for cpu intensive codecs that may be causing stuttering, not file intensive codecs (ie those from CD or netstreams) which are normally altered with System::setStreamBufferSize.  As an example of cpu intensive codecs, an mp3 file will take more cpu to decode than a PCM wav file.
        If you have a stuttering effect, then it is using more cpu than the decode buffer playback rate can keep up with.  Increasing the decode buffersize will most likely solve this problem.

        [PLATFORMS]
        Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2, PlayStation Portable, PlayStation 3, Wii

        [SEE_ALSO]
        System::createSound
        System::setStreamBufferSize
        FMOD_MODE
    ]
    */	
}
