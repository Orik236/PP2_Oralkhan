using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2
{
	class Program
	{
		static void Main(string[] args)
		{
			string s = "";
			string t = Console.ReadLine();
			System.IO.StreamReader file = new System.IO.StreamReader(t);
			string line = file.ReadLine();
			string[] arr = Regex.Split(line, " ");
			int x;
			foreach(string i in arr)
			{
				x = int.Parse(i);
				for(int z = 2; z <= Math.Sqrt(x); ++z)
				{
					if(x % z == 0)
					{
						x = 0;
						break;
					}
				}
				if(x > 1)
				{
					s += i;
					s += " ";

				}
			}
			file.Close();
			string t2 = Console.ReadLine();
			System.IO.File.WriteAllText(t2, s);
		}
	}
}
