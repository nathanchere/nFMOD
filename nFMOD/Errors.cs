using System;
using nFMOD.Enums;

namespace nFMOD
{
	public static class Errors
	{

		/// <summary>
		/// Use this module if you want to store or display a string version.
		/// english explanation of the FMOD error codes.
		/// </summary>
		/// <param name="errcode">
		/// A <see cref="fmodexvb.FMOD_RESULT"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.String"/>
		/// </returns>
		public static string ErrorString (ErrorCode errcode)
		{
		    switch (errcode)
		    {
		        case ErrorCode.OK:
		            return "No errors.";

		        case ErrorCode.AlreadyLocked:
		            return "Tried to call lock a second time before unlock was called. ";
		        case ErrorCode.BadCommand:
		            return
		                "Tried to call a function on a data type that does not allow this type of functionality (ie calling Sound::lock on a streaming sound). ";
		        case ErrorCode.CDDA_Drivers:
		            return "Neither NTSCSI nor ASPI could be initialised. ";
		        case ErrorCode.CDDA_Init:
		            return "An error occurred while initialising the CDDA subsystem. ";
		        case ErrorCode.CDDA_InvalidDevice:
		            return "Couldn't find the specified device. ";
		        case ErrorCode.CDDA_NoAudio:
		            return "No audio tracks on the specified disc. ";
		        case ErrorCode.CDDA_NoDevices:
		            return "No CD/DVD devices were found. ";
		        case ErrorCode.CDDA_NoDisc:
		            return "No disc present in the specified drive. ";
		        case ErrorCode.CDDA_Read:
		            return "A CDDA read error occurred. ";
		        case ErrorCode.Channel_Alloc:
		            return "Error trying to allocate a channel. ";
		        case ErrorCode.Channel_Stolen:
		            return "The specified channel has been reused to play another sound. ";
		        case ErrorCode.COM:
		            return
		                "A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly. ";
		        case ErrorCode.DMA:
		            return "DMA Failure.  See debug output for more information. ";
		        case ErrorCode.DSP_Connection:
		            return "DSP connection error.  Connection possibly caused a cyclic dependancy. ";
		        case ErrorCode.DSP_Format:
		            return
		                "DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format. ";
		        case ErrorCode.DSP_NotFound:
		            return "DSP connection error.  Couldn't find the DSP unit specified. ";
		        case ErrorCode.DSP_Running:
		            return
		                "DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback. ";
		        case ErrorCode.DSP_TooManyConnections:
		            return
		                "DSP connection error.  The unit being connected to or disconnected should only have 1 input or output. ";
		        case ErrorCode.File_Bad:
		            return "Error loading file. ";
		        case ErrorCode.File_CouldNotSeek:
		            return
		                "Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format. ";
		        case ErrorCode.File_DiskEjected:
		            return "Media was ejected while reading. ";
		        case ErrorCode.File_EOF:
		            return "End of file unexpectedly reached while trying to read essential data (truncated data?). ";
		        case ErrorCode.File_NotFound:
		            return "File not found. ";
		        case ErrorCode.File_Unwanted:
		            return "Unwanted file access occured. ";
		        case ErrorCode.Format:
		            return "Unsupported file or audio format. ";
		        case ErrorCode.HTTP:
		            return "A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere. ";
		        case ErrorCode.HTTP_Access:
		            return "The specified resource requires authentication or is forbidden. ";
		        case ErrorCode.HTTP_ProxyAuth:
		            return "Proxy authentication is required to access the specified resource. ";
		        case ErrorCode.HTTP_ServerError:
		            return "A HTTP server error occurred. ";
		        case ErrorCode.HTTP_Timeout:
		            return "The HTTP request timed out. ";
		        case ErrorCode.Initialization:
		            return "FMOD was not initialized correctly to support this function. ";
		        case ErrorCode.Initialized:
		            return "Cannot call this command after System::init. ";
		        case ErrorCode.Internal:
		            return "An error occured that wasn't supposed to.  Contact support. ";
		        case ErrorCode.InvalidFloat:
		            return "Value passed in was a NaN, Inf or denormalized float. ";
		        case ErrorCode.InvalidHandle:
		            return "An invalid object handle was used. ";
		        case ErrorCode.InvalidParam:
		            return "An invalid parameter was passed to this function. ";
		        case ErrorCode.InvalidSpeaker:
		            return "An invalid speaker was passed to this function based on the current speaker mode. ";
		        case ErrorCode.InvalidSyncpoint:
		            return "The syncpoint did not come from this sound handle.";
		        case ErrorCode.InvalidVector:
		            return "The vectors passed in are not unit length, or perpendicular. ";
		        case ErrorCode.MaxAudible:
		            return "Reached maximum audible playback count for this sound's soundgroup. ";
		        case ErrorCode.Memory:
		            return "Not enough memory or resources. ";
		        case ErrorCode.Memory_CantPoint:
		            return
		                "Can't use FMOD_OPENMEMORY_POINT on non PCM source data, or non mp3/xma/adpcm data if FMOD_CREATECOMPRESSEDSAMPLE was used. ";
		        case ErrorCode.Memory_SRAM:
		            return "Not enough memory or resources on console sound ram. ";
		        case ErrorCode.Needs2D:
		            return "Tried to call a command on a 3d sound when the command was meant for 2d sound. ";
		        case ErrorCode.Needs3D:
		            return "Tried to call a command on a 2d sound when the command was meant for 3d sound. ";
		        case ErrorCode.NeedsHardware:
		            return
		                "Tried to use a feature that requires hardware support.  (ie trying to play a VAG compressed sound in software on PS2). ";
		        case ErrorCode.NeedsSoftware:
		            return
		                "Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature. ";
		        case ErrorCode.Net_Connect:
		            return "Couldn't connect to the specified host. ";
		        case ErrorCode.Net_SocketError:
		            return "A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere. ";
		        case ErrorCode.Net_Url:
		            return "The specified URL couldn't be resolved. ";
		        case ErrorCode.Net_WouldBlock:
		            return "Operation on a non-blocking socket could not complete immediately. ";
		        case ErrorCode.NotReady:
		            return "Operation could not be performed because specified sound is not ready. ";
		        case ErrorCode.Output_Allocated:
		            return
		                "Error initializing output device, but more specifically, the output device is already in use and cannot be reused. ";
		        case ErrorCode.Output_CreateBuffer:
		            return "Error creating hardware sound buffer. ";
		        case ErrorCode.Output_DriverCall:
		            return
		                "A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted. ";
		        case ErrorCode.Output_Enumeration:
		            return
		                "Error enumerating the available driver list. List may be inconsistent due to a recent device addition or removal.";
		        case ErrorCode.Output_Format:
		            return
		                "Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output). ";
		        case ErrorCode.Output_Init:
		            return "Error initializing output device. ";
		        case ErrorCode.Output_NoHardware:
		            return
		                "FMOD_HARDWARE was specified but the sound card does not have the resources nescessary to play it. ";
		        case ErrorCode.Output_NoSoftware:
		            return "Attempted to create a software sound but no software channels were specified in System::init. ";
		        case ErrorCode.Pan:
		            return "Panning only works with mono or stereo sound sources. ";
		        case ErrorCode.Plugin:
		            return "An unspecified error has been return ed from a 3rd party plugin. ";
		        case ErrorCode.Plugin_Instances:
		            return "The number of allowed instances of a plugin has been exceeded ";
		        case ErrorCode.Plugin_Missing:
		            return "A requested output, dsp unit type or codec was not available. ";
		        case ErrorCode.Plugin_Resource:
		            return "A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback) ";
		        case ErrorCode.Record:
		            return "An error occured trying to initialize the recording device. ";
		        case ErrorCode.Reverb_Instance:
		            return
		                "Specified Instance in FMOD_REVERB_PROPERTIES couldn't be set. Most likely because another application has locked the EAX4 FX slot. ";
		        case ErrorCode.SubSound_Allocated:
		            return
		                "This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first. ";
		        case ErrorCode.SubSound_CantMove:
		            return
		                "Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file.";
		        case ErrorCode.SubSound_Mode:
		            return
		                "The subsound's mode bits do not match with the parent sound's mode bits.  See documentation for function that it was called with.";
		        case ErrorCode.SubSounds:
		            return
		                "The error occured because the sound referenced contains subsounds.  (ie you cannot play the parent sound as a static sample, only its subsounds.) ";
		        case ErrorCode.TagNotFound:
		            return "The specified tag could not be found or there are no tags. ";
		        case ErrorCode.TooManyChannels:
		            return
		                "The sound created exceeds the allowable input channel count.  This can be increased using the maxinputchannels parameter in System::setSoftwareFormat. ";
		        case ErrorCode.Unimplemented:
		            return "Something in FMOD hasn't been implemented when it should be! contact support! ";
		        case ErrorCode.Uninitialized:
		            return "This command failed because System::init or System::setDriver was not called. ";
		        case ErrorCode.Unsupported:
		            return
		                "A command issued was not supported by this object.  Possibly a plugin without certain callbacks specified. ";
		        case ErrorCode.Update:
		            return "An error caused by System::update occured. ";
		        case ErrorCode.Version:
		            return "The version number of this file format is not supported. ";
		        case ErrorCode.Event_Failed:
		            return
		                "An Event failed to be retrieved, most likely due to 'just fail' being specified as the max playbacks behavior. ";
		        case ErrorCode.Event_InfoOnly:
		            return "Can't execute this command on an EVENT_INFOONLY event. ";
		        case ErrorCode.Event_Internal:
		            return "An error occured that wasn't supposed to.  See debug log for reason. ";
		        case ErrorCode.Event_MaxStreams:
		            return "Event failed because 'Max streams' was hit when FMOD_INIT_FAIL_ON_MAXSTREAMS was specified. ";
		        case ErrorCode.Event_Mismatch:
		            return "FSB mis-matches the FEV it was compiled with. ";
		        case ErrorCode.Event_NameConflict:
		            return "A category with the same name already exists. ";
		        case ErrorCode.Event_NotFound:
		            return "The requested event, event group, event category or event property could not be found. ";
		        case ErrorCode.Music_NoCallback:
		            return "The music callback is required, but it has not been set. ";
		        case ErrorCode.Music_Uninitialized:
		            return "Music system is not initialized probably because no music data is loaded. ";
		        case ErrorCode.Music_NotFound:
		            return "The requested music entity could not be found.";

                // Irrelevant:

		        case ErrorCode.InvalidAddress:
		            return "On Xbox 360, this memory address passed to FMOD must be physical, (ie allocated with XPhysicalAlloc.) ";
		        case ErrorCode.IRX:
		            return "PS2 only.  fmodex.irx failed to initialize.  This is most likely because you forgot to load it. ";
		        case ErrorCode.Memory_IOP:
		            return "PS2 only.  Not enough memory or resources on PlayStation 2 IOP ram. ";

		        default:
		            return "Unknown error.";
		    }
		}
		
		public static void ThrowError(ErrorCode errcode)
		{
			if(errcode == ErrorCode.OK)
				return;
			
			switch (errcode) {
				//TODO Translate error to Exception
			default:
				throw new Exception(string.Format("FMod retuned an unexpected Code: [{0}] {1}: {2}",
				                                  (int)errcode, errcode, Errors.ErrorString(errcode)));
			}
		}
		
	}
}
