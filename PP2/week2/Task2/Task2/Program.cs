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
			string s = ""; //Create null string
			string t = Console.ReadLine(); //Read way to file
			StreamReader file = new StreamReader(t); //Read text in file
			string line = file.ReadLine(); //line equal text in file
			string[] arr = Regex.Split(line, " "); //Create string array without " "
			int x; 
			foreach(string i in arr) //Check all number in array palindrome or not
			{
				x = int.Parse(i); //Create string to int
				for(int z = 2; z <= Math.Sqrt(x); ++z) //Check palindrome or not
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
			file.Close(); //Close file
			string t2 = Console.ReadLine(); //Read way to textfile where we input our numbers
			File.WriteAllText(t2, s); //write in second file prime numbers
		}
	}
}
