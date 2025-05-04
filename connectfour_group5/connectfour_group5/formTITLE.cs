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
    public partial class formTITLE : Form {

        private List<Form> savedGames = new List<Form>();

        public formTITLE() {
            InitializeComponent();
        }

        public void loadNewForm(object sender, EventArgs e) {
            if (sender == buttonSINGLEPLAYER) {
                formGAMEPLAY formToLoad = new formGAMEPLAY(this, false, savedGames);
                formToLoad.Show();
            }
            if (sender == buttonMULTIPLAYER) {
				formGAMEPLAY formToLoad = new formGAMEPLAY(this, true, savedGames);
                formToLoad.Show();
            }
            if (sender == buttonSTATISTICS) {
                formSTATISTICS formToLoad = new formSTATISTICS(this);
                formToLoad.Show();
            }
            if (sender == buttonEXIT) {
                this.Close();
            }
            this.Hide();
        }
    }
}
