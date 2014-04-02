using System;
using System.Runtime.InteropServices;
using System.Security;
using nFMOD.Enums;

namespace nFMOD
{	
	/// <summary>
	/// Bit fields to use with <see cref="Debug.Level"/> to
	/// control the level of tty debug output with logging versions of FMOD (fmodL).
	/// </summary>
	/// <platforms>
	/// Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2,
	/// PlayStation Portable, PlayStation 3, Wii, Android
	/// </platforms>
	[Flags]
	public enum DebugLevel : byte
	{
		None = 0x00,
		
		Log = 0x01,
		Error = 0x02,
		Warning = 0x04,
		Hint = 0x08,
		
		All = 0xFF,
	}
	
	[Flags]
	public enum DebugType : byte
	{
		None = 0x00,
		
		Memory = 0x01,
        Thread = 0x02,
        File = 0x04,
        Net = 0x08,
        Event = 0x10,
		
        All = 0xFF,
	}
	
	[Flags]
	public enum DebugDisplay : byte
	{
		None = 0x00,
		
		Timestamps = 0x01,
        LineNumbers = 0x02,
        Compress = 0x04,
        Thread = 0x08,
		
        All = 0x0F,
	}
	
	/// <platforms>
	/// Win32, Win64, Linux, Linux64, Macintosh, Xbox360, PlayStation 2,
	/// PlayStation Portable, PlayStation 3, Wii
	/// </platforms>
	public static class Debug
	{
		public static DebugLevel Level {
			get { return (DebugLevel)(DebugValue & 0xFF); }
			set { DebugValue = (int)value | (int)(DebugValue & 0xFFFFFF00); }
		}
		
		public static DebugType Type {
			get { return (DebugType)((DebugValue >> 8) & 0xFF); }
			set { DebugValue = ((int)value << 8) | (int)(DebugValue & 0xFFFF00FF); }
		}
		
		public static DebugDisplay Display {
			get { return (DebugDisplay)((DebugValue >> 24) & 0x0F); }
			set { DebugValue = (((int)value & 0x0F) << 24) | (int)(DebugValue & 0xF0FFFFFF); }
		}
		
		private static int DebugValue 
        {
		    get
		    {		        
		        try
		        {
                    int value = 0;
		            Errors.ThrowIfError(GetLevel(ref value));
                    return value;
		        }
		        catch (FmodUnimplementedException ex)
		        {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return -1;
		        }
			}
			
			set 
            {
                try
		        {
		            Errors.ThrowIfError(SetLevel(value));
		        }
		        catch (FmodUnimplementedException ex)
		        {
                    System.Diagnostics.Debug.WriteLine(ex.Message);                    
		        }
			}
		}
		
		[DllImport("fmodex", SetLastError = true, EntryPoint = "FMOD_Debug_SetLevel"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetLevel (int Level);
		
		[DllImport("fmodex", SetLastError = true, EntryPoint = "FMOD_Debug_GetLevel"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetLevel (ref int Level);
		
	}
}
