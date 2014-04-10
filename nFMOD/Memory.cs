using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
    public class Memory
    {
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Memory_GetStats"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetStats_External(ref int currentalloced, ref int maxalloced, bool blocking);

        public static void GetStats(ref int currentalloced, ref int maxalloced)
        {
            Errors.ThrowIfError(GetStats_External(ref currentalloced, ref maxalloced, true));
        }

        public static void GetStats(ref int currentalloced, ref int maxalloced, bool blocking)
        {
            Errors.ThrowIfError(GetStats_External(ref currentalloced, ref maxalloced, blocking));
        }
    }
}

