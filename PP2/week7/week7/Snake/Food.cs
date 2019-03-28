using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Food : GameObj
	{
		public Food() : base()
		{

		}
		public Food(char sign) : base(sign)
		{
			
		}
		public void Generate(int x, int y)
		{
			body.Clear();
			body.Add(new Point { X = x, Y = y});
		}
	}
}
