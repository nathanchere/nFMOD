using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
    public class Geometry : Handle
    {
        #region Externs
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_Release"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Release(IntPtr geometry);
        
        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_Flush"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Flush(IntPtr geometry);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_AddPolygon"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode AddPolygon(IntPtr geometry, float directocclusion, float reverbocclusion, int doublesided, int numvertices, Vector3[] vertices, ref int polygonindex);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetNumPolygons"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetNumPolygons(IntPtr geometry, ref int numpolygons);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetMaxPolygons"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMaxPolygons(IntPtr geometry, ref int maxpolygons, ref int maxvertices);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetPolygonNumVertices"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPolygonNumVertices(IntPtr geometry, int index, ref int numvertices);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetPolygonVertex"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPolygonVertex(IntPtr geometry, int index, int vertexindex, ref Vector3 vertex);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetPolygonVertex"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPolygonVertex(IntPtr geometry, int index, int vertexindex, ref Vector3 vertex);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetPolygonAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPolygonAttributes(IntPtr geometry, int index, float directocclusion, float reverbocclusion, int doublesided);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetPolygonAttributes"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPolygonAttributes(IntPtr geometry, int index, ref float directocclusion, ref float reverbocclusion, ref int doublesided);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetActive(IntPtr geometry, int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetActive"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetActive(IntPtr geometry, ref int active);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetRotation"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetRotation(IntPtr geometry, ref Vector3 forward, ref Vector3 up);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetRotation"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetRotation(IntPtr geometry, ref Vector3 forward, ref Vector3 up);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetPosition(IntPtr geometry, ref Vector3 position);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetPosition(IntPtr geometry, ref Vector3 position);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetScale"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetScale(IntPtr geometry, ref Vector3 scale);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetScale"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetScale(IntPtr geometry, ref Vector3 scale);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_Save"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode Save(IntPtr geometry, IntPtr data, ref int datasize);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_SetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode SetUserData(IntPtr geometry, IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetUserData"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetUserData(IntPtr geometry, ref IntPtr userdata);

        [DllImport(Common.FMOD_DLL_NAME, EntryPoint = "FMOD_Geometry_GetMemoryInfo"), SuppressUnmanagedCodeSecurity]
        private static extern ErrorCode GetMemoryInfo(IntPtr geometry, uint memorybits, uint event_memorybits, ref uint memoryused, ref MemoryUsageDetails memoryused_details);
        #endregion

        private Geometry() { }

        internal Geometry(IntPtr hnd)
        {
            SetHandle(hnd);
        }

        protected override bool ReleaseHandle()
        {
            if (IsInvalid) return true;

            Release(handle);
            SetHandleAsInvalid();
            return true;
        }
    }
}

