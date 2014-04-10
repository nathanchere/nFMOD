using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{	
	public static class Debug
    {
	    #region Externs
	    [DllImport(Common.FMOD_DLL_NAME, SetLastError = true, EntryPoint = "FMOD_Debug_GetLevel"), SuppressUnmanagedCodeSecurity]
	    private static extern ErrorCode GetLevel (ref int Level);

	    [DllImport(Common.FMOD_DLL_NAME, SetLastError = true, EntryPoint = "FMOD_Debug_SetLevel"), SuppressUnmanagedCodeSecurity]
	    private static extern ErrorCode SetLevel (int Level);
	    #endregion

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
                    int result = 0;
		            Errors.ThrowIfError(GetLevel(ref result));
                    return result;
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
	}
}
