using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{
		public static void LvLUp(int lvl) //print " "
		{
			for (int i = 0; i <= lvl; ++i)
			{
				Console.Write(" ");
			}
		}
		public static void DirWr(DirectoryInfo dirInfo, int lvl) //create function
		{
			Console.ForegroundColor = ConsoleColor.Yellow;//all text is yellow(just fun)
			foreach(var i in dirInfo.GetFiles()) //print all files in directory with " "
			{
				LvLUp(lvl);//print " "
				Console.WriteLine(i.Name);
			}
			foreach(var i in dirInfo.GetDirectories())//print all directories
			{
				LvLUp(lvl);//print" "
				Console.WriteLine(i.Name);
				DirWr(i, lvl + 3);//print all files and directories in directory with lvl + 3(recursion)
			}
		}
		static void Main(string[] args)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(Console.ReadLine());//Read way to our directory
			Console.WriteLine(dirInfo.Name);//Write Directory Name
			DirWr(dirInfo, 0);
		}
	}
}