using System;
using System.Runtime.InteropServices;

namespace FmodSharp.fmodex
{
	public static class fmodexvb
	{
		//
		//   Helper Functions
		//

		//Example: MyDriverName = GetStringFromPointer(namepointer)
		public static string GetStringFromPointer (int lpString)
		{
			int NullCharPos = 0;
			string szBuffer = null;
			
			szBuffer = new string (Strings.Chr (0), 255);
			ConvCStringToVBString (szBuffer, lpString);
			// Look for the null char ending the C string
			NullCharPos = Strings.InStr (szBuffer, Constants.vbNullChar);
			return Strings.Left (szBuffer, NullCharPos - 1);
		}

		public static float GetSingleFromPointer (int lpSingle)
		{
			//A Single is 4 bytes, so we copy 4 bytes
			CopyMemory (ref GetSingleFromPointer (), ref lpSingle, 4);
		}


		// WRAPPED FMODEX CREATESOUND FUNCTIONS
		//UPGRADE_NOTE: system was upgraded to system_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		public static FMOD_RESULT FMOD_System_CreateSound (int system_Renamed, string Name_or_data, FMOD_MODE Mode, ref int Sound)
		{
			FMOD_CREATESOUNDEXINFO exinfo = new FMOD_CREATESOUNDEXINFO ();
			FMOD_RESULT result = default(FMOD_RESULT);
			
			//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			exinfo.cbsize = Strings.Len (exinfo);
			
			result = FMOD_System_CreateSoundEx (system_Renamed, Name_or_data, Mode, ref exinfo, ref Sound);
			
			return result;
		}

		//UPGRADE_NOTE: system was upgraded to system_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
		public static FMOD_RESULT FMOD_System_CreateStream (int system_Renamed, string Name_or_data, FMOD_MODE Mode, ref int Sound)
		{
			FMOD_CREATESOUNDEXINFO exinfo = new FMOD_CREATESOUNDEXINFO ();
			FMOD_RESULT result = default(FMOD_RESULT);
			
			//UPGRADE_ISSUE: LenB function is not supported. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="367764E5-F3F8-4E43-AC3E-7FE0B5E074E2"'
			exinfo.cbsize = Strings.Len (exinfo);
			
			result = FMOD_System_CreateStreamEx (system_Renamed, Name_or_data, Mode, ref exinfo, ref Sound);
			
			return result;
		}
		
	}
}
