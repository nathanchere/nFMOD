using System;
using System.Collections.Generic;
using System.Text;

namespace nFMOD.Dsps
{
    public class Oscillator : Dsp
    {
        public const float MAX_FREQUENCY = 22000f;
        public const float MIN_FREQUENCY = 1f;
        private readonly int MAX_WAVEFORM_TYPES = Enum.GetValues(typeof(Waveform)).Length;

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

        public enum Waveform
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

        private float _frequency = 220f;
        private Waveform _waveform = Waveform.Sine;

        public Waveform CycleWaveforms()
        {
            WaveformType = (Waveform)((int)(WaveformType + 1) % MAX_WAVEFORM_TYPES);
            return WaveformType;
        }

        /// <summary>
        /// Oscillation rate (in hz) from 1.0 to 220000
        /// Default: 220.0
        /// </summary>
        public float Frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                value = Math.Max(Math.Min(value, MAX_FREQUENCY), MIN_FREQUENCY);
                SetParameter(DangerousGetHandle(), (int)Parameter.Rate, value);
                _frequency = value;
            }
        }

        public Waveform WaveformType
        {
            get
            {
                return _waveform;
            }
            set
            {
                SetParameter(DangerousGetHandle(), (int)Parameter.Type, (int)value);
                _waveform = value;
            }
        }
    }
}
