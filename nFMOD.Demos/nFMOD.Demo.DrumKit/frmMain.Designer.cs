namespace nFMOD.Demo
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHihatOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSnare = new System.Windows.Forms.Button();
            this.btnHihatClosed = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHihatOpen
            // 
            this.btnHihatOpen.Location = new System.Drawing.Point(14, 68);
            this.btnHihatOpen.Name = "btnHihatOpen";
            this.btnHihatOpen.Size = new System.Drawing.Size(71, 35);
            this.btnHihatOpen.TabIndex = 0;
            this.btnHihatOpen.Text = "HH (Open)";
            this.btnHihatOpen.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnSnare);
            this.panel1.Controls.Add(this.btnHihatClosed);
            this.panel1.Controls.Add(this.btnHihatOpen);
            this.panel1.Location = new System.Drawing.Point(30, 239);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 118);
            this.panel1.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(259, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(71, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "Tom (Low)";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "Tom (Mid)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(71, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "Kick";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSnare
            // 
            this.btnSnare.Location = new System.Drawing.Point(103, 68);
            this.btnSnare.Name = "btnSnare";
            this.btnSnare.Size = new System.Drawing.Size(71, 35);
            this.btnSnare.TabIndex = 2;
            this.btnSnare.Text = "Snare";
            this.btnSnare.UseVisualStyleBackColor = true;
            this.btnSnare.Click += new System.EventHandler(this.btnSnare_Click);
            // 
            // btnHihatClosed
            // 
            this.btnHihatClosed.Location = new System.Drawing.Point(14, 37);
            this.btnHihatClosed.Name = "btnHihatClosed";
            this.btnHihatClosed.Size = new System.Drawing.Size(71, 35);
            this.btnHihatClosed.TabIndex = 1;
            this.btnHihatClosed.Text = "HH (Closed)";
            this.btnHihatClosed.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 369);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.Text = "nFMOD Demo: Drum Kit";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHihatOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSnare;
        private System.Windows.Forms.Button btnHihatClosed;        
    }
}

