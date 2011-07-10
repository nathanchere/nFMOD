using System;
using System.Runtime.InteropServices;

namespace FmodSharp
{
	/// <summary>
	/// Bit fields to use with <see cref="FmodSharp.Debug.Level"/> to
	/// control the level of tty debug output with logging versions of FMOD (fmodL).
	/// </summary>
	/// <platforms>
	/// Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2,
	/// PlayStation Portable, PlayStation 3, Wii, Android
	/// </platforms>
	[Flags]
	public enum DebugLevel
	{
		Level_None = 0x00000000,
        Level_Log = 0x00000001,
        Level_Error = 0x00000002,
        Level_Warning = 0x00000004,
        Level_Hint = 0x00000008,
        Level_All = 0x000000FF,
        
		Type_Memory = 0x00000100,
        Type_Thread = 0x00000200,
        Type_File = 0x00000400,
        Type_Net = 0x00000800,
        Type_Event = 0x00001000,
        Type_All = 0x0000FF00,
        
		Display_Timestamps = 0x01000000,
        Display_LineNumbers = 0x02000000,
        Display_Compress = 0x04000000,
        Display_Thread = 0x08000000,
        Display_All = 0x0F000000,
        
		All = Level_All | Type_All | Display_All,
	}
	
	/// <platforms>
	/// Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2,
	/// PlayStation Portable, PlayStation 3, Wii
	/// </platforms>
	public static class Debug
	{
		public static DebugLevel Level
		{
			get {
				DebugLevel Val = (DebugLevel)0;
				
				Error.Code ReturnCode = GetLevel(ref Val);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
				
				return Val;
			}
			
			set {
				Error.Code ReturnCode = SetLevel(value);
				if(ReturnCode != Error.Code.OK)
					Error.Errors.ThrowError(ReturnCode);
			}
		}
	
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_Debug_SetLevel")]
		private static extern Error.Code SetLevel (DebugLevel Level);
		
		[DllImport("fmodex", CharSet = CharSet.Ansi, SetLastError = true, EntryPoint = "FMOD_Debug_GetLevel")]
		private static extern Error.Code GetLevel (ref DebugLevel Level);
	}
}
