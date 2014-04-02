using System;

namespace nFMOD.Exceptions
{
    public class FmodAlreadyLockedException : Exception {
        public override string Message {
            get { return "Tried to call lock a second time before unlock was called."; }
        }
    }

    public class FmodBadCommandException : Exception {
        public override string Message {
            get { return "Tried to call a function on a data type that does not allow this type of functionality (ie calling Sound::lock on a streaming sound).";
            }
        }
    }

    public class FmodCddaDriversException : Exception {
        public override string Message {
            get { return "Neither NTSCSI nor ASPI could be initialised."; }
        }
    }

    public class FmodCddaInitException : Exception {
        public override string Message {
            get { return "An error occurred while initialising the CDDA subsystem."; }
        }
    }

    public class FmodCddaInvalidDeviceException : Exception {
        public override string Message {
            get { return "Couldn't find the specified device."; }
        }
    }

    public class FmodCddaNoAudioException : Exception {
        public override string Message {
            get { return "No audio tracks on the specified disc."; }
        }
    }

    public class FmodCddaNoDevicesException : Exception {
        public override string Message {
            get { return "No CD/DVD devices were found."; }
        }
    }

    public class FmodCddaNoDiscException : Exception {
        public override string Message {
            get { return "No disc present in the specified drive."; }
        }
    }

    public class FmodCddaReadException : Exception {
        public override string Message {
            get { return "A CDDA read error occurred."; }
        }
    }

    public class FmodChannelAllocateException : Exception {
        public override string Message {
            get { return "Error trying to allocate a channel."; }
        }
    }

    public class FmodChannelStolenException : Exception {
        public override string Message {
            get { return "The specified channel has been reused to play another sound."; }
        }
    }

    public class FmodComException : Exception {
        public override string Message {
            get { return "A Win32 COM related error occured. COM failed to initialize or a QueryInterface failed meaning a Windows codec or driver was not installed properly.";
            }
        }
    }

    public class FmodDmaException : Exception {
        public override string Message {
            get { return "DMA Failure.  See debug output for more information."; }
        }
    }

    public class FmodDspConnectionException : Exception {
        public override string Message {
            get { return "DSP connection error.  Connection possibly caused a cyclic dependancy.  Or tried to connect a tree too many units deep (more than 128).";
            }
        }
    }

    public class FmodDspFormatException : Exception {
        public override string Message {
            get { return "DSP Format error.  A DSP unit may have attempted to connect to this network with the wrong format.";
            }
        }
    }

    public class FmodDspNotFoundException : Exception {
        public override string Message {
            get { return "DSP connection error.  Couldn't find the DSP unit specified."; }
        }
    }

    public class FmodDspNotRunningException : Exception {
        public override string Message {
            get { return "DSP error.  Cannot perform this operation while the network is in the middle of running.  This will most likely happen if a connection or disconnection is attempted in a DSP callback.";
            }
        }
    }

    public class FmodDspTooManyConnectionsException : Exception {
        public override string Message {
            get { return "DSP connection error.  The unit being connected to or disconnected should only have 1 input or output.";
            }
        }
    }

    public class FmodEventAlreadyLoadedException : Exception {
        public override string Message {
            get { return "The specified project or bank has already been loaded. Having multiple copies of the same project loaded simultaneously is forbidden.";
            }
        }
    }

    public class FmodEventFailedException : Exception {
        public override string Message {
            get { return "An Event failed to be retrieved, most likely due to 'just fail' being specified as the max playbacks behavior.";
            }
        }
    }

    public class FmodEventGuidConflictException : Exception {
        public override string Message {
            get { return "An event with the same GUID already exists."; }
        }
    }

    public class FmodEventInfoOnlyException : Exception {
        public override string Message {
            get { return "Can't execute this command on an EVENT_INFOONLY event."; }
        }
    }

    public class FmodEventInternalException : Exception {
        public override string Message {
            get { return "An error occured that wasn't supposed to.  See debug log for reason."; }
        }
    }

