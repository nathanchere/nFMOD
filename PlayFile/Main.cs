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

namespace PlayFile
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Play File Test");
			
#if DEBUG
			
#else
			Linsft.FmodSharp.Debug.Level = Linsft.FmodSharp.DebugLevel.Error;
#endif
			
			var SoundSystem = new Linsft.FmodSharp.SoundSystem.SoundSystem();
			
			Console.WriteLine ("Default Output: {0}", SoundSystem.Output);
			
			SoundSystem.Init();
			SoundSystem.ReverbProperties = Linsft.FmodSharp.Reverb.Presets.Room;
			
			if (args.Length > 0) {
				foreach (string StringItem in args) {
					Linsft.FmodSharp.Sound.Sound SoundFile;
					SoundFile = SoundSystem.CreateSound (StringItem);
					
					Linsft.FmodSharp.Channel.Channel Chan;
					Chan = SoundSystem.PlaySound(SoundFile);
					
					while(Chan.IsPlaying) {
						System.Threading.Thread.Sleep(10);
					}
					
					SoundFile.Dispose();
					Chan.Dispose();
				}
				
			} else {
				Console.WriteLine ("No File to play.");
			}
			
			SoundSystem.CloseSystem();
			SoundSystem.Dispose();
		}
	}
}