using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	class Interface
	{
		public int Diff
		{
			get;
			set;
		}
		public string[] Options
		{
			get;	 
			set;
		}

		public int SelectedIndex
		{
			get;
			set;
		}
		public void Draw()
		{
			Console.ResetColor();
			Console.Clear();
			if(SelectedIndex > 1)
			{
				SelectedIndex = 0;
			}
			else if(SelectedIndex < 0)
			{
				SelectedIndex = 1;
			}
			for(int i = 0; i < Options.Length; ++i)
			{
				Console.SetCursorPosition(20, 10 + i);
				Console.BackgroundColor = ConsoleColor.Black;
				if (i == SelectedIndex)
				{
					Console.BackgroundColor = ConsoleColor.Blue;
					Console.WriteLine(Options[i]);
				}
				else
				{
					Console.WriteLine(Options[i]);
				}
			}
		}
		public void Option()
		{
			Console.ResetColor();
			Console.Clear();
			if(Diff > 4)
			{
				Diff = 4;
			}
			else if(Diff < 0)
			{
				Diff = 0;
			}
			Console.SetCursorPosition(22, 9);
			Console.WriteLine("Select difficult: ");
			for(int i = 0; i <= Diff; ++i)
			{
				Console.SetCursorPosition(20+i*4, 10);
				Console.Write("  +  ");
			}
			for (int i = Diff + 1; i < 5; ++i)
			{
				Console.SetCursorPosition(20+i*4, 10);
				Console.Write("  -  ");
			}
			Console.WriteLine();
		}
	}
}
