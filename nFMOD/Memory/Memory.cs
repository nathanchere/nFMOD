using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD.Memory
{
	public class Memory
	{
		public Memory ()
		{
		}

		public static void GetStats (ref int currentalloced, ref int maxalloced)
		{
			ErrorCode ReturnCode = GetStats_External (ref currentalloced, ref maxalloced, true);
			Errors.ThrowIfError (ReturnCode);
		}

		public static void GetStats (ref int currentalloced, ref int maxalloced, bool blocking)
		{
			ErrorCode ReturnCode = GetStats_External (ref currentalloced, ref maxalloced, blocking);
			Errors.ThrowIfError (ReturnCode);
		}

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_Memory_GetStats"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetStats_External (ref int currentalloced, ref int maxalloced, bool blocking);
		
	}
}

