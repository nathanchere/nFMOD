namespace nFMOD
{
    public static class Common
    {
        #if (_WIN64) 
        public const string FMOD_DLL = "fmodex64";
        #else
        public const string FMOD_DLL_NAME = "fmodex";
        #endif

        public const uint FMOD_DLL_MINIMUM_VERSION = 0x44432;
    }
}
