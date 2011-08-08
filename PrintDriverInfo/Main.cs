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

