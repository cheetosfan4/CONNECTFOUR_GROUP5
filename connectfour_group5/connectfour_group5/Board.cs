using connectfour_group5.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

		public List<Cell> getAllCells() {
			return cells;
		}

		public int updateCell(int player, int x) {
			int columnAmount = 0;
			for (int i = 0; i < cells.Count; i++) {
				if (cells[i].getXCoord() == x && cells[i].getState() != 0) {
					columnAmount++;
				}
			}
			//sets the state for the cell above the current top cell in the selected column

			//this only runs if player1/player2 places a chip
			//so for the preview chips it still calculates the amount of chips in a column it just doesn't actually update any cells
			if (player == 1 || player == 2) {
				for (int i = 0; i < cells.Count; i++) {
					if (cells[i].getXCoord() == x && cells[i].getYCoord() == (5 - columnAmount)) {
						cells[i].setState(player);
						Console.WriteLine("chip set to " + player + " at: " + cells[i].getXCoord() + ", " + cells[i].getYCoord());
					}
				}
			}
			if (columnAmount == 6) {
				//this is just when the column is full
				return -1;
			} else {
				return columnAmount;
			}
		}

		public Cell getCell(int x, int y) {
			foreach (Cell cell in cells) {
				if (cell.getXCoord() == x && cell.getYCoord() == y) {
					return cell;
				}
			}
			return null;
		}
	}
}
