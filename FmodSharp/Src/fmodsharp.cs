using System;

using SoundsSharpNameSpace.fmodex.fmodexvb;
using SoundsSharpNameSpace.fmodex.DSP;

namespace FmodSharp
{

	public class SoundsSharp
	{
		//public static  GlobalVelocity;
		public static Vector lastpos = new Vector ();


		#region "SoundManager"
		public static long SoundSystem;
		public class SoundManager
		{
			#region "SoundManager::Init Stuffs"
			#region "SoundManager::Init Stuffs::New"
			public SoundManager ()
			{
				Init ();
				Config (FMOD_OUTPUTTYPE.FMOD_OUTPUTTYPE_OPENAL, FMOD_SPEAKERMODE.FMOD_SPEAKERMODE_STEREO);
			}
			public SoundManager (FMOD_OUTPUTTYPE optype)
			{
				Init ();
				Config (optype, FMOD_SPEAKERMODE.FMOD_SPEAKERMODE_STEREO);
			}
			public SoundManager (FMOD_OUTPUTTYPE optype, FMOD_SPEAKERMODE spkmde)
			{
				Init ();
				Config (optype, spkmde);
			}
			#endregion

			public bool Init ()
			{
				bool FirstResult = false;
				bool SecondResult = false;
				if (SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Create (ref SoundsSharp.SoundSystem) == 0) {
					FirstResult = true;
				} else {
					FirstResult = false;
				}
				
				
				if (SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Init (SoundsSharp.SoundSystem, 32, FMOD_INITFLAGS.FMOD_INIT_3D_RIGHTHANDED, 0) == FMOD_RESULT.FMOD_OK) {
					SecondResult = true;
				} else {
					SecondResult = false;
				}
				
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Set3DSettings (SoundsSharp.SoundSystem, 1, 1.0, 1);
				
				return (FirstResult & SecondResult);
			}

			public void Config (fmodex.FMOD_OUTPUTTYPE Outputmode, fmodex.FMOD_SPEAKERMODE SpeakerMode)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_SetOutput (SoundsSharp.SoundSystem, Outputmode);
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_SetSpeakerMode (SoundsSharp.SoundSystem, SpeakerMode);
			}
			#endregion
			//  Function CreateSound(ByVal filepath$, ByVal Position As vector) As SoundEntity
			//Dim tempSound&
			//Dim SndEnt As New SoundEntity
			//
			//           SndEnt.hWnd = tempSound
			//          Return SndEnt
			//     End Function

			private long[] DSP = new long[21];
			private long[] Active = new long[21];
			public long getID ()
			{
				return SoundsSharp.SoundSystem;
			}
			public void ActivateSFX (FMOD_DSP_TYPE type)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_CreateDSPByType (SoundsSharp.SoundSystem, FMOD_DSP_TYPE.FMOD_DSP_TYPE_COMPRESSOR, ref DSP (type));
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_DSP_GetActive (DSP (type), ref Active (type));
			}
			public void DesactivateSFX (FMOD_DSP_TYPE type)
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_DSP_Remove (DSP (type));
			}

			public void Update ()
			{
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Update (SoundsSharp.SoundSystem);
			}

			public void Update_3D (Vector pos, Vector Forward, Vector up, float FPS)
			{
				Vector vel = default(Vector);
				vel.X = (pos.X - SoundsSharp.lastpos.X) * (1000 / FPS);
				vel.Y = (pos.Y - SoundsSharp.lastpos.Y) * (1000 / FPS);
				vel.Z = (pos.Z - SoundsSharp.lastpos.Z) * (1000 / FPS);
				
				SoundsSharp.lastpos = pos;
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Update (SoundsSharp.SoundSystem);
				SoundsSharpNameSpace.fmodex.fmodexvb.FMOD_System_Set3DListenerAttributes (SoundsSharp.SoundSystem, 0, ref pos, ref SoundsSharp.GlobalVelocity, ref Forward, ref up);
				
			}
			
			
			
			
		}
		#endregion
		
	}
}

