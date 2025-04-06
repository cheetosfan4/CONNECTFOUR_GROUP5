using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connectfour_group5 {
    internal class Cell {
        private int state;
        private int xCoord;
        private int yCoord;

        public Cell() {
            //state should be used for what the cell has in it
            //0 for empty, 1 for player 1's piece, and 2 for player 2's piece
            state = 0;
            //x and y coords should just be integers counting up by 1, not their actual form control's coordinates on the form
            //that way it's simple to know which one you're manipulating
            xCoord = 0;
            yCoord = 0;
        }
        public Cell(int s, int x, int y) {
            state = s;
            xCoord = x;
            yCoord = y;
        }

        //i think each cell on the form should be a picturebox, and when the cell object changes state it will load a different image onto it's respective picturebox
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