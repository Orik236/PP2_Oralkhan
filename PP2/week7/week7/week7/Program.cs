using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace week7
{
	class Program
	{
		static void Main(string[] args)
		{
			ThreadStart ts = new ThreadStart(F1);
			Thread[] arr = new Thread[3];
			for(int i = 0; i < arr.Length; ++i)
			{
				arr[i] = new Thread(ts);
				arr[i].Start();
			}

		}
		static void F1()
		{
			Thread.CurrentThread.Name = Console.ReadLine();
			Console.WriteLine(Thread.CurrentThread.Name);
		}
	}
}
