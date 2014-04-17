using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace nFMOD.Demo
{
    public partial class frmMain : Form
    {
        FmodSystem _fmod;
        Dictionary<DrumType, Sound> _drums;
        Dictionary<DrumType, Channel> _channels;

        #region ctor etc
        public frmMain()
        {
            InitializeComponent();
            _fmod = new FmodSystem();
            _fmod.Init(32, InitFlags.SoftwareHRTF);

            _drums = new Dictionary<DrumType, Sound>();
            const SoundMode flags = SoundMode.NonBlocking | SoundMode.SoftwareProcessing;
            _drums[DrumType.Snare] = _fmod.CreateSound("data/snare.wav", flags);
            _drums[DrumType.TomMid] = _fmod.CreateSound("data/tom_mid.wav", flags);
            _drums[DrumType.TomLow] = _fmod.CreateSound("data/tom_low.wav", flags);
            _drums[DrumType.TomFloor] = _fmod.CreateSound("data/tom_floor.wav", flags);
            _drums[DrumType.Kick] = _fmod.CreateSound("data/kick.wav", flags);
            _drums[DrumType.HihatOpen] = _fmod.CreateSound("data/cym_hatopen.wav", flags);
            _drums[DrumType.HihatMid] = _fmod.CreateSound("data/cym_hatmid.wav", flags);
            _drums[DrumType.HithatClosed] = _fmod.CreateSound("data/cym_hatclosed.wav", flags);
            _drums[DrumType.CymbalCrash] = _fmod.CreateSound("data/cym_crash.wav", flags);
            _drums[DrumType.CymbalRide] = _fmod.CreateSound("data/cym_ride.wav", flags);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if (!_fmod.IsClosed) _fmod.Close();
                _fmod.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        private void PlayDrum(DrumType drumType)
        {
            _fmod.PlaySound(_drums[drumType]);
            _fmod.Update();
        }

        private void frmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z) PlayDrum(DrumType.HithatClosed);
            if (e.KeyCode == Keys.X) PlayDrum(DrumType.Snare);
            if (e.KeyCode == Keys.B) PlayDrum(DrumType.TomMid);
            if (e.KeyCode == Keys.N) PlayDrum(DrumType.TomLow);
            if (e.KeyCode == Keys.M) PlayDrum(DrumType.CymbalCrash);
            if (e.KeyCode == Keys.Space) PlayDrum(DrumType.Kick);
        }
    }
}
