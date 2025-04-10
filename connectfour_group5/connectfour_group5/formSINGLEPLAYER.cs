﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectfour_group5 {
    public partial class formSINGLEPLAYER : Form {
        bool switching = false;
        formTITLE tform;

        public formSINGLEPLAYER() {
            InitializeComponent();
        }
        public formSINGLEPLAYER(formTITLE title) {
            InitializeComponent();
            tform = title;
        }

        private void buttonTITLE_Click(object sender, EventArgs e) {
            switching = true;
            this.Close();
            tform.Show();
        }

        private void formSINGLEPLAYER_FormClosed(object sender, FormClosedEventArgs e) {
            if (!switching) {
                tform.Close();
            }
            switching = false;
        }

        private void buttonCLOSE_Click(object sender, EventArgs e) {
            this.Close();
            tform.Close();
        }
    }
}
