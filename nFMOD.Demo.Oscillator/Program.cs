using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nFMOD.Dsps;
using System.Threading;
using System.Threading.Tasks;

namespace nFMOD.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var quit = new ManualResetEvent(false);
            Console.CancelKeyPress += (s, a) => {
                quit.Set();
                a.Cancel = true;
            };

            using (var fmod = new FmodSystem()) {
                fmod.Init();                
                using (var oscillator = (Oscillator)fmod.CreateDsp(DspType.Oscillator))
                {
                    oscillator.Play();

                    while (!quit.WaitOne(0))
                    {
                        Console.SetCursorPosition(0,0);
                        var prompt = string.Format(
                            "nFMOD test: DSP (Oscillator)\n" + 
                            "----------------------------\n\n" + 
                            "Generating {0} wave; frequency: {1:0}hz\n" + 
                            "Left/Right to change frequency, Ctrl+C to quit",
                            oscillator.WaveformType, oscillator.Frequency);
                        Console.WriteLine(prompt);

                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.Escape:
                                quit.Set();
                                break;

                            case ConsoleKey.LeftArrow:
                                oscillator.Frequency -= 10f;
                                break;

                            case ConsoleKey.RightArrow:
                                oscillator.Frequency += 10f;
                                break;

                            case ConsoleKey.Spacebar:
                                oscillator.CycleWaveforms();
                                break;
                        }

                        Thread.Sleep(1);
                    }

                    quit.WaitOne();
                }
                fmod.CloseSystem();
            }
        }
    }
}
