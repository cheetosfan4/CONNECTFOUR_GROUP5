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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.buttonTITLE.Location = new System.Drawing.Point(19, 17);
            this.buttonTITLE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonTITLE.Name = "buttonTITLE";
            this.buttonTITLE.Size = new System.Drawing.Size(133, 74);
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
            this.buttonCLOSE.Location = new System.Drawing.Point(19, 108);
            this.buttonCLOSE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCLOSE.Name = "buttonCLOSE";
            this.buttonCLOSE.Size = new System.Drawing.Size(133, 74);
            this.buttonCLOSE.TabIndex = 1;
            this.buttonCLOSE.Text = "CLOSE GAME";
            this.buttonCLOSE.UseVisualStyleBackColor = true;
            this.buttonCLOSE.Click += new System.EventHandler(this.buttonCLOSE_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(283, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "wins";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(283, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 20);
            this.label2.TabIndex = 31;
            this.label2.Text = "lossess";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(283, 407);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(227, 20);
            this.label3.TabIndex = 32;
            this.label3.Text = "draws";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(650, 407);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "games played";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(650, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(227, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "player win rate";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(650, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(227, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "ai winrate";
            // 
            // formSTATISTICS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(69)))), ((int)(((byte)(222)))));
            this.BackgroundImage = global::connectfour_group5.Properties.Resources.connectfour_gamebg;
            this.ClientSize = new System.Drawing.Size(1280, 738);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCLOSE);
            this.Controls.Add(this.buttonTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}