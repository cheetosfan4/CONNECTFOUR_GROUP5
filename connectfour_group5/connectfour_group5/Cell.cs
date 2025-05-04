using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//----------------------------------------------------------------------------------------------
// Names: Marc McLennan, Jacob Young, Austin Thornton
// Date:  05/04/2025
// Desc:  Contains all information for each cell, including position and state (color)
//----------------------------------------------------------------------------------------------

namespace connectfour_group5 {
    public class Cell {
        private int state;
        private int xCoord;
        private int yCoord;

        public Cell() {
            //state determines chip color
            //0 for empty, 1 for player 1's piece, 2 for player 2's piece
            //3 for player 1's preview, and 4 for player 2's preview
            state = 0;
            // x increases right
            // y increases down
            xCoord = 0;
            yCoord = 0;
        }

        public void setState(int s) {
            state = s;
        }
        public void setXCoord(int x) {
            xCoord = x;
        }
        public void setYCoord(int y) {
            yCoord = y;
        }
        public int getState() {
            return state;
        }
        public int getXCoord() {
            return xCoord;
        }
        public int getYCoord() {
            return yCoord;
        }
    }
}