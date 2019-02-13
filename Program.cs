﻿using System;
using Buff;

struct DifficultyLevels {
	public const double Easy = 0.10;
	public const double Medium = 0.15;
	public const double Hard = 0.20;
}

namespace Minesweeper {
class Program {

	static void
	Main(string[] args) {
		Console.Write("What board size do you want? ");
		if (!Int32.TryParse(Console.ReadLine(), out int boardSize)) {
			Console.WriteLine("You should've given me a number, ya dingus");
			Environment.Exit(1);
		}
		var game = new Game(boardSize);
		game.DrawBoard();
	}
}
}
