using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
	class Program
	{
		static void Main(string[] args)
		{
			string n = Console.ReadLine();
			int nn = int.Parse(n);
			for (int i = 1; i <= nn; ++i)
			{
				for (int j = 0; j < i; ++j)
				{
					Console.Write("[*]");
				}
				Console.WriteLine();
			}
		}
	}
}
