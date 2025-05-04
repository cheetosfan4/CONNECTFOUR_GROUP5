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
using System.Threading;
using System.Runtime.Remoting.Channels;

namespace connectfour_group5 {
	public partial class formGAMEPLAY : Form {
		private bool switching = false, multiplayer, gameover = false, draw = false, cellLeaveCalled;
		private int player = 1;
		private bool aiPlacing = false;
		private formTITLE tform;
		private Board board;
		private List<Form> savedGames;
		private List<Cell> cells;
		private AI ai;
		private PictureBox currentSender;

		private PictureBox[] column0 = new PictureBox[6], column1 = new PictureBox[6], 
			column2 = new PictureBox[6], column3 = new PictureBox[6], column4 = new PictureBox[6], 
			column5 = new PictureBox[6], column6 = new PictureBox[6];

		private PictureBox[][] columns = new PictureBox[7][];


		public formGAMEPLAY(formTITLE title, bool multiplayer, List<Form> savedGames) {
			InitializeComponent();
			columnSetup();
			tform = title;
			board = new Board();
			cells = board.getAllCells();
			ai = new AI(board, columns, cells);
			this.multiplayer = multiplayer;
			this.Text = multiplayer ? "Connect Four: Multiplayer" : "Connect Four: Singleplayer";
			this.savedGames = savedGames;
		}

		private void buttonTITLE_Click(object sender, EventArgs e) {
			switching = true;
			savedGames.Add(this);
			this.Close();
			tform.Show();
		}

		private void formGAMEPLAY_FormClosed(object sender, FormClosedEventArgs e) {
			if (!switching) {
				tform.Close();
			}
			switching = false;
		}

		private void buttonCLOSE_Click(object sender, EventArgs e) {
			this.Close();
			tform.Close();
		}

		private async void cellClick(object sender, EventArgs e) {
			if (aiPlacing) {
				return;
			}

			int column = columnCheck(sender);
			int y = board.updateCell(player + 2, column);

			if (!gameover) {
				if (multiplayer) {
					placeChip(sender, player);
				} else {
					if (player == 1) {
						placeChip(sender, 1);
					}
				}
                checkDraw();
                checkVictory();
			}

			cellLeaveCalled = false;

			if (y != -1 && !gameover) {
				switchPlayer();
				cellHover(sender, e);

				if (!multiplayer) {
					aiPlacing = true;
					int aiColumn = ai.getOptimalColumn();
					Random random = new Random();
					await Task.Delay(random.Next(500, 2000));
					placeChip(columns[aiColumn][5], 2);
                    checkDraw();
                    checkVictory();
					switchPlayer();
					cellHover(currentSender, e);
					aiPlacing = false;
				}
			}
		}

		private void cellHover(object sender, EventArgs e) {
			currentSender = sender as PictureBox;
			if (!gameover) {
				if (multiplayer) {
					placeChip(sender, player + 2);
				} else {
					if (player == 1) {
						placeChip(sender, 3);
					}
				}
			}
		}

		private void cellLeave(object sender, EventArgs e) {
			placeChip(sender, 0);
			cellLeaveCalled = true;
		}

		private void buttonCLOSE_REVIEW_Click(object sender, EventArgs e) {
			this.Hide();
		}

		// Functions -----------------------------------------------------------

		public int columnCheck(object sender) {

			//this loops through each column array to determine which column the player clicked
			for (int c = 0; c < columns.Length; c++) {
				for (int r = 0; r < 6; r++) {
					if (sender.Equals(columns[c][r])) {
						return c;
					}
				}
			}

			//this is just in case some weird error happens
			return -1;
		}

		public void placeChip(object sender, int player) {
			
			int y;
			Image image;
			int column = columnCheck(sender);
			y = board.updateCell(player, column);

			switch (player) {
				case 1:
					image = Resources.chip_red;
					break;
				case 2:
					image = Resources.chip_yellow;
					break;
				case 3:
					image = Resources.chip_red_preview;
					break;
				case 4:
					image = Resources.chip_yellow_preview;
					break;
				default:
					image = Resources.chip_empty;
					break;
			}

			if (y < 6 && y != -1) {
				columns[column][y].Image = image;
			}
		}

