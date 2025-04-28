using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectfour_group5 {
	internal class AI {
		private Board board;
		private PictureBox[][] columns;
		private List<Cell> cells;

		public AI(Board board, PictureBox[][] columns, List<Cell> cells) {
			this.board = board;
			this.columns = columns;
			this.cells = cells;
		}

		public int getOptimalColumn() {

			// maps columns (keys) to their scores (values)
			Dictionary<int, int> potentialColumnsMap = new Dictionary<int, int>();
			// stores all potential columns to place the next chip in
			Dictionary<int, int> bestColumns = new Dictionary<int, int>();
			// stores all columns with same highest scores

			for (int i = 2; i <=4; i++) {
				addVerticalLineColumns(i, potentialColumnsMap);
			}
			
			int bestScore = 0;

			foreach(int score in potentialColumnsMap.Values) {
				// add the column if it has the highest score so far, or if it matches the highest score
				if (score >= bestScore) {
					bestScore = score;
					addToMap(bestColumns, potentialColumnsMap.FirstOrDefault(pair => pair.Value == score).Key, score);
				}
				// remove all columns with scores lower than it, as long as there are columns to remove
				if (bestColumns.Count > 0) { 
					foreach (int existingScore in bestColumns.Values.ToList()) {
						if (existingScore < score) {
							bestColumns.Remove(bestColumns.FirstOrDefault(pair => pair.Value == existingScore).Key);
						}
						if (bestColumns.Count == 0) break;
					}
				}
			}

			// choose a random column from bestColumns
			Random random = new Random();
			int finalColumn;
			if (bestColumns.Count > 0) {
				finalColumn = bestColumns.Keys.ElementAt(random.Next(bestColumns.Count));
			} else {
				finalColumn = random.Next(columns.Count());
			}

			return finalColumn;
		}

		// columns that would:

		// any combination gets added together

		// create a line of 4 (AI victory) - score 100
		// block a line of 3 by placing a 4th chip (prevent a player victory) - score 50

		// create a line of 3 - score 10
		// block a line of 2 by placing a 3rd chip - score 5
		// create a line of 2 - score 1

		// split into 3 different functions - 1 for each height
		// this one is messy and complicated and very difficult and confusing to follow
		public void addVerticalLineColumns(int height, Dictionary<int, int> columnsToScoresMap) {
			// returns the column that the line is in
			if (height < 2 || height > 4) {
				return;
			}

			int score;
			switch (height) {
				case 2: score = 1; break;
				case 3: score = 10; break;
				case 4: score = 100; break;
				default: score = 0; break;
			}
			foreach (Cell cell in cells) {
				//Console.WriteLine("AI - Currently checking vertical potential for " + cell.ToString());
				int y = cell.getYCoord(), x = cell.getXCoord();
				// y increases down - 0 is top row, 5 is bottom
				if (y > 0) {
					if (
							// line start
							board.getCell(x, y).getState() == 2
						&& (
							// if height is 2, check if above cell is empty
							// otherwise, check if its an ai chip
							height == 2 ?
							board.getCell(x, y - 1).getState() == 0 :
							board.getCell(x, y - 1).getState() == 2
						) && (
							// if height is 3 or 4, check if the cell 2 spots up is an ai chip
							// otherwise, check if that spot is empty
							y < 1 ||
							height >= 3 ?
							board.getCell(x, y - 2).getState() == 2 :
							board.getCell(x, y - 2).getState() == 0
						) && (
							// same check as above
							y < 2 ||
							height == 4 ?
							board.getCell(x, y - 3).getState() == 2 : (
								// if the height is 3, check for an empty cell above 2 chips
								height != 3 || board.getCell(x, y - 3).getState() == 0
							)
						) && (
							// same check again, but only to make sure the spot above 3 chips is empty
							y < 3 ||
							height != 4 || board.getCell(x, y - 4).getState() == 0
						)
					) {
						addToMap(columnsToScoresMap, x, score);
						Console.WriteLine("Added column " + x + " with a score of " + score);
					}
				}
			}
		}

		public void addToMap(Dictionary<int, int> map, int column, int score) {
			// if the column already has an entry, add the existing score to the new one, and then remove the existing one
			if (map.ContainsKey(column)) {
				score += map.FirstOrDefault(pair => pair.Key == column).Value;
				map.Remove(column);
			}
			map.Add(column, score);
		}
	}
}