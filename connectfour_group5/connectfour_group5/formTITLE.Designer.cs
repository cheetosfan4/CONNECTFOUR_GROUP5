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
            this.buttonSINGLEPLAYER = new System.Windows.Forms.Button();
            this.buttonMULTIPLAYER = new System.Windows.Forms.Button();
            this.buttonSTATISTICS = new System.Windows.Forms.Button();
            this.buttonEXIT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTITLE
            // 
            this.labelTITLE.Font = new System.Drawing.Font("Microsoft Tai Le", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTITLE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.labelTITLE.Location = new System.Drawing.Point(407, 25);
            this.labelTITLE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTITLE.Name = "labelTITLE";
            this.labelTITLE.Size = new System.Drawing.Size(467, 164);
            this.labelTITLE.TabIndex = 0;
            this.labelTITLE.Text = "CONNECT FOUR";
            this.labelTITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTITLE.Click += new System.EventHandler(this.labelTITLE_Click);
            // 
            // buttonSINGLEPLAYER
            // 
            this.buttonSINGLEPLAYER.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(69)))), ((int)(((byte)(222)))));
            this.buttonSINGLEPLAYER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSINGLEPLAYER.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonSINGLEPLAYER.FlatAppearance.BorderSize = 3;
            this.buttonSINGLEPLAYER.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(242)))));
            this.buttonSINGLEPLAYER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSINGLEPLAYER.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSINGLEPLAYER.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonSINGLEPLAYER.Location = new System.Drawing.Point(407, 372);
            this.buttonSINGLEPLAYER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSINGLEPLAYER.Name = "buttonSINGLEPLAYER";
            this.buttonSINGLEPLAYER.Size = new System.Drawing.Size(467, 46);
            this.buttonSINGLEPLAYER.TabIndex = 1;
            this.buttonSINGLEPLAYER.Text = "SINGLEPLAYER";
            this.buttonSINGLEPLAYER.UseVisualStyleBackColor = false;
            this.buttonSINGLEPLAYER.Click += new System.EventHandler(this.loadNewForm);
            // 
            // buttonMULTIPLAYER
            // 
            this.buttonMULTIPLAYER.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMULTIPLAYER.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonMULTIPLAYER.FlatAppearance.BorderSize = 3;
            this.buttonMULTIPLAYER.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(242)))));
            this.buttonMULTIPLAYER.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMULTIPLAYER.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.buttonMULTIPLAYER.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonMULTIPLAYER.Location = new System.Drawing.Point(407, 442);
            this.buttonMULTIPLAYER.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMULTIPLAYER.Name = "buttonMULTIPLAYER";
            this.buttonMULTIPLAYER.Size = new System.Drawing.Size(467, 46);
            this.buttonMULTIPLAYER.TabIndex = 2;
            this.buttonMULTIPLAYER.Text = "MULTIPLAYER";
            this.buttonMULTIPLAYER.UseVisualStyleBackColor = true;
            this.buttonMULTIPLAYER.Click += new System.EventHandler(this.loadNewForm);
            // 
            // buttonSTATISTICS
            // 
            this.buttonSTATISTICS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSTATISTICS.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonSTATISTICS.FlatAppearance.BorderSize = 3;
            this.buttonSTATISTICS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(242)))));
            this.buttonSTATISTICS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSTATISTICS.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSTATISTICS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonSTATISTICS.Location = new System.Drawing.Point(407, 512);
            this.buttonSTATISTICS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSTATISTICS.Name = "buttonSTATISTICS";
            this.buttonSTATISTICS.Size = new System.Drawing.Size(467, 46);
            this.buttonSTATISTICS.TabIndex = 3;
            this.buttonSTATISTICS.Text = "STATISTICS";
            this.buttonSTATISTICS.UseVisualStyleBackColor = true;
            this.buttonSTATISTICS.Click += new System.EventHandler(this.loadNewForm);
            // 
            // buttonEXIT
            // 
            this.buttonEXIT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEXIT.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonEXIT.FlatAppearance.BorderSize = 3;
            this.buttonEXIT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(139)))), ((int)(((byte)(242)))));
            this.buttonEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEXIT.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.buttonEXIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(171)))), ((int)(((byte)(18)))));
            this.buttonEXIT.Location = new System.Drawing.Point(407, 582);
            this.buttonEXIT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEXIT.Name = "buttonEXIT";
            this.buttonEXIT.Size = new System.Drawing.Size(467, 46);
            this.buttonEXIT.TabIndex = 4;
            this.buttonEXIT.Text = "CLOSE GAME";
            this.buttonEXIT.UseVisualStyleBackColor = true;
            this.buttonEXIT.Click += new System.EventHandler(this.loadNewForm);
            // 
            // formTITLE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(69)))), ((int)(((byte)(222)))));
            this.BackgroundImage = global::connectfour_group5.Properties.Resources.connectfour_titlebg;
            this.ClientSize = new System.Drawing.Size(1280, 738);
            this.Controls.Add(this.buttonEXIT);
            this.Controls.Add(this.buttonSTATISTICS);
            this.Controls.Add(this.buttonMULTIPLAYER);
            this.Controls.Add(this.buttonSINGLEPLAYER);
            this.Controls.Add(this.labelTITLE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "formTITLE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connect Four";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTITLE;
        private System.Windows.Forms.Button buttonSINGLEPLAYER;
        private System.Windows.Forms.Button buttonMULTIPLAYER;
        private System.Windows.Forms.Button buttonSTATISTICS;
        private System.Windows.Forms.Button buttonEXIT;
    }
}

