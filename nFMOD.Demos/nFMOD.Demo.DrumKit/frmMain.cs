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
            _drums[DrumType.Snare] = _fmod.CreateSound(Properties.Resources.snare);
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
    }
}
