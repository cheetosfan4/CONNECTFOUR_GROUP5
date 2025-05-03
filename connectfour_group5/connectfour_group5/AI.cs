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
			//add2LongRight();
			//add2LongLeft();
			//add3LongRightEnd();

			add2LongHorizontal();
			add3LongHorizontal();
			add4LongHorizontal();

			add2LongDiagonal();
			add3LongDiagonal();
			add4LongDiagonal();
			
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
                            int index = getFirstIndexOfValue(bestColumns, existingScore);
                            //Console.WriteLine("Index of existingScore: " + getFirstIndexOfValue(bestColumns, existingScore));
                            Console.WriteLine("Index of existingScore: " + index);

							//i was getting an error that index was out of bounds in getkeyfromindex
                            if (index != -1) {
                                int key = getKeyFromIndex(bestColumns, index);
                                bestColumns.Remove(key);
                                //bestColumns.Remove(getKeyFromIndex(bestColumns, getFirstIndexOfValue(bestColumns, existingScore)));
                                Console.WriteLine(
                                   "getOptimalColumn: Removed column " +
                                   key +
                                   //getKeyFromIndex(bestColumns, getFirstIndexOfValue(bestColumns, existingScore)) +
                                   " with score " + existingScore + " from bestColumns"
                                );
                            }

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
                    //============
                    // ai scoring
                    //============
                    if (
						startState(cell, 2) &&
						matchesState(cell, 2, 0, 1) &&
						matchesState(cell, 0, 0, 2)
						) {
						addToMap(potentialColumns, cell.getXCoord(), 10);
						Console.WriteLine("3LongVertical: Added column " + cell.getXCoord() + " with score 10 to potentialColumns");
					}
                    //====================
                    // ai blocking player
                    //====================
                    if (
					    startState(cell, 1) &&
					    matchesState(cell, 1, 0, 1) &&
					    matchesState(cell, 0, 0, 2)
					    ) {
                        addToMap(potentialColumns, cell.getXCoord(), 5);
                        Console.WriteLine("3LongVerticalBlock: Added column " + cell.getXCoord() + " with score 5 to potentialColumns");
                    }
                }
			}
		}

		public void add4LongVertical() {
			foreach (Cell cell in cells) {
				if (cell.getYCoord() > 2) {
                    //============
                    // ai scoring
                    //============
                    if (
						startState(cell, 2) &&
						matchesState(cell, 2, 0, 1) &&
						matchesState(cell, 2, 0, 2) &&
						matchesState(cell, 0, 0, 3)
					) {
						addToMap(potentialColumns, cell.getXCoord(), 1000);
						Console.WriteLine("4LongVertical: Added column " + cell.getXCoord() + " with score 1000 to potentialColumns");
					}
                    //====================
                    // ai blocking player
                    //====================
                    if (
					    startState(cell, 1) &&
					    matchesState(cell, 1, 0, 1) &&
					    matchesState(cell, 1, 0, 2) &&
					    matchesState(cell, 0, 0, 3)
					) {
                        addToMap(potentialColumns, cell.getXCoord(), 50);
                        Console.WriteLine("4LongVerticalBlock: Added column " + cell.getXCoord() + " with score 50 to potentialColumns");
                    }
                }
			}
		}

		public void add4LongHorizontal() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
                //============
                // ai scoring
                //============
                //checks going right
                if (x < 4 && startState(cell, 2)) {
                    if (matchesState(cell, 2, 1, 0) && matchesState(cell, 2, 2, 0) && matchesState(cell, 0, 3, 0) && checkPlatform(cell, 3, -1)) {
                        addToMap(potentialColumns, (x + 3), 1000);
                        Console.WriteLine("4LongRightEnd: Added column " + (x + 3) + " with score 1000 to potentialColumns");
                    }
                }
                //checks going left
                if (x > 2 && startState(cell, 2)) {
                    if (matchesState(cell, 2, -1, 0) && matchesState(cell, 2, -2, 0) && matchesState(cell, 0, -3, 0) && checkPlatform(cell, -3, -1)) {
                        addToMap(potentialColumns, (x - 3), 1000);
                        Console.WriteLine("4LongLeftEnd: Added column " + (x - 3) + " with score 1000 to potentialColumns");
                    }
                }
                //X = chip, 0 = empty
                //X0XX
                if (x > 0 && x < 5 && startState(cell, 0)) {
                    //checks chip to left, chip to right, chip 2 to the right
                    if (matchesState(cell, 2, -1, 0) && matchesState(cell, 2, 1, 0) && matchesState(cell, 2, 2, 0) && checkPlatform(cell, 0, -1)) {
                        addToMap(potentialColumns, x, 1000);
                        Console.WriteLine("4LongX0XX: Added column " + x + " with score 1000 to potentialColumns");
                    }
                }
                //XX0X
                if (x > 1 && x < 6 && startState(cell, 0)) {
                    //checks chip to right, chip to left, chip 2 to the left
                    if (matchesState(cell, 2, 1, 0) && matchesState(cell, 2, -1, 0) && matchesState(cell, 2, -2, 0) && checkPlatform(cell, 0, -1)) {
                        addToMap(potentialColumns, x, 1000);
                        Console.WriteLine("4LongXX0X: Added column " + x + " with score 1000 to potentialColumns");
                    }
                }
                //====================
                // ai blocking player
                //====================
                //checks going right
                if (x < 4 && startState(cell, 1)) {
                    if (matchesState(cell, 1, 1, 0) && matchesState(cell, 1, 2, 0) && matchesState(cell, 0, 3, 0) && checkPlatform(cell, 3, -1)) {
                        addToMap(potentialColumns, (x + 3), 50);
                        Console.WriteLine("4LongRightEndBlock: Added column " + (x + 3) + " with score 50 to potentialColumns");
                    }
                }
                //checks going left
                if (x > 2 && startState(cell, 1)) {
                    if (matchesState(cell, 1, -1, 0) && matchesState(cell, 1, -2, 0) && matchesState(cell, 0, -3, 0) && checkPlatform(cell, -3, -1)) {
                        addToMap(potentialColumns, (x - 3), 50);
                        Console.WriteLine("4LongLeftEndBlock: Added column " + (x - 3) + " with score 50 to potentialColumns");
                    }
                }
				//X = chip, 0 = empty
				//X0XX
				if (x > 0 && x < 5 && startState(cell, 0)) {
					//checks chip to left, chip to right, chip 2 to the right
					if (matchesState(cell, 1, -1, 0) && matchesState(cell, 1, 1, 0) && matchesState(cell, 1, 2, 0) && checkPlatform(cell, 0, -1)) {
                        addToMap(potentialColumns, x, 50);
                        Console.WriteLine("4LongX0XXBlock: Added column " + x + " with score 50 to potentialColumns");
                    }
				}
				//XX0X
				if (x > 1 && x < 6 && startState(cell, 0)) {
					//checks chip to right, chip to left, chip 2 to the left
					if (matchesState(cell, 1, 1, 0) && matchesState(cell, 1, -1, 0) && matchesState(cell, 1, -2, 0) && checkPlatform(cell, 0, -1)) {
                        addToMap(potentialColumns, x, 50);
                        Console.WriteLine("4LongXX0XBlock: Added column " + x + " with score 50 to potentialColumns");
                    }
				}

            }
		}

		public void add3LongHorizontal() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				//============
				// ai scoring
				//============
				//checks going right
				if (x < 5 && startState(cell, 2)) {
                    if (matchesState(cell, 2, 1, 0) && matchesState(cell, 0, 2, 0) && checkPlatform(cell, 2, -1)) {
                        addToMap(potentialColumns, (x + 2), 10);
                        Console.WriteLine("3LongRightEnd: Added column " + (x + 2) + " with score 10 to potentialColumns");
                    }
                }
				//checks going left
				if (x > 1 && startState(cell, 2)) {
					if (matchesState(cell, 2, -1, 0) && matchesState(cell, 0, -2, 0) && checkPlatform(cell, -2, -1)) {
						addToMap(potentialColumns, (x - 2), 10);
						Console.WriteLine("3LongLeftEnd: Added column " + (x - 2) + " with score 10 to potentialColumns");
					}
				}
                //X = chip, 0 = empty
                //X0X
                if (x > 0 && x < 6 && startState(cell, 0)) {
                    //checks chip to left, chip to right
                    if (matchesState(cell, 2, -1, 0) && matchesState(cell, 2, 1, 0) && checkPlatform(cell, 0, -1)) {
                        addToMap(potentialColumns, x, 10);
                        Console.WriteLine("3LongX0X: Added column " + x + " with score 10 to potentialColumns");
                    }
                }
                //====================
                // ai blocking player
                //====================
                if (x < 5 && startState(cell, 1)) {
                    if (matchesState(cell, 1, 1, 0) && matchesState(cell, 0, 2, 0) && checkPlatform(cell, 2, -1)) {
                        addToMap(potentialColumns, (x + 2), 5);
                        Console.WriteLine("3LongRightEndBlock: Added column " + (x + 2) + " with score 5 to potentialColumns");
                    }
                }
                //checks going left
                if (x > 1 && startState(cell, 1)) {
                    if (matchesState(cell, 1, -1, 0) && matchesState(cell, 0, -2, 0) && checkPlatform(cell, -2, -1)) {
                        addToMap(potentialColumns, (x - 2), 5);
                        Console.WriteLine("3LongLeftEndBlock: Added column " + (x - 2) + " with score 5 to potentialColumns");
                    }
                }
				//X = chip, 0 = empty
				//X0X
				if (x > 0 && x < 6 && startState(cell, 0)) {
					//checks chip to left, chip to right
					if (matchesState(cell, 1, -1, 0) && matchesState(cell, 1, 1, 0) && checkPlatform(cell, 0, -1)) {
                        addToMap(potentialColumns, x, 5);
                        Console.WriteLine("3LongX0XBlock: Added column " + x + " with score 5 to potentialColumns");
                    }
				}
            }
		}

		public void add2LongHorizontal() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				//checks going right
                if (x < 6) {
                    if (
                        startState(cell, 2) &&
                        matchesState(cell, 0, 1, 0) &&
                        checkPlatform(cell, 1, -1)
                        ) {
                        addToMap(potentialColumns, (x + 1), 1);
                        Console.WriteLine("2LongRightEnd: Added column " + (x + 1) + " with score 1 to potentialColumns");
                    }
                }
				//checks going left
                if (x > 0) {
                    if (
                        startState(cell, 2) &&
                        matchesState(cell, 0, -1, 0) &&
                        checkPlatform(cell, -1, -1)
                        ) {
                        addToMap(potentialColumns, (x - 1), 1);
                        Console.WriteLine("2LongLeftEnd: Added column " + (x - 1) + " with score 1 to potentialColumns");
                    }
                }
            }
		}

		public void add2LongDiagonal() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				int y = cell.getYCoord();
                //downright
				if (x < 6 && y < 5 && startState(cell, 2) && matchesState(cell, 0, 1, -1) && checkPlatform(cell, 1, -2)) {
                    addToMap(potentialColumns, (x + 1), 1);
                    Console.WriteLine("2LongDownRight: Added column " + (x + 1) + " with score 1 to potentialColumns");
                }
                //downleft
                if (x > 0 && y < 5 && startState(cell, 2) && matchesState(cell, 0, -1, -1) && checkPlatform(cell, -1, -2)) {
                    addToMap(potentialColumns, (x - 1), 1);
                    Console.WriteLine("2LongDownLeft: Added column " + (x - 1) + " with score 1 to potentialColumns");
                }
                //upright
                if (x < 6 && y > 0 && startState(cell, 2) && matchesState(cell, 0, 1, 1) && checkPlatform(cell, 1, -1)) {
                    addToMap(potentialColumns, (x + 1), 1);
                    Console.WriteLine("2LongUpRight: Added column " + (x + 1) + " with score 1 to potentialColumns");
                }
                //upleft
                if (x > 0 && y > 0 && startState(cell, 2) && matchesState(cell, 0, -1, 1) && checkPlatform(cell, -1, -1)) {
                    addToMap(potentialColumns, (x - 1), 1);
                    Console.WriteLine("2LongUpLeft: Added column " + (x - 1) + " with score 1 to potentialColumns");
                }
            }
		}

		public void add3LongDiagonal() {
			foreach (Cell cell in cells) {
				int x = cell.getXCoord();
				int y = cell.getYCoord();
                //====================
                // ai scoring
                //====================
                //downright
                if (y < 4 && x < 5 && startState(cell, 2) && matchesState(cell, 2, 1, -1) && matchesState(cell, 0, 2, -2) && checkPlatform(cell, 2, -3)) {
                    addToMap(potentialColumns, (x + 2), 10);
                    Console.WriteLine("3LongDownRight: Added column " + (x + 2) + " with score 10 to potentialColumns");
                }
                //downleft
                if (y < 4 && x > 1 && startState(cell, 2) && matchesState(cell, 2, -1, -1) && matchesState(cell, 0, -2, -2) && checkPlatform(cell, -2, -3)) {
                    addToMap(potentialColumns, (x - 2), 10);
                    Console.WriteLine("3LongDownLeft: Added column " + (x - 2) + " with score 10 to potentialColumns");
                }
                //upright
                if (y > 1 && x < 5 && startState(cell, 2) && matchesState(cell, 2, 1, 1) && matchesState(cell, 0, 2, 2) && checkPlatform(cell, 2, 1)) {
                    addToMap(potentialColumns, (x + 2), 10);
                    Console.WriteLine("3LongUpRight: Added column " + (x + 2) + " with score 10 to potentialColumns");
                }
                //upleft
                if (y > 1 && x > 1 && startState(cell, 2) && matchesState(cell, 2, -1, 1) && matchesState(cell, 0, -2, 2) && checkPlatform(cell, -2, 1)) {
                    addToMap(potentialColumns, (x - 2), 10);
                    Console.WriteLine("3LongUpLeft: Added column " + (x - 2) + " with score 10 to potentialColumns");
                }
                //posX0X
                if (y > 0 && y < 5 && x < 6 && x > 0 && startState(cell, 0) && matchesState(cell, 2, -1, -1) && matchesState(cell, 2, 1, 1) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 10);
                    Console.WriteLine("3LongPosX0X: Added column " + x + " with score 10 to potentialColumns");
                }
                //negX0X
                if (y > 0 && y < 5 && x < 6 && x > 0 && startState(cell, 0) && matchesState(cell, 2, -1, 1) && matchesState(cell, 2, 1, -1) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 10);
                    Console.WriteLine("3LongNegX0X: Added column " + x + " with score 10 to potentialColumns");
                }
                //====================
                // ai blocking player
                //====================
                //downright
                if (y < 4 && x < 5 && startState(cell, 1) && matchesState(cell, 1, 1, -1) && matchesState(cell, 0, 2, -2) && checkPlatform(cell, 2, -3)) {
                    addToMap(potentialColumns, (x + 2), 5);
                    Console.WriteLine("3LongDownRightBlock: Added column " + (x + 2) + " with score 5 to potentialColumns");
                }
                //downleft
                if (y < 4 && x > 1 && startState(cell, 1) && matchesState(cell, 1, -1, -1) && matchesState(cell, 0, -2, -2) && checkPlatform(cell, -2, -3)) {
                    addToMap(potentialColumns, (x - 2), 5);
                    Console.WriteLine("3LongDownLeftBlock: Added column " + (x - 2) + " with score 5 to potentialColumns");
                }
                //upright
                if (y > 1 && x < 5 && startState(cell, 1) && matchesState(cell, 1, 1, 1) && matchesState(cell, 0, 2, 2) && checkPlatform(cell, 2, 1)) {
                    addToMap(potentialColumns, (x + 2), 5);
                    Console.WriteLine("3LongUpRightBlock: Added column " + (x + 2) + " with score 5 to potentialColumns");
                }
                //upleft
                if (y > 1 && x > 1 && startState(cell, 1) && matchesState(cell, 1, -1, 1) && matchesState(cell, 0, -2, 2) && checkPlatform(cell, -2, 1)) {
                    addToMap(potentialColumns, (x - 2), 5);
                    Console.WriteLine("3LongUpLeftBlock: Added column " + (x - 2) + " with score 5 to potentialColumns");
                }
                //posX0X
                if (y > 0 && y < 5 && x < 6 && x > 0 && startState(cell, 0) && matchesState(cell, 1, -1, -1) && matchesState(cell, 1, 1, 1) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 5);
                    Console.WriteLine("3LongPosX0XBlock: Added column " + x + " with score 5 to potentialColumns");
                }
                //negX0X
                if (y > 0 && y < 5 && x < 6 && x > 0 && startState(cell, 0) && matchesState(cell, 1, -1, 1) && matchesState(cell, 1, 1, -1) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 5);
                    Console.WriteLine("3LongNegX0XBlock: Added column " + x + " with score 5 to potentialColumns");
                }
            }
        }

		public void add4LongDiagonal() {
            foreach (Cell cell in cells) {
                int x = cell.getXCoord();
                int y = cell.getYCoord();
                //====================
                // ai scoring
                //====================
                //downright
                if (y < 3 && x < 4 && startState(cell, 2) && matchesState(cell, 2, 1, -1) && matchesState(cell, 2, 2, -2) && matchesState(cell, 0, 3, -3) && checkPlatform(cell, 3, -4)) {
					addToMap(potentialColumns, (x + 3), 1000);
                    Console.WriteLine("4LongDownRight: Added column " + (x+3) + " with score 1000 to potentialColumns");
                }
                //downleft
                if (y < 3 && x > 2 && startState(cell, 2) && matchesState(cell, 2, -1, -1) && matchesState(cell, 2, -2, -2) && matchesState(cell, 0, -3, -3) && checkPlatform(cell, -3, -4)) {
                    addToMap(potentialColumns, (x - 3), 1000);
                    Console.WriteLine("4LongDownLeft: Added column " + (x - 3) + " with score 1000 to potentialColumns");
                }
                //upright
                if (y > 2 && x < 4 && startState(cell, 2) && matchesState(cell, 2, 1, 1) && matchesState(cell, 2, 2, 2) && matchesState(cell, 0, 3, 3) && checkPlatform(cell, 3, 2)) {
                    addToMap(potentialColumns, (x + 3), 1000);
                    Console.WriteLine("4LongUpRight: Added column " + (x + 3) + " with score 1000 to potentialColumns");
                }
                //upleft
                if (y > 2 && x > 2 && startState(cell, 2) && matchesState(cell, 2, -1, 1) && matchesState(cell, 2, -2, 2) && matchesState(cell, 0, -3, 3) && checkPlatform(cell, -3, 2)) {
                    addToMap(potentialColumns, (x - 3), 1000);
                    Console.WriteLine("4LongUpLeft: Added column " + (x - 3) + " with score 1000 to potentialColumns");
                }
                //posX0XX
                if (y > 1 && y < 5 && x > 0 && x < 5 && startState(cell, 0) && matchesState(cell, 2, -1, -1) && matchesState(cell, 2, 1, 1) && matchesState(cell, 2, 2, 2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 1000);
                    Console.WriteLine("4LongPosX0XX: Added column " + x + " with score 1000 to potentialColumns");
                }
                //posXX0X
                if (y > 0 && y < 4 && x > 1 && x < 6 && startState(cell, 0) && matchesState(cell, 2, 1, 1) && matchesState(cell, 2, -1, -1) && matchesState(cell, 2, -2, -2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 1000);
                    Console.WriteLine("4LongPosXX0X: Added column " + x + " with score 1000 to potentialColumns");
                }
                //negX0XX
                if (y > 0 && y < 4 && x > 0 && x < 5 && startState(cell, 0) && matchesState(cell, 2, -1, 1) && matchesState(cell, 2, 1, -1) && matchesState(cell, 2, 2, -2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 1000);
                    Console.WriteLine("4LongNegX0XX: Added column " + x + " with score 1000 to potentialColumns");
                }
                //negXX0X
                if (y > 1 && y < 5 && x > 1 && x < 6 && startState(cell, 0) && matchesState(cell, 2, 1, -1) && matchesState(cell, 2, -1, 1) && matchesState(cell, 2, -2, 2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 1000);
                    Console.WriteLine("4LongNegXX0X: Added column " + x + " with score 1000 to potentialColumns");
                }
                //====================
                // ai blocking player
                //====================
                //downright
                if (y < 3 && x < 4 && startState(cell, 1) && matchesState(cell, 1, 1, -1) && matchesState(cell, 1, 2, -2) && matchesState(cell, 0, 3, -3) && checkPlatform(cell, 3, -4)) {
                    addToMap(potentialColumns, (x + 3), 50);
                    Console.WriteLine("4LongDownRightBlock: Added column " + (x + 3) + " with score 50 to potentialColumns");
                }
                //downleft
                if (y < 3 && x > 2 && startState(cell, 1) && matchesState(cell, 1, -1, -1) && matchesState(cell, 1, -2, -2) && matchesState(cell, 0, -3, -3) && checkPlatform(cell, -3, -4)) {
                    addToMap(potentialColumns, (x - 3), 50);
                    Console.WriteLine("4LongDownLeftBlock: Added column " + (x - 3) + " with score 50 to potentialColumns");
                }
                //upright
                if (y > 2 && x < 4 && startState(cell, 1) && matchesState(cell, 1, 1, 1) && matchesState(cell, 1, 2, 2) && matchesState(cell, 0, 3, 3) && checkPlatform(cell, 3, 2)) {
                    addToMap(potentialColumns, (x + 3), 50);
                    Console.WriteLine("4LongUpRightBlock: Added column " + (x + 3) + " with score 50 to potentialColumns");
                }
                //upleft
                if (y > 2 && x > 2 && startState(cell, 1) && matchesState(cell, 1, -1, 1) && matchesState(cell, 1, -2, 2) && matchesState(cell, 0, -3, 3) && checkPlatform(cell, -3, 2)) {
                    addToMap(potentialColumns, (x - 3), 50);
                    Console.WriteLine("4LongUpLeftBlock: Added column " + (x - 3) + " with score 50 to potentialColumns");
                }
                //posX0XX
                if (y > 1 && y < 5 && x > 0 && x < 5 && startState(cell, 0) && matchesState(cell, 1, -1, -1) && matchesState(cell, 1, 1, 1) && matchesState(cell, 1, 2, 2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 50);
                    Console.WriteLine("4LongPosX0XXBlock: Added column " + x + " with score 50 to potentialColumns");
                }
                //posXX0X
                if (y > 0 && y < 4 && x > 1 && x < 6 && startState(cell, 0) && matchesState(cell, 1, 1, 1) && matchesState(cell, 1, -1, -1) && matchesState(cell, 1, -2, -2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 50);
                    Console.WriteLine("4LongPosXX0XBlock: Added column " + x + " with score 50 to potentialColumns");
                }
                //negX0XX
                if (y > 0 && y < 4 && x > 0 && x < 5 && startState(cell, 0) && matchesState(cell, 1, -1, 1) && matchesState(cell, 1, 1, -1) && matchesState(cell, 1, 2, -2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 50);
                    Console.WriteLine("4LongNegX0XXBlock: Added column " + x + " with score 50 to potentialColumns");
                }
                //negXX0X
                if (y > 1 && y < 5 && x > 1 && x < 6 && startState(cell, 0) && matchesState(cell, 1, 1, -1) && matchesState(cell, 1, -1, 1) && matchesState(cell, 1, -2, 2) && checkPlatform(cell, 0, -1)) {
                    addToMap(potentialColumns, x, 50);
                    Console.WriteLine("4LongNegXX0XBlock: Added column " + x + " with score 50 to potentialColumns");
                }
            }
        }

		// Helper functions

		public bool checkPlatform(Cell cell, int xOffset, int yOffset) {
			// if the cell is in the bottom row, done checking
			// otherwise, check to see if there is a chip to place on
            if ((cell.getYCoord() - yOffset) > 5) {
                Console.WriteLine("out of bounds error\n");
                return true;
            }
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