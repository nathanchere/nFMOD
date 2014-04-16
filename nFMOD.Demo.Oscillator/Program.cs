using System;
using nFMOD.Dsps;
using System.Threading;

namespace nFMOD.Demo
{
    class Program
    {
        private static void Main(string[] args)
        {
            (new Program()).Run();
        }

        Oscillator oscillator;

        void Run()
        {
            var quit = new ManualResetEvent(false);
            Console.CancelKeyPress += (s, a) => {
                quit.Set();
                a.Cancel = true;
            };

            using (var fmod = new FmodSystem())
            {
                fmod.Init();                
                using (oscillator = (Oscillator)fmod.CreateDsp(DspType.Oscillator))
                {
                    oscillator.Play();

                    while (!quit.WaitOne(0))
                    {
                        ShowPrompt();
                        ProcessInput(quit);
                        Thread.Sleep(1);
                    }
                }
                fmod.CloseSystem();
            }
        }

        void ProcessInput(ManualResetEvent quit)
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

        private void ShowPrompt()
        {
            Console.SetCursorPosition(0, 0);
            var prompt = string.Format(
                "nFMOD test: DSP (Oscillator)\n" +
                "----------------------------\n\n" +
                "Generating {0} wave; frequency: {1:0}hz                 \n" +
                "Left/Right to change frequency, Ctrl+C to quit",
                oscillator.WaveformType, oscillator.Frequency);
            Console.WriteLine(prompt);
        }
    }
}
