﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class GameObj
	{
		public List<Point> body = new List<Point>();
		protected char sign;

		public GameObj()
		{

		}	
		public GameObj(char sign)
		{
			this.sign = sign;
		}

		public void Clear()
		{
			for(int i = 0; i < body.Count; ++i)
			{
				Console.SetCursorPosition(body[i].X, body[i].Y);
				Console.Write(' ');
			}
		}

		public void Draw()
		{
			for(int i = 0; i < body.Count; ++i)
			{
				Console.SetCursorPosition(body[i].X, body[i].Y);
				Console.Write(sign);
			}
		}
	}
}
