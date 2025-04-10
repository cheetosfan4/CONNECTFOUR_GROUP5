namespace connectfour_group5 {
    partial class formSTATISTICS {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSTATISTICS));
            this.buttonTITLE = new System.Windows.Forms.Button();
            this.buttonCLOSE = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTITLE
            // 
            this.buttonTITLE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTITLE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonTITLE.FlatAppearance.BorderSize = 3;
            this.buttonTITLE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(242)))));
            this.buttonTITLE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTITLE.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.buttonTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonTITLE.Location = new System.Drawing.Point(14, 14);
            this.buttonTITLE.Name = "buttonTITLE";
            this.buttonTITLE.Size = new System.Drawing.Size(100, 60);
            this.buttonTITLE.TabIndex = 0;
            this.buttonTITLE.Text = "TITLE MENU";
            this.buttonTITLE.UseVisualStyleBackColor = true;
            this.buttonTITLE.Click += new System.EventHandler(this.buttonTITLE_Click);
            // 
            // buttonCLOSE
            // 
            this.buttonCLOSE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCLOSE.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonCLOSE.FlatAppearance.BorderSize = 3;
            this.buttonCLOSE.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(242)))));
            this.buttonCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCLOSE.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.buttonCLOSE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonCLOSE.Location = new System.Drawing.Point(14, 88);
            this.buttonCLOSE.Name = "buttonCLOSE";
            this.buttonCLOSE.Size = new System.Drawing.Size(100, 60);
            this.buttonCLOSE.TabIndex = 1;
            this.buttonCLOSE.Text = "CLOSE GAME";
            this.buttonCLOSE.UseVisualStyleBackColor = true;
            this.buttonCLOSE.Click += new System.EventHandler(this.buttonCLOSE_Click);
            // 
            // formSTATISTICS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(69)))), ((int)(((byte)(222)))));
            this.BackgroundImage = global::connectfour_group5.Properties.Resources.connectfour_gamebg;
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.buttonCLOSE);
            this.Controls.Add(this.buttonTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formSTATISTICS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four: Statistics";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formSTATISTICS_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTITLE;
        private System.Windows.Forms.Button buttonCLOSE;
    }
}