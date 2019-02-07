using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
	class Program
	{
		public static void LvLUp(int lvl)
		{
			for (int i = 0; i <= lvl; ++i)
			{
				Console.Write(" ");
			}
		}
		public static void DirWr(DirectoryInfo dirInfo, int lvl)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			foreach(var i in dirInfo.GetFiles())
			{
				LvLUp(lvl);
				Console.WriteLine(i.Name);
			}
			foreach(var i in dirInfo.GetDirectories())
			{
				LvLUp(lvl);
				Console.WriteLine(i.Name);
				DirWr(i, lvl + 3);
			}
		}
		static void Main(string[] args)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(Console.ReadLine());
			Console.WriteLine(dirInfo.Name);
			DirWr(dirInfo, 0);
		}
	}
}