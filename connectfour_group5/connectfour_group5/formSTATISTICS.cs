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

namespace connectfour_group5
{
    public partial class formSTATISTICS : Form
    {
        bool switching = false;
        formTITLE tform;
         private int playerwin = 0;
         private int playerloss = 0;
         private int draws = 0;

        public formSTATISTICS()
        {

            InitializeComponent();
            
           
            
        }
        public formSTATISTICS(formTITLE title)
        {
            InitializeComponent();

            tform = title;
            string line = "";
            //works
            line = readtxtfile(line);
            string playwin = playerwin.ToString();
            string playloss = playerloss.ToString();
            string draw = draws.ToString();
            label1.Text ="player wins: " + playwin;
            label2.Text = "ai wins: " +playloss;
            label3.Text = "draws: " + draw;
            label4.Text = "total games: " + (playerwin + playerloss + draws).ToString();
            label5.Text = "player win rate: %" + ((double)playerwin / (playerwin + playerloss + draws)).ToString("P2");
            label6.Text = "ai win rate: %" + ((double)playerloss / (playerwin + playerloss + draws)).ToString("P2");
            parseline(line);
        }
        private void buttonTITLE_Click(object sender, EventArgs e)
        {
            switching = true;
            this.Close();
            tform.Show();
        }

        private void formSTATISTICS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!switching)
            {
                tform.Close();
            }
            switching = false;
        }
        private void buttonCLOSE_Click(object sender, EventArgs e)
        {
            this.Close();
            tform.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string readtxtfile(string line)
        {
            // need to change path to work with evveryone
            string filePath = @"C:\Users\athor\source\repos\CONNECTFOUR_GROUP5\connectfour_group5\connectfour_group5\connectfour_group5\stats.txt";
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    line = reader.ReadLine();
                    playerwin = Int32.Parse(line);
                    line = reader.ReadLine();
                    playerloss = Int32.Parse(line);
                    line = reader.ReadLine();
                    draws = Int32.Parse(line);
                    return line;
                }
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}");
                return null;
            }
        }
        private void parseline(string line)
        {
            Int32.Parse(line);

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
   