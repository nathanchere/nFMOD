using System.Windows.Forms;
namespace nFMOD.Demo
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.picVisualisation = new nFMOD.Demo.FftVisualisationPictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.numWaveDetail = new System.Windows.Forms.NumericUpDown();
            this.numSpectrumDetail = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oscInput = new nFMOD.Demo.OscillatorInput();
            this.btnCycle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picVisualisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaveDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectrumDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscInput)).BeginInit();
            this.SuspendLayout();
            // 
            // picVisualisation
            // 
            this.picVisualisation.BackColor = System.Drawing.Color.Black;
            this.picVisualisation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picVisualisation.Image = ((System.Drawing.Image)(resources.GetObject("picVisualisation.Image")));
            this.picVisualisation.Location = new System.Drawing.Point(295, 0);
            this.picVisualisation.Name = "picVisualisation";
            this.picVisualisation.Size = new System.Drawing.Size(358, 221);
            this.picVisualisation.TabIndex = 0;
            this.picVisualisation.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.Location = new System.Drawing.Point(297, 228);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 41);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // numWaveDetail
            // 
            this.numWaveDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numWaveDetail.Location = new System.Drawing.Point(591, 250);
            this.numWaveDetail.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numWaveDetail.Name = "numWaveDetail";
            this.numWaveDetail.Size = new System.Drawing.Size(59, 20);
            this.numWaveDetail.TabIndex = 3;
            this.numWaveDetail.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // numSpectrumDetail
            // 
            this.numSpectrumDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numSpectrumDetail.Location = new System.Drawing.Point(591, 227);
            this.numSpectrumDetail.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSpectrumDetail.Name = "numSpectrumDetail";
            this.numSpectrumDetail.Size = new System.Drawing.Size(59, 20);
            this.numSpectrumDetail.TabIndex = 4;
            this.numSpectrumDetail.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "FFT resolution";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Wave resolution";
            // 
            // oscInput
            // 
            this.oscInput.Image = ((System.Drawing.Image)(resources.GetObject("oscInput.Image")));
            this.oscInput.Location = new System.Drawing.Point(5, 3);
            this.oscInput.Name = "oscInput";
            this.oscInput.Size = new System.Drawing.Size(284, 269);
            this.oscInput.TabIndex = 7;
            this.oscInput.TabStop = false;
            this.oscInput.VolumeChanged += new System.EventHandler<nFMOD.Demo.OscillatorInput.ValueChangedEventArgs>(this.oscInput_VolumeChanged);
            this.oscInput.FrequencyChanged += new System.EventHandler<nFMOD.Demo.OscillatorInput.ValueChangedEventArgs>(this.oscInput_FrequencyChanged);
            // 
            // btnCycle
            // 
            this.btnCycle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCycle.Location = new System.Drawing.Point(397, 228);
            this.btnCycle.Name = "btnCycle";
            this.btnCycle.Size = new System.Drawing.Size(100, 41);
            this.btnCycle.TabIndex = 8;
            this.btnCycle.Text = "Cycle Waveform";
            this.btnCycle.UseVisualStyleBackColor = true;
            this.btnCycle.Click += new System.EventHandler(this.btnCycle_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 276);
            this.Controls.Add(this.btnCycle);
            this.Controls.Add(this.oscInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSpectrumDetail);
            this.Controls.Add(this.numWaveDetail);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.picVisualisation);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "nFMOD Demo: Spectrum Analysis";
            ((System.ComponentModel.ISupportInitialize)(this.picVisualisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaveDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectrumDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oscInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FftVisualisationPictureBox picVisualisation;
        private Button btnPlay;
        private NumericUpDown numWaveDetail;
        private NumericUpDown numSpectrumDetail;
        private Label label1;
        private Label label2;
        private OscillatorInput oscInput;
        private Button btnCycle;
    }
}

