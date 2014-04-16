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

        public OscillatorInput()
        {
            DoubleBuffered = true;
            Image = new Bitmap(Width, Height);
            _font = new Font("Arial", 12);
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
            var brush = new SolidBrush(Color.FromArgb(160, 255, 0));
            var point = GetPoint();
            g.FillEllipse(brush, point.X,point.Y,10,10);

            //g.DrawString(string.Format("{0:00000.00",_frequency), 
            //    new Font("Arial", 12), Brushes.BlueViolet, 5f,5f);
            g.DrawString(string.Format("{0:00000.00}",_frequency),
                _font,
                Brushes.BlueViolet, 5f,5f)
                ;

            //Invalidate();
        }

        private Point GetPoint()
        {
            var result = Point.Empty;
            result.X = (int)(Width / 22000f * _frequency);
            result.Y = (int)(Height - (Height  * _volume));
            return result;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                base.OnMouseMove(e);
                return;
            }

            var newFrequency = e.X / (float)Width * 22000f;
            var newVolume = 1 - (1 / (float)Height * e.Y);
            //TODO: raise event

            _frequency = newFrequency;
            _volume = newVolume;
            Refresh();
        }
    }

}