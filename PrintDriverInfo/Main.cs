using System;

namespace PrintDriverInfo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Driver Info Test");
			
#if DEBUG
			
#else
			FmodSharp.Debug.Level = FmodSharp.DebugLevel.Error;
#endif
			
			FmodSharp.SoundSystem.SoundSystem  SoundSystem = new FmodSharp.SoundSystem.SoundSystem();
			Guid DriverGuid = new Guid();
			string Name;
			
			int numbDriver = SoundSystem.NumberOutputDrivers;
			Console.WriteLine("Found {0} output drivers.", numbDriver);
			for (int i = 0; i < numbDriver; i++) {
				SoundSystem.GetOutputDriverInfo(i, out Name, ref DriverGuid);
				Console.WriteLine("{0}: {1}", Name, DriverGuid);
			}
			
			int numbRecordDriver = SoundSystem.NumberRecordDrivers;
			Console.WriteLine("Found {0} record drivers.", numbRecordDriver);
			for (int i = 0; i < numbRecordDriver; i++) {
				SoundSystem.GetRecordDriverInfo(i, out Name, ref DriverGuid);
				Console.WriteLine("{0}: {1}", Name, DriverGuid);
			}
			
			SoundSystem.Dispose();
		}
	}
}

