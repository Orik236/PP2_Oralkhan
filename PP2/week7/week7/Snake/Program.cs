using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	enum Menu
	{
		main,
		Option
	}

	class Program
	{
		static void Main(string[] args)
		{
			string[] Option = new string[2];
			Option[0] ="Start";
			Option[1] = "Difficult";
			GameState gameState = new GameState();
			Interface menu = new Interface {
			Diff = 0,
			Options = Option,
			SelectedIndex = 0};
			Menu m = Menu.main;
			bool res = false;
			int diff = 0;
			while (!res)
			{
				if (m == Menu.main)
				{
					menu.Draw();
				}
				else
				{
					menu.Option();
				}
				ConsoleKeyInfo Key = Console.ReadKey();
				switch (Key.Key)
				{
					case ConsoleKey.UpArrow:
						menu.SelectedIndex++;
						break;
					case ConsoleKey.DownArrow:
						menu.SelectedIndex--;
						break;
					case ConsoleKey.RightArrow:
						if(menu.SelectedIndex == 1)
						{
							menu.Diff++;
						}
						break;
					case ConsoleKey.LeftArrow:
						if(menu.SelectedIndex  == 1)
						{
							menu.Diff--;
						}
						break;
					case ConsoleKey.Enter:
						if(menu.SelectedIndex == 1)
						{
							m = Menu.Option;
							Console.WriteLine("Press ESC");
						}
						else
						{
							m = Menu.main;
							res = true;
						}
						break;
					case ConsoleKey.Escape:
						if(menu.SelectedIndex  == 1)
						{
							diff = menu.Diff;
							m = Menu.main;
						}
						else
						{
							Environment.Exit(0);
						}
						break;
				}
			}
			Console.Clear();
			gameState.AskName();
			gameState.Run(diff);
			gameState.Generate();
			gameState.Score(0);
			while (true)
			{
				ConsoleKeyInfo consoleKey = Console.ReadKey();
				switch (consoleKey.Key)
				{
					case ConsoleKey.F4:
						gameState = gameState.Load();
						break;
					case ConsoleKey.F5:
						gameState.Save();
						break;
					default:
						gameState.PressedKey(consoleKey);
						break;
				}
			}
		}
	}
}
