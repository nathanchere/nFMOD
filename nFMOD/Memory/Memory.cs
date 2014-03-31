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
			Error.Code ReturnCode = GetStats_External (ref currentalloced, ref maxalloced, true);
			Error.Errors.ThrowError (ReturnCode);
		}

		public static void GetStats (ref int currentalloced, ref int maxalloced, bool blocking)
		{
			Error.Code ReturnCode = GetStats_External (ref currentalloced, ref maxalloced, blocking);
			Error.Errors.ThrowError (ReturnCode);
		}

		[DllImport("fmodex", EntryPoint = "FMOD_Memory_GetStats"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetStats_External (ref int currentalloced, ref int maxalloced, bool blocking);
		
	}
}

