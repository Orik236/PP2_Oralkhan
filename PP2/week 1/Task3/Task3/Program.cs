using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			string size = Console.ReadLine();//created number string
			int lenght = int.Parse(size);//converted string to int
			string a = Console.ReadLine();//created string numbers. Ex: 1 2 3 4 5
			string[] a2 = Regex.Split(a, " ");//created string array
			int[] b = new int[a2.Length * 2];//created second array type int
			int cnt = 0;//created counter
			foreach(var i in a2)//created cycle from first element in a2 to last element
			{
				int x = int.Parse(i);//converted string to int
				b[cnt] = x;//input x in b
				cnt++;//increased counter
				b[cnt] = x;//input x in b again
				cnt++;//increased counter
			}
			for(int i = 0; i < cnt; ++i)//created cyccle
			{
				Console.Write(b[i] + " ");//print b[i] and " " 
			}
		}
	}
}
