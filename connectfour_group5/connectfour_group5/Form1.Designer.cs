namespace connectfour_group5 {
    partial class formTITLE {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTITLE));
            this.labelTITLE = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTITLE
            // 
            this.labelTITLE.Font = new System.Drawing.Font("Microsoft Tai Le", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.labelTITLE.Location = new System.Drawing.Point(305, 0);
            this.labelTITLE.Name = "labelTITLE";
            this.labelTITLE.Size = new System.Drawing.Size(350, 133);
            this.labelTITLE.TabIndex = 0;
            this.labelTITLE.Text = "CONNECT FOUR";
            this.labelTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formTITLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(69)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(960, 600);
            this.Controls.Add(this.labelTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formTITLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTITLE;
    }
}

