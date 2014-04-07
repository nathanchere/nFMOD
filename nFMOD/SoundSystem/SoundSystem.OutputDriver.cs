using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security;

namespace nFMOD
{
	public partial class SoundSystem
	{
        public struct OutputDriverDTO
	    {
		    internal int Id { get; set; }
		    public string Name { get; internal set; }
		    public Guid Guid { get; internal set; }
		    public Capabilities Capabilities { get; internal set; }
		    public int MinimumFrequency { get; internal set; }
		    public int MaximumFrequency { get; internal set; }
		    public SpeakerMode SpeakerMode { get; internal set; }
		
		    public override string ToString ()
		    {
			    return this.Name;
		    }
	    }

		public OutputDriverDTO OutputDriver {
			get {
				int driver;
				ErrorCode ReturnCode = GetDriver (this.DangerousGetHandle (), out driver);
				Errors.ThrowIfError (ReturnCode);
				
				return this.GetOutputDriver(driver);
			}
			set {
				ErrorCode ReturnCode = SetDriver (this.DangerousGetHandle (), value.Id);
				Errors.ThrowIfError (ReturnCode);
			}
		}
		
		public IEnumerable<OutputDriverDTO> OutputDrivers {
			get {
				int Numb = this.NumberOutputDrivers;
				for (int i = 0; i < Numb; i++) {
					yield return this.GetOutputDriver(i);
				}
			}
		}
		
		private int NumberOutputDrivers {
			get {
				int numdrivers;
				ErrorCode ReturnCode = GetNumDrivers (this.DangerousGetHandle (), out numdrivers);
				Errors.ThrowIfError (ReturnCode);
				
				return numdrivers;
			}
		}
		
		private void GetOutputDriverInfo(int Id, out string Name, out Guid DriverGuid)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder(255);
			
			ErrorCode ReturnCode = GetDriverInfo (this.DangerousGetHandle (), Id, str, str.Capacity, out DriverGuid);
			Errors.ThrowIfError (ReturnCode);
			
			Name = str.ToString();
		}
		
		private void GetOutputDriverCapabilities (int Id, out Capabilities caps, out int minfrequency, out int maxfrequency, out SpeakerMode controlpanelspeakermode)
		{
			ErrorCode ReturnCode = GetDriverCaps (this.DangerousGetHandle (), Id, out caps, out minfrequency, out maxfrequency, out controlpanelspeakermode);
			Errors.ThrowIfError (ReturnCode);
		}
		
		private OutputDriverDTO GetOutputDriver (int Id)
		{
			Guid DriverGuid;
			string DriverName;
			this.GetOutputDriverInfo(Id, out DriverName, out DriverGuid);
			
			Capabilities caps;
			int minfrequency, maxfrequency;
			SpeakerMode controlpanelspeakermode;
			this.GetOutputDriverCapabilities(Id, out caps, out minfrequency, out maxfrequency, out controlpanelspeakermode);
			
			return new OutputDriverDTO {
				Id = Id,
				Name = DriverName,
				Guid = DriverGuid,
				
				Capabilities = caps,
				MinimumFrequency = minfrequency,
				MaximumFrequency = maxfrequency,
				SpeakerMode = controlpanelspeakermode
			};
		}
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetNumDrivers"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetNumDrivers (IntPtr system, out int Numdrivers);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetDriverInfo"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDriverInfo (IntPtr system, int id, System.Text.StringBuilder name, int namelen, out Guid guid);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetDriverInfoW"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDriverInfoW (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder name, int namelen, out Guid guid);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetDriverCaps"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDriverCaps (IntPtr system, int id, out Capabilities caps, out int minfrequency, out int maxfrequency, out SpeakerMode controlpanelspeakermode);
		
		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_SetDriver"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode SetDriver (IntPtr system, int driver);

		[DllImport(Common.FMOD_DLL, EntryPoint = "FMOD_System_GetDriver"), SuppressUnmanagedCodeSecurity]
		private static extern ErrorCode GetDriver (IntPtr system, out int driver);
		
	}
}

