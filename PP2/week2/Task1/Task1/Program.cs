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
			string t = Console.ReadLine();  //way to file
			string line; //created string
			bool k = true; //check palindrom or not
			StreamReader file = new StreamReader(t); //Read our file
			line = file.ReadLine(); //line equal to text in file
			for(int i = 0; i < line.Length; ++i) //check palindrome line or not with cycle
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
