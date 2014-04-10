using System.Drawing;
using System.Windows.Forms;

namespace nFMOD.Demo.SpectrumAnalysis
{
    public class FftVisualisationPictureBox : PictureBox
    {
        public FftVisualisationPictureBox()
        {
            DoubleBuffered = true;
        }

        public void Draw()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
        }
    }
}