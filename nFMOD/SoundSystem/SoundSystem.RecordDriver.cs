using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security;

namespace nFMOD.SoundSystem
{
	public partial class SoundSystem
	{
        public struct RecordDriverDTO
	    {
		    internal int Id { get; set; }
		    public string Name { get; internal set; }
		    public Guid Guid { get; internal set; }
		    public Capabilities Capabilities { get; internal set; }
		    public int MinimumFrequency { get; internal set; }
		    public int MaximumFrequency { get; internal set; }
		
		    public override string ToString ()
		    {
			    return this.Name;
		    }
	    }

		public IEnumerable<RecordDriverDTO> RecordDrivers {
			get {
				int Numb = this.NumberRecordDrivers;
				for (int i = 0; i < Numb; i++) {
					yield return this.GetRecordDriver(i);
				}
			}
		}
		
		private int NumberRecordDrivers {
			get {
				int numdrivers;
				
				Error.Code ReturnCode = GetRecordNumDrivers (this.DangerousGetHandle (), out numdrivers);
				Error.Errors.ThrowError (ReturnCode);
				
				return numdrivers;
			}
		}
		
		private void GetRecordDriverInfo(int Id, out string Name, out Guid DriverGuid)
		{
			System.Text.StringBuilder str = new System.Text.StringBuilder(255);
			
			Error.Code ReturnCode = GetRecordDriverInfo (this.DangerousGetHandle (), Id, str, str.Capacity, out DriverGuid);
			Error.Errors.ThrowError (ReturnCode);
			
			Name = str.ToString();
		}
		
		private void GetRecordDriverCapabilities (int id, out Capabilities caps, out int minfrequency, out int maxfrequency)
		{
			Error.Code ReturnCode = GetRecordDriverCaps (this.DangerousGetHandle (), id, out caps, out minfrequency, out maxfrequency);
			Error.Errors.ThrowError (ReturnCode);
		}
		
		private RecordDriverDTO GetRecordDriver (int Id)
		{
			Guid DriverGuid;
			string DriverName;
			this.GetRecordDriverInfo(Id, out DriverName, out DriverGuid);
			
			Capabilities caps;
			int minfrequency, maxfrequency;
			this.GetRecordDriverCapabilities(Id, out caps, out minfrequency, out maxfrequency);
			
			return new RecordDriverDTO {
				Id = Id,
				Name = DriverName,
				Guid = DriverGuid,
				
				Capabilities = caps,
				MinimumFrequency = minfrequency,
				MaximumFrequency = maxfrequency,
			};
		}
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordNumDrivers"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetRecordNumDrivers (IntPtr system, out int numdrivers);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordDriverInfo"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetRecordDriverInfo (IntPtr system, int id, System.Text.StringBuilder name, int namelen, out Guid guid);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordDriverInfoW"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code FMOD_System_GetRecordDriverInfoW (IntPtr system, int id, [MarshalAs(UnmanagedType.LPWStr)] System.Text.StringBuilder name, int namelen, out Guid guid);
		
		[DllImport("fmodex", EntryPoint = "FMOD_System_GetRecordDriverCaps"), SuppressUnmanagedCodeSecurity]
		private static extern Error.Code GetRecordDriverCaps (IntPtr system, int id, out Capabilities caps, out int minfrequency, out int maxfrequency);
		
	}
}

