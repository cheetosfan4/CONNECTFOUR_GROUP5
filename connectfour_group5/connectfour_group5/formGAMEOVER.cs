﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectfour_group5 {
	public partial class formGAMEOVER : Form {

		private bool multiplayer;
		private bool switching = false;
		private formGAMEPLAY formGameplay;
		private formTITLE tform;
		private List<Form> savedGames;
		private int playerwin = 0;
		private int playerloss = 0;
		private int draws = 0;

		public formGAMEOVER(formGAMEPLAY formGameplay, formTITLE title, int winner, bool multiplayer, bool draw, List<Form> savedGames) {
			InitializeComponent();
			this.multiplayer = multiplayer;
			this.formGameplay = formGameplay;
			this.tform = title;
			this.savedGames = savedGames;

            readtxtfile();
			buttonGAMES.Text = "Games: " + (playerwin + playerloss + draws).ToString();
            buttonWINS.Text = "Wins: " + playerwin;
			buttonLOSSES.Text = "Losses: " + playerloss;
			buttonDRAWS.Text = "Draws: " + draws;
			buttonWINPCT.Text = "Win%: " + ((double)playerwin / (playerwin + playerloss + draws)).ToString("P2");
			buttonLOSEPCT.Text = "Loss%: " + ((double)playerloss / (playerwin + playerloss + draws)).ToString("P2");

            if (winner == 1) {
				buttonWINNER.Text = "PLAYER 1 WINS!";
				if (!multiplayer) {
					playerwin++;
					writetofile();
				}

			} else if (winner == 2) {
				if (!multiplayer) {
					buttonWINNER.Text = "COMPUTER WINS!";
					playerloss++;
					writetofile();

				} else {
					buttonWINNER.Text = "PLAYER 2 WINS!";
				}
			} else {
				buttonWINNER.Text = "DRAW!";
				if (!multiplayer) {
					draws++;
					writetofile();
				}
			}

            readtxtfile();
            buttonGAMES.Text = "Games: " + (playerwin + playerloss + draws).ToString();
            buttonWINS.Text = "Wins: " + playerwin;
            buttonLOSSES.Text = "Losses: " + playerloss;
            buttonDRAWS.Text = "Draws: " + draws;
            buttonWINPCT.Text = "Win%: " + ((double)playerwin / (playerwin + playerloss + draws)).ToString("P2");
            buttonLOSEPCT.Text = "Loss%: " + ((double)playerloss / (playerwin + playerloss + draws)).ToString("P2");

        }

		private void buttonTITLE_Click(object sender, EventArgs e) {
			switching = true;
			this.Close();
			tform.Show();
		}

		private void formGAMEOVER_FormClosed(object sender, FormClosedEventArgs e) {
			if (!switching) {
				tform.Close();
			}
			switching = false;
		}

		private void buttonCLOSE_Click(object sender, EventArgs e) {
			this.Close();
			tform.Close();
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

		private void readtxtfile() {
			string filePath = Path.GetFullPath(@"..\..\Resources\stats.txt");
			string line = "";
			if (File.Exists(filePath)) {
				using (StreamReader reader = new StreamReader(filePath)) {
					line = reader.ReadLine();
					playerwin = Int32.Parse(line);
					line = reader.ReadLine();
					playerloss = Int32.Parse(line);
					line = reader.ReadLine();
					draws = Int32.Parse(line);
				}
			} else {
				MessageBox.Show($"File not found: {filePath}");
			}
		}

		private void writetofile() {
			string filePath = Path.GetFullPath(@"..\..\Resources\stats.txt");
			if (File.Exists(filePath)) {
				File.WriteAllText(filePath, string.Empty);
				using (StreamWriter writer = new StreamWriter(filePath)) {
					try {
						writer.WriteLine(playerwin);
						writer.WriteLine(playerloss);
						writer.WriteLine(draws);
					} catch (Exception e) {
						MessageBox.Show(e.ToString());
					}
				}
			} else {
				MessageBox.Show($"File not found: {filePath}");  
			}
		}
	}
}
