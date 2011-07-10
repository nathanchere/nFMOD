using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Memory
{
	public class Memory
	{
		public Memory ()
		{
		}

		public static void GetStats (ref int currentalloced, ref int maxalloced)
		{
			Error.Code ReturnCode = GetStats_extern (ref currentalloced, ref maxalloced, true);
			if (ReturnCode != Error.Code.OK)
				Error.Errors.ThrowError (ReturnCode);
		}

		public static void GetStats (ref int currentalloced, ref int maxalloced, bool blocking)
		{
			Error.Code ReturnCode = GetStats_extern (ref currentalloced, ref maxalloced, blocking);
			if (ReturnCode != Error.Code.OK)
				Error.Errors.ThrowError (ReturnCode);
		}

		[DllImport("fmodex", EntryPoint = "FMOD_Memory_GetStats")]
		private static extern Error.Code GetStats_extern (ref int currentalloced, ref int maxalloced, bool blocking);
		
	}
}

