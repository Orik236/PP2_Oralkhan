using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Wall : GameObj
	{
		public Wall() : base()
		{

		}

		public Wall(char sign) : base(sign)
		{
			LoadLevel(0);
		}
		public void LoadLevel(int level)
		{
			string name = string.Format("Levels/level{0}.txt", level);
			StreamReader sr = new StreamReader(name);

			int r = 0;
			while (!sr.EndOfStream)
			{
				string line = sr.ReadLine();
				for (int c = 0; c < line.Length; ++c)
				{
					if(line[c] == '#')
					{
						body.Add(new Point { X = c, Y = r });
					}
				}
				r++;
			}
			sr.Close();
		}
	}
}
