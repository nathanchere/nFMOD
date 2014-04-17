using System;
using System.Windows.Forms;

namespace nFMOD.Demo
{
    public enum DrumType
    {
        Kick,
        Snare,
        HihatOpen,
        HihatMid,
        HithatClosed,
        TomMid,
        TomLow,
        TomFloor,
        CymbalCrash,
        CymbalRide,
    }

    public partial class frmMain : Form
    {
        FmodSystem fmod;
        

        #region ctor etc
        public frmMain()
        {
            InitializeComponent();
            fmod = new FmodSystem();
            fmod.Init();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                if(!fmod.IsClosed) fmod.Close();
                fmod.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}
