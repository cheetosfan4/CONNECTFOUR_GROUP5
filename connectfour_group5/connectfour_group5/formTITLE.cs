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
        public formTITLE() {
            InitializeComponent();
            Board board = new Board();
            board.outputCells();
        }

        public void loadNewForm(object sender, EventArgs e) {
            if(sender == buttonSINGLEPLAYER) {
                formSINGLEPLAYER formToLoad = new formSINGLEPLAYER(this);
                formToLoad.Show();
            }
            if (sender == buttonMULTIPLAYER) {
                formMULTIPLAYER formToLoad = new formMULTIPLAYER(this);
                formToLoad.Show();
            }
            if(sender == buttonSTATISTICS) {
                formSTATISTICS formToLoad = new formSTATISTICS(this);
                formToLoad.Show();
            }
            if(sender == buttonEXIT) {
                this.Close();
            }
            this.Hide();
        }
    }
}
