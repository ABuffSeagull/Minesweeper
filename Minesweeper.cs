using System;

struct Space {
	public bool isHidden;
	public int type; // -1 for Bombs, everything else
}

namespace Buff {
class Game {
	private Space[,] board;
	private int boardSize;
	public Game(int boardSize) {
		this.boardSize = boardSize;
		board = new Space[boardSize, boardSize];
		var rng = new Random();
		var mineTotal = (uint)(boardSize * boardSize * DifficultyLevels.Easy);
		for (uint i = 0; i < mineTotal; i++) {
			var x = rng.Next(boardSize);
			var y = rng.Next(boardSize);
			if (board[x, y].type == -1) {
				i--;
				continue;
			}
			board[x, y].type = -1;
		}
	}

	public void DrawBoard() {
		Console.Clear();
		for (int x = 0; x < boardSize; x++) {
			for (int y = 0; y < boardSize; y++) {
				Console.Write(board[x, y].type == -1 ? "💣 " : "📦 ");
			}
			Console.WriteLine();
		}
	}
}
}
