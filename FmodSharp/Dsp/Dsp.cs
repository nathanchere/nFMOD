using System;
using System.Runtime.InteropServices;

namespace FmodSharp.Dsp
{
	public class Dsp : Handle
	{
		internal Dsp (IntPtr hnd) : base()
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
		
		[DllImport ("fmodex", EntryPoint = "FMOD_DSP_Release")]
		private static extern Error.Code Release (IntPtr dsp);
		
		/*

		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetSystemObject           (IntPtr dsp, ref IntPtr system);
        
		[DllImport (VERSION.dll)]                   
        private static extern RESULT FMOD_DSP_AddInput                  (IntPtr dsp, IntPtr target, ref IntPtr connection);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_DisconnectFrom            (IntPtr dsp, IntPtr target);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_DisconnectAll             (IntPtr dsp, int inputs, int outputs);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_Remove                    (IntPtr dsp);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetNumInputs              (IntPtr dsp, ref int numinputs);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetNumOutputs             (IntPtr dsp, ref int numoutputs);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetInput                  (IntPtr dsp, int index, ref IntPtr input, ref IntPtr inputconnection);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetOutput                 (IntPtr dsp, int index, ref IntPtr output, ref IntPtr outputconnection);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetActive                 (IntPtr dsp, int active);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetActive                 (IntPtr dsp, ref int active);    
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetBypass                 (IntPtr dsp, int bypass);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetBypass                 (IntPtr dsp, ref int bypass);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetSpeakerActive          (IntPtr dsp, SPEAKER speaker, int active);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetSpeakerActive          (IntPtr dsp, SPEAKER speaker, ref int active);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_Reset                     (IntPtr dsp);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetParameter              (IntPtr dsp, int index, float value);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetParameter              (IntPtr dsp, int index, ref float value, StringBuilder valuestr, int valuestrlen);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetNumParameters          (IntPtr dsp, ref int numparams);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetParameterInfo          (IntPtr dsp, int index, ref IntPtr name, ref IntPtr label, StringBuilder description, int descriptionlen, ref float min, ref float max);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_ShowConfigDialog          (IntPtr dsp, IntPtr hwnd, int show);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetInfo                   (IntPtr dsp, ref IntPtr name, ref uint version, ref int channels, ref int configwidth, ref int configheight);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetType                   (IntPtr dsp, ref DSP_TYPE type);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_SetDefaults               (IntPtr dsp, float frequency, float volume, float pan, int priority);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetDefaults               (IntPtr dsp, ref float frequency, ref float volume, ref float pan, ref int priority);
        
		[DllImport (VERSION.dll)]                   
        private static extern RESULT FMOD_DSP_SetUserData               (IntPtr dsp, IntPtr userdata);
        
		[DllImport (VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetUserData               (IntPtr dsp, ref IntPtr userdata);
        
		[DllImport(VERSION.dll)]
        private static extern RESULT FMOD_DSP_GetMemoryInfo             (IntPtr dsp, uint memorybits, uint event_memorybits, ref uint memoryused, ref MEMORY_USAGE_DETAILS memoryused_details);
		*/
	}
}
