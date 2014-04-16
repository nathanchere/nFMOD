using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using nFMOD.Dsps;

namespace nFMOD.Demo
{
    public partial class frmMain : Form
    {
        private FmodSystem fmod;
        private Dsps.Oscillator oscillator;
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
            if (fmod == null || fmod.IsInvalid
                || channel == null || !channel.IsPlaying
                )
                return;
           
            int spectrumSize = (int) Math.Pow(2,(int)numSpectrumDetail.Value);
            int waveSize = (int)numWaveDetail.Value;

            var spectrum = new float[spectrumSize];
            var wavedata = new float[waveSize];

            var result = new VisData();
            fmod.GetWaveData(wavedata, waveSize, 0);
            fmod.GetSpectrum(spectrum, spectrumSize, 0, FFTWindow.Max);
            result.WaveData = wavedata.ToList();
            result.SpectrumData = spectrum.ToList();

            picVisualisation.UpdateData(result);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (channel != null && channel.IsPlaying) return;
            oscillator = (Oscillator) fmod.CreateDsp(DspType.Oscillator);
            channel = oscillator.Play();
        }

        private void btnPause(object sender, EventArgs e)
        {
            channel.Paused = !channel.Paused;
        }

        ~frmMain()
        {
            if (oscillator != null) oscillator.Close();
            if (channel != null) channel.Close();            
            if (fmod != null) fmod.Close();
        }

        private void oscInput_VolumeChanged(object sender, OscillatorInput.ValueChangedEventArgs e)
        {
            if (channel != null) channel.Volume = e.Value;
        }

        private void oscInput_FrequencyChanged(object sender, OscillatorInput.ValueChangedEventArgs e)
        {
            if (oscillator != null) oscillator.Frequency = e.Value;
        }

        private void btnCycle_Click(object sender, EventArgs e)
        {
            if (oscillator != null) oscillator.CycleWaveforms();
        }        
    }
}