		public void switchPlayer() {

			if (player == 1) {
				player = 2;
				buttonCURRENT_TURN.Text = "PLAYER 2'S TURN";
				return;
			}
			if (player == 2) {
				player = 1;
				buttonCURRENT_TURN.Text = "PLAYER 1'S TURN";
				return; 
			}
		}

		public void checkVictory() {
			foreach (Cell cell in cells) {		
				if (
					horizontalVictory(cell) ||
					verticalVictory(cell) ||
					downLeftVictory(cell) ||
					downRightVictory(cell)
				) {
					gameover = true;
					displayWinner(cell.getState());
					return;
				}
			}
			if (draw) {
                gameover = true;
                displayWinner(0);
                return;
            }
        }

		public bool horizontalVictory(Cell cell) {
			int stateToCheck = cell.getState();
			if (stateToCheck == 0 || cell.getXCoord() > 3) {
				return false;
			}
			if (
				board.getCell(cell.getXCoord() + 1, cell.getYCoord()).getState() == stateToCheck &&
				board.getCell(cell.getXCoord() + 2, cell.getYCoord()).getState() == stateToCheck &&
				board.getCell(cell.getXCoord() + 3, cell.getYCoord()).getState() == stateToCheck
			) {
				return true;
			} else {
				return false;
			}
		}

		public bool verticalVictory(Cell cell) {
			int stateToCheck = cell.getState();
			if (stateToCheck == 0 || cell.getYCoord() < 3) {
				return false;
			}
			if (
				board.getCell(cell.getXCoord(), cell.getYCoord() - 1).getState() == stateToCheck &&
				board.getCell(cell.getXCoord(), cell.getYCoord() - 2).getState() == stateToCheck &&
				board.getCell(cell.getXCoord(), cell.getYCoord() - 3).getState() == stateToCheck
			) {
				return true;
			} else {
				return false;
			}
		}

		public bool downLeftVictory(Cell cell) {
			int stateToCheck = cell.getState();
			if (stateToCheck == 0 || cell.getXCoord() < 3 || cell.getYCoord() < 3) {
				return false;
			}
			if (
				board.getCell(cell.getXCoord() - 1, cell.getYCoord() - 1).getState() == stateToCheck &&
				board.getCell(cell.getXCoord() - 2, cell.getYCoord() - 2).getState() == stateToCheck &&
				board.getCell(cell.getXCoord() - 3, cell.getYCoord() - 3).getState() == stateToCheck
			) {
				return true;
			} else {
				return false;
			}
		}

		public bool downRightVictory(Cell cell) {
			int stateToCheck = cell.getState();
			if (stateToCheck == 0 || cell.getXCoord() > 3 || cell.getYCoord() < 3) {
				return false;
			}
			if (
				board.getCell(cell.getXCoord() + 1, cell.getYCoord() - 1).getState() == stateToCheck &&
				board.getCell(cell.getXCoord() + 2, cell.getYCoord() - 2).getState() == stateToCheck &&
				board.getCell(cell.getXCoord() + 3, cell.getYCoord() - 3).getState() == stateToCheck
			) {
				return true;
			} else {
				return false;
			}
		}

		public void checkDraw() {
			foreach (Cell cell in cells) {
				if (cell.getState() == 0) {
					return;
				}
			}
			gameover = true;
			draw = true;
		}

		public void displayWinner(int player) {
			formGAMEOVER formGAMEOVER = new formGAMEOVER(this, tform, player, multiplayer, draw, savedGames);
			formGAMEOVER.Show();
			this.Hide();
		}

		public void review() {
			buttonCURRENT_TURN.Visible = false;
			buttonTITLE.Visible = false;
			buttonCLOSE_REVIEW.Visible = true;
		}

		public void columnSetup() {
			// columns are ordered bottom to top

			// Individual columns
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

			// 2d array of all columns
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
