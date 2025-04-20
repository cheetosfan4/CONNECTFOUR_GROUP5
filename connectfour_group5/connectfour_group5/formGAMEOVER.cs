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
	public partial class formGAMEOVER : Form {

		private bool multiplayer;
		private formGAMEPLAY formGameplay;
		private formTITLE tform;
		private List<Form> savedGames;

		public formGAMEOVER(formGAMEPLAY formGameplay, formTITLE title, int winner, bool multiplayer, List<Form> savedGames) {
			InitializeComponent();
			this.multiplayer = multiplayer;
			this.formGameplay = formGameplay;
			this.tform = title;
			this.savedGames = savedGames;

			if (winner == 1) {
				labelWINNER.Text = "PLAYER 1 WINS!";
			} else if (winner == 2) {
				if (multiplayer) {
					labelWINNER.Text = "COMPUTER WINS!";
				} else {
					labelWINNER.Text = "PLAYER 2 WINS!";
				}
			}
		}

		private void buttonTITLE_Click(object sender, EventArgs e) {
			this.Hide();
			tform.Show();
		}

		private void buttonCLOSE_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void buttonPLAY_AGAIN_Click(object sender, EventArgs e) {
			formGAMEPLAY newGame = new formGAMEPLAY(tform, multiplayer, savedGames);
			newGame.Show();
			this.Hide();
			formGameplay.Hide();
		}

		private void buttonREVIEW_GAME_Click(object sender, EventArgs e) {
			formGameplay.review();
			formGameplay.Show();
		}
	}
}
