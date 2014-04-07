using System;
using System.Runtime.InteropServices;
using System.Security;

namespace nFMOD
{
	public partial class SoundSystem
	{
		
		public Dsp CreateDSP(ref Dsp.DSPDescription description)
		{
			IntPtr DspHandle = IntPtr.Zero;
			
			ErrorCode ReturnCode = CreateDSP (this.DangerousGetHandle (), ref description, ref DspHandle);
			Errors.ThrowIfError (ReturnCode);
			
			return new Dsp (DspHandle);
		}
		
		public Dsp CreateDspByType(DspType type)
		{
			IntPtr DspHandle = IntPtr.Zero;
			
			ErrorCode ReturnCode = CreateDspByType (this.DangerousGetHandle (), type, ref DspHandle);
			Errors.ThrowIfError (ReturnCode);
			
			return new Dsp (DspHandle);
		}
		
		public Channel PlayDsp (Dsp dsp)
		{
			return PlayDsp (dsp, false);
		}

		public Channel PlayDsp (Dsp dsp, bool paused)
		{
			IntPtr ChannelHandle = IntPtr.Zero;
			
			ErrorCode ReturnCode = PlayDsp (this.DangerousGetHandle (), Channel.Index.Free, dsp.DangerousGetHandle (), paused, ref ChannelHandle);
			Errors.ThrowIfError (ReturnCode);
			
			return new Channel(ChannelHandle);
		}

		public void PlayDsp (Dsp dsp, bool paused, Channel chn)
		{
			IntPtr channel = chn.DangerousGetHandle ();
			
			ErrorCode ReturnCode = PlayDsp (this.DangerousGetHandle (), Channel.Index.Reuse, dsp.DangerousGetHandle (), paused, ref channel);
			Errors.ThrowIfError (ReturnCode);
			
			//This can't really happend.
			//Check just in case...
			if(chn.DangerousGetHandle () != channel)
				throw new Exception("Channel handle got changed by Fmod.");
		}
		
		public DspConnection AddDsp (Dsp dsp)
		{
			IntPtr ConnectionHandle = IntPtr.Zero;
			
			ErrorCode ReturnCode = AddDSP (this.DangerousGetHandle (), dsp.DangerousGetHandle (), ref ConnectionHandle);
			Errors.ThrowIfError (ReturnCode);
			
			return new DspConnection (ConnectionHandle);
		}
		
		public void LockDSP ()
		{
			ErrorCode ReturnCode = LockDSP (this.DangerousGetHandle ());
			Errors.ThrowIfError (ReturnCode);
		}
		
		public void UnlockDSP ()
		{
			ErrorCode ReturnCode = UnlockDSP (this.DangerousGetHandle ());
			Errors.ThrowIfError (ReturnCode);
		}
		
		public ulong DSPClock {
			get {
				uint hi = 0, low = 0;
				ErrorCode ReturnCode = GetDSPClock (this.DangerousGetHandle (), ref hi, ref low);
				Errors.ThrowIfError (ReturnCode);
				return (hi << 32) | low;
			}
		}

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport ("fmodex", EntryPoint = "FMOD_System_CreateDSP")]
		private static extern ErrorCode CreateDSP (IntPtr system, ref Dsp.DSPDescription description, ref IntPtr dsp);

		[System.Security.SuppressUnmanagedCodeSecurity]
		[DllImport ("fmodex", EntryPoint = "FMOD_System_CreateDSPByType")]
		private static extern ErrorCode CreateDspByType (IntPtr system, DspType type, ref IntPtr dsp);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_PlayDSP"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode PlayDsp (IntPtr system, Channel.Index channelid, IntPtr dsp, bool paused, ref IntPtr channel);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_AddDSP"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode AddDSP (IntPtr system, IntPtr dsp, ref IntPtr connection);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_LockDSP"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode LockDSP (IntPtr system);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_UnlockDSP"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode UnlockDSP (IntPtr system);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetDSPClock"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDSPClock (IntPtr system, ref uint hi, ref uint lo);
	}
}