    public class FmodEventMaxStreamsException : Exception {
        public override string Message {
            get { return "Event failed because 'Max streams' was hit when FMOD_EVENT_INIT_FAIL_ON_MAXSTREAMS was specified.";
            }
        }
    }

    public class FmodEventMismatchException : Exception {
        public override string Message {
            get { return "FSB mismatches the FEV it was compiled with, the stream/sample mode it was meant to be created with was different, or the FEV was built for a different platform.";
            }
        }
    }

    public class FmodEventNameConflictException : Exception {
        public override string Message {
            get { return "A category with the same name already exists."; }
        }
    }

    public class FmodEventNeedsSimpleException : Exception {
        public override string Message {
            get { return "Tried to call a function on a complex event that's only supported by simple events."; }
        }
    }

    public class FmodEventNotFoundException : Exception {
        public override string Message {
            get { return "The requested event, event group, event category or event property could not be found."; }
        }
    }

    public class FmodFileBadException : Exception {
        public override string Message {
            get { return "Error loading file."; }
        }
    }

    public class FmodFileCouldNotSeekException : Exception {
        public override string Message {
            get { return "Couldn't perform seek operation.  This is a limitation of the medium (ie netstreams) or the file format.";
            }
        }
    }

    public class FmodFileDiskEjectedException : Exception {
        public override string Message {
            get { return "Media was ejected while reading."; }
        }
    }

    public class FmodFileEofException : Exception {
        public override string Message {
            get { return "End of file unexpectedly reached while trying to read essential data (truncated data?)."; }
        }
    }

    public class FmodFileNotFoundException : Exception {
        public override string Message {
            get { return "File not found."; }
        }
    }

    public class FmodFileUnwantedException : Exception {
        public override string Message {
            get { return "Unwanted file access occured."; }
        }
    }

    public class FmodFormatException : Exception {
        public override string Message {
            get { return "Unsupported file or audio format."; }
        }
    }

    public class FmodHttpException : Exception {
        public override string Message {
            get { return "A HTTP error occurred. This is a catch-all for HTTP errors not listed elsewhere."; }
        }
    }

    public class FmodHttpAccessException : Exception {
        public override string Message {
            get { return "The specified resource requires authentication or is forbidden."; }
        }
    }

    public class FmodHttpProxyAuthException : Exception {
        public override string Message {
            get { return "Proxy authentication is required to access the specified resource."; }
        }
    }

    public class FmodHttpServerErrorException : Exception {
        public override string Message {
            get { return "A HTTP server error occurred."; }
        }
    }

    public class FmodHttpTimeoutException : Exception {
        public override string Message {
            get { return "The HTTP request timed out."; }
        }
    }

    public class FmodInitializationException : Exception {
        public override string Message {
            get { return "FMOD was not initialized correctly to support this function."; }
        }
    }

    public class FmodInitializedException : Exception {
        public override string Message {
            get { return "Cannot call this command after System::init."; }
        }
    }

    public class FmodInternalException : Exception {
        public override string Message {
            get { return "An error occured that wasn't supposed to.  Contact support."; }
        }
    }

    public class FmodInvalidAddressException : Exception {
        public override string Message {
            get { return "On Xbox 360, this memory address passed to FMOD must be physical, (ie allocated with XPhysicalAlloc.) ";
            }
        }
    }

    public class FmodInvalidFloatException : Exception {
        public override string Message {
            get { return "Value passed in was a NaN, Inf or denormalized float."; }
        }
    }

    public class FmodInvalidHandleException : Exception {
        public override string Message {
            get { return "An invalid object handle was used."; }
        }
    }

    public class FmodInvalidParameterException : Exception {
        public override string Message {
            get { return "An invalid parameter was passed to this function."; }
        }
    }

    public class FmodInvalidPosittionException : Exception {
        public override string Message {
            get { return "An invalid seek position was passed to this function."; }
        }
    }

    public class FmodInvalidSpeakerException : Exception {
        public override string Message {
            get { return "An invalid speaker was passed to this function based on the current speaker mode."; }
        }
    }

