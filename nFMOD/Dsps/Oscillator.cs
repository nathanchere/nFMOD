using System;
using System.Collections.Generic;
using System.Text;

namespace nFMOD.Dsps
{
    public class Oscillator : Dsp
    {
        private enum Parameter
        {
            /// <summary>
            /// Waveform type
            /// </summary>
            /// <value>
            /// 0 = sine
            /// 1 = square
            /// 2 = saw (up)
            /// 3 = saw (down)
            /// 4 = triangle
            /// 5 = noise
            /// </value>
            Type,

            /// <summary>
            /// Frequency (in hz) from 1.0 to 22000.0
            /// Default: 220.0
            /// </summary>
            Rate,
        }

        public enum WaveformType
        {
            Sine,
            Square,
            SawUp,
            SawDown,
            Triangle,
            Noise,
        }

        internal Oscillator(IntPtr hnd, FmodSystem parent)
            : base(hnd, parent)
        {
        }

        private float _rate = 220f;
        private WaveformType _waveformType = WaveformType.Sine;

        public void CycleWaveforms()
        {
            Waveform+=1;
        }

        /// <summary>
        /// Oscillation rate (in hz) from 1.0 to 220000
        /// Default: 220.0
        /// </summary>
        public float Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                SetParameter(DangerousGetHandle(), (int)Parameter.Rate, value);
                _rate = value;
            }
        }

        public WaveformType Waveform
        {
            get
            {
                return _waveformType;
            }
            set
            {
                SetParameter(DangerousGetHandle(), (int)Parameter.Type, (int)value);
                _waveformType = value;
            }
        }
    }
}
