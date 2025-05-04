using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//------------------------------------------------------------------------------------------------------------
// Names: Marc McLennan, Jacob Young, Austin Thornton
// Date:  05/04/2025
// Desc:  The statistics form showing stats such as player wins and losses, win rates, and # of games played
//------------------------------------------------------------------------------------------------------------

namespace connectfour_group5
{
	public partial class formSTATISTICS : Form {
		bool switching = false;
		formTITLE tform;
		private int playerwin = 0;
		private int playerloss = 0;
		private int draws = 0;

		public formSTATISTICS(formTITLE title) {
			InitializeComponent();

			tform = title;
			string line = "";
			line = readtxtfile(line);
			string playwin = playerwin.ToString();
			string playloss = playerloss.ToString();
			string draw = draws.ToString();
			buttonWINS.Text = "Wins: " + playwin;
			buttonLOSSES.Text = "Losses: " + playloss;
			buttonDRAWS.Text = "Draws: " + draw;
			buttonGAMES_PLAYED.Text = "Games Played: " + (playerwin + playerloss + draws).ToString();
			buttonPLAYER_WIN_RATE.Text = "Player Win Rate: " + ((double)playerwin / (playerwin + playerloss + draws)).ToString("P2");
			buttonAI_WIN_RATE.Text = "AI Win Rate: " + ((double)playerloss / (playerwin + playerloss + draws)).ToString("P2");
            parseline(line);
		}
		private void buttonTITLE_Click(object sender, EventArgs e) {
			switching = true;
			this.Close();
			tform.Show();
		}

		private void formSTATISTICS_FormClosed(object sender, FormClosedEventArgs e) {
			if (!switching) {
				tform.Close();
			}
			switching = false;
		}
		private void buttonCLOSE_Click(object sender, EventArgs e) {
			this.Close();
			tform.Close();
		}

		private string readtxtfile(string line) {
			string filePath = Path.GetFullPath(@"..\..\Resources\stats.txt");
			if (File.Exists(filePath)) {
				using (StreamReader reader = new StreamReader(filePath)) {
					line = reader.ReadLine();
					playerwin = Int32.Parse(line);
					line = reader.ReadLine();
					playerloss = Int32.Parse(line);
					line = reader.ReadLine();
					draws = Int32.Parse(line);
					return line;
				}
			} else {
				MessageBox.Show($"File not found: {filePath}");
				return null;
			}
		}
		private void parseline(string line) {
			Int32.Parse(line);
		}
	}
}
   