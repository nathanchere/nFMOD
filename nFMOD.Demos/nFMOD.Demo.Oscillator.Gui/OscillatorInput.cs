using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace nFMOD.Demo
{
    public sealed class OscillatorInput : PictureBox
    {
        private float _frequency = 220f;
        private float _volume = 0.5f;
        private Font _font;
        private Point _lastPosition;

        public class ValueChangedEventArgs : EventArgs
        {
            public ValueChangedEventArgs(float value)
            {
                Value = value;
            }
            public float Value
            {
                get;
                private set;
            }
        }

        public event EventHandler<ValueChangedEventArgs> VolumeChanged;
        public event EventHandler<ValueChangedEventArgs> FrequencyChanged;

        public OscillatorInput()
        {
            DoubleBuffered = true;
            Image = new Bitmap(Width, Height);
            _font = new Font("Lucida Console", 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTemplate(e.Graphics);
            DrawInput(e.Graphics);
        }

        private void DrawTemplate(Graphics g)
        {
            g.Clear(Color.Black);
        }

        private void DrawInput(Graphics g)
        {
            var point = GetPoint();
            g.FillEllipse(Brushes.Chartreuse, point.X, point.Y, 10, 10);
            g.DrawString(string.Format("Frequency: {0,7:####0.0}hz", _frequency), _font, Brushes.BlueViolet, 5f, 5f);
            g.DrawString(string.Format("Volume: {0:0.00}", _volume), _font, Brushes.BlueViolet, 5f, 20f);
        }

        private Point GetPoint()
        {
            return _lastPosition;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) {
                base.OnMouseMove(e);
                return;
            }            
            _lastPosition = e.Location;

            if (e.X > 0 && e.X <= Width)
            {
                var newFrequency = e.X/(float) Width*22000f;
                newFrequency = (float) (newFrequency*Math.Pow(Math.Log(e.X, 1024), 6));

                if (Math.Abs(newFrequency - _frequency) > 0.1f) {
                if (FrequencyChanged != null)
                    FrequencyChanged(this, new ValueChangedEventArgs(newFrequency));
                _frequency = newFrequency;
            }
            }

            if (e.Y > 0 && e.Y <= Height)
            {
                var newVolume = 1 - (1 / (float)Height * e.Y);
                if (Math.Abs(newVolume - _volume) > 0.001f)
                {
                    if (VolumeChanged != null)
                        VolumeChanged(this, new ValueChangedEventArgs(newVolume));
                    _volume = newVolume;
                }
            }

            Refresh();
        }
    }

}