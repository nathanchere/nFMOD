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


        #region ctor etc
        public frmMain()
        {
            InitializeComponent();
            _fmod = new FmodSystem();
            _fmod.Init();

            _drums = new Dictionary<DrumType, Sound>();
            _drums[DrumType.Snare] = _fmod.CreateSound("data/snare.wav");
            _drums[DrumType.TomMid] = _fmod.CreateSound("data/tom_mid.wav");
            _drums[DrumType.TomLow] = _fmod.CreateSound("data/tom_low.wav");
            _drums[DrumType.TomFloor] = _fmod.CreateSound("data/tom_floor.wav");
            _drums[DrumType.Kick] = _fmod.CreateSound("data/kick.wav");
            _drums[DrumType.HihatOpen] = _fmod.CreateSound("data/cym_hatopen.wav");
            _drums[DrumType.HihatMid] = _fmod.CreateSound("data/cym_hatmid.wav");
            _drums[DrumType.HithatClosed] = _fmod.CreateSound("data/cym_hatclosed.wav");
            _drums[DrumType.CymbalCrash] = _fmod.CreateSound("data/cym_crash.wav");
            _drums[DrumType.CymbalRide] = _fmod.CreateSound("data/cym_ride.wav");
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

        private void btnSnare_Click(object sender, EventArgs e)
        {
            _fmod.PlaySound(_drums[DrumType.Snare]);
        }
    }
}
