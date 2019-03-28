using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
	class MyThread
	{
		ThreadStart ts = new ThreadStart(start);
		Thread threadField;
		public MyThread(string name)
		{
			threadField = new Thread(ts);
			threadField.Name = name;
		}

		public void startThread()
		{
			threadField.Start();
		}

		public static void start()
		{
			Console.WriteLine(Thread.CurrentThread.Name + " выводит 1");
			Console.WriteLine(Thread.CurrentThread.Name + " выводит 2");
			Console.WriteLine(Thread.CurrentThread.Name + " выводит 3");
			Console.WriteLine(Thread.CurrentThread.Name + " выводит 4");
			Console.WriteLine(Thread.CurrentThread.Name + " завершился");
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			MyThread t1 = new MyThread("Thread 1");
			MyThread t2 = new MyThread("Thread 2");
			MyThread t3 = new MyThread("Thread 3");

			t1.startThread();
			t2.startThread();
			t3.startThread();
		}
	}
}
