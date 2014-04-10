/*
 * A port of the main demo from FmodSharp (http://gitorious.org/fmodsharp).
 */

using System;
using System.Threading;

namespace nFMOD
{
	class Program
	{
		public static void Main (string[] args)
		{            
			Console.WriteLine ("Fmod Sound Test");
			
			Console.WriteLine ("Level: {0}", Debug.Level);
			Console.WriteLine ("Type: {0}", Debug.Type);
			Console.WriteLine ("Display: {0}", Debug.Display);
			
            var fmod = new FmodSystem();
			
            Console.WriteLine ("Default Output Type: {0}", fmod.Output);
			
            fmod.Init();
			
            Channel Chan = null;
			
            //Create an oscillator DSP unit for the tone.
            Dsp Oscillator;
			
            Oscillator = fmod.CreateDspByType(DspType.Oscillator);
            Chan = fmod.PlayDsp(Oscillator);
			
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
				
                Thread.Sleep(10);
            }
            Oscillator.Dispose();
            Chan.Dispose();
            fmod.CloseSystem();
            fmod.Dispose();

            Console.Write("Press any key to exit...");
            Console.ReadKey(true);
		}        
	}
}