    public class FmodInvalidSyncPointException : Exception {
        public override string Message {
            get { return "The syncpoint did not come from this sound handle."; }
        }
    }

    public class FmodInvalidVectorException : Exception {
        public override string Message {
            get { return "The vectors passed in are not unit length, or perpendicular."; }
        }
    }

    public class FmodMaxAudibleException : Exception {
        public override string Message {
            get { return "Reached maximum audible playback count for this sound's soundgroup."; }
        }
    }

    public class FmodMemoryException : Exception {
        public override string Message {
            get { return "Not enough memory or resources."; }
        }
    }

    public class FmodMemoryCantPointException : Exception {
        public override string Message {
            get { return "Can't use FMOD_OPENMEMORY_POINT on non PCM source data, or non mp3/xma/adpcm data if FMOD_CREATECOMPRESSEDSAMPLE was used.";
            }
        }
    }

    public class FmodMemorySramException : Exception {
        public override string Message {
            get { return "Not enough memory or resources on console sound ram."; }
        }
    }

    public class FmodMusicNoCallbackException : Exception {
        public override string Message {
            get { return "The music callback is required, but it has not been set."; }
        }
    }

    public class FmodMusicNotFoundException : Exception {
        public override string Message {
            get { return "The requested music entity could not be found."; }
        }
    }

    public class FmodMusicUnintializedException : Exception {
        public override string Message {
            get { return "Music system is not initialized probably because no music data is loaded."; }
        }
    }

    public class FmodNeeds2dException : Exception {
        public override string Message {
            get { return "Tried to call a command on a 3d sound when the command was meant for 2d sound."; }
        }
    }

    public class FmodNeeds3dException : Exception {
        public override string Message {
            get { return "Tried to call a command on a 2d sound when the command was meant for 3d sound."; }
        }
    }

    public class FmodNeedsHardwareException : Exception {
        public override string Message {
            get { return "Tried to use a feature that requires hardware support.  (ie trying to play a GCADPCM compressed sound in software on Wii).";
            }
        }
    }

    public class FmodNeedsSoftwareException : Exception {
        public override string Message {
            get { return "Tried to use a feature that requires the software engine.  Software engine has either been turned off, or command was executed on a hardware channel which does not support this feature.";
            }
        }
    }

    public class FmodNetConnectException : Exception {
        public override string Message {
            get { return "Couldn't connect to the specified host."; }
        }
    }

    public class FmodNetSocketErrorException : Exception {
        public override string Message {
            get { return "A socket error occurred.  This is a catch-all for socket-related errors not listed elsewhere.";
            }
        }
    }

    public class FmodNetUrlException : Exception {
        public override string Message {
            get { return "The specified URL couldn't be resolved."; }
        }
    }

    public class FmodNetWouldBlockException : Exception {
        public override string Message {
            get { return "Operation on a non-blocking socket could not complete immediately."; }
        }
    }

    public class FmodNotReadyException : Exception {
        public override string Message {
            get { return "Operation could not be performed because specified sound/DSP connection is not ready."; }
        }
    }

    public class FmodOutputAllocatedException : Exception {
        public override string Message {
            get { return "Error initializing output device, but more specifically, the output device is already in use and cannot be reused.";
            }
        }
    }

    public class FmodOutputCreateBufferException : Exception {
        public override string Message {
            get { return "Error creating hardware sound buffer."; }
        }
    }

    public class FmodOutputDriverCallException : Exception {
        public override string Message {
            get { return "A call to a standard soundcard driver failed, which could possibly mean a bug in the driver or resources were missing or exhausted.";
            }
        }
    }

    public class FmodOutputEnumerationException : Exception {
        public override string Message {
            get { return "Error enumerating the available driver list. List may be inconsistent due to a recent device addition or removal.";
            }
        }
    }

    public class FmodOutputFormatException : Exception {
        public override string Message {
            get { return "Soundcard does not support the minimum features needed for this soundsystem (16bit stereo output).";
            }
        }
    }

    public class FmodOutputInitException : Exception {
        public override string Message {
            get { return "Error initializing output device."; }
        }
    }

