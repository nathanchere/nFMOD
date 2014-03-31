using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security;

namespace nFMOD.SoundSystem
{
	public partial class SoundSystem
	{
		public OutputDriver OutputDriver {
			get {
				int driver;
				Error.Code ReturnCode = GetDriver (this.DangerousGetHandle (), out driver);
				Error.Errors.ThrowError (ReturnCode);
				
				return this.GetOutputDriver(driver);
			}
			set {
				Error.Code ReturnCode = SetDriver (this.DangerousGetHandle (), value.Id);
				Error.Errors.ThrowError (ReturnCode);
			}
		}
		
		public IEnumerable<OutputDriver> OutputDrivers {
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
				Error.Code ReturnCode = GetNumDrivers (this.DangerousGetHandle (), out numdrivers);
				Error.Errors.ThrowError (ReturnCode);
				
				return numdrivers;
			}
		}
		
		private void GetOutputDriverInfo(int Id, out string Name, out Guid DriverGuid)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder(255);
			
			Error.Code ReturnCode = GetDriverInfo (this.DangerousGetHandle (), Id, str, str.Capacity, out DriverGuid);
			Error.Errors.ThrowError (ReturnCode);
			
			Name = str.ToString();
		}
		
		private void GetOutputDriverCapabilities (int Id, out Capabilities caps, out int minfrequency, out int maxfrequency, out SpeakerMode controlpanelspeakermode)
		{
			Error.Code ReturnCode = GetDriverCaps (this.DangerousGetHandle (), Id, out caps, out minfrequency, out maxfrequency, out controlpanelspeakermode);
			Error.Errors.ThrowError (ReturnCode);
		}
		
		private OutputDriver GetOutputDriver (int Id)
		{
			Guid DriverGuid;
			string DriverName;
			this.GetOutputDriverInfo(Id, out DriverName, out DriverGuid);
			
			Capabilities caps;
			int minfrequency, maxfrequency;
			SpeakerMode controlpanelspeakermode;
			this.GetOutputDriverCapabilities(Id, out caps, out minfrequency, out maxfrequency, out controlpanelspeakermode);
			
			return new OutputDriver {
				Id = Id,
				Name = DriverName,
				Guid = DriverGuid,
				
				Capabilities = caps,
				MinimumFrequency = minfrequency,
				MaximumFrequency = maxfrequency,
				SpeakerMode = controlpanelspeakermode
			};
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetNumDrivers"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetNumDrivers (IntPtr system, out int Numdrivers);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverInfo"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetDriverInfo (IntPtr system, int id, System.Text.StringBuilder name, int namelen, out Guid guid);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverInfoW"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetDriverInfoW (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder name, int namelen, out Guid guid);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriverCaps"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetDriverCaps (IntPtr system, int id, out Capabilities caps, out int minfrequency, out int maxfrequency, out SpeakerMode controlpanelspeakermode);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_SetDriver"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code SetDriver (IntPtr system, int driver);

		[DllImport("fmodex", EntryPoint = "FMOD_System_GetDriver"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetDriver (IntPtr system, out int driver);
		
	}
}

