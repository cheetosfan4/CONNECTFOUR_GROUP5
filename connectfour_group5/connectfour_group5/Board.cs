using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace connectfour_group5 {
    internal class Board {
        private List<Cell> cells;

        public Board() {
            int j = 0;
            cells = new List<Cell>();
            //7 width, 6 height for connect four board
            for (int i = 0; i < 42; i++) {
                Cell cell = new Cell();
                cell.setState(0);
                //first cell's coords are 0,0
                //last cell's are 6,5
                //every seven cells, the x coordinate gets set back to 0 for the next row
                cell.setXCoord(i % 7);
                //for every new row, j is increased by one for the y coordinate
                if ((i > 0) && (i % 7 == 0)) {
                    j++;
                }
                cell.setYCoord(j);
                cells.Add(cell);
            }
        }

        public void updateCell(int player, int x, int y) {
            int columnAmount = 0;
            for (int i = 0; i < cells.Count; i++) {
                if (cells[i].getXCoord() == x) {
                    columnAmount++;
                }
            }
            //sets the state for the cell above the current top cell in the selected column
            for (int i = 0; i < cells.Count; i++) {
                if (cells[i].getXCoord() == x && cells[i].getYCoord() == (5 - columnAmount)) {
                    cells[i].setState(player);
                }
            }
        }

        //testing function just to view the data for each cell in the list
        public void outputCells() {
            for (int i = 0; i < cells.Count; i++) {
                Console.WriteLine("\nState: " + cells[i].getState() + "\nX Coord: " + cells[i].getXCoord() + "\nY Coord: " + cells[i].getYCoord());
            }
        }

    }
}
