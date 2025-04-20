using connectfour_group5.Properties;
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
	public partial class formMULTIPLAYER : Form {

		// !!! IMPORTANT !!!
		// This class has been merged into formSINGLEPLAYER, which has been renamed as formGAMEPLAY
		// This class is currently unused

		private bool switching = false;
		private formTITLE tform;
		private Board board;
		private int player = 1;

		private PictureBox[] column0 = new PictureBox[6], column1 = new PictureBox[6],
			column2 = new PictureBox[6], column3 = new PictureBox[6], column4 = new PictureBox[6],
			column5 = new PictureBox[6], column6 = new PictureBox[6];

		private PictureBox[][] columns = new PictureBox[7][];

		public formMULTIPLAYER(formTITLE title) {
			InitializeComponent();
			columnSetup();
			tform = title;
			this.board = new Board();
		}

		private void buttonTITLE_Click(object sender, EventArgs e) {
			switching = true;
			this.Close();
			tform.Show();
		}

		private void formMULTIPLAYER_FormClosed(object sender, FormClosedEventArgs e) {
			if (!switching) {
				tform.Close();
			}
			switching = false;
		}

		private void buttonCLOSE_Click(object sender, EventArgs e) {
			this.Close();
			tform.Close();
		}

		// Copied from formSINGLEPLAYER

		private void cellClick(object sender, EventArgs e) {
			//placeChip(sender, player, columns);
			switchPlayer();
			//placeChip(sender, player + 2, columns);
		}

		private void cellHover(object sender, EventArgs e) {
			//placeChip(sender, player + 2, columns);
		}

		private void cellLeave(object sender, EventArgs e) {
			//placeChip(sender, 0, columns);
		}

		// Functions -----------------------------------------------------------

		public void switchPlayer() {
			if (player == 1) {
				player = 2;
				return;
			}
			if (player == 2) {
				player = 1;
				return;
			}
		}


		public void columnSetup() {
			column0[0] = slot35;
			column0[1] = slot28;
			column0[2] = slot21;
			column0[3] = slot14;
			column0[4] = slot7;
			column0[5] = slot0;

			column1[0] = slot36;
			column1[1] = slot29;
			column1[2] = slot22;
			column1[3] = slot15;
			column1[4] = slot8;
			column1[5] = slot1;

			column2[0] = slot37;
			column2[1] = slot30;
			column2[2] = slot23;
			column2[3] = slot16;
			column2[4] = slot9;
			column2[5] = slot2;

			column3[0] = slot38;
			column3[1] = slot31;
			column3[2] = slot24;
			column3[3] = slot17;
			column3[4] = slot10;
			column3[5] = slot3;

			column4[0] = slot39;
			column4[1] = slot32;
			column4[2] = slot25;
			column4[3] = slot18;
			column4[4] = slot11;
			column4[5] = slot4;

			column5[0] = slot40;
			column5[1] = slot33;
			column5[2] = slot26;
			column5[3] = slot19;
			column5[4] = slot12;
			column5[5] = slot5;

			column6[0] = slot41;
			column6[1] = slot34;
			column6[2] = slot27;
			column6[3] = slot20;
			column6[4] = slot13;
			column6[5] = slot6;


			columns[0] = column0;
			columns[1] = column1;
			columns[2] = column2;
			columns[3] = column3;
			columns[4] = column4;
			columns[5] = column5;
			columns[6] = column6;
		}
	}
}
