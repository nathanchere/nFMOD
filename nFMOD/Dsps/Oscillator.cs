using System;
using System.Collections.Generic;
using System.Text;

namespace nFMOD.Dsps
{
    public class Oscillator : Dsp
    {
        internal Oscillator(IntPtr hnd, FmodSystem parent) : base(hnd, parent)
        {
        }

        public float Rate {
            get { return 0;}
            set { 
                //Oscillator.setParameter((int)FMOD.DSP_OSCILLATOR.RATE, 440.0f);
            }
        }
    }
}
