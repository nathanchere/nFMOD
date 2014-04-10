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
            Image = new Bitmap(Width,Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_data == null)
            {
                e.Graphics.Clear(Color.Aqua);
                return;
            }            

            e.Graphics.Clear(Color.FromArgb(255,
                DateTime.Now.Second * 4,
                (60 - DateTime.Now.Second) * 4,
                0));
        }

        internal void UpdateData(VisData result)
        {
            _data = result;
            Refresh();
        }
    }
}