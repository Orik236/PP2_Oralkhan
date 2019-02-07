using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LAb1
{
	class Task1
	{
		static void Main(string[] args)
		{
			string size = Console.ReadLine();//we created class string
			int lenght = int.Parse(size); // converte string 'size' to int
			string a = Console.ReadLine(); //created number type string. Ex: "1 2 3 4 5"
			string[] a2 = Regex.Split(a," "); //created string Array without " ". Ex: "12345"
			int[] b = new int[lenght]; //created int Array where we input prime numbers
			int cnt = 0; //created counter
			foreach (var i in a2) // created cycle from first element to last element in string array
			{
				int x = int.Parse(i);//converted string number to int
				for (int j = 2; j <= Math.Sqrt(x); ++j)//created cycle to check prime number or not
				{
					if(x % j == 0)//check divided number x by j or not
					{
						x = -1;//x equal to "-1"
						break;//finish cycle
					}
				}
				if(x != -1 && x > 1)//if x not equal to "-1" or x not less then 2
				{
					b[cnt] = x;//input x number in b
					cnt++;//increased counter
				}
			}
			for (int i = 0; i < cnt; ++i)//created cycle
			{
				Console.Write(b[i] + " ");//print number b[i] and " "
			}
		}
	}
}