using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace nFMOD.Demo
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

            DrawSpectrum(e.Graphics);
            DrawWaveBackground(e.Graphics);
            DrawWave(e.Graphics);            
        }

        private void DrawSpectrum(Graphics g)
        {
            const int offset = 20;            

            _data.SpectrumData = _data.SpectrumData
                .Select(f=>1 - Math.Pow(1-f,3))
                .Select(f=>(float)f)
                //.Where(f=>f > 0.1)
                .ToList();

            if(!_data.SpectrumData.Any()) return;

            float barWidth = Math.Max((Width / _data.SpectrumData.Count),2);
            for (int i = 0; i < _data.SpectrumData.Count; i++)
            {                
                var value = Math.Abs(_data.SpectrumData[i]); // value should always be between 0 : 1.0

                float x = i * barWidth;
                float y = (value*Height*0.5f);
                float G = (127 + (value * 128));
                float B = (int)(255 / Width * x);
                float R = (int)(DateTime.Now.Millisecond * 0.15);

                var brush = new SolidBrush(Color.FromArgb((int)R,(int)G,(int)B));
                g.FillRectangle(brush, x, Height / 2 + offset, barWidth, y);
                g.FillRectangle(brush, x, Height / 2 - offset - y, barWidth, y);
            }            
        }

        private void DrawWaveBackground(Graphics g)
        {
            for (int i = 0; i < _data.WaveData.Count; i++)
            {                
                var value = _data.WaveData[i]; // value should always be between ±1.0

                float x = Width * i / _data.WaveData.Count;
                float y = Height / 2 + (value*Height*0.5f);
                float B = (127 + (value * 128));
                float G = (int)(255 / Width * x);
                float R = (int)(DateTime.Now.Millisecond * 0.15);                
                float height = (1 - (float)Math.Pow(1-Math.Abs(value),5)) * 50;

                var brush = new SolidBrush(Color.FromArgb(32, (int)R,(int)G,(int)B));
                g.FillEllipse(brush, x - 2.5f, y - height * 0.5f, 5, height);
            }
        }

        private void DrawWave(Graphics g)
        {
            for (int i = 0; i < _data.WaveData.Count; i++)
            {                
                var value = _data.WaveData[i]; // value should always be between ±1.0

                float x = Width * i / _data.WaveData.Count;
                float y = Height / 2 + (value*Height*0.5f);
                float R = (127 + (value * 128));
                float G = (int)(255 / Width * x);
                float B = (int)(DateTime.Now.Millisecond * 0.15);

                var brush = new SolidBrush(Color.FromArgb((int)R,(int)G,(int)B));
                g.FillEllipse(brush, x, y, 5, (2 + value*2) * 7);
            }
        }

        public void UpdateData(VisData result)
        {
            _data = result;
            Refresh();
        }
    }
}