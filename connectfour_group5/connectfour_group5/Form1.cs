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
    }
}
