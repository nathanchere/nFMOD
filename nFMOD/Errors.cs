using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            exceptionTypes[ErrorCode.CddaDrivers] = typeof(FmodCddaDriversException);
            exceptionTypes[ErrorCode.CddaInit] = typeof(FmodCddaInitException);
            exceptionTypes[ErrorCode.CddaInvalidDevice] = typeof(FmodCddaInvalidDeviceException);
            exceptionTypes[ErrorCode.CddaNoAudio] = typeof(FmodCddaNoAudioException);
            exceptionTypes[ErrorCode.CddaNoDevices] = typeof(FmodCddaNoDevicesException);
            exceptionTypes[ErrorCode.CddaNoDisc] = typeof(FmodCddaNoDiscException);
            exceptionTypes[ErrorCode.CddaRead] = typeof(FmodCddaReadException);
            exceptionTypes[ErrorCode.Win32Com] = typeof(FmodComException);
            exceptionTypes[ErrorCode.ChannelAllocate] = typeof(FmodChannelAllocateException);
            exceptionTypes[ErrorCode.ChannelStolen] = typeof(FmodChannelStolenException);
            exceptionTypes[ErrorCode.Dma] = typeof(FmodDmaException);
            exceptionTypes[ErrorCode.DspConnection] = typeof(FmodDspConnectionException);
            exceptionTypes[ErrorCode.DspFormat] = typeof(FmodDspFormatException);
            exceptionTypes[ErrorCode.DspNotFound] = typeof(FmodDspNotFoundException);
            exceptionTypes[ErrorCode.DspRunning] = typeof(FmodDspRunningException);
            exceptionTypes[ErrorCode.DspTooManyConnections] = typeof(FmodDspTooManyConnectionsException);
            exceptionTypes[ErrorCode.EventAlreadyLoaded] = typeof(FmodEventAlreadyLoadedException);
            exceptionTypes[ErrorCode.EventFailed] = typeof(FmodEventFailedException);
            exceptionTypes[ErrorCode.EventGuidConflict] = typeof(FmodEventGuidConflictException);
            exceptionTypes[ErrorCode.EventInfoOnly] = typeof(FmodEventInfoOnlyException);
            exceptionTypes[ErrorCode.EventInternal] = typeof(FmodEventInternalException);
            exceptionTypes[ErrorCode.EventMaxStreams] = typeof(FmodEventMaxStreamsException);
            exceptionTypes[ErrorCode.EventMismatch] = typeof(FmodEventMismatchException);
            exceptionTypes[ErrorCode.EventNameConflict] = typeof(FmodEventNameConflictException);
            exceptionTypes[ErrorCode.EventNeedsSimple] = typeof(FmodEventNeedsSimpleException);
            exceptionTypes[ErrorCode.EventNotFound] = typeof(FmodEventNotFoundException);
            exceptionTypes[ErrorCode.FileBad] = typeof(FmodFileBadException);
            exceptionTypes[ErrorCode.FileCouldNotSeek] = typeof(FmodFileCouldNotSeekException);
            exceptionTypes[ErrorCode.FileMediaEjected] = typeof(FmodFileDiskEjectedException);
            exceptionTypes[ErrorCode.FileEnd] = typeof(FmodFileEofException);
            exceptionTypes[ErrorCode.FileNotFound] = typeof(FmodFileNotFoundException);
            exceptionTypes[ErrorCode.FileUnwantedAccess] = typeof(FmodFileUnwantedException);
            exceptionTypes[ErrorCode.Format] = typeof(FmodFormatException);
            exceptionTypes[ErrorCode.HttpError] = typeof(FmodHttpException);
            exceptionTypes[ErrorCode.HttpAccess] = typeof(FmodHttpAccessException);
            exceptionTypes[ErrorCode.HttpProxyAuth] = typeof(FmodHttpProxyAuthException);
            exceptionTypes[ErrorCode.HttpServerError] = typeof(FmodHttpServerErrorException);
            exceptionTypes[ErrorCode.HttpTimeout] = typeof(FmodHttpTimeoutException);
            exceptionTypes[ErrorCode.Initialization] = typeof(FmodInitializationException);
            exceptionTypes[ErrorCode.Initialized] = typeof(FmodInitializedException);
            exceptionTypes[ErrorCode.Internal] = typeof(FmodInternalException);
            exceptionTypes[ ErrorCode.InvalidAddress] = typeof(FmodInvalidAddressException);
            exceptionTypes[ErrorCode.InvalidFloat] = typeof(FmodInvalidFloatException);
            exceptionTypes[ErrorCode.InvalidHandle] = typeof(FmodInvalidHandleException);
            exceptionTypes[ErrorCode.InvalidParam] = typeof(FmodInvalidParameterException);
            exceptionTypes[ErrorCode.InvalidPosition] = typeof(FmodInvalidPositionException);
            exceptionTypes[ErrorCode.InvalidSpeaker] = typeof(FmodInvalidSpeakerException);
            exceptionTypes[ErrorCode.InvalidSyncpoint] = typeof(FmodInvalidSyncPointException);
            exceptionTypes[ErrorCode.InvalidVector] = typeof(FmodInvalidVectorException);
            exceptionTypes[ErrorCode.MaxAudible] = typeof(FmodMaxAudibleException);
            exceptionTypes[ErrorCode.Memory] = typeof(FmodMemoryException);
            exceptionTypes[ErrorCode.MemoryCantPoint] = typeof(FmodMemoryCantPointException);
            exceptionTypes[ErrorCode.MemorySram] = typeof(FmodMemorySramException);
            exceptionTypes[ErrorCode.MusicNoCallback] = typeof(FmodMusicNoCallbackException);
            exceptionTypes[ErrorCode.MusicNotFound] = typeof(FmodMusicNotFoundException);
            exceptionTypes[ErrorCode.MusicUninitialized] = typeof(FmodMusicUnintializedException);
            exceptionTypes[ErrorCode.Needs2d] = typeof(FmodNeeds2dException);
            exceptionTypes[ErrorCode.Needs3d] = typeof(FmodNeeds3dException);
            exceptionTypes[ErrorCode.NeedsHardware] = typeof(FmodNeedsHardwareException);
            exceptionTypes[ErrorCode.NeedsSoftware] = typeof(FmodNeedsSoftwareException);
            exceptionTypes[ErrorCode.NetConnect] = typeof(FmodNetConnectException);
            exceptionTypes[ErrorCode.NetSocketError] = typeof(FmodNetSocketErrorException);
            exceptionTypes[ErrorCode.NetUrl] = typeof(FmodNetUrlException);
            exceptionTypes[ErrorCode.NetWouldBlock] = typeof(FmodNetWouldBlockException);
            exceptionTypes[ErrorCode.NotReady] = typeof(FmodNotReadyException);
            exceptionTypes[ErrorCode.OutputAllocated] = typeof(FmodOutputAllocatedException);
            exceptionTypes[ErrorCode.OutputCreateBuffer] = typeof(FmodOutputCreateBufferException);
            exceptionTypes[ErrorCode.OutputDriverCall] = typeof(FmodOutputDriverCallException);
            exceptionTypes[ErrorCode.OutputEnumeration] = typeof(FmodOutputEnumerationException);
            exceptionTypes[ErrorCode.OutputFormat] = typeof(FmodOutputFormatException);
            exceptionTypes[ErrorCode.OutputInit] = typeof(FmodOutputInitException);
            exceptionTypes[ErrorCode.OutputNoHardware] = typeof(FmodOutputNoHardwareException);
            exceptionTypes[ErrorCode.OutputNoSoftware] = typeof(FmodOutputNoSoftwareException);
            exceptionTypes[ErrorCode.Pan] = typeof(FmodPanException);
            exceptionTypes[ErrorCode.Plugin] = typeof(FmodPluginException);
            exceptionTypes[ErrorCode.PluginInstances] = typeof(FmodPluginInstancesException);
            exceptionTypes[ErrorCode.PluginMissing] = typeof(FmodPluginMissingException);
            exceptionTypes[ErrorCode.PluginResource] = typeof(FmodPluginResourceException);
            exceptionTypes[ErrorCode.Preloaded] = typeof(FmodPreloadedException);
            exceptionTypes[ErrorCode.ProgrammerSound] = typeof(FmodProgrammerSoundException);
            exceptionTypes[ErrorCode.Record] = typeof(FmodRecordException);
            exceptionTypes[ErrorCode.ReverbInstance] = typeof(FmodReverbInstanceException);
            exceptionTypes[ErrorCode.SubSoundAllocated] = typeof(FmodSubsoundAllocatedException);
            exceptionTypes[ErrorCode.SubSoundCantMove] = typeof(FmodSubsoundCantMoveException);
            exceptionTypes[ErrorCode.SubSoundMode] = typeof(FmodSubsoundModeException);
            exceptionTypes[ErrorCode.SubSounds] = typeof(FmodSubsoundsException);
            exceptionTypes[ErrorCode.TagNotFound] = typeof(FmodTagNotFoundException);
            exceptionTypes[ErrorCode.TooManyChannels] = typeof(FmodTooManyChannelsException);
            exceptionTypes[ErrorCode.Unimplemented] = typeof(FmodUnimplementedException);
            exceptionTypes[ErrorCode.Uninitialized] = typeof(FmodUninitializedException);
            exceptionTypes[ErrorCode.Unsupported] = typeof(FmodUnsupportedException);
            exceptionTypes[ErrorCode.Update] = typeof(FmodUpdateException);
            exceptionTypes[ErrorCode.Version] = typeof(FmodVersionException);

            /*
             * // Only valid for Playstation 2: 
             * exceptionTypes[ErrorCode.IRX] = typeof(FmodIrxException);
             * exceptionTypes[ErrorCode.Memory_IOP] = typeof(FmodMemoryIopException);
             */
        }

        public static void ThrowIfError(ErrorCode errorCode)
        {
            if (errorCode == ErrorCode.OK)
                return;
            var exceptionType = exceptionTypes[errorCode] ?? typeof(FmodException);


            if (Debugger.IsAttached)
                Debugger.Break();

            throw (FmodException)Activator.CreateInstance(exceptionType);
        }

    }
}
