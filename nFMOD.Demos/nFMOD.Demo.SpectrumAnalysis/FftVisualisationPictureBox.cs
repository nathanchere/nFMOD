using System;
using System.Drawing;
using System.Windows.Forms;

namespace nFMOD.Demo.SpectrumAnalysis
{
    public class FftVisualisationPictureBox : PictureBox
    {
        private VisData _data;

        public FftVisualisationPictureBox()
        {
            DoubleBuffered = true;
            Image = new Bitmap(Width, Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {            
            e.Graphics.Clear(Color.Black);

            if (_data == null)
                return;

            DrawWave(e.Graphics);
            DrawSpectrum(e.Graphics);
        }

        private void DrawSpectrum(Graphics g)
        {
            float barWidth = Width / _data.WaveData.Count;
            for (int i = 0; i < _data.SpectrumData.Count; i++)
            {                
                var value = Math.Abs(_data.SpectrumData[i]); // value should always be between 0 : 1.0

                float x = i * barWidth;
                float y = (value*Height*0.5f);
                float R = (128 + (value * 128));
                float G = (int)(255 / Width * x);
                float B = (int)(DateTime.Now.Millisecond * 0.15);

                var brush = new SolidBrush(Color.FromArgb((int)R,(int)G,(int)B));
                g.FillRectangle(brush, x, 200, barWidth, y);
            }            
        }

        private void DrawWave(Graphics g)
        {
            for (int i = 0; i < _data.WaveData.Count; i++)
            {                
                var value = _data.WaveData[i]; // value should always be between ±1.0

                float x = Width * i / _data.WaveData.Count;
                float y = Height / 2 + (value*Height*0.5f);
                float R = (128 + (value * 128));
                float G = (int)(255 / Width * x);
                float B = (int)(DateTime.Now.Millisecond * 0.15);

                var brush = new SolidBrush(Color.FromArgb((int)R,(int)G,(int)B));
                g.FillEllipse(brush, x, y, 5, (2 + value*2) * 7);
            }
        }

        internal void UpdateData(VisData result)
        {
            _data = result;
            Refresh();
        }
    }
}