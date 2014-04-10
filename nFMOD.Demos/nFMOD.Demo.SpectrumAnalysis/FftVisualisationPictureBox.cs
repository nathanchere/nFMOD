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
            foreach (var s in _data.SpectrumData) {
                //g.FillRectangle(mBrushWhite, count2 + GRAPHICWINDOW_WIDTH - WAVEDATASIZE - 10.0f, y, 1.0f, 1.0f); 
            }
        }

        float max=0,maxX=0,maxY=0,maxR=0,maxG=0,maxB=0;
        private void DrawWave(Graphics g)
        {
            for (int i = 0; i < _data.WaveData.Count; i++) {
                
                var value = _data.WaveData[i];                          
                float x = Width * i / _data.WaveData.Count;
                float y = Height / 2 + (value*Height*0.5f);
                float R = (128 + (value * 128));
                float G = (int)(255 / Width * x);
                float B = (int)(DateTime.Now.Millisecond * 0.15);

                max = Math.Max(value,max);
                maxX = Math.Max(x,maxX);
                maxY = Math.Max(y,maxY);
                maxR = Math.Max(R,maxR);
                maxG = Math.Max(G,maxG);
                maxB = Math.Max(B,maxB);
                (Parent as Form).Text = string.Format("V:{0:0.00} X:{1:0.00} Y:{2:0.00} R:{3:0.00} G:{4:0.00} B:{5:0.00}",
                    max,maxX,maxY,maxR,maxG,maxB);

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