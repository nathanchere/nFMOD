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

namespace PrintDriverInfo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Fmod Driver Info Test");
			
#if DEBUG
			
#else
			Xpod.FmodSharp.Debug.Level = Xpod.FmodSharp.DebugLevel.Error;
#endif
			
			var SoundSystem = new Xpod.FmodSharp.SoundSystem.SoundSystem();
			
			Console.WriteLine("OutputDrivers");
			foreach (Xpod.FmodSharp.SoundSystem.OutputDriver DriverItem in SoundSystem.OutputDrivers) {
				Console.WriteLine("  {0}", DriverItem.Name);
				Console.WriteLine("    Guid: {0}", DriverItem.Guid);
				Console.WriteLine("    Capabilities: {0}", DriverItem.Capabilities);
				Console.WriteLine("    Minimum Frequency: {0}", DriverItem.MinimumFrequency);
				Console.WriteLine("    Maximum Frequency: {0}", DriverItem.MaximumFrequency);
				Console.WriteLine("    Speaker Mode: {0}", DriverItem.SpeakerMode);
			}
			Console.WriteLine("");
			
			Console.WriteLine("RecordDrivers");
			foreach (Xpod.FmodSharp.SoundSystem.RecordDriver DriverItem in SoundSystem.RecordDrivers) {
				Console.WriteLine("  {0}", DriverItem.Name);
				Console.WriteLine("    Guid: {0}", DriverItem.Guid);
				Console.WriteLine("    Capabilities: {0}", DriverItem.Capabilities);
				Console.WriteLine("    Minimum Frequency: {0}", DriverItem.MinimumFrequency);
				Console.WriteLine("    Maximum Frequency: {0}", DriverItem.MaximumFrequency);
			}
			
			SoundSystem.Dispose();
		}
	}
}

