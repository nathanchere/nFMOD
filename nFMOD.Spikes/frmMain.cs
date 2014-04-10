using System;
using System.Windows.Forms;

namespace nFMOD.Spikes
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGetSystemObjectWhenNotInitialized_Click(object sender, EventArgs e)
        {
            var fmod = new SoundSystem();
            var dsp = fmod.CreateDspByType(DspType.Oscillator);
            var channel = fmod.PlayDsp(dsp);
        }
    }
}
