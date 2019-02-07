using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{
		static void Main(string[] args)
		{
			string t = Console.ReadLine();
			string line;
			bool k = true;
			System.IO.StreamReader file = new System.IO.StreamReader(t);
			line = file.ReadLine();
			for(int i = 0; i < line.Length; ++i)
			{
				if(line[i] != line[line.Length - 1 - i])
				{
					k = false;
					break;
				}
			}
			if(k == true)
			{
				Console.WriteLine("YES");
			}
			else
			{
				Console.WriteLine("NO");
			}
		}
	}
}
