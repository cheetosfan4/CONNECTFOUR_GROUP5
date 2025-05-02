using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectfour_group5 {
	internal class AI {
		private Board board;
		private PictureBox[][] columns;
		private List<Cell> cells;
		private List<int> availableColumns = new List<int>();

		// maps columns (keys) to their scores (values)
		private OrderedDictionary potentialColumns = new OrderedDictionary();
		// stores all potential columns to place the next chip in

		private OrderedDictionary bestColumns = new OrderedDictionary();
		// stores all columns with same highest scores

		public AI(Board board, PictureBox[][] columns, List<Cell> cells) {
			this.board = board;
			this.columns = columns;
			this.cells = cells;

			availableColumns.Add(0);
			availableColumns.Add(1);
			availableColumns.Add(2);
			availableColumns.Add(3);
			availableColumns.Add(4);
			availableColumns.Add(5);
			availableColumns.Add(6);
		}

		public int getOptimalColumn() {
			add2LongVertical();
			add3LongVertical();
			add4LongVertical();
			add2LongRight();
			add2LongLeft();
			add3LongRightEnd();
			
			int bestScore = 0;

			for (int i = 0; i < potentialColumns.Values.Count; i++) {
				// add the column if it has the highest score so far, or if it matches the highest score
				int score = (int) potentialColumns[i];
				if (score >= bestScore) {
					bestScore = score;
					addToMap(bestColumns, getKeyFromIndex(potentialColumns, i), score);
					Console.WriteLine(
						"getOptimalColumn: Added column " + 
						getKeyFromIndex(potentialColumns, i) + 
						" with score " + score + " to bestColumns"
						);
				}
				// remove all columns with scores lower than it, as long as there are columns to remove
				if (bestColumns.Count > 0) {
					foreach (int existingScore in bestColumns.Values.Cast<int>().ToList()) {
						if (existingScore < score) {
							Console.WriteLine("Existing score to remove: " + existingScore);
							Console.WriteLine("Score to compare: " + score);
							Console.WriteLine("Attempting to remove column...");
							Console.WriteLine("Size of bestColumns: " + bestColumns.Count);
							Console.WriteLine("Index of existingScore: " + getFirstIndexOfValue(bestColumns, existingScore));
							bestColumns.Remove(getKeyFromIndex(bestColumns, getFirstIndexOfValue(bestColumns, existingScore)));
							Console.WriteLine(
								"getOptimalColumn: Removed column " +
								getKeyFromIndex(bestColumns, getFirstIndexOfValue(bestColumns, existingScore)) +
								" with score " + existingScore + " from bestColumns"
								);
						}
						if (bestColumns.Count == 0) break;
					}
				}
			}

			// choose a random column from bestColumns
			Random random = new Random();
			int finalColumn;
			if (bestColumns.Count > 0) {
				finalColumn = bestColumns.Keys.Cast<int>().ToList()[random.Next(bestColumns.Count)];
			} else {
				finalColumn = availableColumns[random.Next(availableColumns.Count())];
			}

			potentialColumns.Clear();
			bestColumns.Clear();

			return finalColumn;
		}

		// any combination gets added together

		// columns that would:

		// create a line of 4 (AI victory) - score 1000
		// block a line of 3 by placing a 4th chip (prevent a player victory) - score 50

		// create a line of 3 - score 10
		// block a line of 2 by placing a 3rd chip - score 5
		// create a line of 2 - score 1

		public void add2LongVertical() {
			foreach (Cell cell in cells) {
				if (cell.getYCoord() > 0) {
					if (
						startState(cell, 2) &&
						matchesState(cell, 0, 0, 1)
						) {
						addToMap(potentialColumns, cell.getXCoord(), 1);
						Console.WriteLine("2LongVertical: Added column " + cell.getXCoord() + " with score 1 to potentialColumns");
					}
				}
			}
		}
		
		public void add3LongVertical() {
			foreach (Cell cell in cells) {
				if (cell.getYCoord() > 1) {
					if (
						startState(cell, 2) &&
						matchesState(cell, 2, 0, 1) &&
						matchesState(cell, 0, 0, 2)
						) {
						addToMap(potentialColumns, cell.getXCoord(), 10);
						Console.WriteLine("3LongVertical: Added column " + cell.getXCoord() + " with score 10 to potentialColumns");
					}
				}
			}
		}

		public void add4LongVertical() {
			foreach (Cell cell in cells) {
				if (cell.getYCoord() > 2) {
					if (
						startState(cell, 2) &&
						matchesState(cell, 2, 0, 1) &&
						matchesState(cell, 2, 0, 2) &&
						matchesState(cell, 0, 0, 3)
					) {
						addToMap(potentialColumns, cell.getXCoord(), 1000);
						Console.WriteLine("4LongVertical: Added column " + cell.getXCoord() + " with score 1000 to potentialColumns");
					}
				}
			}
		}

		public void add2LongRight() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				if (x < 6) {
					if (
						startState(cell, 2) &&
						matchesState(cell, 0, 1, 0) && 
						checkPlatform(cell, 1, -1)
						) {
						addToMap(potentialColumns, x + 1, 1);
						Console.WriteLine("2LongRight: Added column " + (x + 1) + " with score 1 to potentialColumns");
					}
				}
			}
		}

		public void add2LongLeft() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				if (x > 0) {
					if (
						startState(cell, 2) &&
						matchesState(cell, 0, -1, 0) && 
						checkPlatform(cell, -1, -1)
						) {
						addToMap(potentialColumns, x - 1, 1);
						Console.WriteLine("2LongLeft: Added column " + (x - 1) + " with score 1 to potentialColumns");
					}
				}
			}
		}

		public void add3LongRightEnd() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				if (x < 5) {
					if (
						startState(cell, 2) &&
						matchesState(cell, 2, 1, 0) && 
						matchesState(cell, 0, 2, 0) &&
						checkPlatform(cell, 2, -1)
						) {
						addToMap(potentialColumns, x + 2, 10);
						Console.WriteLine("3LongRightEnd: Added column " + (x + 2) + " with score 10 to potentialColumns");
					}
				}
			}
		}

		// Helper functions

		public bool checkPlatform(Cell cell, int xOffset, int yOffset) {
			// if the cell is in the bottom row, done checking
			// otherwise, check to see if there is a chip to place on
			return cell.getYCoord() == 5 || chipPresent(cell, xOffset, yOffset);
		}

		public bool chipPresent(Cell cell, int xOffset, int yOffset) {
			return matchesState(cell, 1, xOffset, yOffset) || matchesState(cell, 2, xOffset, yOffset);
		}

		public bool startState(Cell cell, int state) {
			return matchesState(cell, state, 0, 0);
		}

		public bool matchesState(Cell cell, int state, int xOffset, int yOffset) {
			int x = cell.getXCoord(), y = cell.getYCoord();
			return (board.getCell(x + xOffset, y - yOffset).getState() == state);
		}

		public void addToMap(OrderedDictionary map, int column, int score) {
			// if the column already has an entry, add the existing score to the new one, and then remove the existing one
			if (map.Contains(column)) {
				if (map.Equals(potentialColumns)) score += getValueFromIndex(map, getFirstIndexOfKey(map, column));
				map.Remove(column);
			}
			map.Add(column, score);
			Console.WriteLine("addToMap: Added column " + column + " with score " + score);
		}

		public int getKeyFromIndex(OrderedDictionary map, int index) {
			return (int) map.Cast<DictionaryEntry>().ElementAt(index).Key;
		}

		public int getValueFromIndex(OrderedDictionary map, int index) {
			return (int) map.Cast<DictionaryEntry>().ElementAt(index).Value;
		}

		public int getFirstIndexOfKey(OrderedDictionary map, int key) {
			return map.Keys.Cast<int>().ToList().IndexOf(key);
		}

		public int getFirstIndexOfValue(OrderedDictionary map, int value) {
			return map.Values.Cast<int>().ToList().IndexOf(value);
		}

		public void updateAvailableColumns() {
			foreach (Cell cell in cells) {
				int y = cell.getYCoord();
				if (
					y == 0 &&
					chipPresent(cell, 1, 0) &&
					chipPresent(cell, 2, 0) &&
					chipPresent(cell, 3, 0) &&
					chipPresent(cell, 4, 0)	&&
					chipPresent(cell, 5, 0)
					) {
					availableColumns.Remove(cell.getXCoord());
				}
			}
		}
	}
}