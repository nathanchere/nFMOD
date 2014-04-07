using System;
using System.Collections.Generic;

namespace nFMOD
{
	internal static class Errors
	{
        private static readonly Dictionary<ErrorCode, Type> exceptionTypes;
	    
        static Errors()
	    {
	        exceptionTypes = new Dictionary<ErrorCode, Type>();
            exceptionTypes[ErrorCode.AlreadyLocked] = typeof(FmodAlreadyLockedException);
            exceptionTypes[ErrorCode.BadCommand] = typeof(FmodBadCommandException);
            exceptionTypes[ErrorCode.CDDA_Drivers] = typeof(FmodCddaDriversException);
            exceptionTypes[ErrorCode.CDDA_Init] = typeof(FmodCddaInitException);
            exceptionTypes[ErrorCode.CDDA_InvalidDevice] = typeof(FmodCddaInvalidDeviceException);
            exceptionTypes[ErrorCode.CDDA_NoAudio] = typeof(FmodCddaNoAudioException);
            exceptionTypes[ErrorCode.CDDA_NoDevices] = typeof(FmodCddaNoDevicesException);
            exceptionTypes[ErrorCode.CDDA_NoDisc] = typeof(FmodCddaNoDiscException);
            exceptionTypes[ErrorCode.CDDA_Read] = typeof(FmodCddaReadException);
            exceptionTypes[ErrorCode.COM] = typeof(FmodComException);
            exceptionTypes[ErrorCode.Channel_Alloc] = typeof(FmodChannelAllocateException);
            exceptionTypes[ErrorCode.Channel_Stolen] = typeof(FmodChannelStolenException);
            exceptionTypes[ErrorCode.DMA] = typeof(FmodDmaException);
            exceptionTypes[ErrorCode.DSP_Connection] = typeof(FmodDspConnectionException);
            exceptionTypes[ErrorCode.DSP_Format] = typeof(FmodDspFormatException);
            exceptionTypes[ErrorCode.DSP_NotFound] = typeof(FmodDspNotFoundException);
            exceptionTypes[ErrorCode.DSP_Running] = typeof(FmodDspRunningException);
            exceptionTypes[ErrorCode.DSP_TooManyConnections] = typeof(FmodDspTooManyConnectionsException);
            exceptionTypes[ErrorCode.Event_AlreadyLoaded] = typeof(FmodEventAlreadyLoadedException);
            exceptionTypes[ErrorCode.Event_Failed] = typeof(FmodEventFailedException);
            exceptionTypes[ErrorCode.Event_GuidConflict] = typeof(FmodEventGuidConflictException);
            exceptionTypes[ErrorCode.Event_InfoOnly] = typeof(FmodEventInfoOnlyException);
            exceptionTypes[ErrorCode.Event_Internal] = typeof(FmodEventInternalException);
            exceptionTypes[ErrorCode.Event_MaxStreams] = typeof(FmodEventMaxStreamsException);
            exceptionTypes[ErrorCode.Event_Mismatch] = typeof(FmodEventMismatchException);
            exceptionTypes[ErrorCode.Event_NameConflict] = typeof(FmodEventNameConflictException);
            exceptionTypes[ErrorCode.Event_NeedsSimple] = typeof(FmodEventNeedsSimpleException);
            exceptionTypes[ErrorCode.Event_NotFound] = typeof(FmodEventNotFoundException);
            exceptionTypes[ErrorCode.File_Bad] = typeof(FmodFileBadException);
            exceptionTypes[ErrorCode.File_CouldNotSeek] = typeof(FmodFileCouldNotSeekException);
            exceptionTypes[ErrorCode.File_DiskEjected] = typeof(FmodFileDiskEjectedException);
            exceptionTypes[ErrorCode.File_EOF] = typeof(FmodFileEofException);
            exceptionTypes[ErrorCode.File_NotFound] = typeof(FmodFileNotFoundException);
            exceptionTypes[ErrorCode.File_Unwanted] = typeof(FmodFileUnwantedException);
            exceptionTypes[ErrorCode.Format] = typeof(FmodFormatException);
            exceptionTypes[ErrorCode.HTTP] = typeof(FmodHttpException);
            exceptionTypes[ErrorCode.HTTP_Access] = typeof(FmodHttpAccessException);
            exceptionTypes[ErrorCode.HTTP_ProxyAuth] = typeof(FmodHttpProxyAuthException);
            exceptionTypes[ErrorCode.HTTP_ServerError] = typeof(FmodHttpServerErrorException);
            exceptionTypes[ErrorCode.HTTP_Timeout] = typeof(FmodHttpTimeoutException);
            exceptionTypes[ErrorCode.IRX] = typeof(FmodIrxException);
            exceptionTypes[ErrorCode.Initialization] = typeof(FmodInitializationException);
            exceptionTypes[ErrorCode.Initialized] = typeof(FmodInitializedException);
            exceptionTypes[ErrorCode.Internal] = typeof(FmodInternalException);
            exceptionTypes[ErrorCode.InvalidAddress] = typeof(FmodInvalidAddressException);
            exceptionTypes[ErrorCode.InvalidFloat] = typeof(FmodInvalidFloatException);
            exceptionTypes[ErrorCode.InvalidHandle] = typeof(FmodInvalidHandleException);
            exceptionTypes[ErrorCode.InvalidParam] = typeof(FmodInvalidParameterException);
            exceptionTypes[ErrorCode.InvalidPosition] = typeof(FmodInvalidPositionException);
            exceptionTypes[ErrorCode.InvalidSpeaker] = typeof(FmodInvalidSpeakerException);
            exceptionTypes[ErrorCode.InvalidSyncpoint] = typeof(FmodInvalidSyncPointException);
            exceptionTypes[ErrorCode.InvalidVector] = typeof(FmodInvalidVectorException);
            exceptionTypes[ErrorCode.MaxAudible] = typeof(FmodMaxAudibleException);
            exceptionTypes[ErrorCode.Memory] = typeof(FmodMemoryException);
            exceptionTypes[ErrorCode.Memory_CantPoint] = typeof(FmodMemoryCantPointException);
            exceptionTypes[ErrorCode.Memory_IOP] = typeof(FmodMemoryIopException);
            exceptionTypes[ErrorCode.Memory_SRAM] = typeof(FmodMemorySramException);
            exceptionTypes[ErrorCode.Music_NoCallback] = typeof(FmodMusicNoCallbackException);
            exceptionTypes[ErrorCode.Music_NotFound] = typeof(FmodMusicNotFoundException);
            exceptionTypes[ErrorCode.Music_Uninitialized] = typeof(FmodMusicUnintializedException);
            exceptionTypes[ErrorCode.Needs2D] = typeof(FmodNeeds2dException);
            exceptionTypes[ErrorCode.Needs3D] = typeof(FmodNeeds3dException);
            exceptionTypes[ErrorCode.NeedsHardware] = typeof(FmodNeedsHardwareException);
            exceptionTypes[ErrorCode.NeedsSoftware] = typeof(FmodNeedsSoftwareException);
            exceptionTypes[ErrorCode.Net_Connect] = typeof(FmodNetConnectException);
            exceptionTypes[ErrorCode.Net_SocketError] = typeof(FmodNetSocketErrorException);
            exceptionTypes[ErrorCode.Net_Url] = typeof(FmodNetUrlException);
            exceptionTypes[ErrorCode.Net_WouldBlock] = typeof(FmodNetWouldBlockException);
            exceptionTypes[ErrorCode.NotReady] = typeof(FmodNotReadyException);
            exceptionTypes[ErrorCode.Output_Allocated] = typeof(FmodOutputAllocatedException);
            exceptionTypes[ErrorCode.Output_CreateBuffer] = typeof(FmodOutputCreateBufferException);
            exceptionTypes[ErrorCode.Output_DriverCall] = typeof(FmodOutputDriverCallException);
            exceptionTypes[ErrorCode.Output_Enumeration] = typeof(FmodOutputEnumerationException);
            exceptionTypes[ErrorCode.Output_Format] = typeof(FmodOutputFormatException);
            exceptionTypes[ErrorCode.Output_Init] = typeof(FmodOutputInitException);
            exceptionTypes[ErrorCode.Output_NoHardware] = typeof(FmodOutputNoHardwareException);
            exceptionTypes[ErrorCode.Output_NoSoftware] = typeof(FmodOutputNoSoftwareException);
            exceptionTypes[ErrorCode.Pan] = typeof(FmodPanException);
            exceptionTypes[ErrorCode.Plugin] = typeof(FmodPluginException);
            exceptionTypes[ErrorCode.Plugin_Instances] = typeof(FmodPluginInstancesException);
            exceptionTypes[ErrorCode.Plugin_Missing] = typeof(FmodPluginMissingException);
            exceptionTypes[ErrorCode.Plugin_Resource] = typeof(FmodPluginResourceException);
            exceptionTypes[ErrorCode.Preloaded] = typeof(FmodPreloadedException);
            exceptionTypes[ErrorCode.ProgrammerSound] = typeof(FmodProgrammerSoundException);
            exceptionTypes[ErrorCode.Record] = typeof(FmodRecordException);
            exceptionTypes[ErrorCode.Reverb_Instance] = typeof(FmodReverbInstanceException);
            exceptionTypes[ErrorCode.SubSound_Allocated] = typeof(FmodSubsoundAllocatedException);
            exceptionTypes[ErrorCode.SubSound_CantMove] = typeof(FmodSubsoundCantMoveException);
            exceptionTypes[ErrorCode.SubSound_Mode] = typeof(FmodSubsoundModeException);
            exceptionTypes[ErrorCode.SubSounds] = typeof(FmodSubsoundsException);
            exceptionTypes[ErrorCode.TagNotFound] = typeof(FmodTagNotFoundException);
            exceptionTypes[ErrorCode.TooManyChannels] = typeof(FmodTooManyChannelsException);
            exceptionTypes[ErrorCode.Unimplemented] = typeof(FmodUnimplementedException);
            exceptionTypes[ErrorCode.Uninitialized] = typeof(FmodUninitializedException);
            exceptionTypes[ErrorCode.Unsupported] = typeof(FmodUnsupportedException);
            exceptionTypes[ErrorCode.Update] = typeof(FmodUpdateException);
            exceptionTypes[ErrorCode.Version] = typeof(FmodVersionException); 
	    }

		public static void ThrowIfError(ErrorCode errorCode)
		{
			if(errorCode == ErrorCode.OK) return;
            var exceptionType = exceptionTypes[errorCode] ?? typeof(FmodException);
            throw (FmodException)Activator.CreateInstance(exceptionType);
		}
		
	}
}
