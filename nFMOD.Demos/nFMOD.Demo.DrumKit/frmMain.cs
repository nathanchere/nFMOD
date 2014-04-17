using System;
using System.Windows.Forms;

namespace nFMOD.Demo
{
    public partial class frmMain : Form
    {        
        public frmMain()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
