using System;
using System.Collections.Generic;
using System.Text;

namespace nFMOD
{
    public static class Common
    {
        #if (_WIN64) 
        public const string FMOD_DLL = "fmodex64";
        #else
        public const string FMOD_DLL = "fmodex";
        #endif
    }
}