    public class FmodOutputNoHardwareException : Exception {
        public override string Message {
            get { return "FMOD_HARDWARE was specified but the sound card does not have the resources necessary to play it.";
            }
        }
    }

    public class FmodOutputNoSoftwareException : Exception {
        public override string Message {
            get { return "Attempted to create a software sound but no software channels were specified in System::init.";
            }
        }
    }

    public class FmodPanException : Exception {
        public override string Message {
            get { return "Panning only works with mono or stereo sound sources."; }
        }
    }

    public class FmodPluginException : Exception {
        public override string Message {
            get { return "An unspecified error has been returned from a 3rd party plugin."; }
        }
    }

    public class FmodPluginInstancesException : Exception {
        public override string Message {
            get { return "The number of allowed instances of a plugin has been exceeded."; }
        }
    }

    public class FmodPluginMissingException : Exception {
        public override string Message {
            get { return "A requested output, dsp unit type or codec was not available."; }
        }
    }

    public class FmodPluginResourceException : Exception {
        public override string Message {
            get { return "A resource that the plugin requires cannot be found. (ie the DLS file for MIDI playback or other DLLs that it needs to load) ";
            }
        }
    }

    public class FmodPreloadedException : Exception {
        public override string Message {
            get { return "The specified sound is still in use by the event system, call EventSystem::unloadFSB before trying to release it.";
            }
        }
    }

    public class FmodProgrammerSoundException : Exception {
        public override string Message {
            get { return "The specified sound is still in use by the event system, wait for the event which is using it finish with it.";
            }
        }
    }

    public class FmodRecordException : Exception {
        public override string Message {
            get { return "An error occured trying to initialize the recording device."; }
        }
    }

    public class FmodReverbInstanceException : Exception {
        public override string Message {
            get { return "Specified instance in FMOD_REVERB_PROPERTIES couldn't be set. Most likely because it is an invalid instance number or the reverb doesnt exist.";
            }
        }
    }

    public class FmodSubsoundsException : Exception {
        public override string Message {
            get { return "The error occured because the sound referenced contains subsounds when it shouldn't have, or it doesn't contain subsounds when it should have.  The operation may also not be able to be performed on a parent sound, or a parent sound was played without setting up a sentence first.";
            }
        }
    }

    public class FmodSubsoundAllocatedException : Exception {
        public override string Message {
            get { return "This subsound is already being used by another sound, you cannot have more than one parent to a sound.  Null out the other parent's entry first.";
            }
        }
    }

    public class FmodSubsoundCantMoveException : Exception {
        public override string Message {
            get { return "Shared subsounds cannot be replaced or moved from their parent stream, such as when the parent stream is an FSB file.";
            }
        }
    }

    public class FmodSubsoundModeException : Exception {
        public override string Message {
            get { return "The subsound's mode bits do not match with the parent sound's mode bits.  See documentation for function that it was called with.";
            }
        }
    }

    public class FmodTagNotFoundException : Exception {
        public override string Message {
            get { return "The specified tag could not be found or there are no tags."; }
        }
    }

    public class FmodTooManyChannelsException : Exception {
        public override string Message {
            get { return "The sound created exceeds the allowable input channel count.  This can be increased using the maxinputchannels parameter in System::setSoftwareFormat.";
            }
        }
    }

    public class FmodUnimplementedException : Exception {
        public override string Message {
            get { return "Something in FMOD hasn't been implemented when it should be! contact support! "; }
        }
    }

    public class FmodUninitializedException : Exception {
        public override string Message {
            get { return "This command failed because System::init or System::setDriver was not called."; }
        }
    }

    public class FmodUnsupportedException : Exception {
        public override string Message {
            get { return "A command issued was not supported by this object.  Possibly a plugin without certain callbacks specified.";
            }
        }
    }

    public class FmodUpdateException : Exception {
        public override string Message {
            get { return "An error caused by System::update occured."; }
        }
    }

    public class FmodVersionException : Exception {
        public override string Message {
            get { return "The version number of this file format is not supported."; }
        }
    }
}