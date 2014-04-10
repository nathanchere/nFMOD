using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nFMOD.Demo.SpectrumAnalysis
{
    public partial class frmMain : Form
    {
        private const string MP3_PATH = @"test.mp3";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            var fmod = new FmodSystem();
            fmod.Init();
            var sound = fmod.CreateSound(MP3_PATH);
            fmod.PlaySound(sound);
        }
    }
}
