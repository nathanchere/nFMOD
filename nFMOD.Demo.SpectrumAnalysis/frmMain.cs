using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace nFMOD.Demo.SpectrumAnalysis
{
    public partial class frmMain : Form
    {
        private const string MP3_PATH = @"test.mp3";
        private FmodSystem fmod;
        private Channel channel;

        public frmMain()
        {
            InitializeComponent();

            fmod = new FmodSystem();
            fmod.Init();

            var timer = new Timer();
            timer.Interval = 33; // approx 30FPS
            timer.Tick += (sender, args) => Render();
            timer.Start();
        }

        private void Render()
        {
            if (fmod == null
                || fmod.IsInvalid
                || channel == null
                || !channel.IsPlaying
                )
                return;

            const int SPECTRUMSIZE = 512;
            const int WAVEDATASIZE = 256;
            var spectrum = new float[SPECTRUMSIZE];
            var wavedata = new float[WAVEDATASIZE];

            var fmodFormat = fmod.GetSoftwareFormat();

            var result = new VisData();
            for (int i = 0; i < fmodFormat.OutputChannelCount; ++i) {
                fmod.GetWaveData(wavedata, WAVEDATASIZE, i);
            }

            picVisualisation.UpdateData(result);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (channel != null && channel.IsPlaying)
                return;
            var sound = fmod.CreateSound(MP3_PATH);
            channel = fmod.PlaySound(sound);
        }

        private void btnPause(object sender, EventArgs e)
        {
            channel.Paused = !channel.Paused;
        }
    }
}
