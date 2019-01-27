using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb1
{
	class Task1
	{
		static void Main(string[] args)
		{
			string a = Console.ReadLine(); //Created string number
			int a2 = int.Parse(a); //Converted string to int
			int[] b = new int[a2]; //Created massive
			int cnt = 0; //created cnt to count the number of prime numbers
			int[] b2 = new int[a2]; // created a massive to save all prime numbers
			for (int i = 0; i < b.Length; ++i) //with for we can "read" numbers in array
			{
				a = Console.ReadLine();
				int aa2 = int.Parse(a); //Converted string to int
				b[i] = aa2;
			}
			for (int i = 0; i < b.Length; ++i) //with for we found prime numbers in array(b)
			{
				for (int j = 2; j <= Math.Sqrt(b[i]); ++j) //we divide number by from j to sqrt number
				{
					if (b[i] % j == 0) //if number divided by j
					{
						b[i] = -1; // assign value
						break; //break for
					}
				}
				if (b[i] != -1 && b[i] > 1) //if number not equal to -1 and bigger than 1 we do next
				{
					b2[cnt] = b[i]; //we put prime number in second array
					cnt++; //we increased cnt
				}
			}
			for (int i = 0; i < cnt; ++i) // with for we print prime numbers
			{
				Console.Write(b2[i]);//print prime number
				Console.Write(" ");//we shared our numbers
			}
		}
	}
}
