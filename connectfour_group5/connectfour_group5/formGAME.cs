using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectfour_group5 {
    public partial class formGAME : Form {
        formTITLE tform;
        public formGAME() {
            InitializeComponent();
        }
        public formGAME(formTITLE title) {
            InitializeComponent();
            tform = title;
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Close();
            tform.Show();
        }
    }
}
