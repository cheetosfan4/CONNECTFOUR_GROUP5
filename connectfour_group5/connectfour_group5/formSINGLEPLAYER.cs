using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connectfour_group5.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Xml.Linq;

namespace connectfour_group5 {
	public partial class formSINGLEPLAYER : Form {
		private bool switching = false;
		private formTITLE tform;
		private Board board;

		private PictureBox[] column0 = new PictureBox[6], column1 = new PictureBox[6], 
			column2 = new PictureBox[6], column3 = new PictureBox[6], column4 = new PictureBox[6], 
			column5 = new PictureBox[6], column6 = new PictureBox[6];

		public formSINGLEPLAYER() {
			InitializeComponent();
			columnSetup();
		}
		public formSINGLEPLAYER(formTITLE title) {
			InitializeComponent();
			columnSetup();
			tform = title;
			this.board = new Board();
			board.outputCells();
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

        //i basically repurposed this into placeChip()
        /*
		private void column0_Click(object sender, EventArgs e) {
			// Just 1 cell for testing
			Cell cell = board.getCell(0, 5);
			cell.setState(1);
            // can't find the image (?)
            try {
                column0[5].Image = Image.FromFile("connectfour_group5\\Resources\\chip_red.png");

            } catch(Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		*/

		//    !!!IMPORTANT!!!
		//when we make the ai i think it should call an overloaded version of placeChip()
		//i wrote placeChip() to include code for player 2 (the ai) but i think it will have to be a separate function
		//cause it cant click on stuff lol so it won't have a "sender" object
		private void cellClick(object sender, EventArgs e) {
			placeChip(sender, 1);
		}

		private void cellHover(object sender, EventArgs e) {
			placeChip(sender, 3);
		}

		private void cellLeave(object sender, EventArgs e) {
			placeChip(sender, 0);
		}

        // Functions -----------------------------------------------------------

		//this loops through each column array to determine which column the player clicked
        public int columnCheck(object sender) {
            for (int i = 0; i <= 5; i++) {
                if (sender.Equals(column0[i])) {
                    return 0;
                }
                if (sender.Equals(column1[i])) {
                    return 1;
                }
                if (sender.Equals(column2[i])) {
                    return 2;
                }
                if (sender.Equals(column3[i])) {
                    return 3;
                }
                if (sender.Equals(column4[i])) {
                    return 4;
                }
                if (sender.Equals(column5[i])) {
                    return 5;
                }
                if (sender.Equals(column6[i])) {
                    return 6;
                }
            }
            //this is just in case some weird error happens
            return 99;
        }

        private void placeChip(object sender, int player) {
			// check for lowest available slot in that column - 
			// loop through all slots
			// for each slot, get the cell at that slot
			// if the state of that cell is 0 (empty), change its state to whichever player is placing the chip and break the loop
			// if the state is either 1 or 2, iterate to the next slot in the column (the slot directly above)

			//yo i had something like kindof similar to this ^ already in the board class (updateCell())
			//i fixed it up a bit and just integrated it into this function
			int y;
			Image image;
			int column = columnCheck(sender);
			//updateCell() gets the cell's y value when updating it
			//so i just had it return that y value to use in this function
			y = board.updateCell(player, column);

			if (player == 1) {
                //idk why the file path method you used wasn't working but Resources.[filename] works
                image = Resources.chip_red;
			}
			else if (player == 2) {
				image = Resources.chip_yellow;
			}
			else if (player == 3) {
				image = Resources.chip_red_preview;
			}
			else if (player == 4) {
				image = Resources.chip_yellow_preview;
			}
			else {
				image = Resources.chip_empty;
			}

			if (y != 99) {
				switch (column) {
					case 0:
						column0[y].Image = image;
						break;
					case 1:
						column1[y].Image = image;
						break;
					case 2:
						column2[y].Image = image;
						break;
					case 3:
						column3[y].Image = image;
						break;
					case 4:
						column4[y].Image = image;
						break;
					case 5:
						column5[y].Image = image;
						break;
					case 6:
						column6[y].Image = image;
						break;
					case 99:
						Console.WriteLine("error");
						break;
				}
			}
			//this is just to re-show the preview chip after the player places one
			//originally it wouldn't show a new one until the player moved the mouse onto a different cell but i thought that looked weird
			if(player == 1) {
				placeChip(sender, 3);
			}

		}

        public void columnSetup() {
			// columns are ordered bottom to top

			//i like what you did with the columns it made it easier to write the other stuff
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
		}
	}
}
