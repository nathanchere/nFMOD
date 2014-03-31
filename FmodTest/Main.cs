using System;

namespace nFMOD.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Sound Test");
			
#if DEBUG
			
#else
			nFMOD.Debug.Level = nFMOD.DebugLevel.Error;
#endif
			
			Console.WriteLine ("Level: {0}", nFMOD.Debug.Level);
			Console.WriteLine ("Type: {0}", nFMOD.Debug.Type);
			Console.WriteLine ("Display: {0}", nFMOD.Debug.Display);
			
			var SoundSystem = new nFMOD.SoundSystem.SoundSystem();
			
			Console.WriteLine ("Default Output Type: {0}", SoundSystem.Output);
			
			SoundSystem.Init();
			
			nFMOD.Channel.Channel Chan = null;
			
			//Create an oscillator DSP unit for the tone.
			nFMOD.Dsp.Dsp Oscillator;
			
			Oscillator = SoundSystem.CreateDspByType(nFMOD.Dsp.Type.Oscillator);
			Chan = SoundSystem.PlayDsp(Oscillator);
			
			Console.WriteLine("\nPress Enter to stop.\n");
			bool Quit = false;
			while(!Quit) {
				switch (Console.ReadKey().Key) {
				
				case ConsoleKey.Enter:
				case ConsoleKey.Escape:
					Quit = true;
					break;
				
					//Change note
				case ConsoleKey.LeftArrow :
					//Oscillator.setParameter((int)FMOD.DSP_OSCILLATOR.RATE, 440.0f);
					break;
					
				case ConsoleKey.RightArrow:
					//Oscillator.setParameter((int)FMOD.DSP_OSCILLATOR.RATE, 440.0f);
					break;
					
					//Change Volume
				case ConsoleKey.UpArrow:
					Chan.Volume += 0.05f;
					break;
					
				case ConsoleKey.DownArrow:
					Chan.Volume -= 0.05f;
					break;
					
					//Change Tone
				case ConsoleKey.Spacebar:
					//dsp.setParameter((int)FMOD.DSP_OSCILLATOR.TYPE, 0);
					//channel.setPaused(false);
					break;
					
				default:
					break;
				}
				
				System.Threading.Thread.Sleep(10);
			}
			Chan.Dispose();
			SoundSystem.CloseSystem();
			SoundSystem.Dispose();
		}
	}
}

