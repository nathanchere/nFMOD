using System;
using System.Runtime.InteropServices;

namespace nFMOD
{
	
	/// <summary>
	/// Structure describing a point in 3D space.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct Vector3
	{
		public float X;
		public float Y;
		public float Z;
	}
	
	//[REMARKS]
	//FMOD uses a left handed co-ordinate system by default.<br>
	//To use a right handed co-ordinate system specify FMOD_INIT_3D_RIGHTHANDED from FMOD_INITFLAGS in System::init.
	
	//[PLATFORMS]
	//Win32, Win64, Linux, Linux64, Macintosh, Xbox, Xbox360, PlayStation 2, GameCube, PlayStation Portable, PlayStation 3, Wii
	
	//[SEE_ALSO]
	//FMOD_System_Set3DListenerAttributes
	//FMOD_System_Get3DListenerAttributes
	//FMOD_Channel_Set3DAttributes
	//FMOD_Channel_Get3DAttributes
	//FMOD_Geometry_AddPolygon
	//FMOD_Geometry_SetPolygonVertex
	//FMOD_Geometry_GetPolygonVertex
	//FMOD_Geometry_SetRotation
	//FMOD_Geometry_GetRotation
	//FMOD_Geometry_SetPosition
	//FMOD_Geometry_GetPosition
	//FMOD_Geometry_SetScale
	//FMOD_Geometry_GetScale
	//FMOD_INITFLAGS
	//]
	//
}
