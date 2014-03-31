using System;
using System.Runtime.InteropServices;

namespace nFMOD
{
	public class Geometry : Handle
	{
		private Geometry()
		{
		}
		
		internal Geometry (IntPtr hnd) : base()
		{
			this.SetHandle (hnd);
		}

		protected override bool ReleaseHandle ()
		{
			if (this.IsInvalid)
				return true;
			
			Release (this.handle);
			this.SetHandleAsInvalid ();
			
			return true;
		}
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_Geometry_Release")]
		private static extern Error.Code Release (IntPtr geometry);
		
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport("fmodex", EntryPoint = "FMOD_Geometry_Flush")]
        private static extern Error.Code Flush_External (IntPtr geometry);
    
		
		//TODO Implement extern funcitons
		
		/*
		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_AddPolygon           (IntPtr geometry, float directocclusion, float reverbocclusion, int doublesided, int numvertices, VECTOR[] vertices, ref int polygonindex);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetNumPolygons       (IntPtr geometry, ref int numpolygons);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetMaxPolygons       (IntPtr geometry, ref int maxpolygons, ref int maxvertices);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetPolygonNumVertices(IntPtr geometry, int index, ref int numvertices);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_SetPolygonVertex     (IntPtr geometry, int index, int vertexindex, ref VECTOR vertex);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetPolygonVertex     (IntPtr geometry, int index, int vertexindex, ref VECTOR vertex);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_SetPolygonAttributes (IntPtr geometry, int index, float directocclusion, float reverbocclusion, int doublesided);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetPolygonAttributes (IntPtr geometry, int index, ref float directocclusion, ref float reverbocclusion, ref int doublesided);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_SetActive            (IntPtr geometry, int active);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetActive            (IntPtr geometry, ref int active);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_SetRotation          (IntPtr geometry, ref VECTOR forward, ref VECTOR up);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetRotation          (IntPtr geometry, ref VECTOR forward, ref VECTOR up);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_SetPosition          (IntPtr geometry, ref VECTOR position);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetPosition          (IntPtr geometry, ref VECTOR position);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_SetScale             (IntPtr geometry, ref VECTOR scale);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetScale             (IntPtr geometry, ref VECTOR scale);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_Save                 (IntPtr geometry, IntPtr data, ref int datasize);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]                   
        private static extern RESULT FMOD_Geometry_SetUserData          (IntPtr geometry, IntPtr userdata);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetUserData          (IntPtr geometry, ref IntPtr userdata);
        
        [System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport(VERSION.dll)]
        private static extern RESULT FMOD_Geometry_GetMemoryInfo        (IntPtr geometry, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		
		*/
	}
}

