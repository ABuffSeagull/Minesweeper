using System;
using System.Collections.Generic;

namespace Buff {
struct Space {
	public bool isRevealed;
	public int type; // -1 for Bombs, everything else
}

struct DifficultyLevels {
	public const double Easy = 0.10;
	public const double Medium = 0.15;
	public const double Hard = 0.20;
}

class Game {
	private Space[,] board;
	private int boardSize;
	private List<KeyValuePair<int, int>> searchList = new List<KeyValuePair<int, int>>();
	public Game(int boardSize) {
		this.boardSize = boardSize;
		board = new Space[boardSize, boardSize];
		var rng = new Random();
		var mineTotal = (uint)(boardSize * boardSize * DifficultyLevels.Easy);
		for (uint i = 0; i < mineTotal; i++) {
			var x = rng.Next(boardSize);
			var y = rng.Next(boardSize);
			if (board[y, x].type == -1) {
				i--;
				continue;
			}
			board[x, y].type = -1;
		}
		searchList.Add(new KeyValuePair<int, int>(-1, -1));
		searchList.Add(new KeyValuePair<int, int>(-1, 0));
		searchList.Add(new KeyValuePair<int, int>(-1, 1));
		searchList.Add(new KeyValuePair<int, int>(0, -1));
		searchList.Add(new KeyValuePair<int, int>(0, 1));
		searchList.Add(new KeyValuePair<int, int>(1, -1));
		searchList.Add(new KeyValuePair<int, int>(1, 0));
		searchList.Add(new KeyValuePair<int, int>(1, 1));

		for (int y = 0; y < boardSize; y++) {
			for (int x = 0; x < boardSize; x++) {
				if (board[y, x].type == -1) continue;
				int surrounding = 0;
				foreach (var delta in searchList) {
					if (x + delta.Key >= 0
					    && x + delta.Key < boardSize
					    && y + delta.Value >= 0
					    && y + delta.Value < boardSize) {
						surrounding += board[y + delta.Value, x + delta.Key].type == -1 ? 1 : 0;
					}
				}
				board[y, x].type = surrounding;
			}
		}
	}

	public void RevealSpace(int x, int y) {
		board[y, x].isRevealed = true;
		Console.CursorLeft -= 1;
	}

	public void DrawBoard() {
		Console.Clear();
		for (int y = 0; y < boardSize; y++) {
			for (int x = 0; x < boardSize; x++) {
				if (!board[y, x].isRevealed) {
					Console.Write("📦 ");
				} else {
					Console.Write(board[y, x].type == -1 ? "💣 " : $"{board[y,x].type}  ");
				}
			}
			Console.WriteLine();
		}
		// Console.WriteLine($"{Console.CursorLeft}, {Console.CursorTop}");
	}
}
}
