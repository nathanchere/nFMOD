//Author:
//      Marc-Andre Ferland <madrang@gmail.com>
//
//Copyright (c) 2011 TheWarrentTeam
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System;

namespace FmodTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Sound Test");
			
#if DEBUG
			
#else
			FmodSharp.Debug.Level = FmodSharp.DebugLevel.Error;
#endif
			
			Console.WriteLine ("Level: {0}", FmodSharp.Debug.Level);
			Console.WriteLine ("Type: {0}", FmodSharp.Debug.Type);
			Console.WriteLine ("Display: {0}", FmodSharp.Debug.Display);
			
			FmodSharp.SoundSystem.SoundSystem  SoundSystem = new FmodSharp.SoundSystem.SoundSystem();
			
			Console.WriteLine ("Default Output Type: {0}", SoundSystem.Output);
			
			SoundSystem.Init();
			
			FmodSharp.Channel.Channel Chan = null;
			
			//Create an oscillator DSP unit for the tone.
			FmodSharp.Dsp.Dsp Oscillator;
			
			Oscillator = SoundSystem.CreateDspByType(FmodSharp.Dsp.Type.Oscillator);
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

