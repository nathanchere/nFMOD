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
        Oscillator oscillator;

        static void Main(string[] args)
        {
            var quit = new ManualResetEvent(false);
            Console.CancelKeyPress += (s, a) => {
                quit.Set();
                a.Cancel = true;
            };

            using (var fmod = new FmodSystem())
            {
                fmod.Init();                
                using (var oscillator = (Oscillator)fmod.CreateDsp(DspType.Oscillator))
                {
                    oscillator.Play();

                    while (!quit.WaitOne(0))
                    {
                        ShowPrompt(oscillator);
                        ProcessInput(quit, oscillator);
                        Thread.Sleep(1);
                    }
                }
                fmod.CloseSystem();
            }
        }

        private static void ProcessInput(ManualResetEvent quit, Oscillator oscillator)
        {
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
        }

        private static void ShowPrompt(Oscillator oscillator)
        {
            Console.SetCursorPosition(0, 0);
            var prompt = string.Format(
                "nFMOD test: DSP (Oscillator)\n" +
                "----------------------------\n\n" +
                "Generating {0} wave; frequency: {1:0}hz\n" +
                "Left/Right to change frequency, Ctrl+C to quit",
                oscillator.WaveformType, oscillator.Frequency);
            Console.WriteLine(prompt);
        }
    }
}
