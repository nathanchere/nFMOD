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

                    Console.WriteLine("nFMOD test\nGenerating sine wave; Ctrl+C to quit");

                    while (!quit.WaitOne(0)) {
                        switch (Console.ReadKey().Key) {
                            case ConsoleKey.Escape:
                                quit.Set();
                                break;

                            case ConsoleKey.LeftArrow:
                                oscillator.Rate -= 0.1f;
                                break;

                            case ConsoleKey.RightArrow:
                                break;

                            case ConsoleKey.Spacebar:
                                //dsp.setParameter((int)FMOD.DSP_OSCILLATOR.TYPE, 0);
                                //channel.setPaused(false);
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
