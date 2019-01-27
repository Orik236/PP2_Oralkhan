using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{
		static void Main(string[] args)
		{
			string a = Console.ReadLine(); //Created string number which is the size of the array
			int a2 = int.Parse(a); // Converted string number to int
			int[] b = new int[a2]; // created first array b
			int[] c = new int[a2 * 2]; //created second array c where we stored elements of the first array twice
			string x; // created x
			int k = 0; // created counter
			for (int i = 0; i < b.Length; ++i) // created cycle "for" from 0 to size b
			{
				x = Console.ReadLine(); // created string element x
				int x2 = int.Parse(x); // converted string element x to int element x2
				b[i] = x2; // Element in array with i index equal to x2
				for (int j = 0; j < 2; ++j) //Created second cycle "for" to add element from first array b in second array c
				{
					c[k] = b[i]; // element in second array c with k index equal to element first arrayt with index i
					k++; // Counter increased by 1
				}
			}
			for (int i = 0; i < a2 * 2; ++i) // Created cycle "for" to through all the elements of the array c
			{
				Console.Write(c[i]); //Print element of the array c with i index
				Console.Write(" "); //Print space between answers
			}
		}
	}
}
