namespace nFMOD.Demo.SpectrumAnalysis
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
            this.picVisualisation = new nFMOD.Demo.SpectrumAnalysis.FftVisualisationPictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.numWaveDetail = new System.Windows.Forms.NumericUpDown();
            this.numSpectrumDetail = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picVisualisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWaveDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpectrumDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // picVisualisation
            // 
            this.picVisualisation.BackColor = System.Drawing.Color.Black;
            this.picVisualisation.Dock = System.Windows.Forms.DockStyle.Top;
            this.picVisualisation.Image = ((System.Drawing.Image)(resources.GetObject("picVisualisation.Image")));
            this.picVisualisation.Location = new System.Drawing.Point(0, 0);
            this.picVisualisation.Name = "picVisualisation";
            this.picVisualisation.Size = new System.Drawing.Size(536, 269);
            this.picVisualisation.TabIndex = 0;
            this.picVisualisation.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 277);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(117, 41);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(135, 277);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(117, 41);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Pause / Unpause";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnPause);
            // 
            // numWaveDetail
            // 
            this.numWaveDetail.Location = new System.Drawing.Point(467, 301);
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
            this.numSpectrumDetail.Location = new System.Drawing.Point(467, 278);
            this.numSpectrumDetail.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numSpectrumDetail.Name = "numSpectrumDetail";
            this.numSpectrumDetail.Size = new System.Drawing.Size(59, 20);
            this.numSpectrumDetail.TabIndex = 4;
            this.numSpectrumDetail.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Spectrum resolution";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(365, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Wave resolution";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 330);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSpectrumDetail);
            this.Controls.Add(this.numWaveDetail);
            this.Controls.Add(this.btnStop);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FftVisualisationPictureBox picVisualisation;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.NumericUpDown numWaveDetail;
        private System.Windows.Forms.NumericUpDown numSpectrumDetail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

