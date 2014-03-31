using System;
using System.Runtime.InteropServices;
using System.Security;
using nFMOD.Enums;

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
			Errors.ThrowError (ReturnCode);
		}

		public static void GetStats (ref int currentalloced, ref int maxalloced, bool blocking)
		{
			ErrorCode ReturnCode = GetStats_External (ref currentalloced, ref maxalloced, blocking);
			Errors.ThrowError (ReturnCode);
		}

		[DllImport("fmodex", EntryPoint = "FMOD_Memory_GetStats"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetStats_External (ref int currentalloced, ref int maxalloced, bool blocking);
		
	}
}

