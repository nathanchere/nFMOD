using System;

namespace PlayFile
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Play File Test");
			
#if DEBUG
			
#else
			FmodSharp.Debug.Level = FmodSharp.DebugLevel.Error;
#endif
			
			FmodSharp.SoundSystem.SoundSystem  SoundSystem = new FmodSharp.SoundSystem.SoundSystem();
			
			Console.WriteLine ("Default Output: {0}", SoundSystem.Output);
			
			SoundSystem.Init();
			
			FmodSharp.Channel.Channel Chan = null;
			
			bool first = true;
			if (args.Length > 0) {
				foreach (string StringItem in args) {
					FmodSharp.Sound.Sound SoundFile = SoundSystem.CreateSound (StringItem, FmodSharp.Mode.Default);
					
					if(first) Chan = SoundSystem.PlaySound(SoundFile);
					else SoundSystem.PlaySound(SoundFile, false, Chan);
					first = false;
					
					while(Chan.IsPlaying) {
						System.Threading.Thread.Sleep(10);
					}
					
					SoundFile.Dispose();
				}
				
			} else {
				Console.WriteLine ("No File to play.");
			}
			
			SoundSystem.CloseSystem();
			SoundSystem.Dispose();
		}
	}
}