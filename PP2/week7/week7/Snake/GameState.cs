using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;

namespace Snake
{
	public class GameState
	{
		public Worm w = new Worm('=');
		public Wall b = new Wall('#');
		public int score = 0;
		public Food f = new Food('@');
		Timer timer = new Timer();
		XmlSerializer xs = new XmlSerializer(typeof(GameState));
		public int x;
		public int y;
		public int diff;
		public GameState()
		{
			Console.SetWindowSize(80, 40);
			Console.SetBufferSize(80, 40);
			Console.CursorVisible = false;
		}


		public void Save()
		{
			using (FileStream fs = new FileStream("save.xml", FileMode.Create, FileAccess.Write))
			{
				xs.Serialize(fs, this);
			}
		}
		public GameState Load()
		{
			Console.Clear();
			GameState res = null;
			using (FileStream fs = new FileStream("save.xml", FileMode.Open, FileAccess.Read))
			{
				res = xs.Deserialize(fs) as GameState;
			}
			return res;
		}


		public void Run(int diff)
		{
			this.diff = diff;
			this.diff += score / 4;
			timer.Elapsed += Timer_Elapsed;
			timer.Interval = 400 - this.diff * 85;
			timer.Start();

			Console.ForegroundColor = ConsoleColor.Green;
			f.Draw();
			Console.ResetColor();
			b.Draw();
		}

		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			CheckGameOver();
			CheckFood();
			Console.ForegroundColor = ConsoleColor.Green;
			f.Draw();
			w.Move();
			Console.ForegroundColor = ConsoleColor.Yellow;
			w.Draw();
		}

		public void AskName()
		{
			Console.Write("Your name is : ");
			Console.ReadLine();
			Console.Clear();
		}

		public void Generate()
		{
			bool res = false;
			while (!res)
			{
				Random random = new Random(DateTime.Now.Second);
				x = random.Next(1, 79);
				y = random.Next(3, 39);
				for (int i = 0; i < b.body.Count; ++i)
				{
					if(x == b.body[i].X && y == b.body[i].Y)
					{
						res = true;
						break;
					}
				}
				res = !res;
			}
			f.Generate(x, y);
		}
		public void CheckFood()
		{
			if (w.CheckCollision(f.body[0]))
			{
				w.Eat(f.body[0]);
				Generate();
				score++;
				Score(score);
			}
		}

		public void GameOver()
		{
			Console.Clear();
			Console.SetCursorPosition(15, 20);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("Game Over   Your Score: " + score);
			Environment.Exit(0);
		}
		public void CheckGameOver()
		{
			if (w.CheckOver())
			{
				GameOver();
			}
			if (CheckWall())
			{
				GameOver();
			}
		}
		public void PressedKey(ConsoleKeyInfo consoleKey)
		{
			switch (consoleKey.Key)
			{
				case ConsoleKey.UpArrow:
					w.Dx = 0;
					w.Dy = -1;
					break;
				case ConsoleKey.DownArrow:
					w.Dx = 0;
					w.Dy = 1;
					break;
				case ConsoleKey.LeftArrow:
					w.Dx = -1;
					w.Dy = 0;
					
					break;
				case ConsoleKey.RightArrow:
					w.Dx = 1;
					w.Dy = 0;
					break;
				case ConsoleKey.Spacebar:
					timer.Enabled = !timer.Enabled;
					break;
				case ConsoleKey.Escape:
					Console.Write("Your score: " + score);
					Environment.Exit(0);
					break;
			}
			CheckGameOver();
			CheckFood();
		}
		public bool CheckWall()
		{
			bool res = false;
			for(int i = 0; i < b.body.Count; ++i)
			{
				if(b.body[i].X == w.body[0].X && b.body[i].Y == w.body[0].Y)
				{
					res = true;
					break;
				}
			}
			return res;
		}
		public void Score(int score)
		{
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Your Score: " + score);
		}
	}
}
