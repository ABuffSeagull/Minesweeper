﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using Buff;

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
		Console.SetCursorPosition(0, 0);
		var key = Console.ReadKey(false);
		while (true) {
			switch (key.Key) {
				case ConsoleKey.RightArrow:
					Console.CursorLeft += 3;
					break;
				case ConsoleKey.LeftArrow:
					Console.CursorLeft -= 3;
					break;
				case ConsoleKey.UpArrow:
					Console.CursorTop -= 1;
					break;
				case ConsoleKey.DownArrow:
					Console.CursorTop += 1;
					break;
				case ConsoleKey.Spacebar:
					game.RevealSpace(Console.CursorLeft / 3, Console.CursorTop);
					break;
			}
			var x = Console.CursorLeft;
			var y = Console.CursorTop;
			game.DrawBoard();
			Console.SetCursorPosition(x, y);
			key = Console.ReadKey(false);
		}

	}
}
}
